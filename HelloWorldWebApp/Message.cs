using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloWorldWebApp
{
    public static class Message
    {
        public static string Write(List<string> users, DateTime systemTime)
        {
            var names = FormatNames(users);
            var time = $"{systemTime:hh:mmtt}".ToLower();
            var date = $"{systemTime:dd MMMM yyyy}";
            return $"Hello {names} - the time on the server is {time} on {date}";
        }
        
        private static string FormatNames(IReadOnlyCollection<string> users)
        {
            return users.Count switch
            {
                0 => throw new InvalidOperationException(),
                1 => users.First(),
                2 => $"{users.First()} and {users.Last()}",
                _ => $"{string.Join(", ", users.ToArray(), 0, users.Count-1)}, and {users.Last()}"
            };
        }

        public static string Write(string message)
        {
            return message;
        }
    }
}