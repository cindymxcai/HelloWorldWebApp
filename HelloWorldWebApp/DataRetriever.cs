using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

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
    }
}