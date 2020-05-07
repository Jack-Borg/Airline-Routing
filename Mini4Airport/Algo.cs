using System.Collections.Generic;

namespace Mini4Airport
{
    public class Algo
    {
        public static bool BFSIsConnected(DirectedGraph dg, string airline, string source, string target)
        {
            HashSet<string> visited = new HashSet<string>();

            //source not in graph
            if (!dg.graph.ContainsKey(source))
                return false;
            
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(source);

            while (queue.Count > 0)
            {
                string cur = queue.Dequeue();
                
                //been there done that
                if(visited.Contains(cur))
                    continue;

                visited.Add(cur);

                foreach (Route neighbor in dg.graph[cur])
                    if (!visited.Contains(neighbor.target) && neighbor.airline == airline)
                    {
                        if (neighbor.target == target)
                            return true;
                        
                        queue.Enqueue(neighbor.target);
                    }
            }
            
            return false;
        } 
        
        public static bool DFSIsConnected(DirectedGraph dg, string airline, string source, string target)
        {
            HashSet<string> visited = new HashSet<string>();

            //source not in graph
            if (!dg.graph.ContainsKey(source))
                return false;
            
            Stack<string> stack = new Stack<string>();
            stack.Push(source);

            while (stack.Count > 0)
            {
                string cur = stack.Pop();
                
                //been there done that
                if(visited.Contains(cur))
                    continue;

                visited.Add(cur);

                foreach (Route neighbor in dg.graph[cur])
                    if (!visited.Contains(neighbor.target) && neighbor.airline == airline)
                    {
                        if (neighbor.target == target)
                            return true;
                        
                        stack.Push(neighbor.target);
                    }
            }
            
            return false;
        }

        
    }
}