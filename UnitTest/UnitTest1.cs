using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
             Debug.WriteLine(VinSolutions.Program.ParseInput("Programming is fun!!"));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Debug.WriteLine(VinSolutions.Program.ParseInput("Programming___is_+++fun!!"));
        }
        [TestMethod]
        public void TestMethod3()
        {
            Debug.WriteLine(VinSolutions.Program.ParseInput("Programming(((is)))fun!!"));

        }
        [TestMethod]
        public void TestMethod4()
        {
            Debug.WriteLine(VinSolutions.Program.ParseInput("bbbbbbBBBBBBB"));
        }
    }
}
