    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ADODB;
    using System.Data.SqlClient;
    using System.Data;
    using System.Configuration ;

    namespace StarWarsClasses
    {
        /// <summary>
        /// 
        /// </summary>
        /// <seealso cref="System.IDisposable" />
        public class DatabaseConnection : IDisposable
        {
            #region
            /// <summary>
            /// The connection string
            /// </summary>
            public string ConnectionString = "";
            /// <summary>
            /// The open
            /// </summary>
            public Boolean Open = false;
            /// <summary>
            /// The object command
            /// </summary>
            public ADODB.Command objCommand = new ADODB.Command();
            /// <summary>
            /// The connection
            /// </summary>
            public ADODB.Connection connection = new ADODB.Connection();
            /// <summary>
            /// The sqlsever connection string
            /// </summary>
            //public string SQLSEVERConnString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=StarWarsRPGDB;Data Source=RSAT-JSPA-14\\SQLEXPRESS;User ID=user;Password=password";
            public string SQLSEVERConnString = "";
            //public string SQLSEVERConnString; //= ConfigurationManager.ConnectionStrings["StarWarsRPGDB"].ConnectionString;
            #endregion
            //StarWarsRPGDB

            #region Constructors
            /// <summary>
            /// Initializes a new instance of the <see cref="DatabaseConnection"/> class.
            /// </summary>
            public DatabaseConnection()
            {
                //ConfigurationManager.ConnectionStrings[].ConnectionString fred = new ConfigurationManager.ConnectionStrings[].ConnectionString;
                //var sqlCon = new System.Data.SqlClient.SqlConnection();
                //sqlCon.ConnectionString = ConfigurationManager.ConnectionStrings["StarWarsRPGDB"].ConnectionString;
                SQLSEVERConnString = ConfigurationManager.ConnectionStrings["StarWarsRPGDB"].ConnectionString;
                //ConfigurationManager.AppSettings  appSet = new ConfigurationManager.AppSettings();
                //Properties.Settings.Default.Tester 
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="DatabaseConnection"/> class.
            /// </summary>
            /// <param name="DBConnString">The database connection string.</param>
            public DatabaseConnection(string DBConnString)
            {
                SQLSEVERConnString = DBConnString;
            }
            #endregion

            #region Methods
            /// <summary>
            /// Opens the database connection.
            /// </summary>
            private void OpenDBConnection()
            {
                try
                {
                    connection.Open();
                    this.Open = true;
                }
                catch
                {
                    Exception e = new Exception();
                    throw e;
                }
            }

            /// <summary>
            /// Closes the database connection.
            /// </summary>
            public void CloseDatabaseConnection()
            {
                if (this.Open)
                {
                    connection.Close();
                    this.Open = false;
                }
            }

            /// <summary>
            /// Executes the SQL string.
            /// </summary>
            /// <param name="strSQL">The string SQL.</param>
            /// <returns></returns>
            public SqlDataReader ExecuteSQLString(string strSQL)
            {
                SqlDataReader sqlDataReader; //= new SqlDataReader();
                SqlConnection sqlConnection = new SqlConnection(SQLSEVERConnString);
                SqlCommand sqlCommand;

                try
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand(strSQL, sqlConnection);

                    sqlDataReader = sqlCommand.ExecuteReader();
                    sqlCommand.Dispose();
                    sqlConnection.Close();
                }
                catch
                {
                    Exception e = new Exception();
                    throw e;
                }
                return sqlDataReader;
            }

            /// <summary>
            /// Gets the data reader.
            /// </summary>
            /// <param name="strSQLCommand">The string SQL command.</param>
            /// <returns></returns>
            public SqlDataReader GetDataReader(string strSQLCommand)
            {
                SqlDataReader sqlDataReader; // = new SqlDataReader();
                SqlConnection sqlConnection = new SqlConnection(SQLSEVERConnString);
                SqlCommand sqlCommand;

                try
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand(strSQLCommand, sqlConnection);
                    sqlDataReader = sqlCommand.ExecuteReader();
                    sqlCommand.Dispose();
                    sqlConnection.Close();
                }
                catch
                {
                    Exception e = new Exception();
                    throw e;
                }
                return sqlDataReader;
            }

            /// <summary>
            /// Loads the data adapters.
            /// </summary>
            /// <param name="strSelectCommand">The string select command.</param>
            /// <returns></returns>
            public System.Data.DataTable LoadDataAdapters(string strSelectCommand)
            {
                SqlDataAdapter adapTemp = new SqlDataAdapter();
                SqlConnection sqlConnection = new SqlConnection(SQLSEVERConnString);
                SqlCommand sqlCommand;
                System.Data.DataSet ds = new System.Data.DataSet();

                try
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand(strSelectCommand, sqlConnection);
                    adapTemp.SelectCommand = sqlCommand;
                    adapTemp.Fill(ds);

                    adapTemp.Dispose();
                    sqlCommand.Dispose();
                    sqlConnection.Close();
                }
                catch
                {
                    Exception e = new Exception();
                    throw e;
                }
                return ds.Tables[0];

            }


            public static System.Data.DataTable LoadDataAdapters(string strSQLConnection, string strSelectCommand)
            {
                SqlDataAdapter adapTemp = new SqlDataAdapter();
                SqlConnection sqlConnection = new SqlConnection(strSQLConnection);
                SqlCommand sqlCommand;
                System.Data.DataSet ds = new System.Data.DataSet();

                try
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand(strSelectCommand, sqlConnection);
                    adapTemp.SelectCommand = sqlCommand;
                    adapTemp.Fill(ds);

                    adapTemp.Dispose();
                    sqlCommand.Dispose();
                    sqlConnection.Close();
                }
                catch
                {
                    Exception e = new Exception();
                    throw e;
                }
                return ds.Tables[0];
            }

            /// <summary>
            /// Executes the stored procedure non query.
            /// </summary>
            /// <param name="strSQLSproc">The string SQL sproc.</param>
            /// <returns></returns>
            public int ExecuteStoredProcedureNonQuery(string strSQLSproc)
            {
                SqlConnection sqlConnection = new SqlConnection(SQLSEVERConnString);
                SqlCommand sqlCommand;

                int result = 0;

                try
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand(strSQLSproc, sqlConnection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    result = sqlCommand.ExecuteNonQuery();
                    sqlCommand.Dispose();
                    sqlConnection.Close();
                }
                catch
                {
                    Exception e = new Exception();
                    throw e;
                }
                return result;
            }

            //public object ExecuteStoredProcedure<T>(string strSQLSproc, ref string strErrorMessage, ref T objClass)
            //{
            //    SqlDataReader sqlDataReader;
            //    SqlConnection sqlConnection = new SqlConnection(SQLSEVERConnString);
            //    SqlCommand sqlCommand;

            //    Game objGame = new Game();
            //    Genre objGenre = new Genre();
            //    GuideBook objGuideBook = new GuideBook();
            //    Ownership objOwnership = new Ownership();
            //    Platform objPlatform = new Platform();

            //    object objectType = new object();

            //    try
            //    {
            //        sqlConnection.Open();
            //        sqlCommand = new SqlCommand(strSQLSproc, sqlConnection);
            //        if (strSQLSproc.Contains("="))
            //        {
            //            sqlCommand.CommandType = CommandType.Text;
            //        }
            //        else
            //        {
            //            sqlCommand.CommandType = CommandType.StoredProcedure;
            //        }

            //        sqlDataReader = sqlCommand.ExecuteReader();


            //        //TODO: Deal with the GetType() calls below.
            //        if (sqlDataReader.HasRows)
            //        {
            //            while (sqlDataReader.Read())
            //            {
            //                strErrorMessage = "";

            //                if (objClass.GetType() is Game)
            //                {
            //                    objGame.SetReaderToObject(ref sqlDataReader);
            //                    objectType = objGame;
            //                }
            //                else if (objClass.GetType() is Genre)
            //                {
            //                    objGenre.SetReaderToObject(ref sqlDataReader);
            //                    objectType = objGenre;
            //                }
            //                else if (objClass.GetType() is GuideBook)
            //                {
            //                    objGuideBook.SetReaderToObject(ref sqlDataReader);
            //                    objectType = objGuideBook;
            //                }
            //                else if (objClass.GetType() is Ownership)
            //                {
            //                    objOwnership.SetReaderToObject(ref sqlDataReader);
            //                    objectType = objOwnership;
            //                }
            //                else if (objClass.GetType() is Platform)
            //                {
            //                    objPlatform.SetReaderToObject(ref sqlDataReader);
            //                    objectType = objPlatform;
            //                }
            //            }
            //        }
            //        else
            //        {
            //            strErrorMessage = "No Data Returned for " + strSQLSproc;
            //        }

            //        sqlCommand.Dispose();
            //        sqlConnection.Close();
            //    }


            //    catch
            //    {
            //        Exception e = new Exception();
            //        throw e;
            //    }


            //    return objectType;
            //}



            /// <summary>
            /// Generates the parameter object.
            /// </summary>
            /// <param name="strParamName">Name of the string parameter.</param>
            /// <param name="sqlType">Type of the SQL.</param>
            /// <param name="strValue">The string value.</param>
            /// <param name="size">The size.</param>
            /// <returns></returns>
            public SqlParameter GenerateParameterObj(string strParamName, SqlDbType sqlType, string strValue, int size = 0)
            {
                SqlParameter sqlParameter = new SqlParameter();
                DateTime dtmDateVariable;
                int intValue = 0;
                bool boolValue = false;
                double dblValue = 0d;
                sqlParameter.ParameterName = strParamName;

                if (size != 0)
                {
                    sqlParameter.Size = size;
                }

                switch (sqlType)
                {
                    case SqlDbType.BigInt:
                        int.TryParse(strValue, out intValue);
                        if (strValue == "")
                        {
                            sqlParameter.Value = null;
                        }
                        else
                        {
                            sqlParameter.Value = intValue;
                        }
                        sqlParameter.DbType = DbType.Int64;
                        break;
                    case SqlDbType.SmallInt:
                    case SqlDbType.Int:
                    case SqlDbType.TinyInt:
                        int.TryParse(strValue, out intValue);
                        if (strValue == "")
                        {
                            sqlParameter.Value = null;
                        }
                        else
                        {
                            sqlParameter.Value = intValue;
                        }
                        sqlParameter.DbType = DbType.Int32;
                        break;
                    case SqlDbType.Binary:
                        break;
                    case SqlDbType.Bit:
                        bool.TryParse(strValue, out boolValue);
                        if (strValue == "")
                        {
                            sqlParameter.Value = null;
                        }
                        else
                        {
                            sqlParameter.Value = boolValue;
                        }
                        sqlParameter.DbType = DbType.Boolean;
                        break;
                    case SqlDbType.Char:
                        sqlParameter.Value = strValue;
                        break;
                    case SqlDbType.Date:
                    case SqlDbType.DateTime:
                    case SqlDbType.DateTime2:
                    case SqlDbType.DateTimeOffset:
                    case SqlDbType.SmallDateTime:
                        DateTime.TryParse(strValue, out  dtmDateVariable);
                        if (strValue == "")
                        {
                            sqlParameter.Value = null;
                        }
                        else
                        {
                            sqlParameter.Value = dtmDateVariable;
                        }
                        sqlParameter.DbType = DbType.Date;
                        break;
                    case SqlDbType.Decimal:
                    case SqlDbType.Float:
                    case SqlDbType.Money:
                    case SqlDbType.SmallMoney:
                        Double.TryParse(strValue, out  dblValue);
                        if (strValue == "")
                        {
                            sqlParameter.Value = null;
                        }
                        else
                        {
                            sqlParameter.Value = dblValue;
                        }
                        sqlParameter.DbType = DbType.Decimal;
                        break;
                    case SqlDbType.NChar:
                    case SqlDbType.NText:
                    case SqlDbType.NVarChar:
                    case SqlDbType.Text:
                    case SqlDbType.VarChar:
                        if (strValue == "")
                        {
                            sqlParameter.Value = "";
                        }
                        else
                        {
                            sqlParameter.Value = strValue;
                        }
                        sqlParameter.DbType = DbType.String;
                        break;
                    default:
                        if (strValue == "")
                        {
                            sqlParameter.Value = null;
                        }
                        else
                        {
                            sqlParameter.Value = strValue;
                        }
                        sqlParameter.DbType = DbType.String;
                        break;
                }


                return sqlParameter;
            }



            #endregion

            #region idisposiable
            /// <summary>
            /// The disposed value
            /// </summary>
            private Boolean disposedValue;

            /// <summary>
            /// Releases unmanaged and - optionally - managed resources.
            /// </summary>
            /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
            protected void Dispose(bool disposing)
            {
                if (!this.disposedValue)
                {
                    if (disposing)
                    {
                        //TODO: Dispose Managed state (Managed objects).
                    }
                    //TODO: Other stuff here, unmanaged Resources
                }
                this.disposedValue = true;
            }

            /// <summary>
            /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            void IDisposable.Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            #endregion
        }
    }

