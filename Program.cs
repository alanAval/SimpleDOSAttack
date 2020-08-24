using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace c_
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();
            int requestCount = 0;
            var list = new List<Task<HttpResponseMessage>>();
            while (true) { 
                list.Add(client.GetAsync("http://nupreco.com/"));
                Console.WriteLine((++requestCount).ToString());
                if (requestCount == 5)
                    break;
            }

            while (list.Where(a => !a.IsCompleted).Any());

            Console.WriteLine("Fim do ataque");

            await Task.Delay(100);
        }
    }
}
