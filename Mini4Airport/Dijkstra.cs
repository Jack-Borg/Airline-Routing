using System;
using System.Collections.Generic;

namespace Mini4Airport
{
    public class Dijkstra
    {
        private DirectedGraph dg;
        private string source;
        private Dictionary<string, double> distTo;
        private Dictionary<string, double> timeTo;
        private Dictionary<string, string> timeEdgeTo;
        private PrioQueue<Path> pqMin = new PrioQueue<Path>();

        public Dijkstra(DirectedGraph dg, string source)
        {
            this.dg = dg;
            this.source = source;
            distTo = new Dictionary<string, double>();
            timeTo = new Dictionary<string, double>();
            timeEdgeTo = new Dictionary<string, string>();
            foreach (string code in dg.GetAirportCodes())
            {
                distTo[code] = double.PositiveInfinity;
                timeTo[code] = double.PositiveInfinity;
                timeEdgeTo[code] = code;
            }

            distTo[source] = 0;
            pqMin.Enqueue(new Path(source, 0));
            DijkstraShortDist();

            timeTo[source] = 0;
            pqMin.Enqueue(new Path(source, 0));
            DijkstraShortTime();
        }

        public void DijkstraShortDist()
        {
            while (pqMin.Count() > 0)
            {
                Path path = pqMin.Dequeue();
                HashSet<Route> adjacents = dg.graph[path.Vertex];
                foreach (Route adjacent in adjacents)
                {
                    double tmpDist = distTo[adjacent.source] + adjacent.distance;
                    if (distTo[adjacent.target] > tmpDist)
                    {
                        distTo[adjacent.target] = tmpDist;
                        pqMin.Enqueue(new Path(adjacent.target, tmpDist));
                    }
                }
            }
        }

        public void DijkstraShortTime()
        {
            while (pqMin.Count() > 0)
            {
                Path path = pqMin.Dequeue();
                HashSet<Route> adjacents = dg.graph[path.Vertex];
                foreach (Route adjacent in adjacents)
                {
                    double tmpTime = timeTo[adjacent.source] + adjacent.time;
                    if (timeTo[adjacent.target] > tmpTime)
                    {
                        timeTo[adjacent.target] = tmpTime;
                        timeEdgeTo[adjacent.target] = adjacent.source;
                        pqMin.Enqueue(new Path(adjacent.target, tmpTime));
                    }
                }
            }
        }

        public double getDist(string target)
        {
            return distTo[target];
        }

        public double getTime(string target)
        {
            double time = timeTo[target];

            while (timeEdgeTo[target] != target)
            {
                target = timeEdgeTo[target];
                time += 1;
            }

            return time;
        }
    }

    public class Path : IComparable<Path>
    {
        private string vertex;
        private double weight;

        public Path(string vertex, double weight)
        {
            this.vertex = vertex;
            this.weight = weight;
        }

        public int CompareTo(Path other)
        {
            if (this.weight < other.weight)
                return 1;
            else if (this.weight > other.weight)
                return -1;
            else
                return 0;
        }

        public string Vertex => vertex;

        public double Weight => weight;
    }
}