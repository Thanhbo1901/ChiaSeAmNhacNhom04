using ChiaSeDuLich.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChiaSeDuLich.Controllers
{
    public class SigninController : Controller
    {
        private TravelShareDBContext db = new TravelShareDBContext();
        // GET: Signin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string tendangnhap, string matkhau, string matkhaulai)
        {
            if (matkhau.Equals(matkhaulai))
            {
                User us = new User();
                us.UserName = tendangnhap;
                us.UserPass = matkhau;
                us.UserPhone = "0988128548";
                us.UserRole = 0;
                if (ModelState.IsValid)
                {
                    db.Users.Add(us);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Login");
                }
            }
            return View();
        }
    }
}