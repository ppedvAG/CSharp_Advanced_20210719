using System;

namespace GenericsContstraintsSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }


    public class DataStore<T> where T: class //Es dürfen nur Referenztypen als T verwendet werden
    {
        public T Data { get; set; }
    }

    public class DataStore1<T, TT>
        where T:struct //Wertetypen
        where TT:class
    {
        public T Data { get; set; }

        public TT Data1 { get; set; }
    }
}
