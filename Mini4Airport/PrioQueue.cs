using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Mini4Airport
{
    /*public class PrioQueue<T> where T : IComparable<T>
    {
        int total_size;
        SortedDictionary<int, Queue>() storage;

        public PrioQueue()
        {
            this.storage = new SortedDictionary<int, Queue>();
            this.total_size = 0;
        }

        public bool IsEmpty()
        {
            return (total_size == 0);
        }

        public object Dequeue()
        {
            if (IsEmpty())
            {
                throw new Exception("Please check that priorityQueue is not empty before dequeing");
            }

            foreach (Queue q in storage.Values)
            {
                // we use a sorted dictionary
                if (q.Count > 0)
                {
                    total_size--;
                    return q.Dequeue();
                }
            }

            Debug.Assert(false, "not supposed to reach here. problem with changing total_size");

            return null; // not supposed to reach here.
        }

        // same as above, except for peek.

        public object Peek()
        {
            if (IsEmpty())
                throw new Exception("Please check that priorityQueue is not empty before peeking");
            else
                foreach (Queue q in storage.Values)
                {
                    if (q.Count > 0)
                        return q.Peek();
                }

            Debug.Assert(false, "not supposed to reach here. problem with changing total_size");

            return null; // not supposed to reach here.
        }

        public object Dequeue(int prio)
        {
            total_size--;
            return storage[prio].Dequeue();
        }

        public void Enqueue(object item, int prio)
        {
            if (!storage.ContainsKey(prio))
            {
                storage.Add(prio, new Queue());
            }

            storage[prio].Enqueue(item);
            total_size++;
        }
    }*/

    class PrioQueue<T> where T : IComparable <T>
    {
        private List <T> queue;

        public PrioQueue()
        {
            this.queue = new List <T>();
        }
        
        
        public void Enqueue(T item)
        {
            queue.Add(item);
            int ci = queue.Count - 1;
            while (ci  > 0)
            {
                int pi = (ci - 1) / 2;
                if (queue[ci].CompareTo(queue[pi])  >= 0)
                    break;
                T tmp = queue[ci]; queue[ci] = queue[pi]; queue[pi] = tmp;
                ci = pi;
            }
        }
        
        public T Dequeue()
        {
            // Assumes pq isn't empty
            int li = queue.Count - 1;
            T frontItem = queue[0];
            queue[0] = queue[li];
            queue.RemoveAt(li);

            --li;
            int pi = 0;
            while (true)
            {
                int ci = pi * 2 + 1;
                if (ci  > li) break;
                int rc = ci + 1;
                if (rc  <= li && queue[rc].CompareTo(queue[ci])  < 0)
                    ci = rc;
                if (queue[pi].CompareTo(queue[ci])  <= 0) break;
                T tmp = queue[pi]; queue[pi] = queue[ci]; queue[ci] = tmp;
                pi = ci;
            }
            return frontItem;
        }
        
        public override string ToString()
        {
            string s = "";
            for (int i = 0; i  < queue.Count; ++i)
                s += queue[i].ToString() + " ";
            s += "count = " + queue.Count;
            return s;
        }
        
        public int Count()
        {
            return queue.Count;
        }
        
        public T Peek()
        {
            T frontItem = queue[0];
            return frontItem;
        }
        
        public bool IsConsistent()
        {
            if (queue.Count == 0) return true;
            int li = queue.Count - 1; // last index
            for (int pi = 0; pi  < queue.Count; ++pi) // each parent index
            {
                int lci = 2 * pi + 1; // left child index
                int rci = 2 * pi + 2; // right child index
                if (lci  <= li && queue[pi].CompareTo(queue[lci])  > 0) return false;
                if (rci  <= li && queue[pi].CompareTo(queue[rci])  > 0) return false;
            }
            return true; // Passed all checks
        }
    }
}