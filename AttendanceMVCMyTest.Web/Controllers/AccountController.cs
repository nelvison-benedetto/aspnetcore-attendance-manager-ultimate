using AttendanceMVCMyTest.Web.Models.ViewModels.User;
using AttendanceMVCMyTest.Web.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AttendanceMVCMyTest.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: /Account/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View(new UserLoginModel());
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(UserLoginModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (await _userService.CheckUserPassword(model))
            {
                // Imposta cookie di autenticazione
                FormsAuthentication.SetAuthCookie(model.Username, createPersistentCookie: false);

                // Redireziona alla pagina protetta
                return RedirectToAction("Index", "Student");
            }

            ModelState.AddModelError("", "Credenziali non valide");
            return View(model);
        }

        // Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }


    }
}