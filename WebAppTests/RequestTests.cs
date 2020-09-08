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

        [Fact]
        public void PostMethodShouldAddUser()
        {
            var dataRetriever = new DataRetriever();
            var users = new Users(dataRetriever);
            var sue = new User{Name = "sue"};
            users.Post(sue);
            var listUsers = users.Get();
            Assert.Equal(3, listUsers.Count);
            Assert.Equal("cindy", listUsers[0].Name);
            Assert.Equal("bob", listUsers[1].Name);
            Assert.Equal("sue", listUsers[2].Name);

        }
    }
}