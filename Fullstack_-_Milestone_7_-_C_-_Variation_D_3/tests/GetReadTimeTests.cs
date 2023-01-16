using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace CSharpMilestone.Test
{
    [TestFixture]
    [Description("GetReadTime tests")]
    public class GetReadTimeTests
    {
        private Assembly _assembly;
        private Type[] _constructorTypes;
        private const string MethodName = "GetReadTime";
        private const string TypePath = "CSharpMilestone.Book";

        [SetUp]
        public void Setup()
        {
            _assembly = Assembly.GetExecutingAssembly();
            _constructorTypes = new[] {typeof(string), typeof(string), typeof(int), typeof(int)};
        }
        
        
        [Test, Description("GetReadTime exists")]
        public void TestGetReadTimeExists()
        {
            var classType = _assembly.GetType(TypePath);
            var method = classType?.GetMethod(MethodName);

            Assert.IsNotNull(method);
        }
        
        [Test, Description("GetReadTime should be public")]
        public void TestGetReadTimeIsPublic()
        {
            var classType = _assembly.GetType(TypePath);
            var method = classType?.GetMethod(MethodName);

            Assert.IsTrue(method?.IsPublic);
        }
        
        [Test, Description("GetReadTime should be an instance method")]
        public void TestGetReadTimeIsNotStatic()
        {
            var classType = _assembly.GetType(TypePath);
            var method = classType?.GetMethod(MethodName);

            Assert.IsFalse(method?.IsStatic);
        }
        
        [Test, Description("GetReadTime should receive integer parameter and return with a double value")]
        public void TestGetReadTimeTakesAnIntegerAndReturnsWithDouble()
        {
            var classType = _assembly.GetType(TypePath);
            var method = classType?.GetMethod(MethodName);

            Assert.AreEqual(typeof(int), method?.GetParameters().FirstOrDefault()?.ParameterType);
            Assert.AreEqual(typeof(double), method?.ReturnType);
        }

        [Test, TestCaseSource(nameof(TestGetReadTimeCases))]
        [Description("GetReadTime should calculate read time")]
        public void TestGetReadTime(string title, string author, int pages, int starRating, int pagesPerMinute, double expected)
        {
            var classType = _assembly.GetType(TypePath);
            var method = classType?.GetMethod(MethodName);

            var constructor = classType?.GetConstructor(_constructorTypes);
            var bookObj = constructor?.Invoke(new object[] { title, author, pages, starRating });

            var actual = method?.Invoke(bookObj, new object[] {pagesPerMinute}) as double?;

            Assert.IsTrue(actual.HasValue);
            Assert.AreEqual(expected, actual.Value, 0.01);
        }
        
        private static IEnumerable<TestCaseData> TestGetReadTimeCases
        {
            get
            {
                yield return new TestCaseData("Game of Thrones", "George R. R. Martin", 800, 5, 2, 400).SetName("TestGetReadTime_Case1");
                yield return new TestCaseData("Chronicles of Narnia: The Lion, the Witch and the Wardrobe", "C. S. Lewis", 180, 4, 4, 45).SetName("TestGetReadTime_Case2");
                yield return new TestCaseData("1984", "George Orwell", 350, 5, 5, 70).SetName("TestGetReadTime_Case3");
                yield return new TestCaseData("Surrounded by Idiots", "Thomas Erikson", 280, 4, 28, 10).SetName("TestGetReadTime_Case4");
                yield return new TestCaseData("An Offer From a Gentleman", "Julia Quinn", 390, 1, 4, 97.5).SetName("TestGetReadTime_Case5");
            }
        }
    }
}
