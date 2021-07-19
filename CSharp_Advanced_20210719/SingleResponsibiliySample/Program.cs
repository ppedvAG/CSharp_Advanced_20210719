using System;

namespace SingleResponsibiliySample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        #region Schlechtes Beispiel
        public class EmployeeBad
        {
            public int Employee_Id { get; set; }
            public string Employee_Name { get; set; }

            /// <summary>
            /// This method used to insert into employee table
            /// </summary>
            /// <param name="em">Employee object</param>
            /// <returns>Successfully inserted or not</returns>
            public bool InsertIntoEmployeeTable(EmployeeBad em)
            {
                //Speicher Daten ab
                return true;
            }
            /// <summary>
            /// Method to generate report
            /// </summary>
            /// <param name="em"></param>
            public void GenerateReport(EmployeeBad em)
            {
                // Report generation with employee data using crystal report.
            }

            // GenerateReport wird in einer eigene Klasse ausgelagert, weil GenerateReport eine eigene Funktionalität mit sich bringt.
        }
        #endregion




        #region Better Variant

        public class Employee
        {
            public int Employee_Id { get; set; }
            public string Employee_Name { get; set; }
        }

        public class ReportGenerator
        {
            /// <summary>
            /// Method to generate report
            /// </summary>
            /// <param name="em"></param>
            public void GenerateReport(Employee em)
            {
                // Report reneration with employee data.
            }
        }

        public class EmployeeRepository
        {
            public bool InsertIntoEmployeeTable(Employee em)
            {
                // Insert into employee table.
                return true;
            }
        }
        #endregion
    }
}
