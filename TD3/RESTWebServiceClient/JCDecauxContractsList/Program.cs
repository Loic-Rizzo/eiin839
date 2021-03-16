using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace JCDecauxContractsList
{
    class Program
    {
        private static string API_KEY = "4f0f1ed3d8bec3f0b96d7cd2b815ab9c18640c67";
        static readonly HttpClient client = new HttpClient();

        private static async Task getAllJCDecauxContracts()
        {
            HttpResponseMessage response;
            try
            {
                response = await client.GetAsync("https://api.jcdecaux.com/vls/v1/contracts?apiKey=" + API_KEY);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                List<Contract> contracts = JsonSerializer.Deserialize<List<Contract>>(responseBody);
                printContracts(contracts);
                printContractsInJson(responseBody);
                Console.ReadLine();

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("HTTP ERROR : ");
                Console.WriteLine(e);  
            }

        }

        private static void printContractsInJson(string responseBody)
        {
            Console.WriteLine("Json format :");
            Console.WriteLine(responseBody);
        }

        private static void printContracts(List<Contract> contracts)
        {
            foreach (Contract contract in contracts)
            {
                Console.WriteLine(contract.ToString());
            }
        }

        static void Main(string[] args)
        {
            getAllJCDecauxContracts().GetAwaiter().GetResult();
        }
    }
}
