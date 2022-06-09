using System.Threading.Tasks;
using RestSharp;
using System;
using MessageBoard.ViewModels;

namespace MessageBoard.Models
{
  class ApiHelper
  {
    public static async Task<string> ApiGetThreads()
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest("threads", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> ApiGetThread(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"threads/{id}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> ApiGetPost(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"posts/{id}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> ApiPostRegister(RegisterViewModel body)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"accounts/register", Method.POST);
      request.AddJsonBody(body);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> ApiPostLogin(LoginViewModel body)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"accounts/login", Method.POST);
      request.AddJsonBody(body);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> ApiPostThread(Thread thread)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"threads", Method.POST);
      request.AddJsonBody(thread);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async void ApiDelete(int id, string controller, string userId)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"{controller}/{id}?userId={userId}", Method.DELETE);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async void ApiPutThread(Thread thread, string userId)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"threads/{thread.ThreadId}?userId={userId}", Method.PUT);
      request.AddJsonBody(thread);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task<string> ApiPostPost(Post post)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"posts", Method.POST);
      request.AddJsonBody(post);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async void ApiPutPost(Post post, string userId)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"posts/{post.PostId}?userId={userId}", Method.PUT);
      request.AddJsonBody(post);
      var response = await client.ExecuteTaskAsync(request);
    }
  }
}


// var param = new MyClass { IntData = 1, StringData = "test123" };
// request.AddJsonBody(param);

