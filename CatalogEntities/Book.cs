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

        public List<Author> Authors { get; set; }


        private string regex = @"^(?: ISBN(?:-13) ?:?●)?(?=[-0-9●]{17}$|[0-9]{13}$)97[89][-●]?[0 - 9]{ 1,5}↵
                               [-●]? (?:[0 - 9] +[-●] ?){ 2}[0-9]$";

        public Book(string isbn, string bookName, DateTime publicationDate)
        {
            if (!Regex.IsMatch(isbn, regex))
            {
                throw new ArgumentException(nameof(isbn));
            }

            isbn = isbn.Replace(OldValue, "");

            ISBN = isbn;
            BookName = bookName;
            PublicationDate = publicationDate;

            Authors = new List<Author>();
        }

        public void AddElement(Author author)
        {
            if (Authors == null)
            {
                throw new ArgumentNullException("Ошибка! Коллекция не может быть пустой");
            }

            Authors.Add(author);
        }

        public bool Equals(Book obj)
        {
            if (obj == null)
                return false;

            Book book = obj as Book;
            if (book == null)
                return false;

            return book.ISBN == this.ISBN;
        }
    }
}
