using Algorithms.Sorting;
using System;
using System.Diagnostics;
using System.Linq;

namespace Algorithms.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = Generator.Generate(10000).ToArray();
            var elapsed = new TimeSpan();

            var bubble = Measure(() => array.BubbleSort(), out elapsed);
            Console.WriteLine("Bubble Sort: elapsed {0}ms", elapsed.TotalMilliseconds);

            var shaker = Measure(() => array.ShakerSort(), out elapsed);
            Console.WriteLine("Shaker Sort: elapsed {0}ms", elapsed.TotalMilliseconds);

            var comb = Measure(() => array.CombSort(), out elapsed);
            Console.WriteLine("Comb Sort: elapsed {0}ms", elapsed.TotalMilliseconds);
        }

        static T Measure<T>(Func<T> func, out TimeSpan elapsed)
        {
            elapsed = new TimeSpan();
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            var result = func.Invoke();

            stopwatch.Stop();

            elapsed = stopwatch.Elapsed;
            return result;
        }
    }
}
