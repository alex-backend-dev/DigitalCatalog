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
        [ExpectedException(typeof(ArgumentException), "??????! ??? ? ??????? ?? ????? ???? ????? 200 ????????!")]
        public void SetFirstAndLastName_Adding_201_SymbolString_ExpectedSetValue()
        {
            var expectedResult = new String('a', 201);

            Author author = new Author(expectedResult, expectedResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "??????! ??? ? ??????? ?? ????? ???? ???????!")]
        public void SetFirstAndLastName_Adding_Null_SymbolString_ExpectedSetValue()
        {
            string expectedResult = null;

            Author author = new Author(expectedResult, expectedResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "??????! ??? ? ??????? ?? ????? ???? ???????!")]
        public void SetFirstAndLastName_Adding_Empty_SymbolString_ExpectedSetValue()
        {
            string expectedResult = String.Empty; 

            Author author = new Author(expectedResult, expectedResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "??????! ??? ? ??????? ?? ????? ???? ???????!")]
        public void Author_Initialization_Null_FirstName_LastName_ExpectedException()
        {
            string expectedResult = null;

            Author author = new Author(expectedResult, expectedResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "??????! ??? ? ??????? ?? ????? ???? ???????!")]
        public void Author_Initialization_StringEmpty_FirstName_LastName_ExpectedException()
        {
            string expectedResult = String.Empty;

            Author author = new Author(expectedResult, expectedResult);
        }
    }
}
