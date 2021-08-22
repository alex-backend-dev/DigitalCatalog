using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DigitalCatalogue
{
    public class Book
    {
        public string ISBN { get; } // свойство для чтения

        private const string OldValue = "-"; // константа для знака, который не будет учитываться

        private readonly int TEXT_LIMIT = 1000; // лимит символов для проверки

        private string _bookName; // поле для названия книги

        public string BookName // свойство с проверкой для ввода данных при иницаилизации поля в конструкторе
        {
            get { return _bookName; }
            private set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.Length <= TEXT_LIMIT) // проверка на null и пустое место, кол-во символов
                {
                    _bookName = value;
                }
            }
        }

        public DateTime PublicationDate { get; } // структура дата публикации для чтения

        public List<Author> Authors { get; } // пустая коллекция для чтения

        private string regex = @"\d{13}"; // рег выражение, которая смотрит на то, что вводится 13 цифр подряд. 

        public Book(string isbn, string bookName, DateTime publicationDate) // конструктор для иницализации полей через свойства
        {
	        isbn = isbn.Replace(OldValue, ""); // сперва приводим ISBN к нужному формату

            if (!Regex.IsMatch(isbn, regex)) // проверяем что регулярка правильна сделана и там 13 цифр
            {
                throw new ArgumentException(nameof(isbn));
            }

            ISBN = isbn; // инициализируем поля
            BookName = bookName; // инициализируем поля
            PublicationDate = publicationDate; // инициализируем поля

            Authors = new List<Author>(); // выделяем оперативную память для инициализации коллекции
        }

        public void AddElement(Author author) // метод для добавления объекта в коллекцию
        {
            if (author == null) // проверка, что объект добавления не является пустым
            {
                throw new ArgumentNullException(nameof(author));
            }

            Authors.Add(author); // добавление объекта в коллекцию
        }

        public bool Equals(Book book) // реализация метода Equals
        {
            if (book == null) // реализация проверки на null
                return false;

            return book.ISBN == this.ISBN;
        }
    }
}
