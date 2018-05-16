using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsClasses;

namespace SWRPGClassUnitTests
{
    /// <summary>
    /// This test will verify all the methods within the ClassLevelInfo Class
    /// </summary>
    [TestClass]
    public class ClassLevelInfoTest
    {
        ClassLevelInfo objNewClassLevelInfo = new ClassLevelInfo();
        public ClassLevelInfoTest()
        {
            objNewClassLevelInfo.ClassLevelID = 0;
            objNewClassLevelInfo.ClassID = 1;
            objNewClassLevelInfo.ClassLevel = 21;
            objNewClassLevelInfo.BonusFeat = 1;
            objNewClassLevelInfo.Talent = 1;
            objNewClassLevelInfo.BaseAttack = 1;
            objNewClassLevelInfo.ForcePointBase = 5;
            objNewClassLevelInfo.ForceSecret = 1;
            objNewClassLevelInfo.ForceTechnique = 1;
            objNewClassLevelInfo.MedicalSecret = 0;
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
        /// Tests the GetClassLevelInfo by ClassLevelID method.
        ///</summary>
        #region GetClassLevelInfo(int ClassLevelInfoID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetClassLevelInfo(int ClassLevelID) Method, Good Outcome")]
        public void Test_GetClassLevelInfo_ByID_GoodResult()
        {
            int ClassLevelID = 1;
            ClassLevelInfo objClassLevelInfo = new ClassLevelInfo();

            objClassLevelInfo.GetClassLevel(ClassLevelID);

            Assert.AreEqual(ClassLevelID, objClassLevelInfo.ClassLevelID);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetClassLevelInfo(int ClassLevelID) Method, Bad Outcome")]
        public void Test_GetClassLevelInfo_ByID_BadResult()
        {
            int ClassLevelID = 0;
            ClassLevelInfo objClassLevelInfo = new ClassLevelInfo();

            objClassLevelInfo.GetClassLevel(ClassLevelID);

            Assert.IsNull(objClassLevelInfo.Class );
        }
        #endregion

        /// <summary>
        /// Tests the GetClassLevelInfo by ClassID and ClassLevel method.
        ///</summary>
        #region GetClassLevelInfo(int ClassID, int ClassLevel)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetClassLevelInfo(int ClassID, int ClassLevel) Method, Good Outcome")]
        public void Test_GetClassLevelInfo_ByClassIDClassLevel_GoodResult()
        {
            int ClassID = 1;
            int ClassLevel = 1;
            ClassLevelInfo objClassLevelInfo = new ClassLevelInfo();

            objClassLevelInfo.GetClassLevel(ClassID, ClassLevel);

            Assert.AreEqual(ClassID, objClassLevelInfo.ClassID );
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetClassLevelInfo(int ClassID, int ClassLevel) Method, Bad Outcome")]
        public void Test_GetClassLevelInfo_ByClassIDClassLevel_BadResult()
        {
            int ClassID = 0;
            int ClassLevel = 1;
            ClassLevelInfo objClassLevelInfo = new ClassLevelInfo();

            objClassLevelInfo.GetClassLevel(ClassID, ClassLevel);

            Assert.IsNull(objClassLevelInfo.Class);
        }
        #endregion
        
        /// <summary>
        /// Tests the GetClassLevelInfos by strWhere, strOrderBy method.
        ///</summary>
        #region GetClassLevels(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetClassLevels(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetClassLevels_WithOrderBy_GoodResult()
        {
            string strWhere = "ClassID=1 and ClassLevel in (1,2,3)";
            string strOrderBy = "ClassLevel";

            ClassLevelInfo objClassLevelInfo = new ClassLevelInfo();
            List<ClassLevelInfo> lstClassLevelInfos = new List<ClassLevelInfo>();

            lstClassLevelInfos = objClassLevelInfo.GetClassLevels(strWhere, strOrderBy);

            Assert.IsTrue(lstClassLevelInfos.Count == 3);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetClassLevels(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetClassLevels_WithOutOrderBy_GoodResult()
        {
            string strWhere = "ClassID=1 and ClassLevel in (1,2,3)";
            string strOrderBy = "";

            ClassLevelInfo objClassLevelInfo = new ClassLevelInfo();
            List<ClassLevelInfo> lstClassLevelInfos = new List<ClassLevelInfo>();

            lstClassLevelInfos = objClassLevelInfo.GetClassLevels(strWhere, strOrderBy);

            Assert.IsTrue(lstClassLevelInfos.Count == 3);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetClassLevels(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetClassLevels_WithOrderBy_NoResult()
        {
            string strWhere = "ClassID=0 and ClassLevel in (1,2,3)";
            string strOrderBy = "ClassLevel";

            ClassLevelInfo objClassLevelInfo = new ClassLevelInfo();
            List<ClassLevelInfo> lstClassLevelInfos = new List<ClassLevelInfo>();

            lstClassLevelInfos = objClassLevelInfo.GetClassLevels(strWhere, strOrderBy);

            Assert.IsTrue(lstClassLevelInfos.Count == 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetClassLevelInfos(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetClassLevelInfos_WithOutOrderBy_NoResult()
        {
            string strWhere = "ClassID=0 and ClassLevel in (1,2,3)";
            string strOrderBy = "";

            ClassLevelInfo objClassLevelInfo = new ClassLevelInfo();
            List<ClassLevelInfo> lstClassLevelInfos = new List<ClassLevelInfo>();

            lstClassLevelInfos = objClassLevelInfo.GetClassLevels(strWhere, strOrderBy);

            Assert.IsTrue(lstClassLevelInfos.Count == 0);
        }

        #endregion

        #region SaveAndDeleteClassLevelInfo()
        /// <summary>
        /// Test_s the save and delete class level information.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SaveClassLevelInfo and DeleteClassLevelInfo Methods)")]
        public void Test_SaveAndDeleteClassLevelInfo()
        {
            bool returnVal;

            objNewClassLevelInfo.SaveClassLevelInfo();

            Assert.IsTrue(objNewClassLevelInfo.ClassLevelID  != 0);

            returnVal = objNewClassLevelInfo.DeleteClassLevelInfo();

            Assert.IsTrue(returnVal && objNewClassLevelInfo.DeleteOK);
        }
        #endregion

        /// <summary>
        /// Tests the IsClassInList by Class, List<Class> method.
        ///</summary>
        #region IsClassInList(Class, List<Class>)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the IsClassInList(ClassLevelInfo, List<ClassLevelInfo>) Method, Good Outcome")]
        public void Test_IsClassInList_SingleClassLevelParam_GoodResult()
        {
            bool blnIsInList = false;
            ClassLevelInfo objClassLI = new ClassLevelInfo();
            List<ClassLevelInfo> lstClassLI = new List<ClassLevelInfo>();
            objClassLI.GetClassLevel (1);
            lstClassLI.Add(objClassLI);

            blnIsInList = ClassLevelInfo.IsClassInList(objClassLI, lstClassLI);

            Assert.IsTrue(blnIsInList);
        }

        /// <summary>
        /// Tests the IsClassInList bad result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the IsClassInList(ClassLevelInfo, List<ClassLevelInfo>) Method, Bad Outcome")]
        public void Test_IsClassInList_SingleClassLevelParam_BadResult()
        {
            bool blnIsInList;
            ClassLevelInfo objClassLI = new ClassLevelInfo();
            List<ClassLevelInfo> lstClassLI = new List<ClassLevelInfo>();
            objClassLI.GetClassLevel(1);
            lstClassLI.Add(objClassLI);


            blnIsInList = ClassLevelInfo.IsClassInList(objNewClassLevelInfo, lstClassLI);

            Assert.IsFalse(blnIsInList);
        }


        /// <summary>
        /// Test_s the is class in list_ list class param_ good result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the IsClassInList(List<ClassLevelInfo> lstClassLI, List<ClassLevelInfo>) Method, Good Outcome")]
        public void Test_IsClassInList_ListClassLevelParam_GoodResult()
        {
            bool blnIsInList = false;
            ClassLevelInfo objClassLI = new ClassLevelInfo();
            ClassLevelInfo objClassLI2 = new ClassLevelInfo();

            List<ClassLevelInfo> lstClassLI = new List<ClassLevelInfo>();
            List<ClassLevelInfo> lstClassLI2 = new List<ClassLevelInfo>();

            objClassLI.GetClassLevel(1);
            objClassLI2.GetClassLevel(2);

            lstClassLI.Add(objClassLI);
            lstClassLI.Add(objClassLI2);

            lstClassLI2.Add(objClassLI);
            lstClassLI2.Add(objClassLI2);

            blnIsInList = ClassLevelInfo.IsClassInList(lstClassLI, lstClassLI2);
            
            Assert.IsTrue(blnIsInList);
        }

        /// <summary>
        /// Test_s the is class in list_ list class param_ bad result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the IsClassInList(List<ClassLevelInfo> , List<ClassLevelInfo>) Method, Bad Outcome")]
        public void Test_IsClassInList_ListClassLevelParam_BadResult()
        {
            bool blnIsInList = false;
            ClassLevelInfo objClassLI = new ClassLevelInfo();
            ClassLevelInfo objClassLI2 = new ClassLevelInfo();

            ClassLevelInfo objClassLI3 = new ClassLevelInfo();
            ClassLevelInfo objClassLI4 = new ClassLevelInfo();

            List<ClassLevelInfo> lstClassLI = new List<ClassLevelInfo>();
            List<ClassLevelInfo> lstClassLI2 = new List<ClassLevelInfo>();

            objClassLI.GetClassLevel (1);
            objClassLI2.GetClassLevel(2);

            objClassLI3.GetClassLevel(3);
            objClassLI4.GetClassLevel(4);

            lstClassLI.Add(objClassLI);
            lstClassLI.Add(objClassLI2);

            lstClassLI2.Add(objClassLI3);
            lstClassLI2.Add(objClassLI4);

            blnIsInList = ClassLevelInfo.IsClassInList(lstClassLI, lstClassLI2);

            Assert.IsFalse(blnIsInList);
        }
        #endregion

        #region Validate() returns bool
        /// <summary>
        /// Validate_s the true result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, True Outcome")]
        public void Validate_TrueResult()
        {
            objNewClassLevelInfo.Validate();
            Assert.IsTrue(objNewClassLevelInfo.Validated);
        }

        /// <summary>
        /// Validate_s the false result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, False Outcome")]
        public void Validate_FalseResult()
        {
            objNewClassLevelInfo.ClassLevel = 0;
            objNewClassLevelInfo.Validate();
            Assert.IsTrue(!objNewClassLevelInfo.Validated && (objNewClassLevelInfo.ValidationMessage.Length > 0));
        }
        #endregion
    }
}
