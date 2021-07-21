using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq; //Hier werden Erweiterungs-Methoden für Listen angeboten

namespace LinqAndLambdaSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<Person> persons = new List<Person>()
            {
                new Person {Id=1, Age=37, Vorname="Kevin", Nachname="Winter"},
                new Person {Id=2, Age=29, Vorname="Hannes", Nachname="Preishuber"},
                new Person {Id=3, Age=19, Vorname="Scott", Nachname="Hunter"},

                new Person {Id=4, Age=21, Vorname="Scott", Nachname="Hanselmann"},
                new Person {Id=5, Age=45, Vorname="Daniel", Nachname="Roth"},
                new Person {Id=6, Age=50, Vorname="Bill", Nachname="Gates"},

                new Person {Id=7, Age=70, Vorname="Newton", Nachname="King"},
                new Person {Id=8, Age=40, Vorname="Andre", Nachname="R"},
                new Person {Id=9, Age=60, Vorname="Petra", Nachname="Musterfrau"},
            };

            //Linq Statement
            IList<Person> lingStatementResult = (from p in persons
                                                 where p.Age >= 40 && p.Age < 50
                                                 orderby p.Nachname
                                                 select p).ToList();

            //Linq-Functionen with Lambda-Expressions
            IList<Person> people = persons.Where(p => p.Age >= 40 && p.Age < 50)
                                          .OrderBy(o => o.Nachname)
                                          .ToList();

            double alterdurschnitt = persons.Average(a => a.Age);
            
            double alterdurschnitt1 = persons.Where(p=>p.Age > 30)
                                             .Average(a => a.Age);

            Person selectedPersons = persons.Single(s => s.Id == 4);
            Person FirstPerson = persons.FirstOrDefault();
            Person LastPerson = persons.LastOrDefault();

            double gesamtesAlterAllerPersonen = persons.Sum(a => a.Age);


            //Pagging -> Skip / Take
            //https://code-maze.com/paging-aspnet-core-webapi/
            int pagingNumber = 1; //Aktuell Pagging-Seite 
            int pagingSize = 3; //Wieiviele Datensätze werden pro Seite angezeigt 

            IList<Person> ergebnisSeite1 = persons.Skip((pagingNumber - 1) * pagingSize)
                                                  .Take(pagingSize).ToList();

            pagingNumber = 2;
            IList<Person> ergebnisSeite2 = persons.Skip((pagingNumber - 1) * pagingSize)
                                                  .Take(pagingSize).ToList();

            pagingNumber = 3;
            IList<Person> ergebnisSeite3 = persons.Skip((pagingNumber - 1) * pagingSize)
                                                  .Take(pagingSize).ToList();


            if (ergebnisSeite1.Count == 0)
            {
                //Liste ist leer
            }

            if (!ergebnisSeite1.Any())
            {
                //Liste ist leer
            }
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public int Age { get; set; }

        public string Vorname { get; set; }
        public string Nachname { get; set; }
    }
}
