using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab_20.Models;

namespace Lab_20.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Authorize(Customer Creds)
        {
            CoffeeShopDBEntities3 db = new CoffeeShopDBEntities3();

            var user = db.Customers.Where(x => x.Email == Creds.Email && x.Password == Creds.Password).FirstOrDefault();
            if(user == null)
            {
                ViewBag.ErrorMessage = "Enter Values!";
                return View("Index");
            }
            else
            {
                Session.Add("Authenticated", true);
                return RedirectToAction("AddUserScreen", "Home");
            }
            
        }

        public ActionResult AdminPwd(string pwd)
        {

            if (pwd == "000")
            {
                return RedirectToAction("Admin", "Home");

            }
            else
            {
                ViewBag.ErrorMessage = "Wrong Values!";
                return View("Index");
            }
        }
    }
}