using System;

namespace HelloWorldWebApp
{
    public static class Message
    {
        public static string Write(string name,  DateTime systemTime)
        {
            var time = $"{systemTime:hh:mmtt}".ToLower();
            var date = $"{systemTime:dd MMMM yyyy}";
            return $"Hello {name} - the time on the server is {time} on {date}";
        }
    }
}