using LabNumber21Take2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabNumber21Take2.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            if (TempData["ErrorMessage"] != null)
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"];
            }
            ViewBag.Items = DAO.GetItemsAsList();
            return View();
        }

        public ActionResult LoginAdminPage()
        {
            return View();
        }

        public ActionResult LoginAdmin(UserLogin admin)
        {
            if (admin.Email == "rmlysogorski@gmail.com" && admin.Password == "P@ssword1")
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Admin password / email incorrect!";
                return View("../Home/Index");
            }
        }

        public ActionResult AddItemPage()
        {
            return View();
        }

        public ActionResult AddItemToDb(Item addMe)
        {
            bool success;
            if (ModelState.IsValid)
            {
                success = DAO.AddItem(addMe);
            }
            else
            {
                success = false;
            }

            if (!success)
            {
                TempData["ErrorMessage"] = "There is already an item with this name in the database.";
            }
            return RedirectToAction("Index");
        }

        public ActionResult DeleteItem(int ItemId)
        {
            DAO.DeleteItem(ItemId);
            return RedirectToAction("Index");
        }

        public ActionResult EditItemPage(int ItemId)
        {
            Item editMe = DAO.FindItem(ItemId);
            return View(editMe);
        }

        public ActionResult EditItem(Item editMe)
        {
            if (ModelState.IsValid)
            {
                DAO.EditItem(editMe);
            }

            return RedirectToAction("Index");
        }
    }
}