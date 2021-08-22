using DigitalCatalogue;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DigitalCatalog.Tests
{
    [TestClass]
    public class AuthorTests
    {
        [TestMethod]
        public void SetFirstAndLastName_Adding_199_SymbolsString_ExpectedSetValue()
        {
            var expectedResult = new String('a', 199);

            Author author = new Author(expectedResult, expectedResult);

            Assert.AreEqual(expectedResult, author.FirstName);
            Assert.AreEqual(expectedResult, author.LastName);
        }

        [TestMethod]
        public void SetFirstAndLastName_Adding_201_SymbolString_ExpectedSetValue()
        {
            var expectedResult = new String('a', 201);

            Author author = new Author(expectedResult, expectedResult);

            Assert.AreEqual(expectedResult, author.FirstName);
            Assert.AreEqual(expectedResult, author.LastName);
        }

        [TestMethod]
        public void SetFirstAndLastName_Adding_Null_SymbolString_ExpectedSetValue()
        {
            string expectedResult = null;

            Author author = new Author(null, null);

            Assert.AreEqual(expectedResult, author.FirstName);
            Assert.AreEqual(expectedResult, author.LastName);
        }

        [TestMethod]
        public void SetFirstAndLastName_Adding_Empty_SymbolString_ExpectedSetValue()
        {
            string expectedResult = String.Empty; 

            Author author = new Author(expectedResult, expectedResult);

            Assert.AreEqual(expectedResult, author.FirstName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Ошибка! Имя и фамилия не могут быть пустыми!")]
        public void Author_Initialization_FirstName_LastName_ExpectedException()
        {
            Author author = new Author(null, null);
        }
    }
}
