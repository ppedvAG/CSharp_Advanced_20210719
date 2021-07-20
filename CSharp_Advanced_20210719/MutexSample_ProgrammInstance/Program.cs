using System;
using System.Threading;

namespace MutexSample_ProgrammInstance
{
    class Program
    {
        static Mutex _mutex;
        
        
        static void Main(string[] args)
        {
            if (!Program.IsSingleInstance())
            {
                Console.WriteLine("More than one instance");
            }
            else
                Console.WriteLine("one Instance");

            Console.ReadLine();
        }

        static bool IsSingleInstance()
        {
            try
            {
               
                Mutex.OpenExisting("ABC");
                //Hier kommen wir nur hin, wenn wir 2 Programme offen haben 
            }
            catch
            {
                //Wenn wir uns hier befinden, haben wir wahscheinlich die Erste Application gestartet
                Program._mutex = new Mutex(true, "ABC");
                return true;
            }

            return false;
        }
    }
}
