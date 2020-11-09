using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Dijkstra.NET.Graph;
using Dijkstra.NET.ShortestPath;

namespace RoutePlanner.net
{
    public class Route
    {
        private Dictionary<string, uint> nodesList;

        private Graph<string, string> graph;
        public Route()
        {
            var graph = new Graph<string, string>();
        }

        private List<string> nodes;

        public List<string> Nodes
        {
            get => nodes;
            set
            {
                if (nodes == value)
                {
                    return;
                }
                var delta = value.Except(nodes);
                foreach (var node in delta)
                {
                    var id = graph.AddNode(node);
                    nodesList.Add(node, id);
                }
            }
        }

        private List<Connection> connections;
        public List<Connection> Connections
        {
            get => connections;
            set
            {
                foreach (var connection in value)
                {
                    graph.Connect(nodesList[connection.From], nodesList[connection.ToRoute], connection.Cost, connection.Custom);
                }
            }

        }

        public List<string> GetRoute(string start, List<string> destinations)
        {
            var remainingDest = destinations;
            var currentLocation = start;
            List<string> Route = null;
            if (nodesList == null)
            {
                return null;
            }
            Route.Add(currentLocation);
            while (remainingDest != null)
            {
                int minLenght = -1;
                string nearestDest = null;                
                foreach (var destination in remainingDest)
                {
                    ShortestPathResult result = graph.Dijkstra(nodesList[currentLocation], nodesList[destination]);
                    if (minLenght > result.Distance)
                    {
                        minLenght = result.Distance;
                        nearestDest = destination;
                    }
                }
                currentLocation = nearestDest;
                Route.Add(currentLocation);
                remainingDest.Remove(currentLocation);
            }
            return Route;
        }


    }
}
