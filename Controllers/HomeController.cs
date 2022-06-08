using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MessageBoard.Models;

namespace MessageBoard.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            var allThreads = Thread.GetThreads();
            return View(allThreads);
        }
    }
}
