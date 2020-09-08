using System;
using System.Collections.Generic;
using System.Net;

namespace HelloWorldWebApp
{
    public static class Response
    {
        public static void Write(List<User> users, HttpListenerContext context)
        {
            var names = new List<string>();
            foreach (var user in users)
            {
                names.Add(user.Name);
            }

            var buffer = System.Text.Encoding.UTF8.GetBytes(Message.Write(names, DateTime.Now));

            context.Response.ContentLength64 = buffer.Length;  //gets number of bytes in body 
            context.Response.OutputStream.Write(buffer, 0, buffer.Length);  // forces send of response  
            context.Response.Close();
        }

        public static void Write(string message, HttpListenerContext context)
        {
            var buffer = System.Text.Encoding.UTF8.GetBytes(Message.Write(message));

            context.Response.ContentLength64 = buffer.Length;  
            context.Response.OutputStream.Write(buffer, 0, buffer.Length);  
            context.Response.Close();
        }
    }
}