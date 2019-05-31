using LabNumber21Take2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabNumber21Take2.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop

        public ActionResult Index()
        {
            if (TempData["SearchResults"] != null)
            {
                ViewBag.Items = TempData["SearchResults"];
            }
            else
            {
                ViewBag.Items = DAO.GetItemsAsList();
            }

            return View();
        }

        public ActionResult SearchItems(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                TempData["SearchResults"] = DAO.SearchNames(searchString);
            }

            return RedirectToAction("Index");
        }
    }
}