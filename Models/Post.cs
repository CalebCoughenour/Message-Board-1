using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MessageBoard.Models
{
  public class Post
  {
    public int PostId { get; set; }
    public string UserId { get; set; }
    public int ThreadId { get; set; }
    public string Message { get; set; }
    public int ReplyId { get; set; }
    public string Author { get; set; }
    public DateTime DateCreated { get; set; }

    public static Post GetPost(int id)
    {
      var apiCallTask = ApiHelper.ApiGetPost(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Post postList = JsonConvert.DeserializeObject<Post>(jsonResponse.ToString());

      return postList;
    }

    public static string PostPost(Post post)
    {
      var apiCallTask = ApiHelper.ApiPostPost(post);
        var result = apiCallTask.Result;
        // int threadId = result;
        JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
        var thisPost = jsonResponse["id"].ToString();
        return thisPost;
    }
  }
}