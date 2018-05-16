using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace StarWarsClasses 
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="StarWarsClasses.BaseValidation" />
    public class Book: BaseValidation 
    {

        /// <summary>
        /// Gets or sets the book identifier.
        /// </summary>
        /// <value>
        /// The book identifier.
        /// </value>
        public int BookID { get; set; }
        /// <summary>
        /// Gets or sets the name of the book.
        /// </summary>
        /// <value>
        /// The name of the book.
        /// </value>
        public string BookName { get; set; }

         #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        public Book()
		{
            SetBaseConstructorOptions();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        /// <param name="BookName">Name of the Book.</param>
        public Book(string BookName)
        {
            SetBaseConstructorOptions();
            GetBook(BookName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        /// <param name="BookID">The Book identifier.</param>
        public Book(int BookID)
        {
            SetBaseConstructorOptions();
            GetBook(BookID);
        }
        #endregion

        #region Methods
        #region Public Methods
        /// <summary>
        /// Gets the book.
        /// </summary>
        /// <param name="strBookName">Name of the string book.</param>
        /// <returns>Book object</returns>
        public Book GetBook(string strBookName)
        {
            return GetSingleBook("Select_Book", "BookName='" + strBookName + "'", "");
        }

        /// <summary>
        /// Gets the book.
        /// </summary>
        /// <param name="intBookID">The int book identifier.</param>
        /// <returns>Book object</returns>
        public Book GetBook(int intBookID)
        {
            return GetSingleBook("Select_Book", "BookID=" + intBookID , "");
        }

        /// <summary>
        /// Gets the books.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of Book objects</returns>
        public List<Book> GetBooks(string strWhere, string strOrderBy)
        {
            return GetBookList("Select_Book", strWhere, strOrderBy);
        }

        /// <summary>
        /// Saves the book.
        /// </summary>
        /// <returns>Book object</returns>
        public Book SaveBook()
        {
            SqlDataReader result;
            DatabaseConnection dbconn = new DatabaseConnection();
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(dbconn.SQLSEVERConnString);

            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "InsertUpdate_Book";
                command.Parameters.Add(dbconn.GenerateParameterObj("@BookID", SqlDbType.Int, BookID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@BookName", SqlDbType.VarChar , BookName.ToString(), 100));
                result = command.ExecuteReader();

                result.Read();
                SetReaderToObject(ref result);

            }
            catch
            {
                Exception e = new Exception();
                this._insertUpdateOK = false;
                this._insertUpdateMessage.Append(e.Message + "                     Inner Exception= " + e.InnerException);
                throw e;
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }
            return this;
        }

        /// <summary>
        /// Delete the Book.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool DeleteBook()
        {
            SqlDataReader result;
            DatabaseConnection dbconn = new DatabaseConnection();
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(dbconn.SQLSEVERConnString);

            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Delete_Book";
                command.Parameters.Add(dbconn.GenerateParameterObj("@BookID", SqlDbType.Int, BookID.ToString(), 0));
                result = command.ExecuteReader();
            }
            catch
            {
                Exception e = new Exception();
                this._deleteOK = false;
                this._deletionMessage.Append(e.Message + "                     Inner Exception= " + e.InnerException);
                throw e;
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }
            return this.DeleteOK;
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>Boolean</returns>
        public override bool Validate()
        {
            this._validated = true;

            //Put Validation checks here
            if (string.IsNullOrEmpty(this.BookName))
            {
                this._validated = false;
                this._validationMessage.Append("The Book Name cannot be blank or null.");
            }
            return this.Validated;
        }

        /// <summary>
        /// Clones the specified object Book.
        /// </summary>
        /// <param name="objBook">The object Book.</param>
        /// <returns>Book</returns>
        static public Book Clone(Book objBook)
        {
            Book objCBook = new Book(objBook.BookID);
            if (objBook.BookID != 0) objCBook.GetBook(objBook.BookID);
            else
            {
                objCBook.BookID = 0;
                objCBook.BookName = objBook.BookName;
            }
            return objCBook;
        }

        /// <summary>
        /// Clones the specified LST Book.
        /// </summary>
        /// <param name="lstBook">The LST Book.</param>
        /// <returns>List<Book></returns>
        static public List<Book> Clone(List<Book> lstBook)
        {
            List<Book> lstCBook = new List<Book>();

            foreach (Book objBook in lstBook)
            {
                lstCBook.Add(Book.Clone(objBook));
            }

            return lstCBook;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Gets the single book.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>Book object</returns>
        private Book GetSingleBook(string sprocName, string strWhere, string strOrderBy)
        {
            SqlDataReader result;
            DatabaseConnection dbconn = new DatabaseConnection();
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(dbconn.SQLSEVERConnString);

            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = sprocName;
                command.Parameters.Add(dbconn.GenerateParameterObj("@strWhere", SqlDbType.VarChar, strWhere, 1000));
                command.Parameters.Add(dbconn.GenerateParameterObj("@strOrderBy", SqlDbType.VarChar, strOrderBy, 1000));
                result = command.ExecuteReader();
                if (result.HasRows)
                {
                    result.Read();
                    SetReaderToObject(ref result);
                }
            }
            catch
            {
                Exception e = new Exception();
                throw e;
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }
            return this;
        }

        /// <summary>
        /// Gets the book list.
        /// </summary>
        /// <param name="strSprocName">Name of the string sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of Book objects</returns>
        private List<Book> GetBookList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<Book> featPrerequisiteAbilitys = new List<Book>();

            SqlDataReader result;
            DatabaseConnection dbconn = new DatabaseConnection();
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(dbconn.SQLSEVERConnString);

            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = strSprocName;
                command.Parameters.Add(dbconn.GenerateParameterObj("@strWhere", SqlDbType.VarChar, strWhere, 1000));
                command.Parameters.Add(dbconn.GenerateParameterObj("@strOrderBy", SqlDbType.VarChar, strOrderBy, 1000));
                result = command.ExecuteReader();

                while (result.Read())
                {
                    Book objBook = new Book();
                    SetReaderToObject(ref objBook, ref result);
                    featPrerequisiteAbilitys.Add(objBook);
                }
            }
            catch
            {
                Exception e = new Exception();
                throw e;
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }
            return featPrerequisiteAbilitys;
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.BookID = (int)result.GetValue(result.GetOrdinal("BookID"));
                this.BookName = result.GetValue(result.GetOrdinal("BookName")).ToString();

                this._objComboBoxData.Add(this.BookID, this.BookName);
            }
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="objBook">The object book.</param>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref Book objBook, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                objBook.BookID = (int)result.GetValue(result.GetOrdinal("BookID"));
                objBook.BookName = result.GetValue(result.GetOrdinal("BookName")).ToString();

                objBook._objComboBoxData.Add(objBook.BookID, objBook.BookName);
            }
        }
        #endregion
        #endregion

    }
}
