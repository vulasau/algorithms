using System;
using System.Linq;
using System.Linq.Expressions;

namespace Algorithms.Sorting
{
    public static class CombSortingExtensions
    {
        public static T[] CombSort<T>(this T[] source, bool desc = false) where T : IComparable<T>
        {
            var array = source.ToArray();

            var factor = 1.247;
            var distance = (int)(array.Length / factor);

            while(distance >= 1)
            {
                for (int i = 0; i + distance < array.Length; i++)
                {
                    var toSwap = !desc && array[i].CompareTo(array[i + distance]) > 0 ? true
                               : desc && array[i].CompareTo(array[i + distance]) < 0 ? true
                               : false;

                    if (toSwap)
                    {
                        array.Swap(i, i + distance);
                    }
                }

                if (distance == 1)
                    return array.BubbleSort(desc);

                distance = (int)(distance / factor);
            }

            return array;
        }

        public static T[] CombSort<T, TProp>(this T[] source, Expression<Func<T,TProp>> property, bool desc = false) where TProp : IComparable<TProp>
        {
            var getValue = property.Compile();
            var array = source.ToArray();

            var factor = 1.247;
            var distance = (int)(array.Length / factor);

            while (distance >= 1)
            {
                for (int i = 0; i + distance < array.Length; i++)
                {
                    var toSwap = !desc && getValue(array[i]).CompareTo(getValue(array[i + distance])) > 0 ? true
                               : desc && getValue(array[i]).CompareTo(getValue(array[i + distance])) < 0 ? true
                               : false;

                    if (toSwap)
                    {
                        array.Swap(i, i + distance);
                    }
                }

                if (distance == 1)
                    return array.BubbleSort(property, desc);

                distance = (int)(distance / factor);
            }

            return array;
        }
    }
}
