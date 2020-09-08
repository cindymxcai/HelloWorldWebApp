using HelloWorldWebApp;
using Xunit;

namespace WebAppTests
{
    public class RequestTests
    {
        [Fact]
        public void GetMethodShouldGetAllUsers()
        {
            var dataRetriever = new DataRetriever();
            var users = new Users(dataRetriever);

            var listUsers = users.Get();
            
            Assert.Equal(2, listUsers.Count);
            Assert.Equal("cindy", listUsers[0].Name);
            Assert.Equal("bob", listUsers[1].Name);
        }
    }
}