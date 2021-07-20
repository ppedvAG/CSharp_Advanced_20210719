using System;

using System.Threading.Tasks;

namespace EasyTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            Task easyTask = new Task(MacheEtwasInEinemThread); //GFunktionszeiger wird übergeben
            easyTask.Start();
            easyTask.Wait();

            for (int i = 0; i < 100; i++)
                Console.WriteLine("+");

            Console.ReadKey();
        }


        private static void MacheEtwasInEinemThread()
        {
            for (int i = 0; i < 100; i++)
                Console.WriteLine("#");
        }
    }
}
