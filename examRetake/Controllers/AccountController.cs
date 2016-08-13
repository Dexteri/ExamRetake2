using examRetake.Account_Manager.Model;
using examRetake.Account_Manager.Security;
using examRetake.Account_Manager.Service;
using examRetake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace examRetake.Controllers
{
    public class AccountController : Controller
    {
        AccountService accountService = new AccountService();
        /// <summary>
        /// Logowanie
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.LogOut = accountService.isLog();
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Users user)
        {
            AccountModel am = new AccountModel();

            if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password)
                || am.login(user.Username, user.Password) == null)
            {
                ViewBag.Error = "Account's Invalid";
                return View("Login");
            }
            SessionPersister.Username = user.Username;
            return RedirectToAction("Index", "Tasks");
        }
        /// <summary>
        /// rejestracja uzytkownikow
        /// </summary>
        /// <returns></returns>
        public ActionResult Registration()
        {
            ViewBag.Account = accountService.AccessAccount();
            return View();
        }
        [HttpPost]
        public ActionResult Registration(Users user)
        {
            RegistrationService rs = new RegistrationService();

            rs.AddRegistration(user);
            return RedirectToAction("Login");
        }
        /// <summary>
        /// wylogowanie
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            SessionPersister.Username = string.Empty;
            return RedirectToAction("Index");
        }

    }
}