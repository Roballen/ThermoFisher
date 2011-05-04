using System.IO;
using System.Reflection;
using System.Resources;
using ThermoFisherScientificCodeSamples;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ThermoFisherScientificCodeSampleTests
{
    
    
    /// <summary>
    ///This is a test class for ExamplesTest and is intended
    ///to contain all ExamplesTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RemoveSpacesTest
    {
        private const string _teststring = "  te st  ";
        private const string _nospacesstring = "test";
        private const string _nullstring = null;

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
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        /// Remove Spaces should remove all spaces including multiple spaces, leading, internal, or trailing
        /// </summary>
        [TestMethod()]
        public void RemoveSpaces_Should_Remove_All_Spaces()
        {
            Assert.AreEqual("test", Examples.RemoveSpaces(_teststring), "Method did not remove consecutive spaces");
        }

        [TestMethod()]
        public void RemoveSpaces_StringBuilder_Should_Remove_All_Spaces()
        {
            Assert.AreEqual("test", Examples.RemoveSpacesStringBuilder(_teststring), "Method did not remove consecutive spaces");
        }

        [TestMethod()]
        public void RemoveSpaces_StringBuilder_foreach_Should_Remove_All_Spaces()
        {
            Assert.AreEqual("test", Examples.RemoveSpacesStringbuilderForeach(_teststring), "Method did not remove consecutive spaces");
        }

        [TestMethod()]
        public void RemoveSpaces_LINQ_Should_Remove_All_Spaces()
        {
            Assert.AreEqual("test", Examples.RemoveSpacesLinq(_teststring), "Method did not remove consecutive spaces");
        }

        [TestMethod()]
        public void RemoveSpaces_CustomReplace_Should_Remove_All_Spaces()
        {
            Assert.AreEqual("test", Examples.RemoveSpacesCustomReplace(_teststring), "Method did not remove consecutive spaces");
        }

        [TestMethod()]
        public void Test_All_Methods_Against_String_with_no_spaces()
        {
            Assert.AreEqual("test", Examples.RemoveSpacesCustomReplace(_nospacesstring), "Method failed on no space string");
            Assert.AreEqual("test", Examples.RemoveSpacesLinq(_nospacesstring), "Method failed on no space string");
            Assert.AreEqual("test", Examples.RemoveSpacesStringbuilderForeach(_nospacesstring), "Method failed on no space string");
            Assert.AreEqual("test", Examples.RemoveSpacesStringBuilder(_nospacesstring), "Method failed on no space string");
            Assert.AreEqual("test", Examples.RemoveSpaces(_nospacesstring), "Method failed on no space string");
        }

        [TestMethod()]
        public void Test_All_Methods_Against_null_string()
        {
            Assert.AreEqual(null, Examples.RemoveSpacesCustomReplace(_nullstring), "Method failed on null string");
            Assert.AreEqual(null, Examples.RemoveSpacesLinq(_nullstring), "Method failed on null string");
            Assert.AreEqual(null, Examples.RemoveSpacesStringbuilderForeach(_nullstring), "Method failed on null string");
            Assert.AreEqual(null, Examples.RemoveSpacesStringBuilder(_nullstring), "Method failed on null string");
            Assert.AreEqual(null, Examples.RemoveSpaces(_nullstring), "Method failed on null string");
        }
        [TestMethod()]
        public void Test_All_Methods_Against_Big_file()
        {
            var teststring = GetStringFromFile("ThermoFisherScientificCodeSamples.ReplaceSpaces.txt");
            Assert.IsFalse(Examples.RemoveSpacesCustomReplace(teststring).Contains(" "));
            Assert.IsFalse(Examples.RemoveSpacesLinq(teststring).Contains(" "));
            Assert.IsFalse(Examples.RemoveSpacesStringbuilderForeach(teststring).Contains(" "));
            Assert.IsFalse(Examples.RemoveSpacesStringBuilder(teststring).Contains(" "));
            Assert.IsFalse(Examples.RemoveSpaces(teststring).Contains(" "));
        }

        [TestMethod()]
        public void FastReplaceNoPattern()
        {
            var val = "sdfsdf sdfsdf sdf ss s   s  s";
            Assert.AreEqual(val,Examples.FastReplace(val,"","", StringComparison.OrdinalIgnoreCase));
        }

        private string GetStringFromFile(string filename)
        {
            try
            {
               var assem = this.GetType().Assembly;
                using (var stream = assem.GetManifestResourceStream(filename))
                {
                    if (stream == null)
                        return "";

                    using (var reader = new StreamReader(stream))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
            catch (Exception e)
            {
                //usually would do something else here like log or try again or determine problem
                Console.WriteLine(e);
            }
            return "";
        }

    }
}
