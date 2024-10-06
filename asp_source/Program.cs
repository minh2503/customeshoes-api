using App.API.DependencyConfig;
using App.API.Filters;
using App.DAL;
using App.EcommerceAPI.DependencyConfig;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;
using TFU.EntityFramework;
using TFU.Models.IdentityModels;

namespace tapluyen.api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var Configuration = builder.Configuration;

            // ==== Add Serilog ======
            var hookAPI = Configuration.GetValue<string>("Serilog:HookAPI");
            Log.Logger = new LoggerConfiguration()
                        .ReadFrom.Configuration(Configuration)
                        .Enrich.WithProperty("TFU Logger", "TFU Logger")
                        .WriteTo.Http(requestUri: hookAPI, httpClient: new CustomHttpClient(Configuration), restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Error)
                        .CreateLogger();

            // ==== Add framework services ======
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddEntityFrameworkSqlServer().AddDbContext<TFUDbContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            // ===== Add Identity =====
            builder.Services.AddAuthorization();
            builder.Services.AddIdentity<UserDTO, RoleDTO>().AddEntityFrameworkStores<TFUDbContext>().AddDefaultTokenProviders();
            builder.Services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;

            });

            //===== Add Jwt Authentication ========
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidAudience = Configuration["JWT:Issuer"],
                        ValidIssuer = Configuration["JWT:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"])),
                        ClockSkew = TimeSpan.Zero // remove delay of token when expire
                    };
                    // Sending the access token in the query string is required due to
                    // a limitation in Browser APIs. We restrict it to only calls to the
                    // SignalR hub in this code.
                    // See https://docs.microsoft.com/aspnet/core/signalr/security#access-token-logging
                    // for more information about security considerations when using
                    // the query string to transmit the access token.
                    cfg.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            var accessToken = context.Request.Query["access_token"];
                            // If the request is for our hub...
                            var path = context.HttpContext.Request.Path;
                            if (!string.IsNullOrEmpty(accessToken) && (path.StartsWithSegments("/eventHub")))
                            {
                                // Read the token out of the query string
                                context.Token = accessToken;
                            }
                            return Task.CompletedTask;
                        }
                    };
                });


            //===== Services ========
            builder.Services.AddSingleton<IAuthorizationPolicyProvider, TFUAuthorizationPolicyProvider>();
            builder.Services.AddSingleton<IAuthorizationHandler, TFURolesHandler>();
            builder.Services.AddSingleton<IAuthorizationHandler, TFUEmailConfirmHandler>();
            builder.Services.AddSingleton<IAuthorizationHandler, TFUPermissionHandler>();
            builder.Services.AddCors();
            builder.Services.AddResponseCaching();

            // API Behavior
            builder.Services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });

            // Forward Headers
            builder.Services.Configure<ForwardedHeadersOptions>(options => { options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto; });

            // Dependency Injection
            DependencyConfig.Register(builder.Services);

            // Static Injection
            StaticConfig.Register(Configuration);

            // Add services to the container.
            builder.Services.AddControllers().AddNewtonsoftJson();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ECommerce API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                var securityRequirement = new OpenApiSecurityRequirement { { new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" } }, Array.Empty<string>() } };
                c.AddSecurityRequirement(securityRequirement);
            });

            // Serilog
            builder.Host.UseSerilog();


            // Configure the HTTP request pipeline.
            var app = builder.Build();
            app.UseRouting();

            // Exception Page
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            // Forward Headers
            app.UseForwardedHeaders();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Configure CORS
            if (app.Environment.IsDevelopment())
            {
                app.UseCors(builder => builder.WithOrigins(
                "https://ranus.vn",
                "https://www.ranus.vn",
                "http://ranus.vn",
                "https://admin.ranus.vn",
                "https://telegram.ranus.vn",
                "https://localhost:5000",
                "https://localhost:7000",
                "https://192.168.199.213:5000",
                "https://192.168.1.17:5000",
                "https://localhost:44407",
                "https://localhost:3000",
                "https://tapta.net",
                "https://admin.tapta.net",
                "http://localhost:3000",
                "https://cdn.tapta.net",
                    "http://localhost:5000"


                )
                .AllowAnyHeader().AllowAnyMethod().AllowCredentials());
            }
            else
            {
                app.UseCors(builder => builder.WithOrigins(
                    "https://ranus.vn",
                    "https://www.ranus.vn",
                    "http://ranus.vn",
                    "https://admin.ranus.vn",
                    "https://telegram.ranus.vn",
                    "https://beta.ranus.vn",
                    "http://beta.ranus.vn",
                    "https://localhost:5000",
                    "https://tapta.net",
                     "https://admin.tapta.net",
                     "http://localhost:3000",
                     "https://cdn.tapta.net/",
                    "https://localhost:3000",
                    "http://localhost:5000"

                    )
                .AllowAnyHeader().AllowAnyMethod().AllowCredentials());
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Other
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            // UseResponseCaching
            app.UseResponseCaching();
            app.MapControllers();
            app.Run();
        }
    }
}