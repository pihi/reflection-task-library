using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PIHI.ReflectionTaskLibrary;

namespace ReflectionTaskLibrary.Tests
{
    [TestClass]
    public class ObjectIsTest
    {
        [TestMethod]
        public void Types_Equal()
        {
            var obj = 13;
            var type = typeof (int);

            Assert.IsTrue(obj.Is<int>());
            Assert.IsTrue(obj.Is(type));
        }

        [TestMethod]
        public void Types_Not_Equal()
        {
            var obj = 13;
            var type = typeof (float);

            Assert.IsFalse(obj.Is<float>());
            Assert.IsFalse(obj.Is(type));
        }
    }
}
