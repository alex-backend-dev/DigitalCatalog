using DigitalCatalogue;
using System;

namespace DigitalCatalog
{
    class Program
    {
        static void Main(string[] args)
        {
			var richterBook = new Book("1234567891011", "CLR Via C#", DateTime.Today);
			var troelsenBook = new Book("1234567891012", "Pro C# 9 with .NET 5", DateTime.Today);


			var catalog = new Catalog();

			catalog[richterBook.ISBN] = richterBook;
			catalog[troelsenBook.ISBN] = troelsenBook;

			Console.WriteLine("Check Setter:\n");
			foreach (Book book in catalog)
			{
				Console.WriteLine(
					$"\tISBN = {book.ISBN};\n\tBookName = {book.BookName};\n\tPublication date = {book.PublicationDate}\n");
			}

			Console.WriteLine("--------------------------------------------------------------");
			var rBook = catalog[richterBook.ISBN];
			Console.WriteLine("Check Getter:\n");
			Console.WriteLine($"\tISBN = {rBook.ISBN};\n\tBookName = {rBook.BookName};\n\tPublication date = {rBook.PublicationDate}");

			Console.ReadKey();
		}
    }
}
