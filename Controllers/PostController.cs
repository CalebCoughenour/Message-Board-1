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
  public class PostController : Controller
  {

    public ActionResult Details(int id)
    {
      var post = Post.GetPost(id);
      return View(post);
    }
  }
}
