using System;
using System.Collections;
using System.Collections.Generic;

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
            foreach (var item in _booksCatalog)
            {
                yield return item;
            }
        }
    }
}
