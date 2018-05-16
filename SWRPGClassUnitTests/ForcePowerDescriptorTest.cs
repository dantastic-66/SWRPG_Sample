using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsClasses;

namespace SWRPGClassUnitTests
{
    /// <summary>
    /// This test will verify all the methods within the ForcePowerDescriptor Class
    /// </summary>
    [TestClass]
    public class ForcePowerDescriptorTest
    {
        /// <summary>
        /// The object new force power descriptor
        /// </summary>
        ForcePowerDescriptor objNewForcePowerDescriptor = new ForcePowerDescriptor();
        /// <summary>
        /// Initializes a new instance of the <see cref="ForcePowerDescriptorTest"/> class.
        /// </summary>
        public ForcePowerDescriptorTest()
        {
            objNewForcePowerDescriptor.ForcePowerDescriptorID = 0;
            objNewForcePowerDescriptor.ForcePowerDescriptorName = "Test Force Power Description";
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
        /// Tests the GetForcePowerDescriptor by ForcePowerDescriptorID method.
        /// </summary>
        #region GetForcePowerDescriptor(int ForcePowerDescriptorID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetForcePowerDescriptor(int ForcePowerDescriptorID) Method, Good Outcome")]
        public void Test_GetForcePowerDescriptor_ByID_GoodResult()
        {
            int intForcePowerDescriptorID = 1;
            ForcePowerDescriptor objForcePowerDescriptor = new ForcePowerDescriptor();

            objForcePowerDescriptor.GetForcePowerDescriptor(intForcePowerDescriptorID);

            Assert.AreEqual(intForcePowerDescriptorID, objForcePowerDescriptor.ForcePowerDescriptorID);
        }

        /// <summary>
        /// Test_s the get force power descriptor_ by i d_ bad result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetForcePowerDescriptor(int ForcePowerDescriptorID) Method, Bad Outcome")]
        public void Test_GetForcePowerDescriptor_ByID_BadResult()
        {
            int intForcePowerDescriptorID = 0;
            ForcePowerDescriptor objForcePowerDescriptor = new ForcePowerDescriptor();

            objForcePowerDescriptor.GetForcePowerDescriptor(intForcePowerDescriptorID);

            Assert.IsNull(objForcePowerDescriptor.ForcePowerDescriptorName);
        }
        #endregion

        /// <summary>
        /// Tests the GetForcePowerDescriptor by ForcePowerDescriptorName method.
        /// </summary>
        #region GetForcePowerDescriptor(string strForcePowerDescriptorName)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetForcePowerDescriptor(string ForcePowerDescriptorName) Method, Good Outcome")]
        public void Test_GetForcePowerDescriptor_ByName_GoodResult()
        {
            string strForcePowerDescriptorName = "Telekenitic";
            ForcePowerDescriptor objForcePowerDescriptor = new ForcePowerDescriptor();

            objForcePowerDescriptor.GetForcePowerDescriptor(strForcePowerDescriptorName);

            Assert.AreEqual(strForcePowerDescriptorName, objForcePowerDescriptor.ForcePowerDescriptorName);
        }

        /// <summary>
        /// Test_s the get force power descriptor_ by name_ bad result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetForcePowerDescriptor(string ForcePowerDescriptorName) Method, Bad Outcome")]
        public void Test_GetForcePowerDescriptor_ByName_BadResult()
        {
            string strForcePowerDescriptorName = "blah blah";
            ForcePowerDescriptor objForcePowerDescriptor = new ForcePowerDescriptor();

            objForcePowerDescriptor.GetForcePowerDescriptor(strForcePowerDescriptorName);

            Assert.IsNull(objForcePowerDescriptor.ForcePowerDescriptorName);
        }
        #endregion

        /// <summary>
        /// Tests the GetForcePowerDescriptors by strWhere, strOrderBy method.
        /// </summary>
        #region GetForcePowerDescriptors(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetForcePowerDescriptors(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetForcePowerDescriptors_WithOrderBy_GoodResult()
        {
            string strWhere = "ForcePowerDescriptorName Like '%Side%'";
            string strOrderBy = "ForcePowerDescriptorName";

            ForcePowerDescriptor objForcePowerDescriptor = new ForcePowerDescriptor();
            List<ForcePowerDescriptor> lstForcePowerDescriptors = new List<ForcePowerDescriptor>();

            lstForcePowerDescriptors = objForcePowerDescriptor.GetForcePowerDescriptors(strWhere, strOrderBy);

            Assert.IsTrue(lstForcePowerDescriptors.Count > 0);
        }

        /// <summary>
        /// Test_s the get force power descriptors_ with out order by_ good result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetForcePowerDescriptors(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetForcePowerDescriptors_WithOutOrderBy_GoodResult()
        {
            string strWhere = "ForcePowerDescriptorName Like '%Side%'";
            string strOrderBy = "";

            ForcePowerDescriptor objForcePowerDescriptor = new ForcePowerDescriptor();
            List<ForcePowerDescriptor> lstForcePowerDescriptors = new List<ForcePowerDescriptor>();

            lstForcePowerDescriptors = objForcePowerDescriptor.GetForcePowerDescriptors(strWhere, strOrderBy);

            Assert.IsTrue(lstForcePowerDescriptors.Count > 0);
        }

        /// <summary>
        /// Test_s the get force power descriptors_ with order by_ no result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetForcePowerDescriptors(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetForcePowerDescriptors_WithOrderBy_NoResult()
        {
            string strWhere = "ForcePowerDescriptorName Like '%Toad%'";
            string strOrderBy = "ForcePowerDescriptorName";

            ForcePowerDescriptor objForcePowerDescriptor = new ForcePowerDescriptor();
            List<ForcePowerDescriptor> lstForcePowerDescriptors = new List<ForcePowerDescriptor>();

            lstForcePowerDescriptors = objForcePowerDescriptor.GetForcePowerDescriptors(strWhere, strOrderBy);

            Assert.IsTrue(lstForcePowerDescriptors.Count == 0);
        }

        /// <summary>
        /// Test_s the get force power descriptors_ with out order by_ no result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetForcePowerDescriptors(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetForcePowerDescriptors_WithOutOrderBy_NoResult()
        {
            string strWhere = "ForcePowerDescriptorName Like '%Toad%'";
            string strOrderBy = "";

            ForcePowerDescriptor objForcePowerDescriptor = new ForcePowerDescriptor();
            List<ForcePowerDescriptor> lstForcePowerDescriptors = new List<ForcePowerDescriptor>();

            lstForcePowerDescriptors = objForcePowerDescriptor.GetForcePowerDescriptors(strWhere, strOrderBy);

            Assert.IsTrue(lstForcePowerDescriptors.Count == 0);
        }

        #endregion

        #region SaveAndDeleteForcePowerDescriptor()
        /// <summary>
        /// Test_s the save and delete force power descriptor.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SaveForcePowerDescriptor and DeleteForcePowerDescriptor Methods)")]
        public void Test_SaveAndDeleteForcePowerDescriptor()
        {
            bool returnVal;

            objNewForcePowerDescriptor.SaveForcePowerDescriptor();

            Assert.IsTrue(objNewForcePowerDescriptor.ForcePowerDescriptorID != 0);

            returnVal = objNewForcePowerDescriptor.DeleteForcePowerDescriptor();

            Assert.IsTrue(returnVal && objNewForcePowerDescriptor.DeleteOK);
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
            objNewForcePowerDescriptor.Validate();
            Assert.IsTrue(objNewForcePowerDescriptor.Validated);
        }

        /// <summary>
        /// Validate_s the false result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, False Outcome")]
        public void Validate_FalseResult()
        {
            objNewForcePowerDescriptor.ForcePowerDescriptorName = "";
            objNewForcePowerDescriptor.Validate();
            Assert.IsTrue(!objNewForcePowerDescriptor.Validated && (objNewForcePowerDescriptor.ValidationMessage.Length > 0));
        }
        #endregion
    }
}
