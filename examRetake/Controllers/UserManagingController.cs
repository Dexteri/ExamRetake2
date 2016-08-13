using examRetake.Account_Manager.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace examRetake.Controllers
{
    public class UserManagingController : Controller
    {
        //
        // GET: /UserManaging/
        UserManagingService userService = new UserManagingService();
        /// <summary>
        /// Zarzadzanie uzytkownikamy
        /// </summary>
        /// 
        /// <returns></returns>
        ///
        /// <summary>
        /// Wyswietlenie listy zarejestrowanych uzytkownikow
        /// </summary>
        /// 
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(userService.GetUserList());
        }
        /// <summary>
        ///usuwanie uzytkownikow
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            userService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}