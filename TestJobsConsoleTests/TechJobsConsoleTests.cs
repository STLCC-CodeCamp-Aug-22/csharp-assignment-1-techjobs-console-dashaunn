using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechJobsConsole;

namespace AutogradingTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPrintJobs()
        {
            // Check that the PrintJobs method returns the appropriate jobs if a user searches for Buzzbold as an employer.
            string text = System.IO.File.ReadAllText("TestPrintJobs.txt");

            var writer = new StringWriter();
            Console.SetOut(writer);

            var reader = new StringReader("0" + Environment.NewLine + "1" + Environment.NewLine + "Buzzbold" + Environment.NewLine + "x");
            Console.SetIn(reader);
            var app = new TechJobs();

            app.RunProgram();

            var output = writer.ToString();
            Assert.AreEqual(text, output);
        }

        [TestMethod]
        public void TestPrintJobsNoResults()
        {
            // Check that the PrintJobs method returns the no results if a user searches for Chicago as an employer.
            string text = System.IO.File.ReadAllText("TestPrintJobsNoResults.txt");

            var writer = new StringWriter();
            Console.SetOut(writer);

            var reader = new StringReader("0" + Environment.NewLine + "1" + Environment.NewLine + "Chicago" + Environment.NewLine + "x");
            Console.SetIn(reader);
            var app = new TechJobs();

            app.RunProgram();

            var output = writer.ToString();
            Assert.AreEqual(text, output);
        }

        [TestMethod]
        public void TestFindAByValue()
        {
            string text = System.IO.File.ReadAllText("TestFindByValue.txt");

            var writer = new StringWriter();
            Console.SetOut(writer);

            var reader = new StringReader("0" + Environment.NewLine + "4" + Environment.NewLine + "Ruby" + Environment.NewLine + "x");
            Console.SetIn(reader);
            var app = new TechJobs();

            app.RunProgram();

            var output = writer.ToString();
            Assert.AreEqual(text, output);
        }

        [TestMethod]
        public void TestCaseInsensitiveSearch()
        {
            string text = System.IO.File.ReadAllText("TestCaseInsensitiveSearch.txt");

            var writer = new StringWriter();
            Console.SetOut(writer);

            var reader = new StringReader("0" + Environment.NewLine + "2" + Environment.NewLine + "new YORK" + Environment.NewLine + "x");
            Console.SetIn(reader);
            var app = new TechJobs();

            app.RunProgram();

            var output = writer.ToString();
            Assert.AreEqual(text, output);
        }
    }
}
