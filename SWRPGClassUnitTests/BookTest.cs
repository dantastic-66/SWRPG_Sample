using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsClasses;

namespace SWRPGClassUnitTests
{
    /// <summary>
    /// This test will verify all the methods within the Talent Class
    /// </summary>
    [TestClass]
    public class BookTest
    {
        Book objNewBook = new Book();
        public BookTest()
        {
            objNewBook.BookID = 0;
            objNewBook.BookName = "Dan Test Book";
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        /// <summary>
        /// Tests the GetBook by BookID method.
        ///</summary>
        #region GetBook(int BookID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetBook(int BookID) Method, Good Outcome")]
        public void Test_GetBook_ByID_GoodResult()
        {
            int intBookID = 1;
            Book objBook = new Book();

            objBook.GetBook(intBookID);

            Assert.AreEqual(intBookID, objBook.BookID);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetBook(int BookID) Method, Good Outcome")]
        public void Test_GetBook_ByID_BadResult()
        {
            int intBookID = 0;
            Book objBook = new Book();

            objBook.GetBook(intBookID);

            Assert.IsNull(objBook.BookName);
        }
        #endregion

        /// <summary>
        /// Tests the GetBook by BookName method.
        ///</summary>
        #region GetBook(string strBookName)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetBook(string BookName) Method, Good Outcome")]
        public void Test_GetBook_ByName_GoodResult()
        {
            string strBookName = "Galaxy At War";
            Book objBook = new Book();

            objBook.GetBook(strBookName);

            Assert.AreEqual(strBookName, objBook.BookName);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetBook(string BookName) Method, Bad Outcome")]
        public void Test_GetBook_ByName_BadResult()
        {
            string strBookName = "blah blah";
            Book objBook = new Book();

            objBook.GetBook(strBookName);

            Assert.IsNull(objBook.BookName);
        }
        #endregion

        /// <summary>
        /// Tests the GetBooks by strWhere, strOrderBy method.
        ///</summary>
        #region GetBooks(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetBooks(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetBooks_WithOrderBy_GoodResult()
        {
            string strWhere = "BookName Like '%Guide%'";
            string strOrderBy = "BookName";

            Book objBook = new Book();
            List<Book> lstBooks = new List<Book>();

            lstBooks = objBook.GetBooks(strWhere, strOrderBy);

            Assert.IsTrue(lstBooks.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetBooks(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetBooks_WithOutOrderBy_GoodResult()
        {
            string strWhere = "BookName Like '%Guide%'";
            string strOrderBy = "";

            Book objBook = new Book();
            List<Book> lstBooks = new List<Book>();

            lstBooks = objBook.GetBooks(strWhere, strOrderBy);

            Assert.IsTrue(lstBooks.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetBooks(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetBooks_WithOrderBy_NoResult()
        {
            string strWhere = "BookName Like '%Toad%'";
            string strOrderBy = "BookName";

            Book objBook = new Book();
            List<Book> lstBooks = new List<Book>();

            lstBooks = objBook.GetBooks(strWhere, strOrderBy);

            Assert.IsTrue(lstBooks.Count == 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetBooks(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetBooks_WithOutOrderBy_NoResult()
        {
            string strWhere = "BookName Like '%Toad%'";
            string strOrderBy = "";

            Book objBook = new Book();
            List<Book> lstBooks = new List<Book>();

            lstBooks = objBook.GetBooks(strWhere, strOrderBy);

            Assert.IsTrue(lstBooks.Count == 0);
        }

        #endregion

        #region SaveAndDeleteBook()
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SaveBook and DeleteBook Methods)")]
        public void Test_SaveAndDeleteBook()
        {
            bool returnVal;

            objNewBook.SaveBook();

            Assert.IsTrue(objNewBook.BookID != 0);

            returnVal = objNewBook.DeleteBook();

            Assert.IsTrue(returnVal && objNewBook.DeleteOK);
        }
        #endregion

        #region Validate() returns bool
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, True Outcome")]
        public void Validate_TrueResult()
        {
            Book objBook = new Book();
            objBook.BookName = "New Book";
            objBook.Validate();
            Assert.IsTrue(objBook.Validated);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, False Outcome")]
        public void Validate_FalseResult()
        {
            Book objBook = new Book();
            objBook.BookName = "";
            objBook.Validate();
            Assert.IsTrue(!objBook.Validated && (objBook.ValidationMessage.Length > 0));
        }
        #endregion
    }
}
