using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

namespace BookDB
{
    class Program
    {
        public static List<Book> books;
        static void Main(string[] args)
        {
            books = LoadBooks("books.xml");
            BookDbContext ctx = new BookDbContext();

            foreach (var item in books)
            {
                ctx.Books.Add(item);
                ctx.SaveChanges();
            }

            var allBooks = ctx.Books.ToList();
            foreach (var item in allBooks)
            {
                Console.WriteLine($"{item.Author}: {item.Title} - ${item.Price}");
            }
            Console.WriteLine();

            // 1)
            Console.WriteLine("------------ Q1 ------------");
            var q1 = ctx.Books.OrderByDescending(x => x.Price).Take(2);
            foreach (var item in q1)
            {
                Console.WriteLine($"{item.Author}: {item.Title} - ${item.Price}");
            }
            Console.WriteLine();

            // 2)
            Console.WriteLine("------------ Q2 ------------");
            var q2 = from book in ctx.Books
                     group book by book.Genre into g
                     select new
                     {
                         Key = g.Key,
                         Count = g.Count(),
                         AvgPrice = g.Average(a => a.Price)
                     };

            foreach (var item in q2)
            {
                Console.WriteLine($"{item.Key} - {item.Count}: ${Math.Round(item.AvgPrice, 2)}");
            }
            Console.WriteLine();

            // 3)
            Console.WriteLine("------------ Q3 ------------");
            var q3 = ctx.Books.OrderBy(x => x.PublishDate);
            foreach (var item in q3)
            {
                Console.WriteLine($"{item.PublishDate.ToString("yyyy-MM-dd")}: {item.Title}");
            }
        }
        static List<Book> LoadBooks(string filename)
        {
            XDocument xdoc = XDocument.Load(filename);
            List<Book> books = new List<Book>();
            foreach (XElement item in xdoc.Element("catalog").Elements("book"))
            {
                books.Add(new Book()
                {
                    Id = item.Attribute("id").Value,
                    Author = item.Element("author").Value,
                    Title = item.Element("title").Value,
                    Genre = item.Element("genre").Value,
                    Price = double.Parse(item.Element("price").Value.Replace(".", ",")),
                    PublishDate = DateTime.ParseExact(item.Element("publish_date").Value, "yyyy-MM-dd", CultureInfo.CurrentCulture),
                    Description = item.Element("description").Value,

                });
            }
            return books;
        }
    }
}
