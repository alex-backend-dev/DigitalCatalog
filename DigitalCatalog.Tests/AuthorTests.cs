using DigitalCatalogue;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DigitalCatalog.Tests
{
    [TestClass]
    public class AuthorTests
    {
        [TestMethod]
        public void SetFirstName_Adding_1_SymbolString_ExpectedSetValue()
        {
            string expectedResult = "a";

            Author author = new Author("Alex", "Ulyanitskiy");

            author.FirstName = expectedResult;

            Assert.AreEqual(expectedResult, author.FirstName);
        }

        [TestMethod]
        public void SetFirstName_Adding_2_SymbolsString_ExpectedSetValue()
        {
            string expectedResult = "ab";

            Author author = new Author("Alex", "Ulyanitskiy");

            author.FirstName = expectedResult;

            Assert.AreEqual(expectedResult, author.FirstName);
        }

        [TestMethod]
        public void SetFirstName_Adding_199_SymbolsString_ExpectedSetValue()
        {
            string expectedResult = 
                "dasdaoioafsklaflka;fka;fskaskflsa;fak;fskal;fklaf;fa;s;lsasssssssssssssssssssssssssllllllllasdasdasd;dasdad;lada;dsadadlasdasd;dasdadadsadsadada;asdk;ad;ksak;dadsda;d;dasdsaddasaass";

            Author author = new Author("Alex", "Ulyanitskiy");

            author.FirstName = expectedResult;

            Assert.AreEqual(expectedResult, author.FirstName);
        }

        [TestMethod]
        public void SetFirstName_Adding_200_SymbolsString_ExpectedSetValue()
        {
            string expectedResult =
                "dasdaoioafsklaflka;fka;fskaskflsa;fak;fskal;fklaf;fa;s;lsassssssdsssssssssssssssssssllllllllasdasdasd;dasdad;lada;dsadadlasdasd;dasdadadsadsadada;asdk;ad;ksak;dadsda;d;dasdsaddasaass";

            Author author = new Author("Alex", "Ulyanitskiy");

            author.FirstName = expectedResult;

            Assert.AreEqual(expectedResult, author.FirstName);
        }

        [TestMethod]
        public void SetFirstName_Adding_201_SymbolString_ExpectedSetValue()
        {
            string expectedResult = "dasdaoioafsklaflka;fka;fskaskflsa;fak;fskal;fklaf;fa;s;lsassssssdsssssssôssssssssssssllllllllasdasdasd;dasdad;lada;dsadadlasdasd;dasdadadsadsadada;asdk;ad;ksak;dad¸";

            Author author = new Author("Alex", "Ulyanitskiy");

            author.FirstName = expectedResult;

            Assert.AreEqual(expectedResult, author.FirstName);
        }

        [TestMethod]
        public void SetFirstName_Adding_Null_SymbolString_ExpectedSetValue()
        {
            string expectedResult = null;

            Author author = new Author("Alex", "Ulyanitskiy");

            author.FirstName = expectedResult;

            Assert.AreEqual(expectedResult, author.FirstName);
        }

        [TestMethod]
        public void SetFirstName_Adding_Empty_SymbolString_ExpectedSetValue()
        {
            string expectedResult = "";

            Author author = new Author("Alex", "Ulyanitskiy");

            author.FirstName = expectedResult;

            Assert.AreEqual(expectedResult, author.FirstName);
        }
    }
}
