using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PIHI.ReflectionTaskLibrary;

namespace ReflectionTaskLibrary.Tests
{
    [TestClass]
    public class TypeIsTest
    {
        private interface ITest
        {    
        }

        private class Base : ITest
        {
        }

        private class Sub : Base
        {
        }

        [TestMethod]
        public void Test_Generic()
        {
            Assert.IsTrue(TypeIs.Is<Base>(typeof(Base)));
        }

        [TestMethod]
        public void Test_Types_Are_Equal()
        {
            var type1 = typeof (Base);
            var type2 = typeof (Base);
            Assert.IsTrue(TypeIs.Is(type1, type2));
        }

        [TestMethod]
        public void Test_Types_Are_Not_Equal()
        {
            var type1 = typeof (DateTime);
            var type2 = typeof (Base);
            Assert.IsFalse(TypeIs.Is(type1, type2));
        }

        [TestMethod]
        public void Test_SubType()
        {
            var type1 = typeof (Sub);
            var type2 = typeof (Base);
            Assert.IsTrue(TypeIs.Is(type1, type2));
            Assert.IsFalse(TypeIs.Is(type2, type1));
        }

        [TestMethod]
        public void Test_Interface()
        {
            var type1 = typeof (Base);
            var type2 = typeof (ITest);
            Assert.IsTrue(TypeIs.Is(type1, type2));
        }

        [TestMethod]
        public void Test_Interface_On_Subclass()
        {
            var type1 = typeof (Sub);
            var type2 = typeof (ITest);
            Assert.IsTrue(TypeIs.Is(type1, type2));
        }

        [TestMethod]
        public void Test_Nullable()
        {
            var type1 = typeof (int);
            var type2 = typeof (int?);
            Assert.IsTrue(TypeIs.Is(type1, type2));
        }

        [TestMethod]
        public void Test_Nullable_Reverse()
        {
            var type1 = typeof (int?);
            var type2 = typeof (int);
            Assert.IsTrue(TypeIs.Is(type1, type2));
        }
    }
}
