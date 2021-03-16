namespace StationsByContract
{
    public class Position
    {
        public double latitude { get; set; }
        public double longitude { get; set; }

        public override string ToString()
        {
            return "(Latitude: " + latitude + "; longitude: " + longitude + ")\n";
        }
    }
}