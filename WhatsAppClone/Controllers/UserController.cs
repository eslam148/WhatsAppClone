using Microsoft.AspNetCore.Mvc;
using ChatDB;
using Microsoft.AspNetCore.Identity;
using WhatsAppClone.Models;

namespace WhatsAppClone.Controllers
{
    public class UserController : Controller
    {
        private readonly ChatDB.AppContext appContext;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        public UserController(ChatDB.AppContext appContext, SignInManager<User> signInManager,UserManager<User> userManager)
        {
            this.appContext = appContext;
            this.signInManager=signInManager;
            this.userManager=userManager;
        }
        public IActionResult Regester()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Regester(RegesterModel info)
        {
            if(ModelState.IsValid == false)
            {
                return View();
            }
            else
            {
                User user = new User()
                {
                    Name = info.Name,
                    Email = info.Email,
                    PhoneNumber = info.Phone,
                    UserName = info.UserName
                };
                IdentityResult result = await userManager.CreateAsync(user, info.Password);
                if (result.Succeeded == false)
                {
                    result.Errors.ToList().ForEach(i => { ModelState.AddModelError("", i.Description); });
                    return View();
                }
                else
                {
                    // await UserManager.AddToRoleAsync(user, admin.Role);
                    //await userManager.AddToRoleAsync(user, "Admin");

                    return RedirectToAction("LogIn");


                }
            }
         }
    
        public async Task<IActionResult> LogIn()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> LogIn(LogInModel info)
        {
            if (ModelState.IsValid == false)
            {
                return View();

            }
            else
            {
                 var result = await signInManager.PasswordSignInAsync(info.UserName,info.Password,false,false);
                if (result.Succeeded == false)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
           
        }

    }
}
