using System.Collections.Generic;

namespace StationsByContract
{
    public class Station
    {
        public long number { get; set; }
        public string contract_name { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public Position position { get; set; }
        public bool banking { get; set; }
        public bool bonus { get; set; }
        public int bike_stands { get; set; }
        public int available_bike_stands { get; set; }
        public int available_bikes { get; set; }
        public string status { get; set; }
        public long last_update { get; set; }

        public override string ToString()
        {
            return "Contract Name: " + contract_name + "\n" +
                "Address: " + address + "\n" +
                "Name: " + name + "\n" +
                "Number: " + number + "\n" +
                position.ToString() +
                "Banking: " + banking + "\n" +
                "Bonus: " + bonus + "\n" +
                "Bike Stands: " + bike_stands + "\n" +
                "Available Bike Stands: " + available_bike_stands + "\n" +
                "Available Bikes: " + available_bikes + "\n" +
                "Status: " + status + "\n" +
                "Last Update: " + last_update + "\n";
        }
    }
}