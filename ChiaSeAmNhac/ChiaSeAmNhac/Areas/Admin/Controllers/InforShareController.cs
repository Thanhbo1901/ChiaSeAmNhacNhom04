using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ChiaSeDuLich.Models;

namespace ChiaSeDuLich.Areas.Admin.Controllers
{
    public class InforShareController : Controller
    {
        private TravelShareDBContext db = new TravelShareDBContext();

        // GET: Admin/InforShare
        public ActionResult Index()
        {
            return View(db.InforShares.ToList());
        }

        // GET: Admin/InforShare/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InforShare inforShare = db.InforShares.Find(id);
            if (inforShare == null)
            {
                return HttpNotFound();
            }
            return View(inforShare);
        }
        [HttpGet]
        public ActionResult DetailsIf(int? id)
        {
            InforShare inforShare = db.InforShares.Find(id);
            List<Comment> listCms = db.Comments.Where(x => x.InforShareId == inforShare.InforShareId).ToList();
            inforShare.OwnComments = new List<Comment>();
            if (listCms != null)
            {
                inforShare.OwnComments.AddRange(listCms);
            }
            inforShare.RankAve = 0;
            List<Rank> listRanks = db.Ranks.Where(x => x.InforShareId == inforShare.InforShareId).ToList();
            if (listRanks?.Count > 0)
            {
                inforShare.RankAve = listRanks.Sum(x => x.Value) / listRanks.Count;
            }
            return Json(new { Success = true, Data = inforShare }, JsonRequestBehavior.AllowGet);
        }

        // GET: Admin/InforShare/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/InforShare/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InforShareId,InforShareTitle,InforShareContent,InforShareSource,UserId,UserName")] InforShare inforShare)
        {
            if (ModelState.IsValid)
            {
                db.InforShares.Add(inforShare);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inforShare);
        }

        // GET: Admin/InforShare/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InforShare inforShare = db.InforShares.Find(id);
            if (inforShare == null)
            {
                return HttpNotFound();
            }
            return View(inforShare);
        }

        // POST: Admin/InforShare/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InforShareId,InforShareTitle,InforShareContent,InforShareSource,UserId,UserName")] InforShare inforShare)
        {
            var file = inforShare.InforShareSource;
            if (ModelState.IsValid)
            {
                db.Entry(inforShare).State = EntityState.Modified;
                if (string.IsNullOrEmpty(inforShare.InforShareSource))
                {
                    db.Entry(inforShare).Property(x => x.InforShareSource).IsModified = false;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inforShare);
        }

        // GET: Admin/InforShare/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InforShare inforShare = db.InforShares.Find(id);
            if (inforShare == null)
            {
                return HttpNotFound();
            }
            return View(inforShare);
        }

        // POST: Admin/InforShare/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InforShare inforShare = db.InforShares.Find(id);
            db.InforShares.Remove(inforShare);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
