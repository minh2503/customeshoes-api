using App.BLL.Implements;
using App.BLL.Interfaces;
using App.DAL.Implements;
using App.DAL.Interfaces;
using TFU.BLL.Implements;
using TFU.BLL.Interfaces;
using TFU.DAL.Implements;
using TFU.DAL.Interfaces;
using TFU.Services;

namespace App.EcommerceAPI.DependencyConfig
{
    public class DependencyConfig
    {
        public static void Register(IServiceCollection services)
        {
            //TFU Service
            services.AddTransient<IEmailSender, EmailSender>();

            //BLL
            services.AddTransient<IIdentityBizLogic, IdentityBizLogic>();
            services.AddTransient<ITFUBizLogic, TFUBizLogic>();
            services.AddTransient<IMenuBizLogic, MenuBizLogic>();
            services.AddTransient<IRoleClaimRepository, RoleClaimRepository>();
            services.AddTransient<IUserDetailsBizLogic, UserDetailsBizLogic>();
			services.AddTransient<IBrandsBizLogic, BrandsBizLogic>();
			services.AddTransient<IBrandsBizLogic, BrandsBizLogic>();
			services.AddTransient<IShoesBizLogic, ShoesBizLogic>();
			services.AddTransient<IShoesImagesBizLogic, ShoesImagesBizLogic>();
			services.AddTransient<ICheckOutBizLogic, CheckOutBizLogic>();

			//DAL
			services.AddTransient<IIdentityRepository, IdentityRepository>();
            services.AddTransient<ITFURepository, TFURepository>();
            services.AddTransient<IMenuRepository, MenuRepository>();
            services.AddTransient<IRoleClaimRepository, RoleClaimRepository>();
            services.AddTransient<IUserDetailsRepository, UserDetailsRepository>();
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<IShoesRepository, ShoesRepository>();
            services.AddTransient<IShoesImagesRepository, ShoesImagesRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderItemsRepository, OrderItemsRepository>();
            services.AddTransient<ICheckOutRepository, CheckOutRepository>();
        }
    }
}
