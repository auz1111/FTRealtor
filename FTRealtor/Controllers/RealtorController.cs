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
        public ActionResult Index(string sortOrder, string NameSearchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var realtors = from s in db.Realtors
                           select s;
            if (!String.IsNullOrEmpty(NameSearchString))
            {
                realtors = realtors.Where(s => s.LastName.Contains(NameSearchString)
                                       || s.FirstMidName.Contains(NameSearchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    realtors = realtors.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    realtors = realtors.OrderBy(s => s.ListingDate);
                    break;
                case "date_desc":
                    realtors = realtors.OrderByDescending(s => s.ListingDate);
                    break;
                default:
                    realtors = realtors.OrderBy(s => s.LastName);
                    break;
            }
            return View(realtors.ToList());
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
        public ActionResult Create([Bind(Include = "ID,Username,Password,LastName,FirstMidName,ListingDate,DateListed")] Realtor realtor)
        {
            if (Request.IsAuthenticated)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        db.Realtors.Add(realtor);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                catch (DataException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }

                return View(realtor);

            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
        }

        // GET: Realtor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Request.IsAuthenticated)
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
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
        }

        // POST: Realtor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var studentToUpdate = db.Realtors.Find(id);
            if (TryUpdateModel(studentToUpdate, "",
               new string[] { "LastName", "FirstMidName", "Username", "Password", "DateListed" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (DataException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(studentToUpdate);
        }

        // GET: Realtor/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (Request.IsAuthenticated)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                if (saveChangesError.GetValueOrDefault())
                {
                    ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
                }
                Realtor realtor = db.Realtors.Find(id);
                if (realtor == null)
                {
                    return HttpNotFound();
                }
                return View(realtor);

            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
        }

        // POST: Realtor/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Realtor realtor = db.Realtors.Find(id);
                db.Realtors.Remove(realtor);
                db.SaveChanges();
            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
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
