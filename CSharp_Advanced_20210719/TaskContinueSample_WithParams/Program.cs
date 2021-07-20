using System;
using System.Threading.Tasks;

namespace TaskContinueSample_WithParams
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<string> task = Task.Run(DayTime); //Rückgabetype -> Alternativer Code:  var Task1 = Task.Run(DayTime);
            task.ContinueWith(task => ShowDayTime(task.Result), TaskContinuationOptions.OnlyOnRanToCompletion);
            Console.ReadKey();
        }

        public static string DayTime()
        {
            DateTime date = new DateTime();

            return date.Hour > 17
                ? "evening"
                : date.Hour > 12
                ? "afternoon"
                : "morning";
        }

        public static void ShowDayTime(string result)
        {
            Console.WriteLine(result);
        }
    }
}
