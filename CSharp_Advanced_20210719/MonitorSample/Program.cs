using System;
using System.Threading;

namespace MonitorSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static void KritischerCodeAbschnitt()
        {
            int x = 1;


            Monitor.Enter(x); //Nur ein Thread kann hier durch. Die Anderen Threads müssen warten.

            try
            {
                //Meine Implementierung
            }
            finally
            {
                Monitor.Exit(x); //Freigabe
            }

        }
    }
}
