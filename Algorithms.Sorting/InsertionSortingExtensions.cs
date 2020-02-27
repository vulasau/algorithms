using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Sorting
{
    public static class InsertionSortingExtensions
    {
        public static int[] InsertionSorting(this int[] source)
        {
            var array = new int[source.Length];

            array[0] = source[0];

            for(var i = 0; i< source.Length; i++)
            {
                if (i == 0)
                {
                    array[i] = source[i];
                    continue;
                }

                if

                for (int j = 0; j < i; j++)
                {
                    if(source[i])
                }


            }

            return array;
        }
    }
}
