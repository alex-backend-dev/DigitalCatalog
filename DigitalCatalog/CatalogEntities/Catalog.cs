using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DigitalCatalogue 
{
    public class Catalog : IEnumerable // делаем класс перечисляемым, реализовывая IEnumerable
    {
        private List<Book> _booksCatalog; // делаем пустую коллекцию

        public Catalog()
        {
            _booksCatalog = new List<Book>(); // инициализируем коллекцию 
        }

        /// <summary>
        /// Метод проверяет, существование книги перед добавлением в коллекцию. 
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        private bool Contains(Book book) // метод возвращает true или false, принимает параметры класс Book, объект класса Book
        {
            foreach (var bk in _booksCatalog) // проходимся по каждому элементу коллекции _booksCatalog
            {
                if (bk.Equals(book)) // если объект в коллекции _booksCatalog будет равен объекту переданному в параметр book, вернем true
                {
                    return true;
                }
            }

            return false; // если книги нет в каталоге, то false
        }

        private Book GetByIsbn(string isbn) // метод возвращает тип данных Book и принимает параметр isbn, по сути ISBN книги
        {
            foreach (var book in _booksCatalog) // проходимся по элементам _booksCatalog 
            {
                if (book.ISBN.Equals(isbn)) // если книга с запрашивыемым ISBN номером будет равна книге с таким же ISBN, считать книги совпадающими
                {
                    return book; // возвращаем книгу в случае совпадения
                }
            }

            return null; // если ISBN книги не совпадает друг с другом, возвращаем null значение
        }

        private void AddBook(Book book) // метод ничего не возвращает, служит для добавления в метод данных
        {
            if (book is null) // если объект добавления в коллекцию пустой, выбрасываем исключение
            {
                throw new ArgumentNullException(nameof(book));
            }

            if (!Contains(book)) // если у нас false, книги нет в каталоге, то вернем false
            {
                _booksCatalog.Add(book); // если условие соблюдается, добавляем книгу в коллекцию
            }
        }

        public Book this[string isbn] // индексатор возвращает тип данных Book, в виде индекса принимает ISBN книги
        {
            get => GetByIsbn(isbn); // для получения доступа к книге используем метод GetByIsbn, с помощью индекса ISBN получаем доступ 

            set => AddBook(value); // с помощью метода AddBook добавляем элемент и записываем его в setter
        }

        public IEnumerator GetEnumerator() // реализуем интерфейс IEnumerable, метод GetEnumerator хранит ссылку на интерфейс IEnumerator 
        {
            //var sortedBooks = from book in _booksCatalog // проходимся по элементам коллекции _booksCatalog
            //                  orderby book.BookName      // сортируем книги по названию (по возрастанию)                                                       
            //                  select book;              // выводим книги, отсортированные по названию  


            var sortedBooks = _booksCatalog.OrderBy(book => book.BookName);

            foreach (var book in sortedBooks) // проходимся по элементам коллекции sortedBooks (sortedBooks типа IEnumerbale)
            {
                yield return book; // возвращаем все отсортированные книги из коллекции
            }
        }

        public Book[] GetBooksByAuthor(string firstName, string lastName) // вовзращаем массив книг, внутри параметры имя и фамилия (вводятся)
        {
            //var setOfBooks = from book in _booksCatalog // проходимся по коллекции книг (берем все книги)
            //                 from athr in book.Authors // проходимся по коллекции авторов (потом берем авторов каждой книги)
            //                 where athr.FirstName.ToUpper().Equals(firstName.ToUpper()) // берем имя автора каждой книги и сравниваем с переданными параметрами в метод
            //                     && athr.LastName.ToUpper().Equals(lastName.ToUpper()) // берем фамилию автора каждой книги и сравниваем с переданными параметрами в метод
            //                 select book; // получаем набор книг по заданным параметрам; приводим все к верхнему регистру и сраниваем

            //return setOfBooks.ToArray(); // приводим к массиву 

            var setOfBooksTwo = _booksCatalog.Where(book => book.Authors.Any(athr => athr.FirstName.ToUpper().Equals(firstName.ToUpper())
                && athr.LastName.ToUpper().Equals(lastName.ToUpper())));

            return setOfBooksTwo.ToArray();
        }

        public Book[] GetBooksUsingDates() // возвращает массив книг по дате публикации
        {
            //var setOfBooksDates = from book in _booksCatalog // проходимся по всем элементам _booksCatalog
            //                      orderby book.PublicationDate descending // отсортировываем набор книг по дате публикации (по убыванию descending)
            //                      select book;                            // получаем набор книг

            //return setOfBooksDates.ToArray(); // набор книг приводим к массиву

            var setOfBooksDates = _booksCatalog.OrderByDescending(book => book.PublicationDate).ToArray();

            return setOfBooksDates;
        }

        public (Author, int)[] GetBooksUsingTuples()
        {
            //var setOfBooksTuples = _booksCatalog.SelectMany(b => b.Authors) // авторы повторяются у книг, поэтому сколько раз появился автор, столько и книг
            //                                    .GroupBy(i => i)
            //                                    .Select(i => (i.Key, i.Count())).ToArray();

            //return setOfBooksTuples;

            var setOfBooksTuples = from book in _booksCatalog
                                   from author in book.Authors
                                   group author by author into athr
                                   select(athr.Key, athr.Count());

            return setOfBooksTuples.ToArray();
        }
    }
}
