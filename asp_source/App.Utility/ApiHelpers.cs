using ImageMagick;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;

namespace App.Utility
{
	public static class ApiHelpers
	{
		#region App Settings
		public const int WidthBarcode = 472;
		public const int HeightBarcode = 236;
		public static string CdnDirectory { get; set; }
		public static string CdnUrl { get; set; }
		public static string AdminUsername { get; set; }
		public static double InchCmRate { get; set; }
		public static string AppSecretKey { get; set; }
		public static string HomeUrl { get; set; }
		public static int PromisedShippingTime { get; set; }
		#endregion

		#region Facebook Variable
		public static string FacebookAppId { get; set; }
		public static string FacebookAppSecret { get; set; }
		public static string FacebookBaseAPI { get; set; }
		public static string FacebookGraphAPI { get; set; }
		#endregion

		#region Google Variable
		public static string GoogleOAuthUrl { get; set; }
		public static string GoogleClientId { get; set; }
		public static string GoogleClientSecret { get; set; }
		#endregion

		#region Utility
		public static Image CompressImage(Image source, double scale)
		{
			if (source == null) return null;

			Stream stream = new MemoryStream();
			MemoryStream memoryStream = new MemoryStream();
			source.Save(stream, ImageFormat.Png);
			stream.Position = 0;
			using (var image = new MagickImage(stream))
			{
				image.Resize((int)(source.Width * scale), (int)(source.Height * scale));
				image.Quality = 50;
				image.Density = new Density(600, 600, DensityUnit.PixelsPerInch);
				image.Write(memoryStream);
			}
			stream.Dispose();
			return Image.FromStream(memoryStream);
		}
		public static Image UrlToImage(string url)
		{
			if (string.IsNullOrEmpty(url)) return null;
			url = url.Replace(@"\", "/");
			using (WebClient webClient = new WebClient())
			{
				byte[] imageBytes = webClient.DownloadData(url);
				using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
				{
					Image image = Image.FromStream(ms, true);
					return image;
				}
			}
		}
		public class ConvertImageModel
		{
			public string ResultUrl { get; set; }
			public Image ResultImage { get; set; }
			public string ResultPath { get; set; }
			public ConvertImageModel()
			{

			}
		}
		#endregion

	}
}
