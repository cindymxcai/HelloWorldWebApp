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
            var cindy = new User{Name = "cindy"};
            var bob = new User{Name = "bob"};
            users.Post(cindy);
            users.Post(bob);
            
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
            var listUsers = users.Get();
            Assert.Equal(2, listUsers.Count);
            Assert.Equal("cindy", listUsers[0].Name);
            Assert.Equal("bob", listUsers[1].Name);
        }

        [Fact]
        public void DeleteMethodShouldDeleteUser()
        {
            var dataRetriever = new DataRetriever();
            var users = new Users(dataRetriever);

            var bob = new User{Name = "bob"};
           
            users.Delete(bob);
            var listUsers = users.Get();
            
            Assert.Single(listUsers);
            
            Assert.Equal("cindy", listUsers[0].Name);
        }
        
        [Fact]
        public void DeleteAllMethodShouldEmptyContent()
        {
            var dataRetriever = new DataRetriever();
            var users = new Users(dataRetriever);
            var listUsers = users.Get();

            users.DeleteAll();
            listUsers = users.Get();
            Assert.Empty(listUsers);
        }
 
    }
}