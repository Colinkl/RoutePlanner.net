using System;
using System.Collections.Generic;
using RoutePlanner.net;

namespace RoutePlanner.Tester
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var route = new RouteCreator();
            route.Nodes = new List<string>() { "hub", "cat", "meow", "owo" };
            route.Connections = new List<Connection> {new Connection(){ From ="hub", ToRoute = "cat", Cost = 1, Custom = "meow"},
                                                      new Connection(){ From ="cat", ToRoute = "hub", Cost = 1, Custom = "meow"},
                                                      new Connection(){ From ="cat", ToRoute = "meow", Cost = 10, Custom = "meow"},
                                                      new Connection(){ From ="meow", ToRoute = "owo", Cost = 1, Custom = "meow"}};
            var destList = new List<string> { "hub", "meow", "owo" };
            var a = route.GetRoute("cat", destList);
            foreach (var point in a)
            {
                Console.WriteLine(point);
            }
        }
    }
}
