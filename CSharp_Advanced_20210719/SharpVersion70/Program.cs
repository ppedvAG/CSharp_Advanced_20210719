using System;

namespace SharpVersion70
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Out-Variable
            int number = 0;
            ReChangeNumber( out number);

            string zahlInString = "123";
            
            if (int.TryParse(zahlInString, out number))
            {
                Console.WriteLine($"Number : {number}");
            }
            #endregion

            #region Tupel
            Person p = new Person("Max", "Maxi", "Mustermann");
            var name = p.VollenNamenAusgabe();
            //name.Item1 name.Item2 name.Item3

            (string a, string b, string c) name1 = p.VollenNamenAusgabe1();
            var name2 = p.VollenNamenAusgabe1();

            //name1.a;
            //name1.b;
            //name1.c

            //name2.a
            //name2.b
            //name2.c

            #endregion

            #region Tupel - Deconstruct
            Kunde k = new Kunde();
            
            var (id, customName) = k;
            var (id1, customName1, stammkunde) = k;

            Kunde k1 = k.GebMichSelberZurueck();
            #endregion

            #region Rückgabe via Referenz

            int[] zahlen = { 5, 7, 432, 567, -98, 3, 2 }; //aus 3 wird 1.000.000
            ref int pos = ref Zahlensuche(3, zahlen);
            pos = 1000_000;
            #endregion
        }


        static void ReChangeNumber(out int number  ) //number MUSS eine Zuweisung erfahren
        {
            number = 123;
        }

        public static ref int Zahlensuche(int gesuchteZahl, int[] zahlenArray)
        {
            for (int i = 0; i < zahlenArray.Length; i++)
            {
                if (zahlenArray[i] == gesuchteZahl)
                    return ref zahlenArray[i]; //Wir geben hier von dem gesuchten Array-Eintrag die Speicheradresse zurück
            }

            throw new IndexOutOfRangeException();
        }
    }


    public class Person
    {
        public string Vorname { get; set; }

        public string ZweiterVorname { get; set; }

        public string Nachname { get; set; }

        public Person(string Vorname, string ZweiterVorname, string Nachname)
        {
            this.Vorname = Vorname;
            this.ZweiterVorname = ZweiterVorname;
            this.Nachname = Nachname;
        }


        //Löst in Item1, Item2 und Item3 auf 
        public (string, string, string) VollenNamenAusgabe()
        {
            return (Vorname, !string.IsNullOrEmpty(ZweiterVorname) ? ZweiterVorname : string.Empty, Nachname);
        }

        //Löst in Item1, Item2 und Item3 auf 
        public (string Vorname, string ZweiterVorname, string Nachname) VollenNamenAusgabe1()
        {
            return (Vorname, !string.IsNullOrEmpty(ZweiterVorname) ? ZweiterVorname : string.Empty, Nachname);
        }

    }

    public class Kunde
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Stammkunde { get; set; }


        public Kunde GebMichSelberZurueck()
        {
            return this;
        }
        public void Deconstruct(out int Id, out string Name, out bool Stammkunde)
        {
            Id = this.Id;
            Name = this.Name;
            Stammkunde = this.Stammkunde;
        }

        public void Deconstruct(out int Id, out string Name)
        {
            Id = this.Id;
            Name = this.Name;
        }
    }
}
