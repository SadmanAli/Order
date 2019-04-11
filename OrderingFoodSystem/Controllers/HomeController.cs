using OrderingFoodSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderingFoodSystem.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		public ActionResult Restaurant()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
		public ActionResult RestaurantP()
		{
			return View();
		}

		public ActionResult Item()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		public ActionResult OrderInformation()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}


		[HttpGet]
		public ActionResult Register()
		{
			if (Session["UserId"] == null)
			{
				return View();
			}
			else
			{
				return RedirectToAction("Profile");
			}

		}

		[HttpPost]
		public ActionResult Register(FormCollection collection)
		{
			bool filledUp = true;
			foreach (string key in collection.AllKeys)
			{
				if (key.StartsWith("_")) continue;

				/*
                Response.Write("Key = " + key + " , ");
                Response.Write("Value = " + collection[key]);
                Response.Write("<br/>");
                */
				if (collection[key] == "") filledUp = false;
			}

			if (filledUp)
			{

				Registration p = new Registration
				{
					CustomerName = collection["CustomerName"],
					Phonenumber = collection["Phonenumber"],
					Email = collection["Email"],
					DeliveryAddress = collection["DeliveryAddress"],
					UserName = collection["UserName"],
					Password = collection["Password"]
				};

				FoodOrderContext foodOrderContext = new FoodOrderContext();
				foodOrderContext.Registrations.Add(p);
				foodOrderContext.SaveChanges();

				Session["UserId"] = p.CustomerID.ToString();
				Session["UserName"] = p.CustomerName.ToString();
				return View("Profile");
			}

			return View();
		}


		public ActionResult Login()
		{
			if (Session["UserId"] == null)
			{
				return View();
			}
			else
			{
				return View("Profile");
			}
		}

		[HttpPost]
		public ActionResult Login(FormCollection collection)
		{
			if (Session["UserId"] == null)
			{
				FoodOrderContext db = new FoodOrderContext();

				string username = collection["UserName"];
				string password = collection["Password"];

				Registration p = null;
				try
				{
					p = db.Registrations.Single(u => u.UserName == username && u.Password == password);
				}
				catch (Exception ex) { }

				if (p != null)
				{
					Session["UserId"] = p.CustomerID.ToString();
					Session["Username"] = p.CustomerName.ToString();
					return View("Profile");
				}
				else
				{
					ModelState.AddModelError("", "Incorrect username or password");
					return View();
				}
			}
			else
			{
				return View("Profile");
			}

		}

		public ActionResult LoggedIn()
		{
			if (Session["UserId"] != null)
			{
				return View("Profile");
			}
			else
			{
				RedirectToAction("Login");
				return View("Login");
			}

		}

		public ActionResult Logout()
		{
			Session.Clear();
			return RedirectToAction("Index");
		}
		public ActionResult Profile()
		{
			if (Session["UserId"] == null)
			{
				return RedirectToAction("Login");
			}
			else
			{
				return View();
			}
		}
		[HttpPost]
		public ActionResult Profile(FormCollection collection)
		{
			if (Session["UserId"] == null)
			{
				return RedirectToAction("Login");
			}
			else
			{
				
				return RedirectToAction("Profile");
			}
		}
		public ActionResult CustomerAccountInfo()
		{
			if (Session["UserId"] == null)
			{
				return RedirectToAction("Login");
			}
			else
			{
				FoodOrderContext hc = new FoodOrderContext();
				Registration p = hc.Registrations.Find(Int32.Parse(Session["UserId"].ToString()));

				return View(p);
			}
		}


	}
}