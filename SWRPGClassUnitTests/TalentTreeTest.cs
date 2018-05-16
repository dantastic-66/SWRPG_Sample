using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsClasses;

namespace SWRPGClassUnitTests
{
    /// <summary>
    /// This test will verify all the methods within the TalentTree Class
    /// </summary>
    [TestClass]
    public class TalentTreeTest
    {
        TalentTree objNewTalentTree = new TalentTree();
        public TalentTreeTest()
        {
            objNewTalentTree.TalentTreeID = 0;
            objNewTalentTree.TalentTreeName = "Test Talent Tree";
            objNewTalentTree.ForceTalent = false;
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
        /// Tests the GetTalentTree by TalentTreeID method.
        ///</summary>
        #region GetTalentTree(int TalentTreeID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTalentTree(int TalentTreeID) Method, Good Outcome")]
        public void Test_GetTalentTree_ByID_GoodResult()
        {
            int intTalentTreeID = 1;
            TalentTree objTalentTree = new TalentTree();

            objTalentTree.GetTalentTree(intTalentTreeID);

            Assert.AreEqual(intTalentTreeID, objTalentTree.TalentTreeID);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTalentTree(int TalentTreeID) Method, Bad Outcome")]
        public void Test_GetTalentTree_ByID_BadResult()
        {
            int intTalentTreeID = 0;
            TalentTree objTalentTree = new TalentTree();

            objTalentTree.GetTalentTree(intTalentTreeID);

            Assert.IsNull(objTalentTree.TalentTreeName);
        }
        #endregion

        /// <summary>
        /// Tests the GetTalentTree by TalentTreeName method.
        ///</summary>
        #region GetTalentTree(string strTalentTreeName)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTalentTree(string TalentTreeName) Method, Good Outcome")]
        public void Test_GetTalentTree_ByName_GoodResult()
        {
            string strTalentTreeName = "Alter";
            TalentTree objTalentTree = new TalentTree();

            objTalentTree.GetTalentTree(strTalentTreeName);

            Assert.AreEqual(strTalentTreeName, objTalentTree.TalentTreeName);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTalentTree(string TalentTreeName) Method, Bad Outcome")]
        public void Test_GetTalentTree_ByName_BadResult()
        {
            string strTalentTreeName = "blah blah";
            TalentTree objTalentTree = new TalentTree();

            objTalentTree.GetTalentTree(strTalentTreeName);

            Assert.IsNull(objTalentTree.TalentTreeName);
        }
        #endregion

        /// <summary>
        /// Tests the GetCoreForceTalentTrees method.
        ///</summary>
        #region GetCoreForceTalentTrees()
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetCoreForceTalentTrees() Method")]
        public void Test_GetCoreForceTalentTrees()
        {
            TalentTree objTalentTree = new TalentTree();
            List<TalentTree> lstTalentTrees = new List<TalentTree>();

            lstTalentTrees = objTalentTree.GetCoreForceTalentTrees();

            Assert.IsTrue(lstTalentTrees.Count > 0);
        }
        #endregion

        /// <summary>
        /// Tests the GetForceTalentTrees method.
        ///</summary>
        #region GetForceTalentTrees()
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetForceTalentTrees(s) Method")]
        public void Test_GetForceTalentTrees()
        {
            string strWhere = "TalentTreeName Like '%Jedi%'";
            string strOrderBy = "";

            TalentTree objTalentTree = new TalentTree();
            List<TalentTree> lstTalentTrees = new List<TalentTree>();

            lstTalentTrees = objTalentTree.GetTalentTrees(strWhere, strOrderBy);

            Assert.IsTrue(lstTalentTrees.Count > 0);
        }
        #endregion

        /// <summary>
        /// Tests the GetTalentTrees by strWhere, strOrderBy method.
        ///</summary>
        #region GetTalentTrees(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTalentTrees(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetTalentTrees_WithOrderBy_GoodResult()
        {
            string strWhere = "TalentTreeName Like '%Jedi%'";
            string strOrderBy = "TalentTreeName";

            TalentTree objTalentTree = new TalentTree();
            List<TalentTree> lstTalentTrees = new List<TalentTree>();

            lstTalentTrees = objTalentTree.GetTalentTrees(strWhere, strOrderBy);

            Assert.IsTrue(lstTalentTrees.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTalentTrees(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetTalentTrees_WithOutOrderBy_GoodResult()
        {
            string strWhere = "TalentTreeName Like '%Jedi%'";
            string strOrderBy = "";

            TalentTree objTalentTree = new TalentTree();
            List<TalentTree> lstTalentTrees = new List<TalentTree>();

            lstTalentTrees = objTalentTree.GetTalentTrees(strWhere, strOrderBy);

            Assert.IsTrue(lstTalentTrees.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTalentTrees(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetTalentTrees_WithOrderBy_NoResult()
        {
            string strWhere = "TalentTreeName Like '%Toad%'";
            string strOrderBy = "TalentTreeName";

            TalentTree objTalentTree = new TalentTree();
            List<TalentTree> lstTalentTrees = new List<TalentTree>();

            lstTalentTrees = objTalentTree.GetTalentTrees(strWhere, strOrderBy);

            Assert.IsTrue(lstTalentTrees.Count == 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTalentTrees(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetTalentTrees_WithOutOrderBy_NoResult()
        {
            string strWhere = "TalentTreeName Like '%Toad%'";
            string strOrderBy = "";

            TalentTree objTalentTree = new TalentTree();
            List<TalentTree> lstTalentTrees = new List<TalentTree>();

            lstTalentTrees = objTalentTree.GetTalentTrees(strWhere, strOrderBy);

            Assert.IsTrue(lstTalentTrees.Count == 0);
        }

        #endregion

        /// <summary>
        /// Tests the MergeTalentTrees(List<TalentTree> lstTreeList1, List<TalentTree> lstTreeList2 , string strSortOrder) function.
        /// </summary>       
        #region MergeTalentTress(List<TalentTree> lstTreeList1, List<TalentTree> lstTreeList2 , string strSortOrder)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the MergeTalentTress(List<TalentTree> lstTreeList1, List<TalentTree> lstTreeList2 , string strSortOrder), True Outcome, Without Order By")]
        public void Test_MergeTalentTress_TrueResult_WithoutOrderBy()
        {
            TalentTree objTalentTree = new TalentTree();
            TalentTree objTalentTree2 = new TalentTree();
            List<TalentTree> lstTalentTreeList = new List<TalentTree>();
            List<TalentTree> lstTalentTreeList2 = new List<TalentTree>();
            bool blnTalentTreeIsInList, blnTalentTreeIsInList2;
            objTalentTree.GetTalentTree(1);
            
            lstTalentTreeList.Add(objTalentTree);
           
            objTalentTree2.GetTalentTree(2);
            lstTalentTreeList2.Add(objTalentTree2);

            List<TalentTree> lstMergedTalentTrees = new List<TalentTree>();
            lstMergedTalentTrees = TalentTree.MergeTalentTrees(lstTalentTreeList, lstTalentTreeList2, "");
            blnTalentTreeIsInList = TalentTree.IsTalentTreeInList(objTalentTree, lstMergedTalentTrees);
            blnTalentTreeIsInList2 = TalentTree.IsTalentTreeInList(objTalentTree2, lstMergedTalentTrees);

            Assert.IsTrue(blnTalentTreeIsInList && blnTalentTreeIsInList2 && lstMergedTalentTrees.Count ==2);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the MergeTalentTrees(List<TalentTree> lstTreeList1, List<TalentTree> lstTreeList2 , string strSortOrder), True Outcome, With Order By")]
        public void Test_MergeTalentTrees_TrueResult_WithOrderBy()
        {
            TalentTree objTalentTree = new TalentTree();
            TalentTree objTalentTree2 = new TalentTree();
            List<TalentTree> lstTalentTreeList = new List<TalentTree>();
            List<TalentTree> lstTalentTreeList2 = new List<TalentTree>();
            bool blnTalentTreeIsInList, blnTalentTreeIsInList2, blnAlterFirst;
            objTalentTree.GetTalentTree(1);

            lstTalentTreeList.Add(objTalentTree);

            objTalentTree2.GetTalentTree(2);
            lstTalentTreeList2.Add(objTalentTree2);

            List<TalentTree> lstMergedTalentTrees = new List<TalentTree>();
            lstMergedTalentTrees = TalentTree.MergeTalentTrees(lstTalentTreeList, lstTalentTreeList2, "TalentTreeName");
            blnTalentTreeIsInList = TalentTree.IsTalentTreeInList(objTalentTree, lstMergedTalentTrees);
            blnTalentTreeIsInList2 = TalentTree.IsTalentTreeInList(objTalentTree2, lstMergedTalentTrees);
            if (lstMergedTalentTrees.IndexOf(objTalentTree2) == 0) blnAlterFirst = true; else blnAlterFirst = false;

            Assert.IsTrue(blnTalentTreeIsInList && blnTalentTreeIsInList2 && lstMergedTalentTrees.Count == 2 && blnAlterFirst);
        }
        #endregion

        /// <summary>
        /// Test's  IsTalentTreeInList(TalentTree objTalentTree, List<TalentTree> lstTalentTreeList)
        /// </summary>       
        #region IsTalentTreeInList(TalentTree objTalentTree, List<TalentTree> lstTalentTreeList)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the IsTalentTreeInList(TalentTree objTalentTree, List<TalentTree> lstTalentTreeList) Method, True Outcome")]
        public void Test_IsTalentTreeInList_TrueResult()
        {
            TalentTree objTalentTree = new TalentTree();

            List<TalentTree> lstTalentTreeList = new List<TalentTree>();
            bool blnTalentTreeIsInList;
            objTalentTree.GetTalentTree(1);

            for (int i = 0; i < 3; i++)
            {
                lstTalentTreeList.Add(objTalentTree);
            }

            blnTalentTreeIsInList = TalentTree.IsTalentTreeInList(objTalentTree, lstTalentTreeList);

            Assert.IsTrue(blnTalentTreeIsInList);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the IsTalentTreeInList(List<TalentTree> lstTalentTrees, List<TalentTree> lstTalentTreeList) Method, Flase Outcome")]
        public void Test_IsTalentTreeInList_FalseResult()
        {
            TalentTree objTalentTree = new TalentTree();
            TalentTree objTalentTree2 = new TalentTree();
            List<TalentTree> lstTalentTreeList = new List<TalentTree>();
            bool blnTalentTreeIsInList;
            objTalentTree.GetTalentTree(1);

            for (int i = 0; i < 3; i++)
            {
                lstTalentTreeList.Add(objTalentTree);
            }
            objTalentTree2.GetTalentTree(2);
            blnTalentTreeIsInList = TalentTree.IsTalentTreeInList(objTalentTree2, lstTalentTreeList);

            Assert.IsFalse(blnTalentTreeIsInList);
        }
        #endregion

        /// <summary>
        /// Test's  IsTalentTreeInList(List<TalentTree> lstNeedList, List<TalentTree> lstTalentTreeList)
        /// </summary> 
        #region IsTalentTreeInList(List<TalentTree> lstNeedList, List<TalentTree> lstTalentTreeList)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the IsTalentTreeInList(List<TalentTree> lstNeedList, List<TalentTree> lstTalentTreeList) Method, True Outcome")]
        public void Test_IsTalentTreeInListList_TrueResult()
        {
            TalentTree objTalentTree = new TalentTree();
            TalentTree objTalentTree2 = new TalentTree();
            List<TalentTree> lstTalentTreeList = new List<TalentTree>();
            List<TalentTree> lstNeedList = new List<TalentTree>();
            bool blnTalentTreeIsInList;
            objTalentTree.GetTalentTree(1);

            for (int i = 0; i < 3; i++)
            {
                lstTalentTreeList.Add(objTalentTree);
            }
            for (int i = 0; i < 1; i++)
            {
                lstNeedList.Add(objTalentTree);
            }

            blnTalentTreeIsInList = TalentTree.IsTalentTreeInList(lstNeedList, lstTalentTreeList);

            Assert.IsTrue(blnTalentTreeIsInList);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the IsTalentTreeInList(List<TalentTree> lstNeedList, List<TalentTree> lstTalentTreeList) Method, Flase Outcome")]
        public void Test_IsTalentTreeInListList_FalseResult()
        {
            TalentTree objTalentTree = new TalentTree();
            TalentTree objTalentTree2 = new TalentTree();
            List<TalentTree> lstTalentTreeList = new List<TalentTree>();
            List<TalentTree> lstNeedList = new List<TalentTree>();
            bool blnTalentTreeIsInList;
            objTalentTree.GetTalentTree(1);
            objTalentTree2.GetTalentTree(2);

            for (int i = 0; i < 3; i++)
            {
                lstTalentTreeList.Add(objTalentTree);
            }

            for (int i = 0; i < 1; i++)
            {
                lstNeedList.Add(objTalentTree2);
            }

            blnTalentTreeIsInList = TalentTree.IsTalentTreeInList(lstNeedList, lstTalentTreeList);

            Assert.IsFalse(blnTalentTreeIsInList);
        }
        #endregion

        /// <summary>
        /// Test's  List<TalentTree> GetCharactersAllowableTalentTrees(Character objChar)
        /// </summary> 
        #region GetCharactersAllowableTalentTrees(Character objChar)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetCharactersAllowableTalentTrees(Character objChar)")]
        public void Test_GetCharactersAllowableTalentTrees()
        {

            Character objChar = new Character();
            objChar.GetCharacter(1);
            TalentTree objTT = new TalentTree();


            List<TalentTree> lstTalentTreeList = new List<TalentTree>();
            lstTalentTreeList = objTT.GetCharactersAllowableTalentTrees(objChar);

            Assert.IsTrue(lstTalentTreeList.Count > 0);
        }
        #endregion

        /// <summary>
        /// Test's  List<TalentTree> GetCharactersAllowableTalentTreesByAddedClass(Character objChar, Class objClass)
        /// </summary> 
        #region GetCharactersAllowableTalentTreesByAddedClass(Character objChar, Class objClass)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetCharactersAllowableTalentTreesByAddedClass(Character objChar, Class objClass)")]
        public void Test_GetCharactersAllowableTalentTreesByAddedClass()
        {

            Character objChar = new Character();
            objChar.GetCharacter(1);
            TalentTree objTT = new TalentTree();

            Class objClass = new Class();
            objClass.GetClass("Crime Lord");

            List<TalentTree> lstTalentTreeList = new List<TalentTree>();
            lstTalentTreeList = objTT.GetCharactersAllowableTalentTreesByAddedClass (objChar, objClass);

            Assert.IsTrue(lstTalentTreeList.Count > 0);
        }
        #endregion

        /// <summary>
        /// Tests the GetTalentTreesPrestigeClass by strWhere, strOrderBy method.
        ///</summary>
        #region GetTalentTreesPrestigeClass(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTalentTreesPrestigeClass(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetTalentTreesPrestigeClass_WithOrderBy_GoodResult()
        {
            string strWhere = "ClassID=6";
            string strOrderBy = "TalentTreeName";

            TalentTree objTalentTree = new TalentTree();
            List<TalentTree> lstTalentTrees = new List<TalentTree>();

            lstTalentTrees = objTalentTree.GetTalentTreesPrestigeClass(strWhere, strOrderBy);

            Assert.IsTrue(lstTalentTrees.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTalentTreesPrestigeClass(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetTalentTreesPrestigeClass_WithOutOrderBy_GoodResult()
        {
            string strWhere = "ClassID=6";
            string strOrderBy = "";

            TalentTree objTalentTree = new TalentTree();
            List<TalentTree> lstTalentTrees = new List<TalentTree>();

            lstTalentTrees = objTalentTree.GetTalentTreesPrestigeClass(strWhere, strOrderBy);

            Assert.IsTrue(lstTalentTrees.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTalentTreesPrestigeClass(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetTalentTreesPrestigeClass_WithOrderBy_NoResult()
        {
            string strWhere = "ClassID=1";
            string strOrderBy = "TalentTreeName";

            TalentTree objTalentTree = new TalentTree();
            List<TalentTree> lstTalentTrees = new List<TalentTree>();

            lstTalentTrees = objTalentTree.GetTalentTreesPrestigeClass(strWhere, strOrderBy);

            Assert.IsTrue(lstTalentTrees.Count == 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTalentTreesPrestigeClass(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetTalentTreesPrestigeClass_WithOutOrderBy_NoResult()
        {
            string strWhere = "ClassID=1";
            string strOrderBy = "";

            TalentTree objTalentTree = new TalentTree();
            List<TalentTree> lstTalentTrees = new List<TalentTree>();

            lstTalentTrees = objTalentTree.GetTalentTreesPrestigeClass(strWhere, strOrderBy);

            Assert.IsTrue(lstTalentTrees.Count == 0);
        }

        #endregion

        #region SaveAndDeleteTalentTree()
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SaveTalentTree and DeleteTalentTree Methods)")]
        public void Test_SaveAndDeleteTalentTree()
        {
            bool returnVal;

            objNewTalentTree.SaveTalentTree();

            Assert.IsTrue(objNewTalentTree.TalentTreeID != 0);

            returnVal = objNewTalentTree.DeleteTalentTree();

            Assert.IsTrue(returnVal && objNewTalentTree.DeleteOK);
        }
        #endregion

        #region Validate() returns bool
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, True Outcome")]
        public void Validate_TrueResult()
        {
            objNewTalentTree.Validate();
            Assert.IsTrue(objNewTalentTree.Validated);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, False Outcome")]
        public void Validate_FalseResult()
        {
            objNewTalentTree.TalentTreeName = "";
            objNewTalentTree.Validate();
            Assert.IsTrue(!objNewTalentTree.Validated && (objNewTalentTree.ValidationMessage.Length > 0));
        }
        #endregion
    }
}
