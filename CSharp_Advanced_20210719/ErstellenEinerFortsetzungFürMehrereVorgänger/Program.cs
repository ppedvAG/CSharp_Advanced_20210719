using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ErstellenEinerFortsetzungFürMehrereVorgänger
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var tasks = new List<Task<int>>();
            for (int ctr = 1; ctr <= 10; ctr++)
            {
                int baseValue = ctr;
                tasks.Add(Task.Factory.StartNew(b => (int)b * (int)b, baseValue));
            }

            // Task.WaitAll() -> WaitAll gibt keine Rückgabewerte zurück (im Gegensatz zu WhenAll)
            var results = await Task.WhenAll(tasks);

            int sum = 0;
            for (int ctr = 0; ctr <= results.Length - 1; ctr++)
            {
                var result = results[ctr];
                Console.Write($"{result} {((ctr == results.Length - 1) ? "=" : "+")} ");
                sum += result;
            }

            Console.WriteLine(sum);
        }
    }
}
