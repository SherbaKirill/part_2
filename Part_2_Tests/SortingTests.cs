using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Part_2;

namespace Part_2_Tests
{
    [TestClass]
    public class SortingTests
    {
        [TestMethod]
        public void Order_Int()
        {
            // Arrange
            int[] testData = { 2, 10, 15, 65, 3 };
            int[] expectedResult = { 2, 3, 10, 15, 65 };

            // Act & Assert
            SortingTestBase(testData, expectedResult, Sorting.Order);
        }

        [TestMethod]
        public void Order_String()
        {
            // Arrange
            string[] testData = { "B", "C", "A", "E", "D" };
            string[] expectedResult = { "A", "B", "C", "D", "E" };

            // Act & Assert
            SortingTestBase(testData, expectedResult, Sorting.Order);
        }

        [TestMethod]
        public void Order_IComparable()
        {
            // Arrange
            TestObject[] testData = { new TestObject(2), new TestObject(1), new TestObject(3) };
            TestObject[] expectedResult = { new TestObject(1), new TestObject(2), new TestObject(3) };

            // Act & Assert
            SortingTestBase(testData, expectedResult, Sorting.Order);
        }

        [TestMethod]
        public void DescendingOrder_Int()
        {
            // Arrange
            int[] testData = { 2, 10, 15, 65, 3 };
            int[] expectedResult = { 65, 15, 10, 3, 2 };

            // Act & Assert
            SortingTestBase(testData, expectedResult, Sorting.DescendingOrder);
        }

        [TestMethod]
        public void DescendingOrder_String()
        {
            // Arrange
            string[] testData = { "B", "C", "A", "E", "D" };
            string[] expectedResult = { "E", "D", "C", "B", "A" };

            // Act & Assert
            SortingTestBase(testData, expectedResult, Sorting.DescendingOrder);
        }

        [TestMethod]
        public void DescendingOrder_IComparable()
        {
            // Arrange
            TestObject[] testData = { new TestObject(2), new TestObject(1), new TestObject(3) };
            TestObject[] expectedResult = { new TestObject(3), new TestObject(2), new TestObject(1) };

            // Act & Assert
            SortingTestBase(testData, expectedResult, Sorting.DescendingOrder);
        }

        [TestMethod]
        public void Unique_Int()
        {
            // Arrange
            int[] testData = { 2, 2, 3, 3, 4, 4, 5, 5 };
            int[] expectedResult = { 2, 3, 4, 5 };

            // Act & Assert
            SortingTestBase(testData, expectedResult, Sorting.Unique);
        }

        [TestMethod]
        public void Unique_String()
        {
            // Arrange
            string[] testData = { "B", "B", "C" };
            string[] expectedResult = { "B", "C" };

            // Act & Assert
            SortingTestBase(testData, expectedResult, Sorting.Unique);
        }

        [TestMethod]
        public void Unique_IComparable()
        {
            // Arrange
            TestObject[] testData = { new TestObject(2), new TestObject(2), new TestObject(3) };
            TestObject[] expectedResult = { new TestObject(2), new TestObject(3) };

            // Act & Assert
            SortingTestBase(testData, expectedResult, Sorting.Unique);
        }

        private class TestObject : IComparable<TestObject>, IComparable, IEquatable<TestObject>
        {
            private int Id { get; }

            public TestObject(int id) => Id = id;

            public int CompareTo(TestObject testObject) => testObject == null ? 1 : Id.CompareTo(testObject.Id);

            public int CompareTo(object obj) => obj == null ? 1 : CompareTo(obj as TestObject);

            public bool Equals(TestObject other) => Id == other?.Id;

            public override bool Equals(object obj) => Equals(obj as TestObject);

            public override int GetHashCode() => Id.GetHashCode();
        }

        private void SortingTestBase<T>(T[] testData, T[] expectedResult, Func<T[], T[]> sutFunc)
            where T : IComparable<T>, IComparable

        {
            // Arrange
            int expectedLength = expectedResult.Length;

            // Act
            T[] actualResult = sutFunc(testData);

            // Assert
            Assert.IsNotNull(actualResult);
            Assert.IsTrue(expectedLength == actualResult.Length);
            for (int i = 0; i < expectedLength; i++)
            {
                Assert.IsTrue(expectedResult[i].Equals(actualResult[i]));
            }
        }
    }
}
