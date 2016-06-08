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

        public ActionResult RedirectToRoleHome()
        {
            if (User.IsInRole("Accountant"))
            {
                // To Do: replace when accountant controller is complete
                return RedirectToAction("Index", "Accountant");
            }
            else if (User.IsInRole("Engineer"))
            {
                return RedirectToAction("Index", "Client");
            }
            else if (User.IsInRole("Manager"))
            {
                // To Do: replace when manager controller is complete
                return RedirectToAction("Index", "Manager");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}