using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PIHI.ReflectionTaskLibrary;

namespace ReflectionTaskLibrary.Tests
{
    [TestClass]
    public class ObjectGetAllTest
    {
        private class TestClass
        {
            public int PublicIntProperty { get; set; }
            public String PublicStringProperty { get; set; }
            public DateTime PublicDateTimeProperty { get; set; }
            public DateTime? PublicNullableDateTimeProperty { get; set; }
            public DateTime PublicDateTimeField;
            public DateTime? PublicNullableDateTimeField { get; set; }
        }

        [TestMethod]
        public void Test_Get_All()
        {
            var test = new TestClass();
            var list = ObjectGetAll.GetAll<DateTime>(test).ToList();
            Assert.AreEqual(4, list.Count);
        }
    }
}
