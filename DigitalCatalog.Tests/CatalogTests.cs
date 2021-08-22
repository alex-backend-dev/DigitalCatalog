using System;
using System.Collections;
using System.Linq;
using DigitalCatalogue;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DigitalCatalog.Tests
{
    [TestClass]
    public class CatalogTests
    {
        [TestMethod]
        public void TestMethod()
        {
            Catalog catalog = new Catalog();

            Book book1 = new Book("1111111111111", "A", DateTime.Now);
            Book book2 = new Book("2222222222222", "Z", DateTime.Now);

            catalog["2222222222222"] = book2;
            catalog["1111111111111"] = book1;

            var books = catalog.GetElements();
            var firstBook = books.FirstOrDefault();
            var secondBook = books.LastOrDefault();


            Assert.IsNotNull(firstBook);
            Assert.AreEqual(firstBook, book1);

            Assert.IsNotNull(secondBook);
            Assert.AreEqual(secondBook, book2);
        }
    }
}
