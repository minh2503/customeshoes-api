using App.Utility;
using TFU.Utility;

namespace App.EcommerceAPI.DependencyConfig
{
	public class StaticConfig
	{
		public static void Register(IConfiguration Configuration)
		{
			// Facebook
			ApiHelpers.FacebookAppId = Configuration.GetValue<string>("Facebook:AppId");
			ApiHelpers.FacebookAppSecret = Configuration.GetValue<string>("Facebook:AppSecret");
			ApiHelpers.FacebookBaseAPI = Configuration.GetValue<string>("Facebook:BaseAPI");
			ApiHelpers.FacebookGraphAPI = Configuration.GetValue<string>("Facebook:GraphAPI");

			// Google
			ApiHelpers.GoogleOAuthUrl = Configuration.GetValue<string>("Google:OAuthAPI");
			ApiHelpers.GoogleClientId = Configuration.GetValue<string>("Google:ClientId");
			ApiHelpers.GoogleClientSecret = Configuration.GetValue<string>("Google:ClientSecret");

			// DependencyConfig
			ApiHelpers.CdnDirectory = Configuration.GetValue<string>("AppSettings:CdnDirectory");

			//Home Url
			ApiHelpers.HomeUrl = Configuration.GetValue<string>("AppSettings:HomeUrl");

			//Helpers
			Helpers.CDNDirectory = Configuration.GetValue<string>("AppSettings:CdnDirectory");
			Helpers.CDNUrl = Configuration.GetValue<string>("AppSettings:CdnUrl");
		}
	}
}
