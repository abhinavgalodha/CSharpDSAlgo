using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Core;
using System.Linq;

namespace DataStructures.Graph
{
    public class GraphUsingAdjList1 
    {
        private readonly Dictionary<int, List<int>> _adjacencyList;

        public GraphUsingAdjList1()
        {
            _adjacencyList = new Dictionary<int, List<int>>();
        }

        public void AddEdge(int from, int to)
        {
            if (_adjacencyList.ContainsKey(from))
            {
                _adjacencyList[from].Add(to);
                return;
            }

            var listOfVerticesConnectedFromVertex = new List<int> {to};
            _adjacencyList.Add(from, listOfVerticesConnectedFromVertex);
        }


        public void AddEdgeBetter(int from, int to)
        {
            if (IsFromVertexAlreadyInAdjacencyList())
            {
                AppendToVertexInExistingListOfFromVertex();
            }
            else
            {
                AddNewFromVertexInAdjacencyDictAndAddToVertexInList();    
            }

            bool IsFromVertexAlreadyInAdjacencyList()
            {
                return _adjacencyList.ContainsKey(from);
            }

            void AppendToVertexInExistingListOfFromVertex()
            {
                var listOfVerticesFromVertex = new List<int> {to};
                _adjacencyList.Add(from, listOfVerticesFromVertex);

            }

            void AddNewFromVertexInAdjacencyDictAndAddToVertexInList()
            {
                _adjacencyList[from].Add(to);
            }
        }

    }
}
