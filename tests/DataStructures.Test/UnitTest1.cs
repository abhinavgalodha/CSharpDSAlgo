using System;
using System.Collections.Generic;
using Xunit;

namespace DataStructures.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Create a graph given in the above diagram  
            Graph1 g = new Graph1(6);
            g.AddEdge(5, 2);
            g.AddEdge(5, 0);
            g.AddEdge(4, 0);
            g.AddEdge(4, 1);
            g.AddEdge(2, 3);
            g.AddEdge(3, 1);

            g.TopologicalSort();
        }
    }

    public class Graph1
    {
        // No. of vertices  
        private int V;

        // Adjacency List as ArrayList of ArrayList's 
        private List<List<int>> adj;

        //Constructor  
        public Graph1(int v)
        {
            V = v;
            adj = new List<List<int>>(v);
            for (int i = 0; i < v; i++)
                adj.Add(new List<int>());
        }

        // Function to add an edge into the graph  
        public void AddEdge(int v, int w)
        {
            adj[v].Add(w);
        }

        // A recursive function used by topologicalSort  
        void TopologicalSortUtil(int v, bool[] visited, Stack<int> stack)
        {
            // Mark the current node as visited.  
            visited[v] = true;

            foreach (var vertex in adj[v])
            {
                if (!visited[vertex])
                    TopologicalSortUtil(vertex, visited, stack);
            }

            // Push current vertex to stack which stores result  
            stack.Push(v);
        }

        // The function to do Topological Sort.  
        // It uses recursive topologicalSortUtil()  
        public void TopologicalSort()
        {

            Stack<int> stack = new Stack<int>();

            // Mark all the vertices as not visited  
            var visited = new bool[V];

            // Call the recursive helper function to store  
            // Topological Sort starting from all vertices one by one  
            for (int i = 0; i < V; i++)
            {
                if (visited[i] == false)
                    TopologicalSortUtil(i, visited, stack);
            }

            Console.WriteLine(stack.Count);

            // Print contents of stack  
            foreach (var vertex in stack)
            {
                Console.Write(vertex);
            }
        }
    }
}
