using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MessageBoard.Models
{
  public class Thread
  {
    public int ThreadId { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string UserId { get; set; }
    public DateTime DateCreated { get; set; }

    public virtual ICollection<Post> Posts { get; set; }
    
    public Thread()
    {
      this.Posts = new HashSet<Post>();
    }

    public static List<Thread> GetThreads()
    {
      var apiCallTask = ApiHelper.ApiGetThreads();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Thread> threadList = JsonConvert.DeserializeObject<List<Thread>>(jsonResponse.ToString());

      return threadList;
    }

    public static Thread GetThread(int id)
    {
      var apiCallTask = ApiHelper.ApiGetThread(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Thread threadList = JsonConvert.DeserializeObject<Thread>(jsonResponse.ToString());

      return threadList;
    }
  }
}