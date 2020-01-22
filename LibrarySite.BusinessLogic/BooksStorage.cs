using HtmlAgilityPack;
using LibrarySite.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml;

namespace LibrarySite.BusinessLogic
{
    public static class BooksStorage
    {
        private static List<Book> _booksList;

        public static List<Book> GetBooks()
        {
            if (_booksList != null)
                return _booksList;

            _booksList = new List<Book>();

            string xmlText = string.Empty;
            using (WebClient client = new WebClient()) // WebClient class inherits IDisposable
            {
                var doc = new HtmlDocument();

                var pageWithXML = client.DownloadString("https://docs.microsoft.com/en-us/previous-versions/windows/desktop/ms762271(v=vs.85)?redirectedfrom=MSDN");
                doc.LoadHtml(pageWithXML);
                var xmlElement = doc.DocumentNode.SelectNodes("//code[@class='lang-xml']").First();
                xmlText = HttpUtility.HtmlDecode(xmlElement.InnerHtml);
            }

            XmlDocument document = new XmlDocument();
            document.LoadXml(xmlText);
            XmlNode catalogNode = document.SelectSingleNode("/catalog");

            foreach (XmlElement node in catalogNode.ChildNodes)
            {
                var book = new Book();

                book.Id = node.Attributes["id"]?.Value;
                var parameters = node.ChildNodes.Cast<XmlNode>().Select(x => new { Name = x.Name, Value = x.InnerText }).ToList();

                book.Author = parameters.FirstOrDefault(x => x.Name == "author")?.Value;
                book.Title = parameters.FirstOrDefault(x => x.Name == "title")?.Value;
                book.Genre = parameters.FirstOrDefault(x => x.Name == "genre")?.Value;
                book.Price = decimal.Parse(parameters.FirstOrDefault(x => x.Name == "price")?.Value ?? "0.0");
                book.PublishDate = DateTime.Parse(parameters.FirstOrDefault(x => x.Name == "publish_date")?.Value);
                book.Description = parameters.FirstOrDefault(x => x.Name == "description")?.Value;

                _booksList.Add(book);
            }

            return _booksList;
        }
    }
}
