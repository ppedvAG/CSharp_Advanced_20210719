using System;
using System.Threading;

namespace HelloThreads
{
    public class Program
    {
        static void Main(string[] args)
        {
            //System.Threading;
            Thread thread = new Thread(MacheEtwasInEinemThread); //Füge Funktionszeige in Thread hinzu
            thread.Start(); //Starte Thread...bzw die angehängte Methode(Invoke)
            thread.Join(); //Warte bis Thread fertig ist
            for (int i = 0; i < 100; i++)
                Console.WriteLine("+");

            Console.WriteLine("Weiter mit KeyPress");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Beispiel 2: ");
            ParameterizedThreadStart parameterizedThread = new ParameterizedThreadStart(MacheEtwasInEinemThreadB);
            Thread thread1 = new Thread(parameterizedThread);
            thread1.Start(150);
            thread1.Join();

            for (int i = 0; i < 100; i++)
                Console.WriteLine("+");

            Console.WriteLine("Weiter mit KeyPress");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Beispiel 3: ");

            Thread thread2 = new Thread(MachEtwas);
            thread2.Start();

            Thread.Sleep(3000); //3 Sekunden warten wir, danach brechen wir den Thread ab
            thread2.Interrupt();
            Console.WriteLine("Weiter mit KeyPress");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Beispiel 4: ");
        }


        //Beispiel 1
        private static void MacheEtwasInEinemThread()
        {
            for (int i = 0; i < 100; i++)
                Console.WriteLine("#");
        }


        // Beispiel 2
        private static void MacheEtwasInEinemThreadB(object obj)
        {
            for (int i = 0; i < (int)obj; i++)
                Console.WriteLine("#");
        }

        //Beispiel 3 - Beenden eines Threads
        
        private static void MachEtwas()
        {
            try
            {
                for (int i = 0; i < 50; i++)
                {
                    Thread.Sleep(200);
                    Console.WriteLine("ZzzZzZZzz");
                }
            }
            catch (AggregateException ex)
            {
                foreach (Exception currentException in ex.InnerExceptions)
                {
                    Console.Write(currentException.ToString());
                }
            }
        }
    }
}
