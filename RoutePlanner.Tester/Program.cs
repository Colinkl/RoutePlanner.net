using System;
using System.Collections.Generic;
using RoutePlanner.net;

namespace RoutePlanner.App
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var route = new RouteCreator();
            route.Nodes = new List<string>() { "hub", "1", "2", "3", "4", "5", "6", "7", "8" };
            route.Connections = new List<Connection> {new Connection(){ From ="1", ToRoute = "4", Cost = 9, Custom = "s", Bidirectional = true},
                                                      new Connection(){ From ="1", ToRoute = "2", Cost = 20, Custom = "d", Bidirectional = true},
                                                      new Connection(){ From ="4", ToRoute = "7", Cost = 20, Custom = "d", Bidirectional = true},
                                                      new Connection(){ From ="6", ToRoute = "8", Cost = 13, Custom = "d", Bidirectional = true},
                                                      new Connection(){ From ="8", ToRoute = "7", Cost = 13, Custom = "d", Bidirectional = true},
                                                      new Connection(){ From ="7", ToRoute = "hub", Cost = 3, Custom = "d", Bidirectional = true},
                                                      new Connection(){ From ="hub", ToRoute = "2", Cost = 9, Custom = "d", Bidirectional = true},
                                                      new Connection(){ From ="hub", ToRoute = "5", Cost = 7, Custom = "d", Bidirectional = true},
                                                      new Connection(){ From ="5", ToRoute = "8", Cost = 30, Custom = "d", Bidirectional = false},
                                                      new Connection(){ From ="5", ToRoute = "3", Cost = 9, Custom = "d", Bidirectional = false},
                                                      new Connection(){ From ="2", ToRoute = "3", Cost = 7, Custom = "d", Bidirectional = false},
                                                      new Connection(){ From ="4", ToRoute = "6", Cost = 3, Custom = "f", Bidirectional = true}};
            var destList = new List<string> {"1", "2", "3", "4", "5", "6", "7", "8" };
            var a = route.GetRoute("hub", destList);
            foreach (var point in a)
            {
                Console.WriteLine(point);
            }
            //Console.ReadLine();
        }
    }
}
