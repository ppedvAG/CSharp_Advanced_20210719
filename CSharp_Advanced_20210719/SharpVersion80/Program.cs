using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;

namespace SharpVersion80
{
    class Program
    {
        static void Main(string[] args)
        {
            #region try /catch / finally + using
            StreamWriter sw = null;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection("myConnectionString");
                sw = new StreamWriter("Datei.txt");
                sw.WriteLine("abc....");
            }
            catch (IOException e)
            {

            }
            finally
            {
                if (sw != null)
                {
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }

                conn.Close();
            }

            using (StreamWriter sw1 = new StreamWriter("datei1.txt"))
            {
                sw1.WriteLine("abc....");

                try
                {
                }
                catch (IOException e)
                {
                }
            }//Dispose -> Objekt wird abgeräumt 

            using (MyTest test = new MyTest())
            {

            }//Dispose -> Objekt wird abgeräumt 


            using MyTest test1 = new MyTest();
            #endregion
            #region Array-Index -> Submengen
            int index = 4;

            var woerter = new string[]
            {
                "Franz",
                "fährt",
                "mit",
                "einem",
                "Taxt"
            };

            string[] result = woerter[index..];
            #endregion

            string myPath = "C:\\Temp\\Datei.txt";
            string myPath2 = @"C:\Temp\Datei1.txt";

        }


        public static async IAsyncEnumerable<int>  GeneriereZahl()
        {
            for(int i = 0; i < 20; i++)
            {
                await Task.Delay(100);
                yield return i;
            }
        }

        public static async void GebeZahlAus()
        {
            await foreach(var zahl in GeneriereZahl())
            {
                Console.WriteLine(zahl);
            }
        }
    }
    #region SampleClass for using-Statement
    public class MyTest : IDisposable
    {
        public int NumberValue { get; set; }

        public void Dispose()
        {
            NumberValue = default;
        }
    }
    #endregion
}
