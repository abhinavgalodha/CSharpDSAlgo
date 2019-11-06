using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Core;
using System.Linq;

namespace DataStructures.Graph
{
    public class GraphUsingAdjList<T> : BaseGraph<T>
    {
        private readonly Dictionary<T, List<T>> _adjacencyList;

        public GraphUsingAdjList()
        {
            _adjacencyList = new Dictionary<T, List<T>>();
        }

        public override void AddEdge(Edge<T> edgeToAdd)
        {
            //testNull(edgeToAdd);
            edgeToAdd.ThrowIfNull(nameof(edgeToAdd));

            if (IsFromVertexAlreadyInAdjacencyList(_adjacencyList, edgeToAdd))
            {
                AppendToVertexInExistingListOfFromVertex(_adjacencyList, edgeToAdd);
            }
            else
            {
                AddNewFromVertexInAdjacencyDictAndAddToVertexInList(_adjacencyList, edgeToAdd);    
            }

            bool IsFromVertexAlreadyInAdjacencyList(Dictionary<T, List<T>> adjacencyList, Edge<T> edgeToAdd)
            {
                var vertexTo = edgeToAdd.To;
                return adjacencyList.ContainsKey(edgeToAdd.From);
            }

            void AppendToVertexInExistingListOfFromVertex(Dictionary<T, List<T>> adjacencyList, Edge<T> edgeToAdd)
            {
                var vertexFrom = edgeToAdd.From;
                var vertexTo = edgeToAdd.To;

                List<T> listOfVerticesFromVertex = new List<T> {vertexTo};
                _adjacencyList.Add(vertexFrom, listOfVerticesFromVertex);

            }

            void AddNewFromVertexInAdjacencyDictAndAddToVertexInList(Dictionary<T, List<T>> adjacencyList, Edge<T> edgeToAdd)
            {
                var vertexFrom = edgeToAdd.From;
                var vertexTo = edgeToAdd.To;

                if (_adjacencyList.ContainsKey(vertexFrom))
                {
                    _adjacencyList[vertexFrom].Add(vertexTo);
                }
            }
        }

        

        public override void AddEdge(T source, T destination)
        {
            var edgeToAdd = new Edge<T>(source, destination);
            AddEdge(edgeToAdd);
        }

        public override IEnumerable<T> GetAllAdjacentVertices(T vertex)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<T> GetAllVertices()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Edge<T>> GetAllEdges()
        {
            throw new NotImplementedException();
        }

        public override bool IsCycleExists()
        {
            throw new NotImplementedException();
        }

        public override int NumberOfVertices => GetAllVertices().Count();

        public override int NumberOfEdges => throw new NotImplementedException();
    }
}
