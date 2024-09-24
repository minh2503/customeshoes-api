using System.Collections.Generic;
using System.IO;
using System.Text;

namespace App.EcommerceAPI.Email
{
    public class PathConstant
    {
        public const string BuyerRegister = @"wwwroot\Email\Buyer\Email.html";
        public const string CreatorRegister = @"wwwroot\Email\Creator\Email.html";
        public const string PrivacyPolicy = @"Resources\privacypolicy.html";

        public static string GetFilePath(string relative)
        {
            return Path.Combine(Directory.GetCurrentDirectory(), relative);
        }
    }

    public class ContentBuilder
    {
        StringBuilder _stringBuilder;

        public ContentBuilder(string content)
        {
            _stringBuilder = new StringBuilder(content);
        }

        public ContentBuilder BuildCallback(List<ObjectReplace> replaces)
        {
            foreach (var item in replaces)
            {
                _stringBuilder.Replace(item.Name, item.Value);
            }

            return this;
        }

        public string GetContent()
        {
            return _stringBuilder.ToString();
        }

    }

    public class ObjectReplace
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }


}
