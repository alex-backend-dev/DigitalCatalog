using DigitalCatalogue;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace DigitalCatalog.Tests
{
    [TestClass]
    public class BookTests
    {
        [TestMethod]
        public void SetFirstName_Adding_999_SymbolsString_ExpectedSetValue()
        {
            var expectedResult = new String('a', 999);

            Book book = new Book("1111111111111", expectedResult, DateTime.Now);

            Assert.AreEqual(expectedResult, book.BookName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Ошибка! Название книги не может быть более 1000 символов!")]
        public void SetFirstName_Adding_1001_SymbolsString_ExpectedSetValue()
        {
            var expectedResult = new String('a', 1001);

            Book book = new Book("1111111111111", expectedResult, DateTime.Now);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Ошибка! Название книги не может быть пустым!")]
        public void SetFirstName_Adding_Null_SymbolString_ExpectedSetValue()
        {
            string expectedResult = null;

            Book book = new Book("1111111111111", expectedResult, DateTime.Now);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Ошибка! Название книги не может быть пустым!")]
        public void SetFirstName_Adding_Empty_SymbolString_ExpectedSetValue()
        {
            var expectedResult = String.Empty;

            Book book = new Book("1111111111111", expectedResult, DateTime.Now);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Ошибка! Формат ввода номера книги неверен!")]
        public void Author_Initialization_FirstName_LastName_ExpectedException()
        {
            var expectedResult = new String('a', 12);

            Book book = new Book(expectedResult, "C# for Professionals", DateTime.Now);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Ошибка! Объект добавления не может быть пустым!")]
        public void AddBook_NullInitialization_ExpectedException()
        {
            Book book = new Book("1111111111111", "C# for Professionals", DateTime.Now);

            book.AddElement(null);
        }

        [TestMethod]
        public void AddElement_AddingElement_ExpectedAdding()
        {
            Author expectedAuthor = new Author("Alex", "Ulyanitskiy");
            Book book = new Book("1111111111111", "C# for Professionals", DateTime.Now);

            book.AddElement(expectedAuthor);
            var actualAuthor = book.Authors.FirstOrDefault();

            Assert.AreEqual(expectedAuthor, actualAuthor);
        }

        [TestMethod]       
        public void Equals_AddingNull_ExpectedFalse()
        {
            Book book = new Book("1111111111111", "C# for Professionals", DateTime.Now);

            Assert.IsFalse(book.Equals(null));
        }

        [TestMethod]
        public void Equals_Comparison_ExpectedCompareResults()
        {
            Book book = new Book("1111111111111", "C# for Professionals", DateTime.Now);

            Assert.IsTrue(book.ISBN.Equals(book.ISBN));
        }
    }
}
