using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PIHI.ReflectionTaskLibrary;

namespace ReflectionTaskLibrary.Tests
{
    [TestClass]
    public class ObjectGetValueTest
    {
        private class TestClass
        {
            public string PublicGetPublicSetStringProperty { get; set; }
            public string PublicGetProtectedSetStringProperty { get; protected set; }
            public string PublicGetPrivateSetStringProperty { get; private set; }
            public string PublicGetInternalSetStringProperty { get; internal set; }

            protected string ProtectedGetProtectedSetStringProperty { get; set; }
            protected string ProtectedGetPrivateSetStringProperty { get; private set; }

            public int IntProperty { get; set; }
            public int? NullableIntProperty { get; set; }

            private string PrivateGetPrivateSetProperty { get; set; }

            public string PublicStringField;
            protected string ProtectedStringField;
            private string PrivateStringField;
            internal string InternalStringField;

            public int IntField;
            public int? NullableIntField;

            public TestClass()
            {
                PublicGetInternalSetStringProperty = TestString;
                PublicGetPrivateSetStringProperty = TestString;
                PublicGetProtectedSetStringProperty = TestString;
                PublicGetPublicSetStringProperty = TestString;

                ProtectedGetPrivateSetStringProperty = TestString;
                ProtectedGetProtectedSetStringProperty = TestString;

                InternalStringField = TestString;
                PrivateStringField = TestString;
                ProtectedStringField = TestString;
                PublicStringField = TestString;

                IntProperty = TestInt;
                NullableIntProperty = null;

                IntField = TestInt;
                NullableIntField = null;
            }
        }

        private const string TestString = "This Is A Test";
        private const int TestInt = 1337;

        private readonly string[] _allPrivileges = new string[]
        {
            "Public", "Protected", "Private", "Internal"
        };

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void Throw_When_Name_Is_Null()
        {
            string test = null;
            ObjectGetValue.GetValue(new object(), test);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Throw_When_Name_Is_Empty()
        {
            string test = "";
            ObjectGetValue.GetValue(new object(), test);
        }

        [TestMethod]
        public void Return_Null_When_Property_Or_Field_Doesnt_Exist()
        {
            var v = ObjectGetValue.GetValue(new object(), "test");
            Assert.IsNull(v);
        }

        [TestMethod]
        public void Return_Default_When_Property_Or_Field_Doesnt_Exist()
        {
            var v = ObjectGetValue.GetValue<int>(new object(), "test");
            Assert.AreEqual(0, v);
        }

        [TestMethod]
        public void GetValue_Using_PropertyInfo_NullableType_As_Object_Default()
        {
            var testClass = new TestClass();
            var pi = testClass.GetType().GetProperty("NullableIntProperty");

            var v = ObjectGetValue.GetValue(testClass, pi);
            Assert.IsNull(v);
        }

        [TestMethod]
        public void GetValue_Using_PropertyInfo_NullableType_As_NullableType_Default()
        {
            var testClass = new TestClass();
            var pi = testClass.GetType().GetProperty("NullableIntProperty");

            var v = ObjectGetValue.GetValue<int?>(testClass, pi);
            Assert.IsNull(v);
        }

        [TestMethod]
        public void GetValue_Using_PropertyInfo_NullableType_As_ValueType_Default()
        {
            var testClass = new TestClass();
            var pi = testClass.GetType().GetProperty("NullableIntProperty");

            var v = ObjectGetValue.GetValue<int>(testClass, pi);
            Assert.AreEqual(0, v);
        }

        [TestMethod]
        public void GetValue_Using_PropertyInfo_NullableType_As_Object_After_Set()
        {
            var testClass = new TestClass();
            testClass.NullableIntProperty = TestInt;

            var pi = testClass.GetType().GetProperty("NullableIntProperty");
            var v = ObjectGetValue.GetValue(testClass, pi);

            Assert.AreEqual(TestInt, v);
        }

        [TestMethod]
        public void GetValue_Using_PropertyInfo_NullableType_As_NullableType_After_Set()
        {
            var testClass = new TestClass();
            testClass.NullableIntProperty = TestInt;

            var pi = testClass.GetType().GetProperty("NullableIntProperty");
            var v = ObjectGetValue.GetValue<int?>(testClass, pi);

            Assert.AreEqual(TestInt, v);
        }

        [TestMethod]
        public void GetValue_Using_PropertyInfo_NullableType_As_ValueType_After_Set()
        {
            var testClass = new TestClass();
            testClass.NullableIntProperty = TestInt;

            var pi = testClass.GetType().GetProperty("NullableIntProperty");
            var v = ObjectGetValue.GetValue<int>(testClass, pi);

            Assert.AreEqual(TestInt, v);
        }

        [TestMethod]
        public void GetValue_Using_FieldInfo_NullableType_As_Object_Default()
        {
            var testClass = new TestClass();
            var pi = testClass.GetType().GetField("NullableIntField");

            var v = ObjectGetValue.GetValue(testClass, pi);
            Assert.IsNull(v);
        }

        [TestMethod]
        public void GetValue_Using_FieldInfo_NullableType_As_NullableType_Default()
        {
            var testClass = new TestClass();
            var pi = testClass.GetType().GetField("NullableIntField");

            var v = ObjectGetValue.GetValue<int?>(testClass, pi);
            Assert.IsNull(v);
        }

        [TestMethod]
        public void GetValue_Using_FieldInfo_NullableType_As_ValueType_Default()
        {
            var testClass = new TestClass();
            var pi = testClass.GetType().GetField("NullableIntField");

            var v = ObjectGetValue.GetValue<int>(testClass, pi);
            Assert.AreEqual(0, v);
        }

        [TestMethod]
        public void GetValue_Using_FieldInfo_NullableType_As_Object_After_Set()
        {
            var testClass = new TestClass();
            testClass.NullableIntField = TestInt;

            var pi = testClass.GetType().GetField("NullableIntField");
            var v = ObjectGetValue.GetValue(testClass, pi);

            Assert.AreEqual(TestInt, v);
        }

        [TestMethod]
        public void GetValue_Using_FieldInfo_NullableType_As_NullableType_After_Set()
        {
            var testClass = new TestClass();
            testClass.NullableIntField = TestInt;

            var pi = testClass.GetType().GetField("NullableIntField");
            var v = ObjectGetValue.GetValue<int?>(testClass, pi);

            Assert.AreEqual(TestInt, v);
        }

        [TestMethod]
        public void GetValue_Using_FieldInfo_NullableType_As_ValueType_After_Set()
        {
            var testClass = new TestClass();
            testClass.NullableIntField = TestInt;

            var pi = testClass.GetType().GetField("NullableIntField");
            var v = ObjectGetValue.GetValue<int>(testClass, pi);

            Assert.AreEqual(TestInt, v);
        }

        [TestMethod]
        public void GetValue_Of_A_Publicly_Gettable_Property_With_A_String()
        {
            var testClass = new TestClass();
            
            foreach (string p in _allPrivileges)
            {
                string n = String.Format("PublicGet{0}SetStringProperty", p);
                var v = ObjectGetValue.GetValue<string>(testClass, n);
                Assert.AreEqual(TestString, v);
            }
        }

        [TestMethod]
        public void GetValue_Of_A_Public_Field_With_A_String()
        {
            var testClass = new TestClass();
            string n = "PublicStringField";
            var v = ObjectGetValue.GetValue<string>(testClass, n);
            Assert.AreEqual(TestString,v);
        }

        [TestMethod]
        public void GetValue_Of_IntProperty()
        {
            var testClass = new TestClass();
            var v = ObjectGetValue.GetValue<int>(testClass, "IntProperty");
            Assert.AreEqual(TestInt, v);
        }

        [TestMethod]
        public void GetValue_Of_NullableIntProperty()
        {
            var testClass = new TestClass();
            var v = ObjectGetValue.GetValue<int?>(testClass, "NullableIntProperty");
            Assert.AreEqual(new Nullable<int>(), v);
        }

        [TestMethod]
        public void GetValue_Of_NullableIntProperty_As_Int()
        {
            var testClass = new TestClass();
            var v = ObjectGetValue.GetValue<int>(testClass, "NullableIntProperty");
            Assert.AreEqual(0, v);
        }

        [TestMethod]
        public void GetValue_Of_NullableIntProperty_As_Int_With_Value()
        {
            var testClass = new TestClass();
            testClass.NullableIntProperty = TestInt;
            var v = ObjectGetValue.GetValue<int>(testClass, "NullableIntProperty");
            Assert.AreEqual(TestInt, v);
        }
    }
}
