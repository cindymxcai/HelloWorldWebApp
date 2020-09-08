using System.Collections.Generic;
using System.Net;

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
            throw new System.NotImplementedException();
        }
    }
}