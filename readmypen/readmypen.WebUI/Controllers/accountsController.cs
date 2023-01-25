using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace readmypen.WebUI.Controllers
{
    public class accountsController : Controller
    {
        // GET: accountsController
        public ActionResult Login()
        {
            return View();
        }

        // GET: accountsController/Details/5
        public ActionResult Signup()
        {
            return View();
        }

    }
}
