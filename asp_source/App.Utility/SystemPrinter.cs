using System.IO;

namespace App.Utility
{
	public static class SystemPrinter
	{
		private static readonly string GTXEXE = "GTX4CMD.exe";
		public static string gtxPath = !string.IsNullOrEmpty(ApiHelpers.CdnDirectory) ? Path.Combine(ApiHelpers.CdnDirectory, "wwwroot", "gtx-bat") : string.Empty;

		public static string GTXExportData(string arx4Output, string xmlProfile, string pngInput, string positionInput, string size = null)
		{
			if (!string.IsNullOrEmpty(arx4Output) &&
				!string.IsNullOrEmpty(xmlProfile) &&
				!string.IsNullOrEmpty(pngInput) &&
				!string.IsNullOrEmpty(positionInput))
			{
				return $"{GTXEXE} " +
					$"{GTXCommandConstant.Print} -" +
					$"{GTXCommandConstant.XMLFile} \"{xmlProfile}\" -" + //require, X - profile xml
					$"{GTXCommandConstant.ImageFile} \"{pngInput}\" -" + //require, I - image png
					$"{GTXCommandConstant.Arx4File} \"{arx4Output}\" -" + //optional, A - output arx4
					$"{GTXCommandConstant.PrintPosition} {positionInput} -" + //optional, L - position left/top edge
					$"{GTXCommandConstant.PrintSize} {size}"; //require, S - PrintSize
																			//$"{GTXCommandConstant.PrintMagnificationFactor} 0500"; //optional, R - magnification factor
			}
			return string.Empty;
		}

		public static string GTXExtractData(string arx4Input, string xmlResult, string pngOutput, string size)
		{
			return $"{GTXEXE} {GTXCommandConstant.Extract} -" +
				$"{GTXCommandConstant.Arx4File} \"{arx4Input}\" -" + //input, arx4
				$"{GTXCommandConstant.XMLFile} \"{xmlResult}\" -" + //output, xml
				$"{GTXCommandConstant.ImageFile} \"{pngOutput}\" -" + //output, pmg
				$"{GTXCommandConstant.PrintSize} {size}"; //output, size img
		}
	}

	public class OutPrinterName
	{
		private string profileName;
		private string resultName;
		private string pngNameInput;
		private string arx4Name;
		private string printBatName;
		private string extractBatName;
		private string pngNameOutput;

		public string ProfileName { get => profileName; set => profileName = $"{value}.xml"; }
		public string ResultName { get => resultName; set => resultName = $"{value}.xml"; }
		public string PngNameInput { get => pngNameInput; set => pngNameInput = $"{value}.png"; }
		public string Arx4Name { get => arx4Name; set => arx4Name = $"{value}.arx4"; }
		public string PrintBatName { get => printBatName; set => printBatName = $"{value}.bat"; }
		public string ExtractBatName { get => extractBatName; set => extractBatName = $"{value}.bat"; }
		public string PngNameOutput { get => pngNameOutput; set => pngNameOutput = $"{value}.png"; }

		public OutPrinterName(string guidId)
		{
			ProfileName = guidId;
			ResultName = guidId;
			PngNameInput = guidId;
			Arx4Name = guidId;
			PrintBatName = guidId;
			ExtractBatName = guidId;
			PngNameOutput = guidId;
		}
	}
}
