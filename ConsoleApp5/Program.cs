using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.GetAsync("https://www.bitmex.com/api/v1/instrument/active").Result;
                string result = response.Content.ReadAsStringAsync().Result;

                List<Instrument> list = JsonConvert.DeserializeObject<List<Instrument>>(result);

                Console.Clear();
                foreach (Instrument item in list)
                {
                    Console.WriteLine("Name: " + item.Symbol);
                    Console.WriteLine("Price: " + item.Price);
                    Console.WriteLine("################################");
                }
                Thread.Sleep(10000);
            }

            Console.ReadKey();
        }
    }
}
