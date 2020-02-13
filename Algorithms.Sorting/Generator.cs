using System;
using System.Collections.Generic;

namespace Algorithms.Sorting
{
    public static class Generator
    {
        private static Random _random = new Random(DateTime.UtcNow.Millisecond);

        public static IEnumerable<int> Generate(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                yield return _random.Next(0, amount);
            }
        }
    }
}
