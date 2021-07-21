using System;
using System.Dynamic;

namespace DynamicTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic myObj = new ExpandoObject();
            myObj.Vorname = "Max";
            myObj.Nachname = "Mustermann";
            myObj.Geb = new DateTime(2001, 3, 3);

            //Nachteile -> Intellicense funktioniert nicht
            //          -> Unübersichtlich 
            //          -> Typisierte Objekte sind schneller

            dynamic d1 = 7;
            dynamic d2 = "a string";
            dynamic d3 = System.DateTime.Today;
            dynamic d4 = System.Diagnostics.Process.GetProcesses();
        }
    }
}
