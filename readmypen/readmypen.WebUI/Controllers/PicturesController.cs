using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace readmypen.WebUI.Controllers
{
    public class PicturesController : Controller
    {
        public ActionResult Upload()
        {
            return View();
        }

    }
}
