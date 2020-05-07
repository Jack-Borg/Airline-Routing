using System.Collections.Generic;
using System.Linq;

namespace Mini4Airport
{
    public class DirectedGraph
    {
        
        public Dictionary<string, HashSet<Route>> graph { get; } = new Dictionary<string, HashSet<Route>>();
        public int NumVertecies;
        
        public DirectedGraph(Airport[] airports, Route[] routes)
        {
            NumVertecies = airports.Length;
            foreach (Airport vertex in airports)
                AddVertex(vertex.code);

            foreach(Route edge in routes)
                AddEdge(edge);
        }

        public void AddVertex(string vertex)
        {
            graph[vertex] = new HashSet<Route>();
        }

        public void AddEdge(Route route)
        {
            if(graph.ContainsKey(route.source))
                graph[route.source].Add(route);
        }

        public string[] GetAirportCodes()
        {
            return graph.Keys.ToArray();
        }
        
        public int getNumVertecies()
        {
            return NumVertecies;
        }

    }
}