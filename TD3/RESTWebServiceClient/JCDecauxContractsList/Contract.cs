using System.Collections.Generic;

namespace JCDecauxContractsList
{
    public class Contract
    {
        public string name { get; set; }
        public string commercial_name { get; set; }
        public string country_code { get; set; }
        public string address { get; set; }
        public List<string> cities { get; set; }
        public override string ToString()
        {
            return "Name: " + name + "\n"
            + "Commercial Name: " + commercial_name + "\n"
            + "Country Code: " + country_code + "\n"
            + "Cities: " + (cities != null ? string.Join(", ", cities) : "N/A") + "\n"
            + "Adresse: " + (address != null ? address : "N/A") + "\n"
            ;
        }
    }
}