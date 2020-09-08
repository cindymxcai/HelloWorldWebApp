using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HelloWorldWebApp
{
    public class Request
    {
        private readonly Users _users;

        public Request(Users users)
        {
            _users = users;
        }
        public void Process(HttpListenerContext context)
        {
            try
            {
                HandleByMethod(context);
            } 
            catch (Exception e)
            {
                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                Response.Write("500", context);
                var buffer = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(e));
                context.Response.ContentLength64 = buffer.Length;
                context.Response.OutputStream.Write(buffer, 0, buffer.Length);
            }
        }

        private void HandleByMethod(HttpListenerContext context)
        {
            switch (context.Request.Url.AbsolutePath)
            {
                case "/":
                    context.Response.StatusCode = (int) HttpStatusCode.OK;
                    Response.Write("Index",context);
                    break;
                case "/users":
                    switch (ConvertHttpMethodToEnum(context.Request.HttpMethod))
                    {
                        case HttpMethod.Get:
                            Console.WriteLine("getting users");
                            context.Response.StatusCode = (int) HttpStatusCode.OK;
                            Response.Write($"users:\n {JsonConvert.SerializeObject(_users.Get())}", context);
                            break;
                        case HttpMethod.Post:
                            Console.WriteLine("posting to users");
                            context.Response.StatusCode = (int) HttpStatusCode.Created;
                            var json = ReadBody(context);
                            var user = JsonConvert.DeserializeObject<User>(json);        
                            _users.Post(user);
                            Response.Write($"users:\n {JsonConvert.SerializeObject(_users.Get())}", context);
                            break;
                        case HttpMethod.Put:
                            Console.WriteLine("updating task");
                            context.Response.StatusCode = (int) HttpStatusCode.OK;
                            _users.Put(context);
                            Response.Write($"users:\n {JsonConvert.SerializeObject(_users.Get())}", context);
                            break;
                        case HttpMethod.Delete:
                            Console.WriteLine("deleting users");
                            context.Response.StatusCode = (int) HttpStatusCode.OK;
                            _users.DeleteAll();
                            Response.Write($"users:\n {JsonConvert.SerializeObject(_users.Get())}", context);
                            break;
                    }
                    break;
                default:
                    context.Response.StatusCode = (int) HttpStatusCode.NotFound;
                    Response.Write("404", context);   
                    break;
            }        
        }

        private HttpMethod ConvertHttpMethodToEnum(string requestHttpMethod)
        {
            if (Enum.TryParse(requestHttpMethod, true,  out HttpMethod method))
            {
                return method;
            }
            throw new Exception("Invalid method");
        }
        
        public string ReadBody( HttpListenerContext context)
        {
            var body = context.Request.InputStream;
            var streamReader = new StreamReader(body, context.Request.ContentEncoding);
            return  streamReader.ReadToEnd();

        }
    }
}