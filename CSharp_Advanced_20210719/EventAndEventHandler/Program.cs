using System;

namespace EventAndEventHandler
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessBusinessLogic processBusinessLogic = new ProcessBusinessLogic();
            processBusinessLogic.ProcessCompleted += ProcessBusinessLogic_ProcessCompleted;
            processBusinessLogic.StartProcess();


            ProcessBusinessLogic2 processBusinessLogic2 = new ProcessBusinessLogic2();
            processBusinessLogic2.ProcessCompleted += ProcessBusinessLogic2_ProcessCompleted;
            processBusinessLogic2.ProcessCompletedNew += ProcessBusinessLogic2_ProcessCompletedNew;
            processBusinessLogic2.StartProcess();
        }

        private static void ProcessBusinessLogic2_ProcessCompletedNew(object sender, EventArgs e)
        {
            MyEventArg myEventArg = (MyEventArg)e;
            Console.WriteLine($"Fertig am {myEventArg.Uhrzeit.ToString()}");
        }

        private static void ProcessBusinessLogic2_ProcessCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Liebe Grüße von ProcessCompleted()");
        }

        private static void ProcessBusinessLogic_ProcessCompleted()
        {
            
        }
    }
}
