using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DigitalCatalogue 
{
    public class Catalog : IEnumerable
    {
        private List<Book> _booksCatalog;

        public Catalog()
        {
            _booksCatalog = new List<Book>();
        }

        private Book Contains(string isbn)
        {
            foreach (var book in _booksCatalog)
            {
                if (book.ISBN.Equals(isbn))
                {
                    return book;
                }
            }

            return null;
        }

        private void AddBook(Book book)
        {
            if (book is null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            var bookExist = Contains(book.ISBN);

            if (bookExist == null)
            {
                _booksCatalog.Add(book);
            }
        }

        public Book this[string isbn]
        {
            get => Contains(isbn);

            set => AddBook(value);
        }

        public IEnumerator GetEnumerator()
        {
            var sortedBooks = from book in _booksCatalog
                              orderby book.BookName
                              select  book;

            foreach (var book in sortedBooks)
            {
                yield return book;
            }
        }

        public IEnumerator GetBooksUsingNames(Author author)
        {
            var setOfBooks = from book in _booksCatalog
                             where author.FirstName == "Александр"
                             && author.LastName == "Ульяницкий"
                             select book;

            foreach (var book in setOfBooks)
            {
                yield return book;
            }
        }

        public IEnumerator GetBooksUsingDates()
        {
            var setOfBooksDates = from book in _booksCatalog
                                  orderby book.PublicationDate descending
                                  select book;

            //var setOfBooksDates = _booksCatalog.OrderByDescending(book => book.PublicationDate);

            foreach (var book in setOfBooksDates)
            {
                yield return book;
            }
        }
    }
}
