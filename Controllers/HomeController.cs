using ChiaSeDuLich.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChiaSeDuLich.Controllers
{
    public class HomeController : Controller
    {
        private TravelShareDBContext db = new TravelShareDBContext();
        public ActionResult Index()
        {
            LoginController.isLogin = true;
            List<InforShare> listIf = db.InforShares.ToList();
            listIf.ForEach(e =>
            {
                List<Comment> listCms = db.Comments.Where(x => x.InforShareId == e.InforShareId).ToList();
                e.OwnComments = new List<Comment>();
                if (listCms != null)
                {
                    e.OwnComments.AddRange(listCms);
                }
                List<Rank> listRanks = db.Ranks.Where(x => x.InforShareId == e.InforShareId).ToList();
                e.RankAve = 0;
                if (listRanks?.Count > 0)
                {
                    e.RankAve = listRanks.Sum(x => x.Value) / listRanks.Count;
                }
            });
            return View(listIf);
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
    }
}