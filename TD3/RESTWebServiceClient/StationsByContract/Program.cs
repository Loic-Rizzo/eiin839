using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace StationsByContract
{
    class Program
    {
        private static string API_KEY = "4f0f1ed3d8bec3f0b96d7cd2b815ab9c18640c67";
        static readonly HttpClient client = new HttpClient();

        private static async Task<List<Station>> getAllStationsByContract(string contract)
        {
            HttpResponseMessage response;
            try
            {
                response = await client.GetAsync("https://api.jcdecaux.com/vls/v1/stations?contract=" + contract + "&apiKey=" + API_KEY);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                List<Station> stations = JsonSerializer.Deserialize<List<Station>>(responseBody);
                printStations(stations);
                return stations;

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("HTTP ERROR : ");
                Console.WriteLine(e);
            }
            return null;
        }

        private static void printStations(List<Station> stations)
        {
            foreach (Station station in stations)
            {
                Console.WriteLine(station.ToString());
            }
        }

        static void Main(string[] args)
        {
            string contract_name = "lyon";
            getAllStationsByContract(contract_name).GetAwaiter().GetResult();
        }
    }
}
