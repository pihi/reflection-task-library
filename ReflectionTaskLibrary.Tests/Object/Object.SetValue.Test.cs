using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PIHI.ReflectionTaskLibrary;

namespace ReflectionTaskLibrary.Tests
{
    [TestClass]
    public class ObjectSetValueTest
    {
        private class TestClass
        {
            public int IntField;
            public int IntProperty { get; set; }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_Null_PropertyOrField_Throws()
        {
            var test = new TestClass();
            ObjectSetValue.SetValue(test, "", 0);
        }

        [TestMethod]
        public void Test_SetValue_With_String_FieldName()
        {
            var test = new TestClass();
            ObjectSetValue.SetValue(test, "IntField", 100);
            Assert.AreEqual(100, test.IntField);
        }

        [TestMethod]
        public void Test_SetValue_With_String_PropertyName()
        {
            var test = new TestClass();
            ObjectSetValue.SetValue(test, "IntProperty", 184);
            Assert.AreEqual(184, test.IntProperty);
        }

        public void Test_SetValue_With_PropertyInfo()
        {
            var test = new TestClass();
            var prop = test.GetType().GetProperty("IntProperty");
            ObjectSetValue.SetValue(test, prop, 83);
            Assert.AreEqual(83, test.IntProperty);
        }

        public void Test_SetValue_With_FieldInfo()
        {
            var test = new TestClass();
            var field = test.GetType().GetField("IntField");
            ObjectSetValue.SetValue(test, field, 23);
            Assert.AreEqual(23, test.IntField);
        }
    }
}
