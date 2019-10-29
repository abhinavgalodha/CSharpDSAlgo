using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Graph
{
    public class GraphUsingArray<T> : BaseGraph<T>
    {
        private List<T> m_listOfEdges;

        public GraphUsingArray()
        {
            m_listOfEdges = new List<T>();
        }

        public override void AddEdge(T source, T destination)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<T> GetAllAdjacentVertices(T vertex)
        {
            throw new NotImplementedException();
        }

        public override int NumberOfEdges { get; }
        public override int NumberOVertices { get; }
    }
}
