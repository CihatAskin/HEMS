using Microsoft.AspNetCore.Mvc;

namespace HEMS.Client.Controllers
{
    public class BaseController : Controller
    {

        public static string RedirectToErrorPath = "/Home/Error";
        public IActionResult Index()
        {
            return View();
        }
        public RedirectResult RedirectToError()
        {
            return Redirect(RedirectToErrorPath);
        }
    }
}
