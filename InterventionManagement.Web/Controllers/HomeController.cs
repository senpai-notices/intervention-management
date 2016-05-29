using ASDF.ENETCare.InterventionManagement.Business;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace ASDF.ENETCare.InterventionManagement.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Home()
        {
            var test = HttpContext.User.IsInRole("Engineer");
            //var user = await userManager.FindAsync(model.Email, model.Password);
            //var roles = await UserManager.GetRolesAsync(user.Id);
            //if (roles.Contains("Engineer"))
            //{
            //    return RedirectToAction("Index", "Engineer");
            //}
            //else if (roles.Contains("Accountant"))
            //{
            //    // To Do: replace when accountant controller is complete
            //    return RedirectToLocal(returnUrl);
            //}
            //else if (roles.Contains("Manager"))
            //{
            //    // To Do: replace when manager controller is complete
            //    return RedirectToLocal(returnUrl);
            //}
            //else
            //{
            //    return RedirectToLocal(returnUrl);
            //}
            return View();
        }
    }
}