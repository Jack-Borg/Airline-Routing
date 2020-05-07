namespace Mini4Airport
{
    public class Airport
    {
        public string code;
        public string name;
        public string country;
        public string latitude;
        public string longitude;
        
        public Airport(string code, string name, string country, string latitude, string longitude)
        {
            this.code = code;
            this.name = name;
            this.country = country;
            this.latitude = latitude;
            this.longitude = longitude;
        }
        
        public override string ToString()
        {
            return code + " " + name + " " + country + " " + latitude + " " + longitude;
        }
    }
}