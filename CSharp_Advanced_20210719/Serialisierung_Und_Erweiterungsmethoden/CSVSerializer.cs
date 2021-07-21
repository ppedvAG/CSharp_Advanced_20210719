using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialisierung_Und_Erweiterungsmethoden
{
    public static class CSVSerializer
    {
        public static void Serialize(this Person p, string path)
        {
            File.WriteAllText(path, $"{p.Vorname};{p.Nachname};{p.Alter};{p.Kontostand};{p.KreditLimit}");
        }

        public static void Deserialize(this Person p, string path)
        {
            string content = File.ReadAllText(path);

            string[] csvParts = content.Split(';');

            p.Vorname = csvParts[0];
            p.Nachname = csvParts[1];
            p.Alter = Convert.ToInt32(csvParts[2]);
            p.Kontostand = Convert.ToInt32(csvParts[3]);
            p.KreditLimit = Convert.ToInt32(csvParts[4]);
        }


    }
}
