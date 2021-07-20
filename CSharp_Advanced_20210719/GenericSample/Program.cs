using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GenericSample
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<string> strList = new List<string>();
            strList.Add("eins");
            strList.Add("zwei");


            Hashtable hashtable = new Hashtable();
            hashtable.Add(1, new List<string>());
            hashtable.Add(2, 123);
            hashtable.Add(new List<string>(), DateTime.Now);

            foreach (object obj in hashtable)
            {
                if (obj is List<string>)
                {
                    //List of string. 
                }
            }

            #region Dictionary


            IDictionary<int, string> dictionary = new Dictionary<int, string>();

            dictionary.Add(1, "eins");
            dictionary.Add(2, "zwei");

            KeyValuePair<int, string> keyValuePairEntry = new KeyValuePair<int, string>(3, "drei");
            dictionary.Add(keyValuePairEntry);


            //Prüfen auf Key, ob dieser schon vergeben ist
            if (!dictionary.Keys.Contains(4))
            {
                
                dictionary.Add(4, "Vier");
            }


            foreach (KeyValuePair<int, string> currentItem1 in dictionary)
            {
                int anyKey = currentItem1.Key;
                string value = currentItem1.Value;
            } //Scope ist hier zuende 


            KeyValuePair<int, string> currentItem = dictionary.Single(n => n.Key == 1);

            #endregion




            DataStore<Guid> dataStore = new DataStore<Guid>();
            dataStore.AddOurUpdate(1, Guid.NewGuid());

            DataStore<int> dataStore1 = new DataStore<int>();
            dataStore1.AddOurUpdate(1, 123);
        }
    }



    public class DataStore<T>
    {
        private T[] _data = new T[10]; 

        public T[] Data
        {
            get
            {
                return _data;
            }

            set
            {
                _data = value;
            }
        }

        public void AddOurUpdate(int index, T item)
        {
            if (index >= 0 && index < 10)
                _data[index] = item;
        }

        public T GetData(int index)
        {
            if (index >= 0 && index < 10)
                return _data[index];

            else return default(T);
        }



    }
}
