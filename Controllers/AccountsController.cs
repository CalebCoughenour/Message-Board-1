using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MessageBoard.Models;
using MessageBoard.ViewModels;

namespace MessageBoard.Controllers
{
    public class AccountsController : Controller
    {
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            ApplicationUser.Register(model);
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Login()
        {
            var allThreads = Thread.GetThreads();
            return View(allThreads);
        }
        public ActionResult Logoff()
        {
            var allThreads = Thread.GetThreads();
            return View(allThreads);
        }
    }
}
