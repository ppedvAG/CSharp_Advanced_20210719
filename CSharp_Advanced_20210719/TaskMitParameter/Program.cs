using System;
using System.Threading.Tasks;

namespace TaskMitParameter
{
    class Program
    {
        static void Main(string[] args)
        {
            Katze katze = new();

            Task<string> task1 = new Task<string>(() => MachEtwas(katze, DateTime.Now));
            task1.Start();
            task1.Wait();
            string result = task1.Result;

            //via Factory
            Task<string> task2 = Task.Factory.StartNew(MachEtwas, katze);
            task2.Wait();
            string result1 = task2.Result;

            //Task.Run
            Task<string> task3 = Task.Run<string>(() => MachEtwas(katze));
            task3.Wait();
            string result2 = task3.Result;
        }

        private static string MachEtwas(object input)
        {
            Katze katze = null;

            if (input is Katze)
                katze = (Katze)input;

            return DateTime.Now.ToShortDateString();
        }

        private static string MachEtwas(object input, DateTime date)
        {
            Katze katze = null;

            if (input is Katze)
                katze = (Katze)input;

            return date.ToShortDateString();
        }
    }

    public class Katze
    {
        public string Name { get; set; } = "Maya";
    }
}
