using StationsByContract;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace StationInfos
{
    class Program
    {
        private static string API_KEY = "4f0f1ed3d8bec3f0b96d7cd2b815ab9c18640c67";
        static readonly HttpClient client = new HttpClient();

        private static async Task<Station> getStationInfos(long stationId, string contract)
        {
            HttpResponseMessage response;
            try
            {
                response = await client.GetAsync("https://api.jcdecaux.com/vls/v1/stations/" + stationId + "?contract=" + contract + "&apiKey=" + API_KEY);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Station station = JsonSerializer.Deserialize<Station>(responseBody);
                Console.WriteLine(station.ToString());
                return station;

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("HTTP ERROR : ");
                Console.WriteLine(e);
            }
            return null;
        }
        static void Main(string[] args)
        {
            string contract_name = "lyon";
            long station_Id = 10036;
            getStationInfos(station_Id,contract_name).GetAwaiter().GetResult();
        }
    }
}
