using System;

namespace SharpVersion72
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            long result1 = Summe(12);
            long result2 = Summe(12, 13);
            long result3 = Summe(12, 13, 14);
            int z2 = 10;
            long result4 = Summe(12, zahl2: z2, 14);

            long result5 = Summe(zahl1:12, zahl3:12);

            long result6 = SummeA(1, 2, 3, 4, 5, 6, 7, 8, 9);
        }

        public static long Summe(int zahl1, int zahl2 = default, int zahl3 = default)
        {
            return zahl1 + zahl2 + zahl3;
        }

        public static long SummeA(params int[] values)
        {
            int result = 0;

            foreach (int value in values)
                result += value;

            return result;
        }

    }
}
