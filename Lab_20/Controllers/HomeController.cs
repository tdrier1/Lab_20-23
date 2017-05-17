using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab_20.Models;

namespace Lab_20.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           ViewBag.Names = GetAllNames();
           ViewBag.ItemInfo = GetAllItems();

            return View();
        }

        public ActionResult SearchItems(string SearchItems)
        {
            CoffeeShopDBEntities3 DB = new CoffeeShopDBEntities3();

            List<Item> ItemList = DB.Items.Where(x => x.Description.ToUpper().Contains(SearchItems.ToUpper())).ToList();

            ViewBag.Names = GetAllNames();
            ViewBag.ItemInfo = ItemList;

            return View("Index");
        }

        public List<string> GetAllNames()
        {
            CoffeeShopDBEntities3 DB = new CoffeeShopDBEntities3();

            return DB.Items.Select(x => x.Description).Distinct().ToList();
        }

        public List<Item> GetAllItems()
        {
            CoffeeShopDBEntities3 DB = new CoffeeShopDBEntities3();

            List<Item> ItemInfo = DB.Items.ToList();

            return ItemInfo;
        }

        public ActionResult Registration()
        {
            return View();
        }

        public ActionResult ItemDetails()
        {
            return View();
        }

        public ActionResult AddUser(Customer NewUser)
        {
            CoffeeShopDBEntities3 DB = new CoffeeShopDBEntities3();

            DB.Customers.Add(NewUser);

            DB.SaveChanges();

            return View("AddUserScreen");

            //to add the data from the model to the db

            //pass the NewUser model to the AddUser view
           
        }

        public ActionResult Admin()
        {
            CoffeeShopDBEntities3 DB = new CoffeeShopDBEntities3();

            List<Item> ItemInfo = DB.Items.ToList();

            ViewBag.Names = GetAllNames();
            ViewBag.ItemInfo = ItemInfo;
            

            return View();
        }

        public ActionResult DeleteItem(string DeleteName)
        {
            CoffeeShopDBEntities3 DB = new CoffeeShopDBEntities3();

            Item ToDelete = DB.Items.Find(DeleteName);

            DB.Items.Remove(ToDelete);

            DB.SaveChanges();

            return RedirectToAction("Admin", "Home");
        }

        public ActionResult UpdateItem(string UpdateName)
        {
            CoffeeShopDBEntities3 DB = new CoffeeShopDBEntities3();

            Item FindItem = DB.Items.Find(UpdateName);

            return View("ItemDetails", FindItem);
        }

        public ActionResult SaveItemUpdate(Item ToBeUpdated)
        {
            if(Session["Authenticated"]!=null && (bool)Session["Authenticated"] == true)
            {
                CoffeeShopDBEntities3 DB = new CoffeeShopDBEntities3();

                Item FindItem = DB.Items.Find(ToBeUpdated.Name);

                FindItem.Name = ToBeUpdated.Name;
                FindItem.Description = ToBeUpdated.Description;
                FindItem.Quantity = ToBeUpdated.Quantity;
                FindItem.Price = ToBeUpdated.Price;

                DB.SaveChanges();

                return RedirectToAction("Admin");
            }
            else
            {
                return View("Login");
            }
            
        }

        public ActionResult SaveNewItem(Item NewItem)
        {
            CoffeeShopDBEntities3 DB = new CoffeeShopDBEntities3();

            DB.Items.Add(NewItem);

            DB.SaveChanges();

            return RedirectToAction("Admin");
        }

        public ActionResult AddItem()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult AdminLogin()
        {
            return View();
        }

        public ActionResult AddUserScreen()
        {
            ViewBag.Names = GetAllNames();
            ViewBag.ItemInfo = GetAllItems();

            return View();
        }

        public ActionResult PurchaseItem(string PurchaseName)
        {
            CoffeeShopDBEntities3 DB = new CoffeeShopDBEntities3();

            Item FindItem = DB.Items.Find(PurchaseName);

            return View("AddUserScreen", FindItem);
        }

        public ActionResult SavePurchaseItem(string PurchaseName)
        {
            CoffeeShopDBEntities3 DB = new CoffeeShopDBEntities3();

            Item FindItem = DB.Items.Find(PurchaseName);

            int count = Convert.ToInt32(FindItem.Quantity);

            int newcount = (count - 1);

            FindItem.Quantity = Convert.ToString(newcount);

            DB.SaveChanges();
            
            return RedirectToAction("AddUserScreen", "Home");
        }
    }
}