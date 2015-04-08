using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SharpTree;
using Sharptools.Trees;
using Sharptools.Arrays;

namespace SharpToolsTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestArrays()
        {
            int[] array = IntArray.newRandomArray(25, arrayType.NO_DUPLICATES);
            Assert.AreEqual(25, array.Length, "Array Initialized with incorrect length");
        }
    }
}
