using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using readmypen.DataAccess.Interfaces;
using readmypen.WebUI.Models;

namespace readmypen.WebUI.Controllers
{
    public class accountsController : Controller
    {
        private readonly IUsersRepository _usersRepository;

        public accountsController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }


        // GET: AccountsController
        public ActionResult Login()
        {
            return View();
        }
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
                return View("~/Views/Home/Index.cshtml");
            }

        }


        // GET: AccountsController/Details/5
        public ActionResult Signup()
        {
            return View();
        }

    }
}
