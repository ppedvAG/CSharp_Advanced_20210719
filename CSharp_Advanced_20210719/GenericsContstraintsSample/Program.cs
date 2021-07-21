using System;
using System.Collections;

namespace GenericsContstraintsSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //DataStore<string> store1 = new DataStore<string>();
            //DataStore<MyClass> store2 = new DataStore<MyClass>();
            //DataStore<IMyInterface> store3 = new DataStore<IMyInterface>();
            //DataStore<MyStruct> store4 = new DataStore<MyStruct>(); 
            //DataStore<int> store5 = new DataStore<int>(); 
            //DataStore<ArrayList> store6 = new DataStore<ArrayList>();
            //DataStore<Person> store7 = new DataStore<Person>();




            //////DataStore2<T> where T : struct 
            //DataStore2<string> store7 = new DataStore2<string>();
            //DataStore2<MyClass> store8 = new DataStore2<MyClass>();
            //DataStore2<IMyInterface> store9 = new DataStore2<IMyInterface>();
            //DataStore2<MyStruct> store10 = new DataStore2<MyStruct>();
            //DataStore2<int> store11 = new DataStore2<int>();
            //DataStore2<MyRecord> store7 = new DataStore2<MyRecord>();
        }
    }


    public class DataStore<T> where T: class //Es dürfen nur Referenztypen als T verwendet werden
    {
        public T Data { get; set; }
    }

    public class DataStore2<T> where T : struct //Es dürfen nur Referenztypen als T verwendet werden
    {
        public T Data { get; set; }
    }

    public class DataStore1<T, TT>
        where T:struct 
        where TT:class //Referenztypen (Interfaces gehen hier)
    {
        public T Data { get; set; }

        public TT Data1 { get; set; }
    }

    public class Animal
    {
        public string Name { get; set; } = "Maya";
    }

    public class Cat : Animal
    {
        public string Katzenrasse { get; set; } = "Keltisch Shorthair";

    }

    public record Person(string Name, DateTime Birthday);

    public class MyClass
    {

    }

    public struct MyStruct
    {

    }

    public interface IMyInterface
    {

    }
}
