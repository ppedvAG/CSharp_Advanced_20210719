using System;
using System.Data.SqlClient;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsynAwaitPatternSample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Task<string> task = Task.Run(
                () =>
                {
                    DateTime date = DateTime.Now;
                    return date.Hour > 17
                   ? "evening"
                   : date.Hour > 12
                       ? "afternoon"
                       : "morning";
                });

            task.Wait();
            string result1 = task.Result;
            
            string result = await Task.Run(
                () =>
                {
                    DateTime date = DateTime.Now;
                    return date.Hour > 17
                   ? "evening"
                   : date.Hour > 12
                       ? "afternoon"
                       : "morning";
                });

            HttpClient client = new();
            HttpResponseMessage response = await client.GetAsync("localhst:121231");

            SqlConnection con = new SqlConnection("myconnectionString...1...2..3");
            await con.OpenAsync();
        }
    }
}
