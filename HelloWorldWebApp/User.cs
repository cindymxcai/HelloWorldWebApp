using Newtonsoft.Json;

namespace HelloWorldWebApp
{
    public class User
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}