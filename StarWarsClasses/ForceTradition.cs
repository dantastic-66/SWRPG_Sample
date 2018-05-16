using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace StarWarsClasses
{
    public class ForceTradition : BaseValidation
    {


        public int ForceTraditionID { get; set; }
        public string ForceTraditionName { get; set; }
        public string ForceTraditionDescription { get; set; }


        #region Constructors
        public ForceTradition()
        {
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ForceTradition"/> class.
        /// </summary>
        /// <param name="ForceTraditionName">Name of the ForceTradition.</param>
        public ForceTradition(string ForceTraditionName)
        {
            SetBaseConstructorOptions();
            GetForceTradition(ForceTraditionName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ForceTradition"/> class.
        /// </summary>
        /// <param name="ForceTraditionID">The ForceTradition identifier.</param>
        public ForceTradition(int ForceTraditionID)
        {
            SetBaseConstructorOptions();
            GetForceTradition(ForceTraditionID);
        }
        #endregion


        #region Methods
        public ForceTradition GetForceTradition(int ForceTraditionID)
        {
            return GetSingleForceTradition("Select_ForceTradition", " ForceTraditionID = " + ForceTraditionID.ToString(), "");
        }

        public ForceTradition GetForceTradition(string ForceTraditionName)
        {
            return GetSingleForceTradition("Select_ForceTradition", " ForceTraditionName = '" + ForceTraditionID.ToString() + "'", "");
        }

        public List<ForceTradition> GetForceTraditions(string strWhere, string strOrderBy)
        {
            return GetForceTraditionList("Select_ForceTradition", strWhere, strOrderBy);
        }

        public ForceTradition SaveForceTradition()
        {
            //SqlDataReader result;
            //DatabaseConnection dbconn = new DatabaseConnection();
            //SqlCommand command = new SqlCommand();
            //SqlConnection connection = new SqlConnection(dbconn.SQLSEVERConnString);

            //try
            //{
            //    connection.Open();
            //    command.Connection = connection;
            //    command.CommandType = CommandType.StoredProcedure;
            //    command.CommandText = "InsertUpdate_Defense";
            //    command.Parameters.Add(dbconn.GenerateParameterObj("@DefenseID", SqlDbType.Int, DefenseID.ToString(), 0));
            //    command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterID", SqlDbType.Int, CharacterID.ToString(), 0));
            //    command.Parameters.Add(dbconn.GenerateParameterObj("@DefenseTypeID", SqlDbType.Int, DefenseTypeID.ToString(), 0));
            //    command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterLevelArmor", SqlDbType.Int, CharacterLevelArmor.ToString(), 0));
            //    command.Parameters.Add(dbconn.GenerateParameterObj("@AbilityMod", SqlDbType.Int, AbilityMod.ToString(), 0));
            //    command.Parameters.Add(dbconn.GenerateParameterObj("@ClassMod", SqlDbType.Int, ClassMod.ToString(), 0));
            //    command.Parameters.Add(dbconn.GenerateParameterObj("@RaceMod", SqlDbType.Int, RaceMod.ToString(), 0));
            //    command.Parameters.Add(dbconn.GenerateParameterObj("@FeatTalentMod", SqlDbType.Int, FeatTalentMod.ToString(), 0));
            //    command.Parameters.Add(dbconn.GenerateParameterObj("@MiscellaneousMod", SqlDbType.Int, MiscellaneousMod.ToString(), 0));
            //    result = command.ExecuteReader();

            //    result.Read();
            //    SetReaderToObject(ref result);

            //}
            //catch
            //{
            //    Exception e = new Exception();
            //    this._validated = false;
            //    this._validationMessage.Append(e.Message.ToString());
            //    throw e;
            //}
            //finally
            //{
            //    command.Dispose();
            //    connection.Close();
            //}
            return this;
        }

        /// <summary>
        /// Clones the specified object ForceTradition.
        /// </summary>
        /// <param name="objForceTradition">The object ForceTradition.</param>
        /// <returns>ForceTradition</returns>
        static public ForceTradition Clone(ForceTradition objForceTradition)
        {
            ForceTradition objCForceTradition = new ForceTradition(objForceTradition.ForceTraditionID);
            return objCForceTradition;
        }

        /// <summary>
        /// Clones the specified LST ForceTradition.
        /// </summary>
        /// <param name="lstForceTradition">The LST ForceTradition.</param>
        /// <returns>List<ForceTradition></returns>
        static public List<ForceTradition> Clone(List<ForceTradition> lstForceTradition)
        {
            List<ForceTradition> lstCForceTradition = new List<ForceTradition>();

            foreach (ForceTradition objForceTradition in lstForceTradition)
            {
                lstCForceTradition.Add(ForceTradition.Clone(objForceTradition));
            }

            return lstCForceTradition;
        }

        private ForceTradition GetSingleForceTradition(string sprocName, string strWhere, string strOrderBy)
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

        private List<ForceTradition> GetForceTraditionList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<ForceTradition> ForceTraditions = new List<ForceTradition>();

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
                    ForceTradition objForceTradition = new ForceTradition();
                    SetReaderToObject(ref objForceTradition, ref result);
                    ForceTraditions.Add(objForceTradition);
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
            return ForceTraditions;
        }

        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.ForceTraditionID = (int)result.GetValue(result.GetOrdinal("ForceTraditionID"));
                this.ForceTraditionName = result.GetValue(result.GetOrdinal("ForceTraditionName")).ToString();
                this.ForceTraditionDescription = result.GetValue(result.GetOrdinal("ForceTraditionDescription")).ToString();
            }
        }

        private void SetReaderToObject(ref ForceTradition objForceTradition, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                objForceTradition.ForceTraditionID = (int)result.GetValue(result.GetOrdinal("ForceTraditionID"));
                objForceTradition.ForceTraditionName = result.GetValue(result.GetOrdinal("ForceTraditionName")).ToString();
                objForceTradition.ForceTraditionDescription = result.GetValue(result.GetOrdinal("ForceTraditionDescription")).ToString();
            }
        }

        public override bool Validate()
        {
            this._validated = true;

            //Put Validation checks here
            //if (string.IsNullOrEmpty(this.ForceTraditionName ))
            //{
            //    this._validated = false;
            //    this._validationMessage.Append("The Weapon Name cannot be blank or null.");
            //}
            return this.Validated;
        }
        #endregion
    }
}
