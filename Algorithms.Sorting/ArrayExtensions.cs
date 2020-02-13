using System;
using System.Linq.Expressions;

namespace Algorithms.Sorting
{
    public static class ArrayExtensions
    {
        public static void Swap<T>(this T[] source, int a, int b)
        {
            T tmp = source[a];
            source[a] = source[b];
            source[b] = tmp;
        }

        public static bool IsSorted<T>(this T[] source, bool descending = false) where T : IComparable<T>
        {
            for(int i = 0; i < source.Length - 1; i++)
            {
                if (descending)
                {
                    if (source[i].CompareTo(source[i + 1]) < 0)
                        return false;
                }
                else
                {
                    if (source[i].CompareTo(source[i + 1]) > 0)
                        return false;
                }
            }

            return true;
        }

        public static bool IsSorted<T, TProp>(this T[] source, Expression<Func<T, TProp>> property, bool descending = false) where TProp : IComparable<TProp>
        {
            var prop = property.Compile();

            for (int i = 0; i < source.Length - 1; i++)
            {
                if (descending)
                {
                    if (prop(source[i]).CompareTo(prop(source[i + 1])) < 0)
                        return false;
                }
                else
                {
                    if (prop(source[i]).CompareTo(prop(source[i + 1])) > 0)
                        return false;
                }
            }

            return true;
        }
    }
}
