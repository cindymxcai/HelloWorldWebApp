using System;
using System.Net;

namespace HelloWorldWebApp
{
    public static class Server
    {
        private const int Port = 8080;

        private static readonly HttpListener Listener = new HttpListener();

        public static void Start()
        {
            var dataRetriever = new DataRetriever();
            var users = new Users(dataRetriever);
            var request = new Request(users);

            Listener.Prefixes.Add($"http://localhost:{Port}/"); 
            Listener.Start();
            Console.WriteLine("Starting Server... listening for requests");
            while (Listener.IsListening)
            {
                var context = Listener.GetContext();  // Gets the request
                Console.WriteLine($"{context.Request.HttpMethod} {context.Request.Url}");
                request.Process(context);
            }

            // Listener.Stop(); // never reached...
        }
    }
}