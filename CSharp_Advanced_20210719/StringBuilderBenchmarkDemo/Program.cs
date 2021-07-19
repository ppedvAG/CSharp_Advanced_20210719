using System;
using System.Diagnostics;
using System.Text;

namespace StringBuilderBenchmarkDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //string hat im arbeitsspeicher eine feste größe, die sich nach der definition nicht mehr erweitern lässt
            //wie ein array 
            string aufbauenderString = string.Empty;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < 10000; i++)
            {
                aufbauenderString += i.ToString();


                //1.) Erstelle neuen String-Speicherplatz mit der neuen größe
                //2.) Kopiere die alten Daten rüber in den Speicherplatz + Variable i 
            }
            stopwatch.Stop();
            long testErgebnis1 = stopwatch.ElapsedMilliseconds;


            Console.WriteLine("Taste drücken......");
            Console.ReadKey();

            StringBuilder sb = new StringBuilder();

            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();

            for (int i = 0; i < 10000; i++)
            {
                sb.Append(i);
            }
            string output = sb.ToString();
            stopwatch1.Stop();

            long testErgebnis2 = stopwatch1.ElapsedMilliseconds;

            Console.WriteLine("Benchmark Endergebnis");
            Console.WriteLine($"Ergebnis aus einfachen addieren - Zeit: {testErgebnis1}");
            Console.WriteLine($"Testergebnis - StringBuilder - Zeit: {testErgebnis2}");
            Console.ReadLine();
        }
    }
}
