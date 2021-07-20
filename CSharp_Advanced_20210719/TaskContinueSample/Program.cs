using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskContinueSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t1 = new Task(() =>
            {
                Console.WriteLine("Task 1 ist gestartet");
                Thread.Sleep(800);
            });

            t1.Start();
            //Allgemeiner Folgetask
            t1.ContinueWith(t => { Console.WriteLine("Allgemeiner Folgetask"); });
            //Dieser Folgetask wird ausgeführt, wenn der erste Task erfolgreich durchgelaufen ist
            t1.ContinueWith(t => { Console.WriteLine("Wenn Erster Task erfolgreich durchgelaufen ist"); }, TaskContinuationOptions.OnlyOnRanToCompletion);

            t1.ContinueWith(t => { Console.WriteLine("T1 hat ein Fehler"); }, TaskContinuationOptions.OnlyOnFaulted);
            Console.ReadLine();
        }
    }
}
