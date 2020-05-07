using System;

namespace Mini4Airport
{ 
    public class Route
    {
        public string airline;
        public string source;
        public string target;
        public double distance;
        public double time;

        public Route(string airline, string source, string target, double distance, double time)
        {
            this.airline = airline;
            this.source = source;
            this.target = target;
            this.distance = distance;
            this.time = time;
        }
    }
}