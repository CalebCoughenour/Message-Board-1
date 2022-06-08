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
  }
}
