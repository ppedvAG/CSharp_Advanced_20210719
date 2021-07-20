using System;

namespace DelegatesActionsFuncsSamples
{
    delegate int NumbChange(int n); 
    class Program
    {
        static void Main(string[] args)
        {
            NumbChange nc1 = new NumbChange(AddNumber); //NumbChange merkt sich den Funktionzeiger von der Methode AddNumber
            nc1 += SubNumber; //Ab jetzt sind zwei hinterlegt
            nc1 -= AddNumber;
            int result = nc1(111);

            Action a1 = new Action(A);
            a1 += B;
            a1();

            Action<int> a2 = new Action<int>(C);
            a2(123);

            Action<int, DateTime> a3 = new Action<int, DateTime>(C);
            a3(123, DateTime.Now);

            //Func...letzte Typangabe ist der Return-Typ
            Func<int, int, int> addNumberFunc = new Func<int, int, int>(AddNumber);
            result = addNumberFunc(12, 15);
        }
        #region Action Sample - Methoden
        public static void A()
        {
            Console.WriteLine("A");
        }

        public static void B()
        {
            Console.WriteLine("B");
        }

        static void C(int zahl)
        {
            Console.WriteLine("C" + zahl);
        }

        static void C(int zahl, DateTime time)
        {
            Console.WriteLine("C" + zahl);
            Console.WriteLine(time.ToShortDateString());
        }
        #endregion

        public static int AddNumber(int number)
        {
            return number += 5;
        }

        public static int AddNumber(int z1, int z2)
        {
            return z1 + z2;
        }

        public static int SubNumber(int number)
        {
            return number -= 7;
        }
    }
}
