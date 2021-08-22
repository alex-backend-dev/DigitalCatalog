using System;
using System.Collections.Generic;
using DigitalCatalogue;

namespace DigitalCatalog
{
	class Program
	{
		static void Main(string[] args)
		{
			Author author = new Author("Author1", "Author1");
			Book book1 = new Book("1111111111111", "AnyBookName", DateTime.Now);
			Book book2 = new Book("2222222222222", "AnyBookName2", DateTime.Now.AddDays(-1));

			book1.AddElement(author);

			Catalog catalog = new Catalog();
			catalog["1111111111111"] = book1;
			catalog["2222222222222"] = book2;

			var b = catalog["2222222222222"];

			var bk = catalog.GetBooksByAuthor(author.FirstName, author.LastName);

			var bks = catalog.GetBooksUsingDates();
		}
	}
}
