using LabNumber21Take2.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabNumber21Take2.Controllers
{
    public class UserInfoController : Controller
    {
        // GET: UserInfo

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {

            return View();
        }

        public ActionResult MakeNewUser(User newUser)
        {
            if (ModelState.IsValid)
            {
                DAO.AddUserToDb(newUser);
                ViewBag.Message = "Successfully registered.";
                return RedirectToAction("LoginPage");
            }
            else
            {
                ViewBag.Message = "There was a problem with your registration.";
                return View("Register");
            }

        }

        public ActionResult LoginPage()
        {
            return View();
        }

        public ActionResult Login(UserLogin thisUser)
        {
            User currentUser = DAO.FindUserExists(thisUser);
            if (currentUser != null)
            {
                ViewBag.Message = "You have successfully logged in.";
                return RedirectToAction("../Shop/Index");
            }
            else
            {
                ViewBag.Message = "There was a problem logging you in";
                return View("../Home/Index");
            }

        }
    }
}