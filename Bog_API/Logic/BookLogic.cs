using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using Entities.Entities;

namespace Logic
{
    public class BookLogic : IBookLogic
    {
        private readonly string booksXML = @"C:\Users\Andreas\Documents\GitHub\Codan---Opgave\Bog_API\Logic\BookData\books.xml";
        private readonly IXMLReader _xmlReader;

        public BookLogic(IXMLReader xmlReader)
        {
            _xmlReader = xmlReader;
        }

        public IList<Book> GetAllBooks()
        {
            var list = new List<Book>();
            var doc = _xmlReader.LoadXDocument(booksXML);
            foreach (XElement element in doc.Descendants("catalog").Descendants("book"))
            {
                list.Add(ConvertXMLBookToBookEntity(element));
            }

            return list;


        }

        public IList<Book> GetBooksByTitle(string title)
        {
            var list = new List<Book>();

            var doc = _xmlReader.LoadXDocument(booksXML);
            foreach (XElement element in doc.Descendants("catalog").Descendants("book").Where(b => b.Element("title").Value.Contains(title)))
            {
                list.Add(ConvertXMLBookToBookEntity(element));
            }

            return list;
        }



       


        //Convert XML values to C# Book Entity
        private Book ConvertXMLBookToBookEntity(XElement xElement)
        {
            Book book = new Book();
            book.Author = xElement.Element("author").Value;
            book.Title = xElement.Element("title").Value;
            book.Description = xElement.Element("description").Value;
            book.Genre = xElement.Element("genre").Value;
            book.Price = Decimal.Parse(xElement.Element("price").Value);
            book.Publish_Date = DateTime.Parse(xElement.Element("publish_date").Value);
            return book;
        }


    }
}
