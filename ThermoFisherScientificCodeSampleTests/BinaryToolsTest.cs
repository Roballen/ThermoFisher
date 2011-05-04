using System.Collections.Generic;
using System.Diagnostics;
using ThermoFisherScientificCodeSamples;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ThermoFisherScientificCodeSampleTests
{
    
    
    /// <summary>
    ///This is a test class for BinaryToolsTest and is intended
    ///to contain all BinaryToolsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BinaryToolsTest
    {
        public BinaryToolsTest()
        {
            _testmatrix = new Dictionary<int, Dictionary<BaseType, string>>();

            var d128 = new Dictionary<BaseType, string> { { BaseType.Sixteen, "80" }, { BaseType.Eight, "200" }, { BaseType.Two, "10000000" } };
            var d255 = new Dictionary<BaseType, string> { { BaseType.Sixteen, "FF" }, { BaseType.Eight, "377" }, { BaseType.Two, "11111111" } };
            var d235 = new Dictionary<BaseType, string> { { BaseType.Sixteen, "EB" }, { BaseType.Eight, "353" }, { BaseType.Two, "11101011" } };
            var d28 = new Dictionary<BaseType, string> { { BaseType.Sixteen, "1C" }, { BaseType.Eight, "34" }, { BaseType.Two, "11100" } };
            var d74 = new Dictionary<BaseType, string> { { BaseType.Sixteen, "4A" }, { BaseType.Eight, "112" }, { BaseType.Two, "1001010" } };

            _testmatrix.Add(128, d128);
            _testmatrix.Add(255, d255);
            _testmatrix.Add(235, d235);
            _testmatrix.Add(28, d28);
            _testmatrix.Add(74, d74);
        }
        private Dictionary<int,Dictionary<BaseType, string>> _testmatrix;

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

        /// <summary>
        ///A test for DecimalToBinary
        ///</summary>
        [TestMethod()]
        public void DecimalToBinaryTest()
        {
            int value = 23; 
            int expected = 10111;
            int actual;
            actual = BinaryTools.DecimalToBinary(value);
            Assert.AreEqual(expected, actual);
        }

                /// <summary>
        ///A test for DecimalToBinary_Faster
        ///</summary>
        [TestMethod()]
        public void DecimalToBinary_FasterTest()
        {
            int value = 23;
            int expected = 10111;
            int actual;
            actual = BinaryTools.DecimalToBinaryCustom(value);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void FrameWork_Test_All_Bases()
        {
            int val = 201;
            string result = BinaryTools.DecimalFromBaseType(val, BaseType.Sixteen);

            foreach (KeyValuePair<int, Dictionary<BaseType, string>> test in _testmatrix)
            {
                foreach (KeyValuePair<BaseType, string> value in test.Value)
                {
                    Assert.AreEqual(value.Value, BinaryTools.DecimalFromBaseType(test.Key, value.Key));
                }
            }

        }

        [TestMethod()]
        public void FrameworkMethod_Should_Be_Same_As_Custom()
        {
            int[] ints = new int[] { 12345, 4568797, 234444, 23, 567, 90993};

            foreach (BaseType value in Enum.GetValues(typeof(BaseType)))
            {
                foreach (var i in ints)
                {
                    Assert.AreEqual(BinaryTools.DecimalFromBaseType(i,value), BinaryTools.DecimalToAnyBaseExpanded(i, GetEncodingTable(value)));
                }
            }

        }


        /// <summary>
        ///A test for DecimalToAnyBaseExpanded
        ///</summary>
        [TestMethod()]
        public void DecimalToAnyBaseExpanded_Simple_Test()
        {
            int value = 23;
            char[] encodingtable = new char[] {'0','1'};
            char leftoverchar = '='; //not need
            string expected = "10111";
            string actual;
            actual = BinaryTools.DecimalToAnyBaseExpanded(value, encodingtable, leftoverchar);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TestIntMaxValueCustom()
        {
            //just make sure there is no error
            int i = int.MaxValue;
            char[] encodingtable = new char[] {'0','1'};
            BinaryTools.DecimalToAnyBaseExpanded(i, encodingtable);
        }

//        [TestMethod()]
//        public void FindMaxIntValForBinaryConversion()
//        {
            //just make sure there is no exception
//            char[] encodingtable = new char[] { '0', '1' };
//            Debug.Print("starting");
//            for (int i = 1000; i < int.MaxValue; i++)
//            {
//                Debug.Print(i.ToString());
//                BinaryTools.DecimalToBinary(i);
//            }
//        }

        [TestMethod()]
        public void Test_Max_value()
        {
            //just make sure there is no exception
            char[] encodingtable = new char[] { '0', '1' };
            BinaryTools.DecimalFromBaseType(int.MaxValue,BaseType.Two);
        }

        [TestMethod()]
        public void Test_Min_value()
        {
            //just make sure there is no exception
            char[] encodingtable = new char[] { '0', '1' };
            BinaryTools.DecimalFromBaseType(int.MinValue, BaseType.Two);
        }

        [TestMethod()]
        public void DecimalToAnyBaseCustomTests()
        {
            //just make sure there are no exceptions
            for (int i = 0; i < 20; i++)
            {
                char[] encodingtable = new char[] {'0', '1'};
                BinaryTools.DecimalToAnyBaseCustom(int.MaxValue, i);
                var t = int.MinValue;
                BinaryTools.DecimalToAnyBaseCustom(int.MinValue, i);
            }
        }

        [TestMethod()]
        public void TestBadEncodingTable()
        {
            Assert.AreEqual("",BinaryTools.DecimalToAnyBaseExpanded(1024, new char[100]));
            Assert.AreEqual("", BinaryTools.DecimalToAnyBaseExpanded(1024, new char[] { }));
        }

        [TestMethod()]
        public void TestNumberToBig()
        {
            Assert.AreEqual(0,BinaryTools.DecimalToBinary(1200));
        }

        [TestMethod()]
        public void DecimalToAnyBaseExpandedTest()
        {
            //base64 is weird, standard definition of encoding table has A=0,B=1 and so forth, there is also the uneven bytes at end, but that is really outside the scope of this at the moment
            var base64 = new char[]{
        '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
        'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
        'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'Y', 'Z',
        '+', '/'};

            //just making sure there are no exceptions
            BinaryTools.DecimalToAnyBaseExpanded(int.MaxValue, new char[] {'0', '1'});
            BinaryTools.DecimalToAnyBaseExpanded(int.MinValue, new char[] { '0', '1' });

            BinaryTools.DecimalToAnyBaseExpanded(int.MaxValue, base64);
            BinaryTools.DecimalToAnyBaseExpanded(int.MinValue, base64);
        }

        [TestMethod()]
        public void VerifyAccuracyOfCustomExpanded()
        {

            foreach (KeyValuePair<int, Dictionary<BaseType, string>> test in _testmatrix)
            {
                foreach (KeyValuePair<BaseType, string> value in test.Value)
                {
                    Assert.AreEqual(value.Value, BinaryTools.DecimalToAnyBaseExpanded(test.Key, GetEncodingTable(value.Key)));
                }
            }
        }

        private char[] GetEncodingTable(BaseType type)
        {
            switch (type)
            {
                case BaseType.Two:
                    return new char[] {'0','1'};
                case BaseType.Eight:
                    return new char[] {'0','1','2','3','4','5','6','7'};
                case BaseType.Ten:
                    return new char[] {'0','1','2','3','4','5','6','7','8','9'};
                case BaseType.Sixteen:
                    return new char[] {'0','1','2','3','4','5','6','7','8','9','A','B','C','D','E','F'};
            }
            return new char[]{};
        }

    }
}
