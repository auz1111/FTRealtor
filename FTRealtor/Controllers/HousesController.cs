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
    public class HousesController : Controller
    {
        private AgencyContext db = new AgencyContext();

        // GET: Houses
        public ActionResult Index(int? MLSSearchInt, string Street1SearchString, string Street2SearchString, string CitySearchString, string StateSearchString, string ZipSearchString, int? BedroomsSearchInt, int? BathroomsSearchInt, int? SQFTSearchInt)
        {
            var houses = from s in db.Houses
                           select s;
            if (MLSSearchInt != null)
            {
                houses = houses.Where(s => s.MLSNum == MLSSearchInt);
            }

            if (!String.IsNullOrEmpty(Street1SearchString))
            {
                houses = houses.Where(s => s.Street1.Contains(Street1SearchString));
            }

            if (!String.IsNullOrEmpty(Street2SearchString))
            {
                houses = houses.Where(s => s.Street2.Contains(Street2SearchString));
            }

            if (!String.IsNullOrEmpty(CitySearchString))
            {
                houses = houses.Where(s => s.City.Contains(CitySearchString));
            }

            if (!String.IsNullOrEmpty(ZipSearchString))
            {
                houses = houses.Where(s => s.Zip.Contains(ZipSearchString));
            }

            if (BedroomsSearchInt != null)
            {
                houses = houses.Where(s => s.Bedrooms == BedroomsSearchInt);
            }

            if (BathroomsSearchInt != null)
            {
                houses = houses.Where(s => s.Bathrooms == BathroomsSearchInt);
            }

            if (SQFTSearchInt != null)
            {
                houses = houses.Where(s => s.SquareFeet == SQFTSearchInt);
            }

           
            return View(houses);
        }

        // GET: Houses/Details/5
        public ActionResult Details(int? id)
        {

            if(Request.IsAuthenticated)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                House house = db.Houses.Find(id);
                if (house == null)
                {
                    return HttpNotFound();
                }
                return View(house);
            }else
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
        }

        // GET: Houses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Houses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HouseID,Title,MLSNum,Street1,Street2,City,State,Zip,Neighborhood,SalesPrice,DateListed,Bedrooms,Bathrooms,Photos,GarageSize,SquareFeet,LotSize,Description")] House house)
        {

            if (Request.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    db.Houses.Add(house);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(house);
            }else
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
        }

        // GET: Houses/Edit/5
        public ActionResult Edit(int? id)
        {

            if (Request.IsAuthenticated)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                House house = db.Houses.Find(id);
                if (house == null)
                {
                    return HttpNotFound();
                }
                return View(house);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
        }

        // POST: Houses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HouseID,Title,MLSNum,Street1,Street2,City,State,Zip,Neighborhood,SalesPrice,DateListed,Bedrooms,Bathrooms,Photos,GarageSize,SquareFeet,LotSize,Description")] House house)
        {
            if (ModelState.IsValid)
            {
                db.Entry(house).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(house);
        }

        // GET: Houses/Delete/5
        public ActionResult Delete(int? id)
        {

            if (Request.IsAuthenticated)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                House house = db.Houses.Find(id);
                if (house == null)
                {
                    return HttpNotFound();
                }
                return View(house);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
        }

        // POST: Houses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            House house = db.Houses.Find(id);
            db.Houses.Remove(house);
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
