using System.Net;
using System.Net.Http;
using System.Threading;
using HelloWorldWebApp;
using Xunit;

namespace WebAppTests
{
    public class ServerTests
    {
        [Fact]
        public  void SendingAGetRequestShouldReturnGreeting()
        {
            var serverThread = new Thread(Server.Start);

            var clientThread = new Thread(GetMessage); 
            serverThread.Start(); 
            clientThread.Start();
        }

        private async void GetMessage()
        {
            var client = new HttpClient();
            var message = await client.GetAsync("http://localhost:8080");
            Assert.Equal(HttpStatusCode.OK, message.StatusCode);
        }
    }
}