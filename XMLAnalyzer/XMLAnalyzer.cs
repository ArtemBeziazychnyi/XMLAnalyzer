using System;
using System.Collections.Generic;
using System.Linq;
using ScrapySharp.Extensions;

namespace XMLAnalyzer
{
	public class XMLAnalyzer
	{
		private readonly HtmlAgilityPack.HtmlDocument _document = new HtmlAgilityPack.HtmlDocument();

		public string GetXPathToElement(string filePatch, Dictionary<string, string> attributes)
		{
			_document.Load(filePatch);

			var element = _document.DocumentNode.CssSelect("a")
								.FirstOrDefault(el => el.Attributes.Contains("rel") && el.Attributes.Contains("title")
													  &&
													  (el.Attributes["rel"].Value == attributes["rel"] ||
													   el.Attributes["title"].Value == attributes["title"]));


			if (element == null)
				throw new Exception("Not found target element");

			return element.XPath;
		}

		public Dictionary<string, string> GetTargetAttributes(string originalFilePatch)
		{
			var targetElementId = "make-everything-ok-button";

			_document.Load(originalFilePatch);

			var tag = _document.GetElementbyId(targetElementId);

			return new Dictionary<string, string>
			{
				{"title", tag.Attributes["title"].Value},
				{"rel", tag.Attributes["rel"].Value}
			};
		}
	}
}

