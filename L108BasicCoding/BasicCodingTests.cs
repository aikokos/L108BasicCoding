// <copyright file="BasicCodingTests.cs" company="LearningCompany">
// Copyright (c) Company. All rights reserved.
// </copyright>

namespace L108BasicCoding
{
    using NUnit.Framework;

    /// <summary>
    /// The tests for main L108BasicCoding class.
    /// Contains all tests for tasks in module Basic Coding.
    /// </summary>
    public class BasicCodingTests
    {
        /// <summary>
        /// Test for method InsertNumber.
        /// </summary>
        [Test]
        public void InsertNumberTest()
        {
            BasicCodingTasks t = new BasicCodingTasks();
            Assert.AreEqual(t.InsertNumber(15, 15, 0, 0), 15);
            Assert.AreEqual(t.InsertNumber(8, 15, 0, 0), 9);
            Assert.AreEqual(t.InsertNumber(8, 15, 3, 8), 120);
        }

        /// <summary>
        /// Test for method FindMax.
        /// </summary>
        [Test]
        public void FindMaxTest()
        {
            BasicCodingTasks t = new BasicCodingTasks();
            int[] x = { 5, 8, 7, 2, -1, 12, 3 };
            Assert.AreEqual(t.FindMax(0, x, x.Length, x[0]), 12);
        }

        /// <summary>
        /// Test for method GetNumberRightAndLeftEqual
        /// </summary>
        [Test]
        public void GetNumberRightAndLeftEqualTest()
        {
            BasicCodingTasks t = new BasicCodingTasks();
            int[] x = { 5, 5, 6, 5, 5 };
            Assert.AreEqual(t.GetNumberRightAndLeftEqual(x), 2);
        }

        /// <summary>
        /// Test for method ConcatenateWithoutDuplicates
        /// </summary>
        [Test]
        public void ConcatenateWithoutDuplicatesTest()
        {
            BasicCodingTasks t = new BasicCodingTasks();
            string a = "aaabbbcccceeedd";
            string b = "mmmnnnkkk";
            Assert.AreEqual(t.ConcatenateWithoutDuplicates(a, b), "abcedmnk");
        }

        /// <summary>
        /// Test for method FindNextNumberTest
        /// </summary>
        /// <param name="n">number to which we need find next bigger number</param>
        /// <returns>Returns the next bigger number from same digits.</returns>
        [Test]
        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(20, ExpectedResult = -1)]
       public int FindNextNumberTest(int n)
        {
            BasicCodingTasks t = new BasicCodingTasks();
            long elapsedMs1;
            return t.FindNextNumber(n, out elapsedMs1);
        }

        /// <summary>
        /// Test for method FilterDigitTest
        /// </summary>
        /// <param name="a">array of digits to filter</param>
        /// <returns>Returns the filtered array with digits containing 7.</returns>
        [Test]
        [TestCase(new int[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, ExpectedResult = new int[] { 7, 7, 70, 17 })]
        [TestCase(new int[] { 1, 6, 777, 45, 34 }, ExpectedResult = new int[] { 777 })]
        public int[] FilterDigitTest(int[] a)
        {
            BasicCodingTasks t = new BasicCodingTasks();
            int[] b = t.FilterDigit(a);
            return b;
        }
    }
}