using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MessageBoard.Models;
using Microsoft.AspNetCore.Http;

namespace MessageBoard.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.LoggedOut = string.IsNullOrEmpty(HttpContext.Session.GetString("userId"));
            var allThreads = Thread.GetThreads();
            return View(allThreads);
        }
    }
}
