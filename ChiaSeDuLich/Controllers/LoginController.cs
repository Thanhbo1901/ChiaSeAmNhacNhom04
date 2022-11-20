using ChiaSeDuLich.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChiaSeDuLich.Controllers
{
    public class LoginController : Controller
    {
        public static bool isLogin = false;
        public static string userName = "Bsaturday";
        private TravelShareDBContext db = new TravelShareDBContext();
        // GET: Login
        public ActionResult Index()
        {
            isLogin = false;
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            if (!string.IsNullOrEmpty(user.UserName))
            {
                userName = user.UserName;
                if (user.UserName.ToLower() == "admin")
                {
                    isLogin = true;
                    return Json(new { Success = true, Data = user });
                }
                else
                {
                    User us = db.Users.Where(x => x.UserName == user.UserName && x.UserPass == user.UserPass).FirstOrDefault();
                    if (us != null)
                    {
                        isLogin = true;
                        return Json(new { Success = true, Data = us });
                    }
                    else
                    {
                        return Json(new { Success = false, Message = "Lỗi" });
                    }
                }

            }
            return Json(new { Success = false, Message = "Lỗi" });
        }
    }
}