using System;
using System.Linq;
using System.Linq.Expressions;

namespace Algorithms.Sorting
{
    public static class BubbleSortingExtensions
    {
        public static T[] BubbleSort<T>(this T[] source, bool desc = false) where T : IComparable<T>
        {
            var array = source.ToArray();
            var end = array.Length - 1;

            while(end > 0)
            {
                var swapped = false;

                for (int i = 0; i < end; i++)
                {
                    var toSwap = !desc && array[i].CompareTo(array[i + 1]) > 0 ? true
                               : desc && array[i].CompareTo(array[i + 1]) < 0 ? true
                               : false;

                    if (toSwap)
                    {
                        array.Swap(i, i + 1);
                        swapped = true;
                    }
                }

                end--;

                if (!swapped)
                    break;
            }

            return array;
        }

        public static T[] BubbleSort<T, TProp>(this T[] source, Expression<Func<T, TProp>> property, bool desc = false) where TProp : IComparable<TProp>
        {
            var getValue = property.Compile();
            var array = source.ToArray();
            var end = array.Length - 1;

            while (end > 0)
            {
                var swapped = false;

                for (int i = 0; i < end; i++)
                {
                    var toSwap = !desc && getValue(array[i]).CompareTo(getValue(array[i + 1])) > 0 ? true
                           : desc && getValue(array[i]).CompareTo(getValue(array[i + 1])) < 0 ? true
                           : false;

                    if (toSwap)
                    {
                        array.Swap(i, i + 1);
                        swapped = true;
                    }
                }

                end--;

                if (!swapped)
                    break;
            }

            return array;
        }
    }
}
