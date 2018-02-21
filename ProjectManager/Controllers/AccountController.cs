using Microsoft.Owin.Security;
using ProjectManager.BLL.BusinessModels;
using ProjectManager.BLL.DTO;
using ProjectManager.BLL.Interfaces;
using ProjectManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjectManager.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;
        
        IUserService UserService;
        public AccountController(IUserService service)
        {
            UserService = service;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(UserLoginViewModel model)
        {
            await SetInitialDataAsync();

            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO { Login = model.Login, Password = model.Password };
                ClaimsIdentity claim = await UserService.Authenticate(userDto);
                if (claim == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(UserRegistrationViewModel model)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO
                {
                    Email = model.Email,
                    Password = model.Password,                 
                    Login = model.Login,
                    Role = "user"
                };
                OperationDetails operationDetails = await UserService.Create(userDto);
                if (operationDetails.Succedeed)  return RedirectToAction("Index", "Board");
                else  ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            }
            return View(model);
        }
        private async Task SetInitialDataAsync()
        {
            await UserService.SetInitialData(new UserDTO
            {
                Email = "somemail@mail.ru",
                Login = "somelogin",
                Password = "ad46D_ewr3",              
                Role = "admin",
            }, new List<string> { "user", "admin" });
        }
    }








        //[HttpGet]
        //[AllowAnonymous]
        //public ActionResult Register()
        //{
        //    if (HttpContext.User.Identity.IsAuthenticated)
        //        FormsAuthentication.SignOut(); 
        //    return View("Register");
        //}
        //[AllowAnonymous]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Register(UserRegistrationViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        UserDTO user = new UserDTO
        //        {
        //            Email = model.Email,
        //            Login = model.Login,
        //            Password = model.Password
        //        };
        //        bool created = _service.Create(user);
        //        if (created)
        //        {
        //            UserLoginViewModel Loginmodel = new UserLoginViewModel
        //            {
        //                Login = model.Login,
        //                Password = model.Password,
        //                RememberMe = true
        //            };                  
        //            return Login(Loginmodel);
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "A user with this Login or Email already registered");
        //            return View("Register");
        //        }
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "Check the correct of entered data");
        //        return View("Register");
        //    }
        //}
        //[HttpGet]
        //[AllowAnonymous]
        //[OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        //public ActionResult Login()
        //{
        //    if (HttpContext.User.Identity.IsAuthenticated)
        //        return RedirectToAction("Index", "Board");
        //    else
        //    {
        //        FormsAuthentication.SignOut();
        //        return View("Login");
        //    }
        //}

        //[AllowAnonymous]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        //public ActionResult Login(UserLoginViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        UserDTO user = _service.Login(model.Login, model.Password);
        //        if (user == null)
        //        {
        //            ModelState.AddModelError("", "Invalid login or password");
        //            return View("Login");
        //        }
        //        else
        //        {
        //            FormsAuthentication.SetAuthCookie(Convert.ToString(user.Id), model.RememberMe);
        //            return RedirectToAction("Index", "Order");
        //        }
        //    }
        //    else  ModelState.AddModelError("", "Check the correct of entered data"); 
        //    return View();
        //}
        //[Authorize]
        //public ActionResult LogOut()
        //{
        //    FormsAuthentication.SignOut();
        //    return RedirectToAction("Login");
        //}
    
}