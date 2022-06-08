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

    public static async Task<string> PostRegister(RegisterViewModel body)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"accounts", Method.POST);
      request.AddJsonBody(body);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
  }
}


// var param = new MyClass { IntData = 1, StringData = "test123" };
// request.AddJsonBody(param);

