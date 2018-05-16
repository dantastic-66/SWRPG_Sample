using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace StarWarsClasses
{
    public class OrganizationScale : BaseValidation
    {


        public int OrganizationScaleID { get; set; }
        public string OrganizationScaleName { get; set; }
        public string OrganizationScaleSample { get; set; }


        #region Constructors
        public OrganizationScale()
        {
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrganizationScale"/> class.
        /// </summary>
        /// <param name="OrganizationScaleName">Name of the OrganizationScale.</param>
        public OrganizationScale(string OrganizationScaleName)
        {
            SetBaseConstructorOptions();
            GetOrganizationScale(OrganizationScaleName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrganizationScale"/> class.
        /// </summary>
        /// <param name="OrganizationScaleID">The OrganizationScale identifier.</param>
        public OrganizationScale(int OrganizationScaleID)
        {
            SetBaseConstructorOptions();
            GetOrganizationScale(OrganizationScaleID);
        }
        #endregion


        #region Methods
        #region Public Methods
        public OrganizationScale GetOrganizationScale(int OrganizationScaleID)
        {
            return GetSingleOrganizationScale("Select_OrganizationScale", " OrganizationScaleID = " + OrganizationScaleID.ToString(), "");
        }

        public OrganizationScale GetOrganizationScale(string OrganizationScaleName)
        {
            return GetSingleOrganizationScale("Select_OrganizationScale", " OrganizationScaleName='" + OrganizationScaleID.ToString() + "'", "");
        }

        public List<OrganizationScale> GetOrganizationScales(string strWhere, string strOrderBy)
        {
            return GetOrganizationScaleList("Select_OrganizationScale", strWhere, strOrderBy);
        }

        public OrganizationScale SaveOrganizationScale()
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
                command.CommandText = "InsertUpdate_OrganizationScale";
                command.Parameters.Add(dbconn.GenerateParameterObj("@OrganizationScaleID", SqlDbType.Int, OrganizationScaleID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@OrganizationScaleName", SqlDbType.VarChar , OrganizationScaleName, 200));
                command.Parameters.Add(dbconn.GenerateParameterObj("@OrganizationScaleSample", SqlDbType.VarChar, OrganizationScaleSample, 4000));

                result = command.ExecuteReader();

                result.Read();
                SetReaderToObject(ref result);

            }
            catch
            {
                Exception e = new Exception();
                this._insertUpdateOK = false;
                this._insertUpdateMessage.Append(e.Message.ToString());
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
        /// Delete the OrganizationScale.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool DeleteOrganizationScale()
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
                command.CommandText = "Delete_OrganizationScale";
                command.Parameters.Add(dbconn.GenerateParameterObj("@OrganizationScaleID", SqlDbType.Int, OrganizationScaleID.ToString(), 0));
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

        public override bool Validate()
        {
            this._validated = true;

            //Put Validation checks here
            //if (string.IsNullOrEmpty(this.WeaponName))
            //{
            //    this._validated = false;
            //    this._validationMessage.Append("The Weapon Name cannot be blank or null.");
            //}
            return this.Validated;
        }

        /// <summary>
        /// Clones the specified object OrganizationScale.
        /// </summary>
        /// <param name="objOrganizationScale">The object OrganizationScale.</param>
        /// <returns>OrganizationScale</returns>
        static public OrganizationScale Clone(OrganizationScale objOrganizationScale)
        {
            OrganizationScale objCOrganizationScale = new OrganizationScale(objOrganizationScale.OrganizationScaleID);
            return objCOrganizationScale;
        }

        /// <summary>
        /// Clones the specified LST OrganizationScale.
        /// </summary>
        /// <param name="lstOrganizationScale">The LST OrganizationScale.</param>
        /// <returns>List<OrganizationScale></returns>
        static public List<OrganizationScale> Clone(List<OrganizationScale> lstOrganizationScale)
        {
            List<OrganizationScale> lstCOrganizationScale = new List<OrganizationScale>();

            foreach (OrganizationScale objOrganizationScale in lstOrganizationScale)
            {
                lstCOrganizationScale.Add(OrganizationScale.Clone(objOrganizationScale));
            }

            return lstCOrganizationScale;
        }
        #endregion

        #region Private Methods
        private OrganizationScale GetSingleOrganizationScale(string sprocName, string strWhere, string strOrderBy)
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

        private List<OrganizationScale> GetOrganizationScaleList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<OrganizationScale> OrganizationScales = new List<OrganizationScale>();

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
                    OrganizationScale objOrganizationScale = new OrganizationScale();
                    SetReaderToObject(ref objOrganizationScale, ref result);
                    OrganizationScales.Add(objOrganizationScale);
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
            return OrganizationScales;
        }

        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.OrganizationScaleID = (int)result.GetValue(result.GetOrdinal("OrganizationScaleID"));
                this.OrganizationScaleName = result.GetValue(result.GetOrdinal("OrganizationScaleName")).ToString();
                this.OrganizationScaleSample = result.GetValue(result.GetOrdinal("OrganizationScaleSample")).ToString();
            }
        }

        private void SetReaderToObject(ref OrganizationScale objOrganizationScale, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                objOrganizationScale.OrganizationScaleID = (int)result.GetValue(result.GetOrdinal("OrganizationScaleID"));
                objOrganizationScale.OrganizationScaleName = result.GetValue(result.GetOrdinal("OrganizationScaleName")).ToString();
                objOrganizationScale.OrganizationScaleSample = result.GetValue(result.GetOrdinal("OrganizationScaleSample")).ToString();
            }
        }

        #endregion
        #endregion
    }
}
