using GameDefinitions;
using HtmlAgilityPack;
using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace WikiParser
{
    public class Page
    {
        public Page(string path)
        {
            this.Path = path;
            this.Parse();
        }

        private void Parse()
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.Load(this.Path);
            //headers = htmlDoc.DocumentNode.SelectNodes("//table")[5].SelectNodes("//tr/th").Select(x => x).First().InnerText.Trim()
            var tableRows = htmlDoc.DocumentNode.SelectNodes("//table")[5].SelectNodes("//tr");
            var entries = tableRows.Select(x => x.SelectNodes("//td"));
            var blades = entries.Select(x => BladeFromTable(x));
        }

        private Blade BladeFromTable(HtmlNodeCollection tableEntry)
        {
            var entry = tableEntry.Select(x => x.InnerText.Trim()).ToList();
            return new Blade(entry[0], entry[4], entry[1], entry[3]);
        }

        private string Path { get; } 
    }
}
