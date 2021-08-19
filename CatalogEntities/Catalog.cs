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

        private bool Contains(Book book)
        {
	        foreach (var bk in _booksCatalog)
	        {
		        if (bk.Equals(book))
		        {
			        return true;
		        }
	        }

	        return false;
        }

        private Book GetByIsbn(string isbn)
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

            if (!Contains(book))
            {
                _booksCatalog.Add(book);
            }
        }

        public Book this[string isbn]
        {
            get => GetByIsbn(isbn);

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

        public Book[] GetBooksByAuthor(string firstName, string lastName)
        {
	        var setOfBooks = from book in _booksCatalog
										  from athr in book.Authors
										  where athr.FirstName.ToUpper().Equals(firstName.ToUpper())
										        && athr.LastName.ToUpper().Equals(lastName.ToUpper())
										  select book;

	        return setOfBooks.ToArray();
        }

        public Book[] GetBooksUsingDates()
        {
            var setOfBooksDates = from book in _booksCatalog
													orderby book.PublicationDate descending
													select book;

            return setOfBooksDates.ToArray();
        }
    }
}
