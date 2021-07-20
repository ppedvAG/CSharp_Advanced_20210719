using System;
using System.Threading;
using System.Threading.Tasks;


namespace TaskBeenden
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            Task task = Task.Factory.StartNew(MeineMethodeMitAbbrechen, cts);

            Thread.Sleep(5000);

            cts.Cancel();
        }

        private static void MeineMethodeMitAbbrechen(object param)
        {
            CancellationTokenSource source = (CancellationTokenSource)param;

            while(true)
            {
                Console.WriteLine("Zzzz...ZZZ..zzZZZzzz");
                Thread.Sleep(50);

                if (source.IsCancellationRequested)
                    break;
            }
        }
    }
}
