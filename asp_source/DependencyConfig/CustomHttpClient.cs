using Microsoft.Extensions.Configuration;
using Serilog.Sinks.Http;
using System.Net.Http;
using System.Threading.Tasks;

namespace App.API.DependencyConfig
{
	public class CustomHttpClient : IHttpClient
	{
		private readonly HttpClient _httpClient;
		public IConfiguration _configuration { get; }
		public CustomHttpClient(IConfiguration configuration)
		{
			_configuration = configuration;
			_httpClient = new HttpClient();
		}
		public async Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content)
		{
			var secretKey = _configuration.GetValue<string>("AppSettings:SecretKey");
			//replace SecretKey of Headers
			_httpClient.DefaultRequestHeaders.Remove("SecretKey");
			_httpClient.DefaultRequestHeaders.Add("SecretKey", secretKey);
			var response = await _httpClient.PostAsync(requestUri, content).ConfigureAwait(false);
			return response;
		}
		public void Dispose() => _httpClient?.Dispose();
	}
}
