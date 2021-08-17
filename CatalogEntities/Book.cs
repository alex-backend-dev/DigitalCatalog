using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DigitalCatalogue
{
    public class Book
    {
        public string ISBN { get; }

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

        public IList<Author> Authors { get; set; }

        private string regex = @"^(?: ISBN(?:-13) ?:?●)?(?=[-0-9●]{17}$|[0-9]{13}$)97[89][-●]?[0 - 9]{ 1,5}↵
                               [-●]? (?:[0 - 9] +[-●] ?){ 2}[0-9]$";

        public Book(string isbn, string bookName, DateTime publicationDate)
        {
            if (!Regex.IsMatch(isbn, regex))
            {
                throw new ArgumentException(nameof(isbn));
            }

            ISBN = isbn;
            BookName = bookName;
            PublicationDate = publicationDate;
        }
    }
}
