using StationsByContract;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Device.Location;

namespace StationGPS
{
    class Program
    {
        private static string API_KEY = "4f0f1ed3d8bec3f0b96d7cd2b815ab9c18640c67";
        static readonly HttpClient client = new HttpClient();

        private static async Task<Station> getNerestStation(GeoCoordinate position, string contract)
        {
            List<Station> stations = await getAllStationsByContract(contract);

            Station station = getNerest(position, stations);

            Console.WriteLine("La station la plus proche est :" + station.name);
        }

        private static Station getNerest(GeoCoordinate position, List<Station> stations)
        {
            Station nearestStation = null;
            double distance = 0;

            foreach (Station station in stations)
            {
                if (nearestStation == null)
                {
                    nearestStation = station;
                    distance = position.GetDistanceTo(new GeoCoordinate(station.position.latitude, station.position.longitude));
                }
                else if (position.GetDistanceTo(new GeoCoordinate(station.position.latitude, station.position.longitude)) < distance)
                {
                    nearestStation = station;
                    distance = position.GetDistanceTo(new GeoCoordinate(station.position.latitude, station.position.longitude));

                }
            }

            return nearestStation;
        }

        private static async Task<List<Station>> getAllStationsByContract(string contract)
        {
            HttpResponseMessage response;
            try
            {
                response = await client.GetAsync("https://api.jcdecaux.com/vls/v1/stations?contract=" + contract + "&apiKey=" + API_KEY);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                List<Station> stations = JsonSerializer.Deserialize<List<Station>>(responseBody);
                return stations;

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
            getNerestStation(new GeoCoordinate(0.0, 0.0), contract_name).GetAwaiter().GetResult();
        }
    }
}
