using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DigitalCatalogue
{
    public class Book
    {
        public string ISBN { get; }

        private const string OldValue = "-";

        private readonly int TEXT_LIMIT = 1000;

        private string _bookName;

        public string BookName
        {
            get { return _bookName; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.Length <= TEXT_LIMIT)
                {
                    _bookName = value;
                }
            }
        }

        public DateTime PublicationDate { get; }

        public List<Author> Authors { get; }


        private string regex = @"\d{13}";

        public Book(string isbn, string bookName, DateTime publicationDate)
        {
	        isbn = isbn.Replace(OldValue, "");

            if (!Regex.IsMatch(isbn, regex))
            {
                throw new ArgumentException(nameof(isbn));
            }

            ISBN = isbn;
            BookName = bookName;
            PublicationDate = publicationDate;

            Authors = new List<Author>();
        }

        public void AddElement(Author author)
        {
            if (author == null)
            {
                throw new ArgumentNullException(nameof(author));
            }

            Authors.Add(author);
        }

        public bool Equals(Book book)
        {
            if (book == null)
                return false;

            return book.ISBN == this.ISBN;
        }
    }
}
