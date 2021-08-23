using System;
using System.Linq;
using DigitalCatalogue;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DigitalCatalog.Tests
{
    [TestClass]
    public class CatalogTests
    {
        [TestMethod]
        public void GetEnumerator_CheckingFirstAndLastBooks_ExpectedActualBookAfterSorting()
        {
            Catalog catalog = new Catalog();

            Book book1 = new Book("1111111111111", "A", DateTime.Now); // инициализация конструктора для 1 ого объета
            Book book2 = new Book("2222222222222", "Z", DateTime.Now); // инициализация конструктора для 2 ого объета

            catalog["2222222222222"] = book2; // 2 книга в каталоге с ISBN 
            catalog["1111111111111"] = book1; // 1 книга в каталоге с ISBN

            var books = catalog.GetElements(); // получаем коллекцию всех книг с помощью метода GetElements()
            var firstBook = books.FirstOrDefault(); // возвращаем 1 ую книгу коллекции, если он существует, иначе null
            var secondBook = books.LastOrDefault(); // возвращаем последнюю книгу коллекции, если она существует, иначе null

            Assert.IsNotNull(firstBook); // проверяем, что полученная 1 ая книга имеет не пустое значение
            Assert.AreEqual(firstBook, book1); // сравниваем 1 ую книгу и 1 ый объект с ISBN

            Assert.IsNotNull(secondBook); // проверяем, что полученная 2 ая книга имеет не пустое значение
            Assert.AreEqual(secondBook, book2); // сравниваем 2 ую книгу и 2 ой объект с ISBN
        }
    }
}
