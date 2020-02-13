using System;
using System.Linq;
using System.Linq.Expressions;

namespace Algorithms.Sorting
{
    public static class ShakerSortingExtensions
    {
        public static T[] ShakerSort<T>(this T[] source, bool desc = false) where T : IComparable<T>
        {
            var array = source.ToArray();
            var start = 0;
            var end = array.Length - 1;

            while(start != end)
            {
                var swapped = false;

                for (int i = start; i < end; i++)
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

                swapped = false;

                for (int i = end; i > start; i--)
                {
                    var toSwap = !desc && array[i].CompareTo(array[i - 1]) < 0 ? true
                               : desc && array[i].CompareTo(array[i - 1]) > 0 ? true
                               : false;

                    if (toSwap)
                    {
                        array.Swap(i, i - 1);
                        swapped = true;
                    }
                }

                start++;

                if (!swapped)
                    break;
            }

            return array;
        }

        public static T[] ShakerSort<T, TProp>(this T[] source, Expression<Func<T, TProp>> property, bool desc = false) where TProp : IComparable<TProp>
        {
            var getValue = property.Compile();
            var array = source.ToArray();
            var start = 0;
            var end = array.Length - 1;

            while (start != end)
            {
                var swapped = false;

                for (int i = start; i < end; i++)
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

                swapped = false;

                for (int i = end; i > start; i--)
                {
                    var toSwap = !desc && getValue(array[i]).CompareTo(getValue(array[i - 1])) < 0 ? true
                               : desc && getValue(array[i]).CompareTo(getValue(array[i - 1])) > 0 ? true
                               : false;

                    if (toSwap)
                    {
                        array.Swap(i, i - 1);
                        swapped = true;
                    }
                }

                start++;

                if (!swapped)
                    break;
            }

            return array;
        }
    }
}
