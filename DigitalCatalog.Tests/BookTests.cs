using DigitalCatalogue;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DigitalCatalog.Tests
{
    [TestClass]
    public class BookTests
    {
        [TestMethod]
        public void SetFirstName_Adding_999_SymbolsString_ExpectedSetValue()
        {
            var expectedResult = new String('a', 999);

            Book book = new Book("1111111111111", "С# for me", DateTime.Now);

            book.BookName = expectedResult;

            Assert.AreEqual(expectedResult, book.BookName);
        }

        [TestMethod]
        public void SetFirstName_Adding_1001_SymbolsString_ExpectedSetValue()
        {
            var expectedResult = new String('a', 1001);

            Book book = new Book("1111111111111", "С# for me", DateTime.Now);

            book.BookName = expectedResult;

            Assert.AreEqual(expectedResult, book.BookName);
        }

        [TestMethod]
        public void SetFirstName_Adding_Null_SymbolString_ExpectedSetValue()
        {
            string expectedResult = null;

            Book book = new Book("1111111111111", "С# for me", DateTime.Now);

            book.BookName = expectedResult;

            Assert.AreEqual(expectedResult, book.BookName);
        }

        [TestMethod]
        public void SetFirstName_Adding_Empty_SymbolString_ExpectedSetValue()
        {
            var expectedResult = "";

            Book book = new Book("1111111111111", "С# for me", DateTime.Now);

            book.BookName = expectedResult;

            Assert.AreEqual(expectedResult, book.BookName);
        }
    }
}
