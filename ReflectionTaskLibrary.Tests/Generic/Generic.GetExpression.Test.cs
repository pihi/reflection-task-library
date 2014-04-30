using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PIHI.ReflectionTaskLibrary;

namespace ReflectionTaskLibrary.Tests.Object
{
    [TestClass]
    public class ObjectGetExpressionTest
    {
        private class TestClass
        {
            public String TestStringProperty { get; set; }
            
            public String TestStringField;

            public String TestMethod()
            {
                return "Test method!";
            }
        }

        [TestMethod]
        public void Can_Get_Field_Expression()
        {
            var obj = new TestClass();


            var exp = GenericGetExpression.GetExpression(obj, "TestStringField");
            
            
            obj.TestStringField = "TestThis";

            var m = exp.Compile();
            Assert.AreEqual("TestThis", m(obj));
        }

        [TestMethod]
        public void Can_Get_Property_Expression()
        {
            var obj = new TestClass();
            var exp = GenericGetExpression.GetExpression(obj, "TestStringProperty");
            obj.TestStringProperty = "TestThis";

            var m = exp.Compile();
            Assert.AreEqual("TestThis", m(obj));
        }

        [TestMethod]
        public void Can_Get_Method_Expression()
        {
            var obj = new TestClass();
            var exp = GenericGetExpression.GetExpression(obj, "TestMethod");
            obj.TestStringField = "TestThis";

            var m = exp.Compile();
            Assert.AreEqual("Test method!", m(obj));
        }
    }
}
