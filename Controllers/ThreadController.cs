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
  public class ThreadController : Controller
  {
    public ActionResult Index()
    {
      var allThreads = Thread.GetThreads();
      return View(allThreads);
    }

    public ActionResult Details(int id)
    {
      var thread = Thread.GetThread(id);
      return View(thread);
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
    public ActionResult Create(Thread thread)
    {
      string userId = HttpContext.Session.GetString("userId");
      thread.UserId = userId;
      int threadId = Thread.PostThread(thread);
      return RedirectToAction("Details", new { id = threadId});
    }

    
    public ActionResult Delete(int id)
    {
      if(string.IsNullOrEmpty(HttpContext.Session.GetString("userId")))
      {
        return RedirectToAction("Login", "Accounts");
      }
      string userId = HttpContext.Session.GetString("userId");
      ApiHelper.ApiDelete(id, "threads", userId);
      return RedirectToAction("Index");
    }
    
    public ActionResult Edit(int id)
    {
      if(string.IsNullOrEmpty(HttpContext.Session.GetString("userId")))
      {
        return RedirectToAction("Login", "Accounts");
      }
      return View();
    }

    [HttpPost]
    public ActionResult Edit(int id, Thread thread)
    {
      var thisThread = Thread.GetThread(id);
      if(string.IsNullOrEmpty(HttpContext.Session.GetString("userId")))
      {
        return RedirectToAction("Login", "Accounts");
      }
      string userId = HttpContext.Session.GetString("userId");
      thread.UserId = thisThread.UserId;
      thread.ThreadId = id;
      ApiHelper.ApiPutThread(thread, userId);
      return RedirectToAction("Index");
    }
  }
}
