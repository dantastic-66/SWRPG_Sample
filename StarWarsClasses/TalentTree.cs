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
    public class TalentTree:BaseValidation
    {
        #region Properties
        /// <summary>
        /// Gets or sets the talent tree identifier.
        /// </summary>
        /// <value>
        /// The talent tree identifier.
        /// </value>
        public int TalentTreeID { get; set; }
        /// <summary>
        /// Gets or sets the name of the talent tree.
        /// </summary>
        /// <value>
        /// The name of the talent tree.
        /// </value>
        public string TalentTreeName { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [force talent].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [force talent]; otherwise, <c>false</c>.
        /// </value>
        public bool ForceTalent { get; set; }

        /// <summary>
        /// Gets or sets the object talent tree talents.
        /// </summary>
        /// <value>
        /// The object talent tree talents.
        /// </value>
        public List<Talent> objTalentTreeTalents { get; set; }
        /// <summary>
        /// Gets or sets the object talent tree race requirement.
        /// </summary>
        /// <value>
        /// The object talent tree race requirement.
        /// </value>
        public List<Race> objTalentTreeRaceRequirement { get; set; }
        /// <summary>
        /// Gets or sets the object talent tree requirement.
        /// </summary>
        /// <value>
        /// The object talent tree requirement.
        /// </value>
        public List<TalentTreeRequirement> objTalentTreeRequirement { get; set;}
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="TalentTree"/> class.
        /// </summary>
        public TalentTree()
        {
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TalentTree"/> class.
        /// </summary>
        /// <param name="TalentTreeName">Name of the TalentTree.</param>
        public TalentTree(string TalentTreeName)
        {
            SetBaseConstructorOptions();
            GetTalentTree(TalentTreeName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TalentTree"/> class.
        /// </summary>
        /// <param name="TalentTreeID">The TalentTree identifier.</param>
        public TalentTree(int TalentTreeID)
        {
            SetBaseConstructorOptions();
            GetTalentTree(TalentTreeID);
        }
        #endregion

        #region Methods
        #region Public_Methods
        /// <summary>
        /// Gets the talent tree.
        /// </summary>
        /// <param name="TalentTreeID">The talent tree identifier.</param>
        /// <returns>TalentTree object</returns>
        public TalentTree GetTalentTree(int TalentTreeID)
        {
            return GetSingleTalentTree("Select_TalentTree", "  TalentTreeID=" + TalentTreeID.ToString(), "");
        }

        /// <summary>
        /// Gets the talent tree.
        /// </summary>
        /// <param name="TalentTreeName">Name of the talent tree.</param>
        /// <returns>TalentTree object</returns>
        public TalentTree GetTalentTree(string TalentTreeName)
        {
            return GetSingleTalentTree("Select_TalentTree", "  TalentTreeName='" + TalentTreeName + "'", "");
        }

        public List<TalentTree> GetCharactersAllowableTalentTrees(Character objChar)
        {
            string strClassIDs = objChar.CharacterClassIDs() ;
            
            List<TalentTree> objCharTalentTrees = new List<TalentTree>();
            List<TalentTree> lstReturnTalentTrees = new List<TalentTree>();

           
            objCharTalentTrees = GetTalentTreeList("Select_ClassTalentTrees", "ClassID IN (" + strClassIDs + ")", "TalentTreeName");

            if (objChar.ForceSensitive)
            {
                List<TalentTree> objForceCoreTalentTrees = new List<TalentTree>();
                objForceCoreTalentTrees = GetCoreForceTalentTrees();

                List<TalentTree> objForceTalentTrees = new List<TalentTree>();
                objForceTalentTrees = GetForceTalentTrees();
                lstReturnTalentTrees = MergeTalentTrees(objForceCoreTalentTrees, objForceTalentTrees, "TalentTreeName");
                lstReturnTalentTrees = MergeTalentTrees(lstReturnTalentTrees, objCharTalentTrees, "TalentTreeName");
            }
            else
            {
                lstReturnTalentTrees = objCharTalentTrees;
            }
        // Summary:
        //     Sorts the elements of a sequence in ascending order according to a key.
        //
        // Parameters:
        //   source:
        //     A sequence of values to order.
        //
        //   keySelector:
        //     A function to extract a key from an element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        //   TKey:
        //     The type of the key returned by keySelector.
        //
        // Returns:
        //     An System.Linq.IOrderedEnumerable<TElement> whose elements are sorted according
        //     to a key.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source or keySelector is null.
        //public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector);



            return lstReturnTalentTrees; //GetTalentTreeList("Select_ClassTalentTrees", "ClassID IN (" + strClassIDs + ")", "TalentTreeName");
        }

        public List<TalentTree> GetCharactersAllowableTalentTreesByAddedClass(Character objChar, Class objClass)
        {
            string strClassIDs = objChar.CharacterClassIDs();

            List<TalentTree> objCharTalentTrees = new List<TalentTree>();
            List<TalentTree> lstReturnTalentTrees = new List<TalentTree>();

            objCharTalentTrees = GetTalentTreeList("Select_ClassTalentTrees", "ClassID=" + objClass.ClassID.ToString(), "TalentTreeName");

            if (objChar.ForceSensitive)
            {
                List<TalentTree> objForceTalentTrees = new List<TalentTree>();
                objForceTalentTrees = GetForceTalentTreesByCharacterTradtion(objChar);
                lstReturnTalentTrees = MergeTalentTrees(objForceTalentTrees, objCharTalentTrees, "TalentTreeName");
            }
            else
            {
                lstReturnTalentTrees = objCharTalentTrees;
            }
            return lstReturnTalentTrees; 
        }

        /// <summary>
        /// Gets the core force talent trees.
        /// </summary>
        /// <returns>List of TalentTree objects</returns>
        public List<TalentTree> GetCoreForceTalentTrees()
        {
            return GetTalentTreeList("Select_TalentTree", "TalentTreeID IN (1,2,3,4,60)", "TalentTreeName");
        }

        /// <summary>
        /// Gets the force talent trees.
        /// </summary>
        /// <returns>List of TalentTree objects</returns>
        public List<TalentTree> GetForceTalentTrees()
        {
            return GetTalentTreeList("Select_TalentTree", "ForceTalent=1", "TalentTreeName");
         }

        //TODO Unit Test
        public List<TalentTree> GetForceTalentTreesByCharacterTradtion(Character objChar)
        {
            List<TalentTree> talentTrees = new List<TalentTree>();

            SqlDataReader result;
            DatabaseConnection dbconn = new DatabaseConnection();
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(dbconn.SQLSEVERConnString);

            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Select_CharacterTalentTreeForceTradtions";
                command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterID", SqlDbType.Int, objChar.CharacterID.ToString() ));
                result = command.ExecuteReader();

                while (result.Read())
                {
                    TalentTree objTalentTree = new TalentTree();
                    SetReaderToObject(ref objTalentTree, ref result);
                    talentTrees.Add(objTalentTree);
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
            return talentTrees;
        }

        /// <summary>
        /// Gets the talent trees prestige class.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of TalentTree objects</returns>
        public List<TalentTree> GetTalentTreesPrestigeClass(string strWhere, string strOrderBy)
        {
            return GetTalentTreeList("Select_TalentTreePrestigeClass", strWhere, strOrderBy);
        }

        /// <summary>
        /// Gets the talent trees.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of TalentTree objects</returns>
        public List<TalentTree> GetTalentTrees(string strWhere, string strOrderBy)
        {
            return GetTalentTreeList("Select_TalentTree", strWhere, strOrderBy);
            //List<TalentTree> talentTrees = new List<TalentTree>();

            //SqlDataReader result;
            //DatabaseConnection dbconn = new DatabaseConnection();
            //SqlCommand command = new SqlCommand();
            //SqlConnection connection = new SqlConnection(dbconn.SQLSEVERConnString);

            //try
            //{
            //    connection.Open();
            //    command.Connection = connection;
            //    command.CommandType = CommandType.StoredProcedure;
            //    command.CommandText = "Select_TalentTree";
            //    command.Parameters.Add(dbconn.GenerateParameterObj("@strWhere", SqlDbType.VarChar, strWhere, 1000));
            //    command.Parameters.Add(dbconn.GenerateParameterObj("@strOrderBy", SqlDbType.VarChar, strOrderBy, 1000));
            //    result = command.ExecuteReader();

            //    while (result.Read())
            //    {
            //        TalentTree objTalentTree = new TalentTree();
            //        SetReaderToObject(ref objTalentTree, ref result);
            //        talentTrees.Add(objTalentTree);
            //    }
            //}
            //catch
            //{
            //    Exception e = new Exception();
            //    throw e;
            //}
            //finally
            //{
            //    command.Dispose();
            //    connection.Close();
            //}
            //return talentTrees;
        }

        /// <summary>
        /// Saves the talent tree.
        /// </summary>
        /// <returns>TalentTree object</returns>
        public TalentTree SaveTalentTree()
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
                command.CommandText = "InsertUpdate_TalentTree";
                command.Parameters.Add(dbconn.GenerateParameterObj("@TalentTreeID", SqlDbType.Int, TalentTreeID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@TalentTreeName", SqlDbType.VarChar, TalentTreeName.ToString(), 50));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ForceTalent", SqlDbType.Bit , ForceTalent.ToString(), 0));
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
        /// Deletes the talent tree.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool DeleteTalentTree()
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
                command.CommandText = "Delete_TalentTree";
                command.Parameters.Add(dbconn.GenerateParameterObj("@TalentTreeID", SqlDbType.Int, TalentTreeID.ToString(), 0));
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
            if (string.IsNullOrEmpty(this.TalentTreeName))
            {
                this._validated = false;
                this._validationMessage.Append("The Talent Tree Name cannot be blank or null.");
            }
            return this.Validated;
        }
        #endregion

        #region Static Methods
        /// <summary>
        /// Determines whether [is talent tree in list] [the specified object talent tree].
        /// </summary>
        /// <param name="objTalentTree">The object talent tree.</param>
        /// <param name="lstTalentTree">The LST talent tree.</param>
        /// <returns>Boolean</returns>
        static public bool IsTalentTreeInList(TalentTree objTalentTree, List<TalentTree> lstTalentTree)
        {
            bool blnTalentTreeFound = false;

            foreach (TalentTree lstObjTalentTree in lstTalentTree)
            {
                if (objTalentTree.TalentTreeID == lstObjTalentTree.TalentTreeID)
                {
                    blnTalentTreeFound = true;
                }
            }

            return blnTalentTreeFound;
        }

        /// <summary>
        /// Determines whether [is talent tree in list] [the specified LST need talent trees].
        /// </summary>
        /// <param name="lstNeedTalentTrees">The LST need talent trees.</param>
        /// <param name="lstTalentTrees">The LST talent trees.</param>
        /// <returns>Boolean</returns>
        static public bool IsTalentTreeInList(List<TalentTree> lstNeedTalentTrees, List<TalentTree> lstTalentTrees)
        {
            bool blnAllTalentTreesFound = true;
            bool blnTalentTreeFound = false;

            foreach (TalentTree objNeededTalentTree in lstNeedTalentTrees)
            {
                foreach (TalentTree objTalentTree in lstTalentTrees)
                {
                    if (objNeededTalentTree.TalentTreeID == objTalentTree.TalentTreeID)
                    {
                        blnTalentTreeFound = true;
                    }
                }
                if (blnAllTalentTreesFound)
                {
                    blnAllTalentTreesFound = blnTalentTreeFound;
                }
            }

            return blnAllTalentTreesFound;
        }

        /// <summary>
        /// Merges the talent trees.
        /// </summary>
        /// <param name="lstTreeList1">The List1 of  TalentTrees.</param>
        /// <param name="lstTreeList2">The List2 of  TalentTrees.</param>
        /// <param name="strSortOrder">The string sort order.</param>
        /// <returns>List<TalentTree></returns>
        static public List<TalentTree> MergeTalentTrees(List<TalentTree> lstTreeList1, List<TalentTree> lstTreeList2, string strSortOrder)
        {
            List<TalentTree> lstReturnTreeList = new List<TalentTree>();
            lstReturnTreeList = lstTreeList1;
            foreach (TalentTree objTT in lstTreeList2)
            {
                if (!IsTalentTreeInList(objTT, lstTreeList1))
                {
                    lstReturnTreeList.Add(objTT);
                }
            }

            //Do order by here somehow...
            if (!String.IsNullOrEmpty(strSortOrder))
            {

                switch (strSortOrder.ToLower())
                {
                    case "talenttreename":
                        lstReturnTreeList = lstReturnTreeList.OrderBy(n => n.TalentTreeName).ToList<TalentTree>();
                        break;
                    case "talenttreeid":
                        lstReturnTreeList = lstReturnTreeList.OrderBy(n => n.TalentTreeID).ToList<TalentTree>();
                        break;
                    case "forcetalent":
                        lstReturnTreeList = lstReturnTreeList.OrderBy(n => n.ForceTalent).ToList<TalentTree>();
                        break;
                    default:
                        lstReturnTreeList = lstReturnTreeList.OrderBy(n => n.TalentTreeName).ToList<TalentTree>();
                        break;
                }
               
            }
            return lstReturnTreeList;
        }

        /// <summary>
        /// Clones the specified object TalentTree.
        /// </summary>
        /// <param name="objTalentTree">The object TalentTree.</param>
        /// <returns>TalentTree</returns>
        static public TalentTree Clone(TalentTree objTalentTree)
        {
            TalentTree objCTalentTree = new TalentTree(objTalentTree.TalentTreeID);
            return objCTalentTree;
        }

        /// <summary>
        /// Clones the specified LST TalentTree.
        /// </summary>
        /// <param name="lstTalentTree">The LST TalentTree.</param>
        /// <returns>List<TalentTree></returns>
        static public List<TalentTree> Clone(List<TalentTree> lstTalentTree)
        {
            List<TalentTree> lstCTalentTree = new List<TalentTree>();

            foreach (TalentTree objTalentTree in lstTalentTree)
            {
                lstCTalentTree.Add(TalentTree.Clone(objTalentTree));
            }

            return lstCTalentTree;
        }
        #endregion

        #region Private_Methods
        /// <summary>
        /// Gets the single talent tree.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>TalentTree object</returns>
        private TalentTree GetSingleTalentTree(string sprocName, string strWhere, string strOrderBy)
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
        /// Gets the talent tree list.
        /// </summary>
        /// <param name="strSprocName">Name of the string sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of TalentTree objects</returns>
        private List<TalentTree> GetTalentTreeList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<TalentTree> talentTrees = new List<TalentTree>();

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
                    TalentTree objTalentTree = new TalentTree();
                    SetReaderToObject(ref objTalentTree, ref result);
                    talentTrees.Add(objTalentTree);
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
            return talentTrees;
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.TalentTreeID = (int)result.GetValue(result.GetOrdinal("TalentTreeID"));
                this.ForceTalent = (bool)result.GetValue(result.GetOrdinal("ForceTalent"));
                this.TalentTreeName = result.GetValue(result.GetOrdinal("TalentTreeName")).ToString();
                
                Talent objTalent = new Talent();
                Race objRace = new Race();
                TalentTreeRequirement objTalentTreeRequirement = new TalentTreeRequirement();

                this.objTalentTreeTalents = objTalent.GetTreeTalents("otmTalentTreeTalent.TalentTreeID=" + this.TalentTreeID.ToString(), "");

                this.objTalentTreeRaceRequirement = objRace.GetRaceRequirementForTalentTree("TalentTreeID=" + this.TalentTreeID.ToString(), " RaceName" );

                this.objTalentTreeRequirement = objTalentTreeRequirement.GetTalentTreeTalentTreeRequirements("TalentTreeID=" + this.TalentTreeID.ToString(), " TalentTreeRequirementDescription ");

                this._objComboBoxData.Add(this.TalentTreeID, this.TalentTreeName);
            }
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="objTalentTree">The object talent tree.</param>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref TalentTree objTalentTree, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                objTalentTree.TalentTreeID = (int)result.GetValue(result.GetOrdinal("TalentTreeID"));
                objTalentTree.ForceTalent = (bool)result.GetValue(result.GetOrdinal("ForceTalent"));
                objTalentTree.TalentTreeName = result.GetValue(result.GetOrdinal("TalentTreeName")).ToString();
                
                Talent objTalent = new Talent();
                Race objRace = new Race();
                TalentTreeRequirement objTalentTreeRequirement = new TalentTreeRequirement();

                objTalentTree.objTalentTreeTalents = objTalent.GetTreeTalents("otmTalentTreeTalent.TalentTreeID=" + objTalentTree.TalentTreeID.ToString(), "");

                objTalentTree.objTalentTreeRaceRequirement = objRace.GetRaceRequirementForTalentTree("TalentTreeID=" + objTalentTree.TalentTreeID.ToString(), " RaceName");

                objTalentTree.objTalentTreeRequirement = objTalentTreeRequirement.GetTalentTreeTalentTreeRequirements("TalentTreeID=" + objTalentTree.TalentTreeID.ToString(), " TalentTreeRequirementDescription ");

                objTalentTree._objComboBoxData.Add(objTalentTree.TalentTreeID, objTalentTree.TalentTreeName);
            }
        }
        #endregion
        #endregion
    }
}
