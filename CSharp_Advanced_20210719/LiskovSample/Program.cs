using System;

namespace LiskovSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Employee
    {
        public virtual decimal SalarySummary()
        {
            return 1000000;
        }
    }

    public class EmployeeWithBoni : Employee
    {
        //
        public override decimal SalarySummary() 
        {
            return 1000000 / 365; // Ist keine Jahresübersicht -> Hier wird fälschlicherweise der Tagessatz ausgegeben. 
        }
    }

    
}
