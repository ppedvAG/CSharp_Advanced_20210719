using System;
using System.Threading;

namespace ThreadWithReturnValueAndParameters
{
    class Program
    {
        static void Main(string[] args)
        {
            string retStr = string.Empty;

            Thread thread = new Thread(() =>
            {
                retStr = StringUpper("Hello World");
            });

            thread.Start();
            thread.Join();
            Console.WriteLine(retStr);
            Console.ReadLine();
        }

        public static string StringUpper(string param1)
        {
            return param1.ToUpper();
        }
    }
}
