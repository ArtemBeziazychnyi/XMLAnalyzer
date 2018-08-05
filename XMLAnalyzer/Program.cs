using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

			if (File.Exists(args.First()))
			{
				attributes = xmlAnalyzer.GetTargetAttributes(args[0]);
			}
			else
			{
				Console.WriteLine($"Original file '{Path.GetFileName(args.First())}' not found");
				return;
			}

			foreach (var htmlFilePath in args)
			{
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
