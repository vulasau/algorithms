using Algorithms.Sorting;
using Algorithms.Tests.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Algorithms.Tests.Sorting
{
    [TestClass]
    public class BubbleSortingExtensionsTests
    {
        [TestMethod]
        public void BubbleSort()
        {
            var numbers = Generator.Generate(1000).ToArray();
            var objects = numbers.Select(number => new V<int>(number)).ToArray();

            var sorted = numbers.BubbleSort();
            Assert.IsTrue(sorted.IsSorted());
            Assert.IsFalse(sorted.IsSorted(true));

            sorted = numbers.BubbleSort(true);
            Assert.IsFalse(sorted.IsSorted());
            Assert.IsTrue(sorted.IsSorted(true));


            var sortedObjects = objects.BubbleSort(v => v.Value);
            Assert.IsTrue(sortedObjects.IsSorted(v => v.Value));
            Assert.IsFalse(sortedObjects.IsSorted(v => v.Value, true));

            sortedObjects = objects.BubbleSort(v => v.Value, true);
            Assert.IsFalse(sortedObjects.IsSorted(v => v.Value));
            Assert.IsTrue(sortedObjects.IsSorted(v => v.Value, true));
        }
    }
}
