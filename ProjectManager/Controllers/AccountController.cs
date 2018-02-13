using ProjectManager.BLL.DTO;
using ProjectManager.BLL.Interfaces;
using ProjectManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjectManager.Controllers
{
    public class AccountController : Controller
    {
        IUserService _service;
        public AccountController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
                FormsAuthentication.SignOut(); 
            return View("Register");
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserRegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserDTO user = new UserDTO
                {
                    Email = model.Email,
                    Login = model.Login,
                    Password = model.Password
                };
                bool created = _service.Create(user);
                if (created)
                {
                    UserLoginViewModel Loginmodel = new UserLoginViewModel
                    {
                        Login = model.Login,
                        Password = model.Password,
                        RememberMe = true
                    };
                    Login(Loginmodel);
                    return null;
                }
                else
                {
                    ModelState.AddModelError("", "A user with this Login or Email already registered");
                    return View("Register");
                }
            }
            else
            {
                ModelState.AddModelError("", "Check the correct of entered data");
                return View("Register");
            }
        }
        [HttpGet]
        [AllowAnonymous]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Order");
            else
            {
                FormsAuthentication.SignOut();
                return View("Login");
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult Login(UserLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserDTO user = _service.Login(model.Login, model.Password);
                if (user == null)
                {
                    ModelState.AddModelError("", "Invalid login or password");
                    return View("Login");
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(user.Login, model.RememberMe);
                    return RedirectToAction("Index", "Order");
                }
            }
            else  ModelState.AddModelError("", "Check the correct of entered data"); 
            return View();
        }
        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}