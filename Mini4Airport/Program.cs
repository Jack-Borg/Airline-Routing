using System;
using System.Collections.Generic;
using System.Linq;

namespace Mini4Airport
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Airport[] airports = LoadAirports();
            //Airline[] airlines = LoadAirlines();
            Route[] routes = LoadRoutes();

            DirectedGraph dg = new DirectedGraph(airports, routes);

            Dijkstra dij = new Dijkstra(dg, "GKA");

            Console.WriteLine(dij.getDist("GKA"));
            Console.WriteLine(dij.getDist("MAG"));
            Console.WriteLine(dij.getTime("GKA"));
            Console.WriteLine(dij.getTime("MAG"));


            //Console.WriteLine(Algo.DFSIsConnected(dg, "2B", "AER", "NJC"));
        }

        private static Airport[] LoadAirports()
        {
            string[] lines = System.IO.File.ReadAllLines(@"..\..\..\data\airports.txt");
            Airport[] airports = new Airport[lines.Length-1];
            for (int i = 0; i < airports.Length; i++)
            {
                string[] split = lines[i+1].Split(';');
                airports[i] = new Airport(split[0], split[1], split[2], split[3], split[4]);
            }

            return airports;
        }

        private static Airline[] LoadAirlines()
        {
            string[] lines = System.IO.File.ReadAllLines(@"..\..\..\data\airlines.txt");
            Airline[] airlines = new Airline[lines.Length];
            for (int i = 1; i < lines.Length; i++)
            {
                string[] split = lines[i].Split(';');
                airlines[i] = new Airline(split[0], split[1], split[2]);
            }

            return airlines;
        }
        
        private static Route[] LoadRoutes()
        {
            string[] lines = System.IO.File.ReadAllLines(@"..\..\..\data\routes.txt");
            Route[] routes = new Route[lines.Length-1];
            for (int i = 0; i < routes.Length; i++)
            {
                string[] split = lines[i+1].Split(';');
                routes[i] = new Route(split[0], split[1], split[2], Convert.ToDouble(split[3]), Convert.ToDouble(split[4]));
            }

            return routes;
        }
    }

    
}