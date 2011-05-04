using ThermoFisherScientificCodeSamples;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ThermoFisherScientificCodeSampleTests
{
    
    
    /// <summary>
    ///This is a test class for FibonacciTest and is intended
    ///to contain all FibonacciTest Unit Tests
    ///</summary>
    [TestClass()]
    public class FibonacciTest
    {


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

        [TestMethod()]
        public void TestLowerNumbers()
        {
            Assert.AreEqual(3, Fibonacci.GetFibonacci(1).Length);
            Assert.AreEqual(0, Fibonacci.GetFibonacci(0)[0]);
        }
        /// <summary>
        ///A test for GetFibonacci
        ///</summary>
        [TestMethod()]
        public void GetFibonacciTest()
        {
            int max = int.MaxValue;
            var results = Fibonacci.GetFibonacci(max);
            Assert.IsNotNull(results);
            Assert.IsTrue(results.Length > 0);

            Assert.IsTrue(results[results.Length-1] <= max);

            for (int i= results.Length; i > 3; i--)
            {
                Assert.AreEqual(results[i-1],results[i-2] + results[i-3]);
            }

            Assert.IsTrue((long) results[results.Length - 2] + (long) results[results.Length - 1] > (long) max);

        }

        [TestMethod()]
        public void BadInput()
        {
            var results = Fibonacci.GetFibonacci(-1);
            Assert.IsTrue(results.Length <1);
        }
    }
}
