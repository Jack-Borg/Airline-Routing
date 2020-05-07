namespace Mini4Airport
{
    public class Airline
    {
        string code;
        string name;
        string country;

        public Airline(string code, string name, string country)
        {
            this.code = code;
            this.name = name;
            this.country = country;
        }

        public override string ToString()
        {
            return code + " " + name + " " + country;
        }
    }
}