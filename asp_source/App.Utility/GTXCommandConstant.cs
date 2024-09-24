using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace App.Utility
{
	public static class GTXCommandConstant
	{
		public static string Extract = "extract";
		public static string Print = "print";

		public static string XMLFile = "X";
		public static string ImageFile = "I";

		public static string GTXPrinter = "P"; //Specify the printer
		public static string Arx4File = "A"; //Specify the output file
		public static string GTXOutputFileWhite = "AW"; //Specify the output	file(white only)
		public static string GTXOutputFilecolor = "AC"; //Specify the output	file(color only)

		public static string PrintSize = "S"; //Print size -S 03000400, 4 digit width, 4 digit height
		public static string PrintMagnificationFactor = "R"; //-R 0400
		public static string PrintPosition = "L";
	}

	public class GTXCommandValue
	{
		public string GTXCommand { get; set; }
		public string GTXValue { get; set; }
		public GTXCommandValue(string gTXCommand, string gTXValue)
		{
			GTXCommand = gTXCommand;
			GTXValue = gTXValue;
		}
		public  override string ToString()
		{
			return $"-{GTXCommand.ToUpper()} {GTXValue}";
		}
	}

	public class FilePath
	{
		public string FolderName { get; set; }
		public string FileName { get; set; }
		public override string ToString()
		{
			return Path.Combine(FolderName, FileName);
		}
	}
}
