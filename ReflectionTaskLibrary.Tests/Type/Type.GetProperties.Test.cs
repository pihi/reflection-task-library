using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PIHI.ReflectionTaskLibrary;

namespace ReflectionTaskLibrary.Tests
{
    [TestClass]
    public class TypeGetPropertiesTest
    {
        private class TestClass
        {
            public DateTime TestDateTime1 { get; set; }
            public DateTime TestDateTime2 { get; set; }
            public int TestInt1 { get; set; }
            public int TestInt2 { get; set; }
        }

        [TestMethod]
        public void Test_Get_Property_By_Name()
        {
            var properties = TypeGetProperties.GetProperties(typeof (TestClass), "TestInt1");
            Assert.AreEqual(1, properties.Count);
            Assert.AreEqual(typeof(int), properties.ElementAt(0).PropertyType);
        }

        [TestMethod]
        public void Test_Get_Properties_By_Name()
        {
            var properties = TypeGetProperties.GetProperties(typeof (TestClass), "TestInt1", "TestDateTime1");
            Assert.AreEqual(2, properties.Count);
            Assert.AreEqual(typeof(int), properties.ElementAt(0).PropertyType);
            Assert.AreEqual(typeof(DateTime), properties.ElementAt(1).PropertyType);
        }

        [TestMethod]
        public void Test_Get_Property_By_Type()
        {
            var properties = TypeGetProperties.GetProperties(typeof (TestClass), typeof (DateTime));
            Assert.AreEqual(2, properties.Count);
            Assert.AreEqual(typeof(DateTime), properties.ElementAt(0).PropertyType);
            Assert.AreEqual(typeof(DateTime), properties.ElementAt(1).PropertyType);
        }

        [TestMethod]
        public void Test_Get_Properties_By_Type()
        {
            var properties = TypeGetProperties.GetProperties(typeof(TestClass), typeof(DateTime), typeof(int));
            Assert.AreEqual(4, properties.Count);
            Assert.AreEqual(typeof(DateTime), properties.ElementAt(0).PropertyType);
            Assert.AreEqual(typeof(DateTime), properties.ElementAt(1).PropertyType);
            Assert.AreEqual(typeof(int), properties.ElementAt(2).PropertyType);
            Assert.AreEqual(typeof(int), properties.ElementAt(3).PropertyType);
        }
    }
}
