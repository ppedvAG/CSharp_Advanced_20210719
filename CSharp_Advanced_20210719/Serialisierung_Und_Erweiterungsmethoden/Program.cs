using Newtonsoft.Json;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialisierung_Und_Erweiterungsmethoden
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Person person = new Person
            {
                Vorname = "Max",
                Nachname = "Mustermann",
                Alter = 63,
                Kontostand = 100_000,
                KreditLimit = 500_000
            };

            Stream stream = null;


            #region Binary Serialisierung
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            stream = File.OpenWrite("Person.bin");
            binaryFormatter.Serialize(stream, person);
            stream.Close();

            //Binärdatei einlesen
            stream = File.OpenRead("Person.bin");
            Person geladenePerson = (Person)binaryFormatter.Deserialize(stream);
            stream.Close();
            #endregion

            #region XML Schreiben
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
            stream = File.OpenWrite("Person.xml");
            xmlSerializer.Serialize(stream, person);
            stream.Close();
            #endregion

            #region XML lesen
            stream = File.OpenRead("Person.xml");
            Person gelandenePerson1 = (Person)xmlSerializer.Deserialize(stream);
            stream.Close();
            #endregion


            #region JSON Schreiben
            string jsonString = JsonConvert.SerializeObject(person);
            await File.WriteAllTextAsync("PErson.json", jsonString);

            #endregion

            #region JSON Lesen
            Person jsonPerson = JsonConvert.DeserializeObject<Person>(jsonString);

            #endregion



            #region eigener CSV
            person.Serialize("Person.csv");

            Person geladenePerson2 = new Person();
            geladenePerson2.Deserialize("Person.csv");

            #endregion




        }
    }

    [Serializable]
    public class Person
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public int Alter { get; set; }
        
        [field:NonSerialized ]//Wird bei Properties verwendet
        public decimal Kontostand { get; set; }


        [NonSerialized()] //Wird bei Variablen verwendet
        public decimal KreditLimit; 
    }
}
