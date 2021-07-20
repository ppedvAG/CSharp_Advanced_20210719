using System;
using System.Threading;
using System.Threading.Tasks;

namespace TasksMitException
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t1 = null, t2 = null, t3 = null, t4 = null;

            try
            {
                t1 = new Task(MachEinenFehler1);
                t1.Start();

                t2 = Task.Factory.StartNew(MachEinenFehler2);

                t3 = Task.Run(MachEinenFehler3);
                t4 = Task.Run(MachKeinenFehler);

                Task.WaitAll(t1, t2, t3, t4);//Hier zeigen sich die Exception in den jeweiligen Tasks


            }
            catch(AggregateException ex) //Exception für Task
            {
                foreach (Exception innerException in ex.InnerExceptions)
                    Console.WriteLine(innerException.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (t4.IsCompleted)
                Console.WriteLine("Task 4 ist fertig!");

            if (t3.IsCompleted)
                Console.WriteLine("Task 3 ist fertig!");

            if (t3.IsFaulted)
                Console.WriteLine("Task 3 hat einen Fehler");

            if (t3.IsCanceled)
                Console.WriteLine("Task 3 wird abgebrochen");

            Console.ReadKey();
        }

        private static void MachEinenFehler1()
        {
            Thread.Sleep(3000);
            throw new DivideByZeroException();
        }

        private static void MachEinenFehler2()
        {
            Thread.Sleep(6000);
            throw new StackOverflowException();
        }

        private static void MachEinenFehler3()
        {
            Thread.Sleep(9000);
            throw new OutOfMemoryException();
        }

        private static void MachKeinenFehler()
        {
            Console.WriteLine("Schönen Tag");
        }
    }
}
