using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserSignupLoginMVC.Models;

namespace UserSignupLoginMVC.Controllers
{
	public class HomeController : Controller
	{
		DBUserSignupLoginEntities db = new DBUserSignupLoginEntities();
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

		public ActionResult Signup()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Signup(User user)
		{
			if (db.Users.Any(x => x.USR_NID == user.USR_NID))
			{
				ViewBag.Notification = "This national id already existed";
				return View();
			}
			db.Users.Add(user);
			db.SaveChanges();
			Session["UserID"] = user.USR_ID.ToString();
			return RedirectToAction("Index", "Home");
		}

		public ActionResult Logout()
		{
			Session.Clear();
			return RedirectToAction("Index", "Home");
		}
	}
}