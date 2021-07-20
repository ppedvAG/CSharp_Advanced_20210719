using System;
using System.Threading;

namespace ThreadWithCallback
{



    class Program
    {
        static void Main(string[] args)
        {
            ThreadWithState tws = new ThreadWithState(
               "this report displas the number",
               42,
               new ExampleCallback(ResultCallback));

            Thread t = new Thread(new ThreadStart(tws.ThreadProc));
            t.Start();
            Console.WriteLine("Main thread does some work, then waits.");
            t.Join();
            Console.WriteLine(
                "Independent task has completed; main thread ends.");

            Console.ReadKey();
        }

        //Ergebnisanzeige nach Thread-Durchlauf
        public static void ResultCallback(MyReturnObject myReturnObject)
        {
            Console.WriteLine($"Rückgabewert -> {myReturnObject.Zahl} {myReturnObject.Text}");
        }
    }

    public class MyReturnObject
    {
        public MyReturnObject()
        {
        }
        public string Text { get; set; }
        public int Zahl { get; set; }
    }


    public delegate void ExampleCallback(MyReturnObject myReturnObject);
    
    public class ThreadWithState
    {
        // State information used in the task.
        private string boilerplate;
        private int numberValue;

        // Delegate used to execute the callback method when the
        // task is complete.
        private ExampleCallback callback;

        // The constructor obtains the state information and the
        // callback delegate.
        public ThreadWithState(string text, int number,
            ExampleCallback callbackDelegate)
        {
            boilerplate = text;
            numberValue = number;
            callback = callbackDelegate;
        }

        // The thread procedure performs the task, such as
        // formatting and printing a document, and then invokes
        // the callback delegate with the number of lines printed.
        public void ThreadProc()
        {
            Console.WriteLine(boilerplate, numberValue);

            MyReturnObject myReturnObject = new();
            myReturnObject.Text = boilerplate;
            myReturnObject.Zahl = numberValue;


            //Callback wird immer am Ende einer Methode ausgelöst um zu signalisieren, dass er fertig ist! 
            if (callback != null)

                callback(myReturnObject);
        }
    }
}
