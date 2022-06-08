using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using MessageBoard.Models;
using Microsoft.AspNetCore.Http;
using System;

namespace MessageBoard.Controllers
{
  public class PostController : Controller
  {

    public ActionResult Details(int id)
    {
      var post = Post.GetPost(id);
      return View(post);
    }

    public ActionResult Create()
    {
      if(string.IsNullOrEmpty(HttpContext.Session.GetString("userId")))
      {
        return RedirectToAction("Login", "Accounts");
      }
      return View();
    }

    [HttpPost]
    public ActionResult Create(int id, Post post)
    {
      if(string.IsNullOrEmpty(HttpContext.Session.GetString("userId")))
      {
        return RedirectToAction("Login", "Accounts");
      }
      string userId = HttpContext.Session.GetString("userId");
      post.UserId = userId;
      post.ThreadId = id;
      Post.PostPost(post);
      return RedirectToAction("Details", "Thread", new { id = id});
    }
  }
}
