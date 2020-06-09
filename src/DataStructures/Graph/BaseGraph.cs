using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Core;
using DataStructures.Graph.Edge;

namespace DataStructures.Graph
{
    public abstract class BaseGraph<T> : IGraph<T>, IEnumerable<T>
    {
        public abstract void AddEdge(Edge<T> edgeToAdd);

        public virtual void AddEdge(T @from, T to)
        {
            var edgeToAdd = new Edge<T>(@from, to);
            AddEdge(edgeToAdd);
        }

        public abstract IEnumerable<T> GetAllAdjacentVertices(T vertex);

        public abstract IEnumerable<T> GetAllVertices();

        public abstract IEnumerable<Edge<T>> GetAllEdges();

        public abstract bool IsCycleExists();

        public virtual int NumberOfEdges => GetAllEdges().Count();

        public virtual int NumberOfVertices => GetAllVertices().Count();

        /// <summary>
        /// Number of vertices connected to a given vertex 
        /// </summary>
        /// <param name="vertex">Vertex for which need to find the degree</param>
        /// <returns></returns>
        public int Degree(T vertex)
        {
            vertex.ThrowIfNull(nameof(vertex));
            return GetAllAdjacentVertices(vertex).ToList().Count;
        }

        public int NumberOfSelfLoops()
        {
            // A self loop is created when Source = Destination
            return GetAllEdges().Count(x => x.IsSelfLoop());
        }

        public override string ToString()
        {
            return GetAllEdges()
                   .Aggregate(seed: string.Empty, (accumulator, initialValue) => accumulator +
                                                                        (!string.IsNullOrWhiteSpace(accumulator) ? " , " : string.Empty) +
                                                                        initialValue);
        }

        public virtual IEnumerable<T> IterateDepthFirst
        {
            get
            {
                //
                // 1. Go through all the vertices.
                // 2. Keep a visited Array to keep a track of all the visited nodes.
                // 3. Visit root Node or any arbitrary node to start
                // 4. Mark the node as visited.
                // 5. Get all the adjacent neighbors of the vertex.
                // 6. Repeat steps 3 to 5
                //

                // Since recursion causes a lot of State machine generation if the stack is too deep.
                // A list is used instead of yield.

                var visitedNodes = new HashSet<T>(this.NumberOfVertices);
                var listVertices = new List<T>(this.NumberOfVertices);

                foreach (var vertex in this.GetAllVertices())
                {
                    if (visitedNodes.Contains(vertex))
                        continue;

                    DepthFirstIterationRecursive(vertex);
                }

                return listVertices;

                void DepthFirstIterationRecursive(T vertex)
                {
                    visitedNodes.Add(vertex);
                    listVertices.Add(vertex);

                    foreach (var adjacentNeighbor in GetAllAdjacentVertices(vertex))
                    {
                        if (visitedNodes.Contains(adjacentNeighbor))
                            continue;

                        DepthFirstIterationRecursive(adjacentNeighbor);
                    }
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return (IEnumerator<T>)IterateDepthFirst;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<T> TopologicalSort()
        {
            //	1. Run depth-first search.
            //  2. Return vertices in reverse postorder.

            var visitedTracker = new HashSet<T>();
            var stackOfVertex = new Stack<T>();

            foreach (var vertex in GetAllVertices())
            {
                if (!visitedTracker.Contains(vertex))
                    DFS(vertex);
            }

            return stackOfVertex;

            void DFS(T vertex)
            {
                visitedTracker.Add(vertex);

                foreach (var adjacentVertex in GetAllAdjacentVertices(vertex))
                {
                    if (!visitedTracker.Contains(adjacentVertex))
                        DFS(adjacentVertex);
                }

                stackOfVertex.Push(vertex);
            }
        }
    }
}
