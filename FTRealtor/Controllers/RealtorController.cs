using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FTRealtor.DAL;
using FTRealtor.Models;

namespace FTRealtor.Controllers
{
    public class RealtorController : Controller
    {
        private AgencyContext db = new AgencyContext();

        // GET: Realtor
        public ActionResult Index()
        {
            return View(db.Realtors.ToList());
        }

        // GET: Realtor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Realtor realtor = db.Realtors.Find(id);
            if (realtor == null)
            {
                return HttpNotFound();
            }
            return View(realtor);
        }

        // GET: Realtor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Realtor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Username,Password,LastName,FirstMidName,ListingDate")] Realtor realtor)
        {
            if (ModelState.IsValid)
            {
                db.Realtors.Add(realtor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(realtor);
        }

        // GET: Realtor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Realtor realtor = db.Realtors.Find(id);
            if (realtor == null)
            {
                return HttpNotFound();
            }
            return View(realtor);
        }

        // POST: Realtor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Username,Password,LastName,FirstMidName,ListingDate")] Realtor realtor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(realtor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(realtor);
        }

        // GET: Realtor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Realtor realtor = db.Realtors.Find(id);
            if (realtor == null)
            {
                return HttpNotFound();
            }
            return View(realtor);
        }

        // POST: Realtor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Realtor realtor = db.Realtors.Find(id);
            db.Realtors.Remove(realtor);
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
