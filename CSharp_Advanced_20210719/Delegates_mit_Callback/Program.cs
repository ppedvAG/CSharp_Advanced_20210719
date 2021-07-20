using System;

namespace Delegates_mit_Callback
{
    class Program
    {
        public delegate void Del(string message);

        static void Main(string[] args)
        {
            Del handler = new Del(FinishResultMethod);

            MethodWithCallback(123, 123, handler); //Handler wird übergeben

            Console.ReadKey();
        }

        public static void MethodWithCallback(int param1, int param2, Del callback)
        {
            //Unsere Berechnung

            //Callback wird ganz zum Schluss aufgerufen, wenn die Methode mit ihrem "tun" fertig ist :-) 
            callback("The number is " + (param1 + param2).ToString());
        }

        
        public static void FinishResultMethod (string message)
        {
            Console.WriteLine(message);
        }
    }
}
