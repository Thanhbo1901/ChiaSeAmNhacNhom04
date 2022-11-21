using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ChiaSeDuLich.Models;

namespace ChiaSeDuLich.Controllers
{
    public class InforSharesController : Controller
    {
        private TravelShareDBContext db = new TravelShareDBContext();

        // GET: InforShares
        public ActionResult Index()
        {
            LoginController.isLogin = true;
            return View(db.InforShares.ToList());
        }

        // GET: InforShares/Details/5
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

        // GET: InforShares/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InforShares/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InforShareId,InforShareTitle,InforShareContent,InforShareSource,UserId,UserName")] InforShare inforShare)
        {
            if (ModelState.IsValid)
            {
                inforShare.UserName = LoginController.userName;
                db.InforShares.Add(inforShare);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inforShare);
        }

        // GET: InforShares/Edit/5
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

        // POST: InforShares/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InforShareId,InforShareTitle,InforShareContent,InforShareSource,UserId,UserName")] InforShare inforShare)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inforShare).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inforShare);
        }

        // GET: InforShares/Delete/5
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

        // POST: InforShares/Delete/5
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
