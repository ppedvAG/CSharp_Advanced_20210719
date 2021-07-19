using System;

namespace SharpVersion73
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonStruct personStruct = new PersonStruct();
            personStruct.Vorname = "Petra";
            personStruct.Nachname = "Musterfrau";
            personStruct.Groeße = 175;
            personStruct.Geburtstag = new DateTime(2001, 6, 13);

            PersonStruct personStruct1 = personStruct; //Struct zuweisungen sind langsamer wie bei Referenztypen.
                                                       //Jede einzelne Variale wird extra zugewiesen  

            PersonClass class1 = new PersonClass(); //Hier wird die referenz übergeben (1 call) 
            PersonClass class2 = class1; 
        }
    }

    public struct PersonStruct
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public DateTime Geburtstag { get; set; }
        public int Groeße { get; set; }
    }

    public class PersonClass
    { 
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public DateTime Geburtstag { get; set; }
        public int Groeße { get; set; }
    }
}
