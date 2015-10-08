using System.IO;
using Equation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EquationTest
{
    
    
    /// <summary>
    ///This is a test class for ProgramTest and is intended
    ///to contain all ProgramTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ProgramTest
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


        /// <summary>
        ///A test for MakeCanonical
        ///</summary>
        [TestMethod()]
        public void MakeCanonicalTest()
        {
            const string equationString = "x^2 + 3.5xy + y = y^2 - xy + y";
            const string expected = "x^2 - y^2 + 4.5xy = 0";
            string actual = Program.MakeCanonical(equationString);
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///A test for BracketsAreCorrect
        ///</summary>
        [TestMethod()]
        public void BracketsAreCorrectTest()
        {
            const string correctBrackets = "2(x^2 + 3.5xy) + y = y^2 - (xy + y)";
            Assert.IsTrue(Program.BracketsAreCorrect(correctBrackets), "Correct brackets test failed:" + correctBrackets);
            const string noBrackets = "x^2 + 3.5xy + y = y^2 - xy + y";
            Assert.IsTrue(Program.BracketsAreCorrect(noBrackets), "No brackets test failed:" + noBrackets);
        }

        /// <summary>
        ///A test for BracketsAreCorrect
        ///</summary>
        [TestMethod()]
        public void BracketsAreIncorrectTest()
        {
            string equationString = "2)x^2 + 3.5xy( + y = y^2 - (xy + y)";
            Assert.IsFalse(Program.BracketsAreCorrect(equationString));
            equationString = "2(x^2 + 3.5xy( + y) = y^2 - (xy + y)";
            Assert.IsFalse(Program.BracketsAreCorrect(equationString));
            equationString = "2(x^2 + 3.5xy( + y) = y^2 - (xy + y))";
            Assert.IsFalse(Program.BracketsAreCorrect(equationString));
        }

        /// <summary>
        ///A test for MakeCanonical using test data from file 
        ///</summary>
        [TestMethod()]
        public void MakeCanonicalFromFileTest()
        {
            const string filePath = "TestData\\Test1.txt";
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                string[] pair = line.Split('|');
                string equation = pair[0];
                string expected = pair[1];
                Assert.AreEqual(expected, Program.MakeCanonical(equation));
            }
        }


        /// <summary>
        ///A test for BracketsAreCorrect
        ///</summary>
        [TestMethod()]
        public void ExpandBracketsTest()
        {
            const string eq = "(x^2 + 3.5xy)(45x + 5y) = 0";
            const string expected = "45x^3 + 162.5x^2y + 17.5xy^2 = 0";
            Assert.AreEqual(expected, Program.ExpandBrackets(eq));

        }

        /// <summary>
        ///A test for MakeCanonical using Wolfram Alpha api
        /// 
        ///</summary>
        [TestMethod()]
        [Ignore()]
        public void MakeCanonicalWolframAlphaTest()
        {
            // receive answer by calling Wolfram Alpha api 
            // http://api.wolframalpha.com/v2/query?input=x%5E2+%2B+3.5xy+%2B+y+%3D+y%5E2+-+xy+%2B+y&appid=XXXX

            const string appid = ""; // <-- insert yours here 

            // TODO: in the end if there will be nothing to do


        }

    }
}
