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
    public class ObjectInvokeTest
    {
        private class TestClass
        {
            public int GetOne()
            {
                return 1;
            }

            public int Add(int a, int b)
            {
                return a + b;
            }
        }

        [TestMethod]
        public void Test_Invoke_With_String_Method_Name_Without_Arguments()
        {
            var testObject = new TestClass();
            int one = ObjectInvoke.Invoke<int>(testObject, "GetOne");
            Assert.AreEqual(1, one);
        }

        [TestMethod]
        public void Test_Invoke_With_String_Method_Name_With_Arguments()
        {
            var testObject = new TestClass();
            int add = ObjectInvoke.Invoke<int>(testObject, "Add", 10, 50);
            Assert.AreEqual(60, add);
        }
    }
}
