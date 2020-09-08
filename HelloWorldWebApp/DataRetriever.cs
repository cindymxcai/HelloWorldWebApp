using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HelloWorldWebApp
{
    public  class DataRetriever
    {
        public List<User> GetAllUsers()
        {
            var streamReader = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "Users.json"));
            var jsonString= streamReader.ReadToEnd();
           
            streamReader.Close();

            return JsonConvert.DeserializeObject<List<User>>(jsonString);
            
        }

        public void AddUser(User user)
        {
            var allUsers = GetAllUsers();
            allUsers.Add(user);
            CreateNewJArray(allUsers);
        }

        private void CreateNewJArray(List<User> allUsers)
        {
            var newUsers = allUsers.Select(t => new JObject(new JProperty("Name", t.Name)));
            var newJson = new JArray(newUsers);
            var streamWriter = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), "Users.json"));
            streamWriter.WriteLine(newJson);
            
            streamWriter.Close();
        }
    }
}