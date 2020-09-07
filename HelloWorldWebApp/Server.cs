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
            Listener.Prefixes.Add($"http://localhost:{Port}/"); 
            Listener.Start();
            Console.WriteLine("Starting Server... listening for requests");
            while (true)
            {
                var context = Listener.GetContext();  // Gets the request
                Console.WriteLine($"{context.Request.HttpMethod} {context.Request.Url}");
                var buffer = System.Text.Encoding.UTF8.GetBytes("Hello");
                context.Response.ContentLength64 = buffer.Length;
                context.Response.OutputStream.Write(buffer, 0, buffer.Length);  // forces send of response
            }

            // Listener.Stop(); // never reached...
        }
    }
}