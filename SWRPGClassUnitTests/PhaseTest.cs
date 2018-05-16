using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsClasses;

namespace SWRPGClassUnitTests
{
    /// <summary>
    /// This test will verify all the methods within the Phase Class
    /// </summary>
    [TestClass]
    public class PhaseTest
    {
        /// <summary>
        /// The object new phase
        /// </summary>
        Phase objNewPhase = new Phase();
        /// <summary>
        /// Initializes a new instance of the <see cref="PhaseTest"/> class.
        /// </summary>
        public PhaseTest()
        {
            objNewPhase.PhaseID = 0;
            objNewPhase.PhaseName = "Test Phase";
        }

        /// <summary>
        /// The test context instance
        /// </summary>
        private TestContext testContextInstance;

        /// <summary>
        /// Gets or sets the test context which provides
        /// information about and functionality for the current test run.
        /// </summary>
        /// <value>
        /// The test context.
        /// </value>
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
        /// Tests the GetPhase by PhaseID method.
        /// </summary>
        #region GetPhase(int PhaseID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetPhase(int PhaseID) Method, Good Outcome")]
        public void Test_GetPhase_ByID_GoodResult()
        {
            int intPhaseID = 1;
            Phase objPhase = new Phase();

            objPhase.GetPhase(intPhaseID);

            Assert.AreEqual(intPhaseID, objPhase.PhaseID);
        }

        /// <summary>
        /// Test_s the get phase_ by i d_ bad result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetPhase(int PhaseID) Method, Bad Outcome")]
        public void Test_GetPhase_ByID_BadResult()
        {
            int intPhaseID = 0;
            Phase objPhase = new Phase();

            objPhase.GetPhase(intPhaseID);

            Assert.IsNull(objPhase.PhaseName);
        }
        #endregion

        /// <summary>
        /// Tests the GetPhase by PhaseName method.
        /// </summary>
        #region GetPhase(string strPhaseName)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetPhase(string PhaseName) Method, Good Outcome")]
        public void Test_GetPhase_ByName_GoodResult()
        {
            string strPhaseName = "Swift";
            Phase objPhase = new Phase();

            objPhase.GetPhase(strPhaseName);

            Assert.AreEqual(strPhaseName, objPhase.PhaseName);
        }

        /// <summary>
        /// Test_s the get phase_ by name_ bad result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetPhase(string PhaseName) Method, Bad Outcome")]
        public void Test_GetPhase_ByName_BadResult()
        {
            string strPhaseName = "blah blah";
            Phase objPhase = new Phase();

            objPhase.GetPhase(strPhaseName);

            Assert.IsNull(objPhase.PhaseName);
        }
        #endregion

        /// <summary>
        /// Tests the GetPhases by strWhere, strOrderBy method.
        /// </summary>
        #region GetPhases(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetPhases(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetPhases_WithOrderBy_GoodResult()
        {
            string strWhere = "PhaseName Like '%o%'";
            string strOrderBy = "PhaseName";

            Phase objPhase = new Phase();
            List<Phase> lstPhases = new List<Phase>();

            lstPhases = objPhase.GetPhases(strWhere, strOrderBy);

            Assert.IsTrue(lstPhases.Count > 0);
        }

        /// <summary>
        /// Test_s the get phases_ with out order by_ good result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetPhases(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetPhases_WithOutOrderBy_GoodResult()
        {
            string strWhere = "PhaseName Like '%o%'";
            string strOrderBy = "";

            Phase objPhase = new Phase();
            List<Phase> lstPhases = new List<Phase>();

            lstPhases = objPhase.GetPhases(strWhere, strOrderBy);

            Assert.IsTrue(lstPhases.Count > 0);
        }

        /// <summary>
        /// Test_s the get phases_ with order by_ no result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetPhases(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetPhases_WithOrderBy_NoResult()
        {
            string strWhere = "PhaseName Like '%Toad%'";
            string strOrderBy = "PhaseName";

            Phase objPhase = new Phase();
            List<Phase> lstPhases = new List<Phase>();

            lstPhases = objPhase.GetPhases(strWhere, strOrderBy);

            Assert.IsTrue(lstPhases.Count == 0);
        }

        /// <summary>
        /// Test_s the get phases_ with out order by_ no result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetPhases(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetPhases_WithOutOrderBy_NoResult()
        {
            string strWhere = "PhaseName Like '%Toad%'";
            string strOrderBy = "";

            Phase objPhase = new Phase();
            List<Phase> lstPhases = new List<Phase>();

            lstPhases = objPhase.GetPhases(strWhere, strOrderBy);

            Assert.IsTrue(lstPhases.Count == 0);
        }

        #endregion

        #region SaveAndDeletePhase()
        /// <summary>
        /// Test_s the save and delete phase.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SavePhase and DeletePhase Methods)")]
        public void Test_SaveAndDeletePhase()
        {
            bool returnVal;

            objNewPhase.SavePhase();

            Assert.IsTrue(objNewPhase.PhaseID != 0);

            returnVal = objNewPhase.DeletePhase();

            Assert.IsTrue(returnVal && objNewPhase.DeleteOK);
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
            objNewPhase.Validate();
            Assert.IsTrue(objNewPhase.Validated);
        }

        /// <summary>
        /// Validate_s the false result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, False Outcome")]
        public void Validate_FalseResult()
        {
            objNewPhase.PhaseName = "";
            objNewPhase.Validate();
            Assert.IsTrue(!objNewPhase.Validated && (objNewPhase.ValidationMessage.Length > 0));
        }
        #endregion
    }
}
