using cricket_statistics.Areas.Admin.DAL;
using cricket_statistics.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace cricket_statistics.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        [Route("/Admin/Login/Login")]
        public IActionResult Login(AdminModel model)
        {
            return View();
        }

        [Route("/Admin/Login/CheckLogin")]
        public IActionResult CheckLogin(AdminModel model)
        {
            Login obj = new Login();
            bool? isLogin = obj.checkLogin(model.username, model.password);

            if (isLogin != null && isLogin == true)
            {
                return RedirectToRoute(new { controller = "AdminSchedule", action = "Index" });
            }
            else if (isLogin != null && isLogin == false)
            {
                TempData["LoginMessage"] = "Invalid Username Or Password";
                return View("Login");
            }
            else
            {
                TempData["LoginMessage"] = "Server side error";
                return View("Login");
            }
        }
    }
}
