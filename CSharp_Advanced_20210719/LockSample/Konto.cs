using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockSample
{
    public static class Konto
    {
        public static decimal Kontostand { get; set; } = 0;
        public static int TransactionsId { get; set; } = 0;
        public static object lockObject = new object();
        
        public static void Einzahlen(decimal betrag)
        {
            try
            {
                lock (lockObject) //Hier darf nur ein Thread hinein. Ein zweiter Thread müsste dann bei Lock warten
                {
                    TransactionsId++;
                    Console.WriteLine($"Kontostand vor dem Einzahlen: {Kontostand}");
                    Kontostand += betrag; //Ressourcenzugriff. (Wenn mehrere Thread gleichzeitig auf die Variable Kontostand zugreifen...bzw schreiben möchten, gibt es ein Dead-Lock
                    Console.WriteLine($"Id{TransactionsId}:  Kontostand nach dem Einzahlen: {Kontostand}");
                }
            }
            catch (Exception ex)
            {

            }
        }

        public static void Abheben(decimal betrag)
        {
            try
            {
                lock (lockObject) //Hier darf nur ein Thread hinein. Ein zweiter Thread müsste dann bei Lock warten
                {
                    TransactionsId++;
                    Console.WriteLine($"Kontostand vor dem Auszahlen: {Kontostand}");
                    Kontostand -= betrag; //Ressourcenzugriff. (Wenn mehrere Thread gleichzeitig auf die Variable Kontostand zugreifen...bzw schreiben möchten, gibt es ein Dead-Lock
                    Console.WriteLine($"Id{TransactionsId}:  Kontostand nach dem Auszahlen: {Kontostand}");
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
