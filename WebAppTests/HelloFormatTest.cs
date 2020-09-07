using System;
using HelloWorldWebApp;
using Xunit;

namespace WebAppTests
{
    public class HelloFormatTest
    {
        [Fact]
       public void GivenNameShouldWriteMessageInCorrectFormat()
       {
           var systemTime = new DateTime(2018, 3, 14, 22, 48, 0);
           var expected = "Hello Bob - the time on the server is 10:48pm on 14 March 2018";

           var actual = Message.Write("Bob", systemTime);

           Assert.Equal(expected, actual);
       } 
    }
}