using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json.Linq;

namespace HelloWorldWebApp
{
    public class Users
    {
        private readonly DataRetriever _dataRetriever;

        public Users(DataRetriever dataRetriever)
        {
            _dataRetriever = dataRetriever;
        }

        public List<User> Get()
        {
            return _dataRetriever.GetAllUsers();
        }

        public void Post(User user)
        {
            _dataRetriever.AddUser(user);

        }

        public void Put(HttpListenerContext context)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteAll()
        {
            _dataRetriever.DeleteAllUsers();
        }

        public void Delete(User user)
        {
            _dataRetriever.DeleteUser(user);
        }

    }
}