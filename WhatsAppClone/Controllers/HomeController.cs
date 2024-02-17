using ChatDB;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WhatsAppClone.Models;

namespace WhatsAppClone.Controllers
{
    public class HomeController : Controller
    {
        private readonly ChatDB.AppContext appContext;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        public HomeController(ChatDB.AppContext appContext, SignInManager<User> signInManager, UserManager<User> userManager)
        {
            this.appContext = appContext;
            this.signInManager=signInManager;
            this.userManager=userManager;
        }
        [HttpPost]
        public IActionResult Index()
        {
           var UserId = userManager.GetUserId(User);
            var frinds =  appContext.Friends.Where(u => u.UserId == UserId).ToList();
            return View(frinds);
        }
        [HttpGet]
        public IActionResult Index(string id)
        {
            var UserId = userManager.GetUserId(User);
            var frinds = appContext.Friends.Where(u => u.UserId == UserId).ToList();
            ViewBag.Chat =appContext.message.Where(u => u.SenderId == UserId && u.ReceverId == id ||  u.SenderId == id && u.ReceverId == UserId).ToList();
            ViewBag.RId = id;
            return View(frinds);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}