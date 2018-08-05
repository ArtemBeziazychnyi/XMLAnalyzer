using System;
using System.Collections.Generic;
using System.IO;

namespace XMLAnalyzer
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length == 0)
			{
				Console.WriteLine("Please input path to the file");
				return;
			}

			var xmlAnalyzer = new XMLAnalyzer();

			Dictionary<string, string> attributes;

			if (File.Exists(args[0]))
			{
				attributes = xmlAnalyzer.GetTargetAttributes(args[0]);
			}
			else
			{
				Console.WriteLine($"Original file '{Path.GetFileName(args[0])}' not found");
				return;
			}

			foreach (var htmlFilePath in args)
			{
				if (args[0] == htmlFilePath) continue;

				if (!File.Exists(htmlFilePath))
				{
					Console.WriteLine($"File '{Path.GetFileName(htmlFilePath)}' not found");
					continue;
				}

				var xPatch = xmlAnalyzer.GetXPathToElement(htmlFilePath, attributes);
				Console.WriteLine($"XPath to the target element: {xPatch}");
			}


			Console.WriteLine("Press any key to exit from the programm");
			Console.ReadKey();
		}
	}
}
