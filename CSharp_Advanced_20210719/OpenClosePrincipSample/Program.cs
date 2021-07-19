using System;

namespace OpenClosePrincipSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }


    #region BadCode
    public class Employee
    {
        public int Employee_Id { get; set; }
        public string Employee_Name { get; set; }

    }


    public class ReportGenerator
    {
        /// <summary>
        /// Report type
        /// </summary>
        public string ReportType { get; set; }

        /// <summary>
        /// Method to generate report
        /// </summary>
        /// <param name="em"></param>
        public void GenerateReport(Employee em)
        {
            if (ReportType == "CRS")
            {
                // Report generation with employee data in Crystal Report.
            }
            if (ReportType == "PDF")
            {
                //Libary für PDF Export
                //Fülllogik us
                // Report generation with employee data in PDF.
            }
        }
    }
    #endregion



    #region Bessere Variante
    //Open - Part
    public abstract class ReportGeneratorBase
    {
        public abstract void ReportGenerator(Employee em);
    }

    //Close - Part
    public class CrstalReportGenerator : ReportGeneratorBase
    {
        public override void ReportGenerator(Employee em)
        {
            // Generatore crystal report
        }
    }

    //Close-Part
    public class PDFReportGenerator : ReportGeneratorBase
    {
        public override void ReportGenerator(Employee em)
        {
            // Genrator für PDF Report
        }
    }
    #endregion
}
