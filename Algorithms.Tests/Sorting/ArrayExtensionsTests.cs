using Algorithms.Sorting;
using Algorithms.Tests.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Tests.Sorting
{
    [TestClass]
    public class ArrayExtensionsTests
    {
        [TestMethod]
        public void Swap()
        {
            var array = new int[] { 0, 1 };
            array.Swap(0, 1);

            Assert.AreEqual(1, array[0]);
            Assert.AreEqual(0, array[1]);
        }

        [TestMethod]
        public void IsSorted()
        {
            var array = new int[] { 0, 1, 2 };
            Assert.IsTrue(array.IsSorted());

            array = new int[] { 2, 1, 0 };
            Assert.IsTrue(array.IsSorted(true));

            array = new int[] { 2, 0, 1 };
            Assert.IsFalse(array.IsSorted());
            Assert.IsFalse(array.IsSorted(true));
        }

        [TestMethod]
        public void IsSorted_Object()
        {
            var array = new V<int>[] { new V<int>(0), new V<int>(1), new V<int>(2) };
            Assert.IsTrue(array.IsSorted(v => v.Value));

            array = new V<int>[] { new V<int>(2), new V<int>(1), new V<int>(0) };
            Assert.IsTrue(array.IsSorted(v => v.Value, true));

            array = new V<int>[] { new V<int>(2), new V<int>(0), new V<int>(1) };
            Assert.IsFalse(array.IsSorted(v => v.Value));
            Assert.IsFalse(array.IsSorted(v => v.Value, true));
        }
    }
}
