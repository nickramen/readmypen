using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using readmypen.DataAccess.Interfaces;
using readmypen.WebUI.Models;

namespace readmypen.WebUI.Controllers
{
    public class accountsController : Controller
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public accountsController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }


        // GET: AccountsController
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Enter(string username, string password)
        {
            UserViewModel model = new UserViewModel();
            model.usr_Username = username;
            model.usr_Password = password;

            var login = _usersRepository.Login(model.usr_Username, model.usr_Password);

            if(login == null)
            {
                return Json("Error");
            }
            else
            {
                HttpContext.Session.SetString("usu_NombreUsuario", login.usr_Username);
                //HttpContext.Session.SetInt32("usu_Id", login.usr_Id);
                //HttpContext.Session.SetString("usu_NombreUsuario", model.usr_Username);
                //ViewBag.Message = HttpContext.Session.GetString("usu_NombreUsuario");

                return View("~/Views/Home/Index.cshtml");
            }

        }

        public ActionResult Signup()
        {
            return View();
        }

    }
}
