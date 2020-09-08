using System;
using System.Collections.Generic;
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
           const string expected = "Hello Bob - the time on the server is 10:48pm on 14 March 2018";

           var names = new List<string>{"Bob"};
           var actual = Message.Write(names, systemTime);
           
          Assert.Equal(expected, actual);
       }

       [Fact]
       public void GivenNoNameShouldJustPrintMessage()
       {
           var actual = Message.Write("Test");
           Assert.Equal("Test", actual);
       }
    }
}