using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hinzberg.Extensions.String;

namespace TestProject
{
    [TestClass]
    public class StringTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string value = "The quick brown fox jumps of the lazy dog";

            Assert.IsTrue(value.CaseInsensitiveContains("fox"));
        }
    }
}
