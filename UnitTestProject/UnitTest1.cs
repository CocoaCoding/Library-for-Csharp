using Hinzberg.Extensions.String;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string value = "The quick brown fox jumps of the lazy dog";
            Assert.IsTrue(value.CaseInsensitiveContains("fox"));
            Assert.IsFalse(value.CaseInsensitiveContains("wolf"));
        }
    }
}
