﻿using Hinzberg.Extensions.String;
using Hinzberg.Helper.Parser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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

            Assert.AreEqual(new DateTime(2020, 5, 14), DateTimeParser.ParseDateTimeFromYYYYMMDDString("2020-05-14"));
            Assert.AreEqual(new DateTime(2020, 5, 1), DateTimeParser.ParseDateTimeFromYYYYMMString("2020-05"));
        }
    }
}
