using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TravelAgency.Models;

namespace TravelAgency.Controllers
{
    public class TravelController : Controller
    {
        private TravelAgencyDBEntities db = new TravelAgencyDBEntities();

        // GET: Travel
        public ActionResult Index()
        {
            var travels = db.Travels.Include(t => t.Briefcase).Include(t => t.City).Include(t => t.City1);
            return View(travels.ToList());
        }

        // GET: Travel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Travel travel = db.Travels.Find(id);
            if (travel == null)
            {
                return HttpNotFound();
            }
            return View(travel);
        }

        // GET: Travel/Create
        public ActionResult Create()
        {
            ViewBag.briefcase_id = new SelectList(db.Briefcases, "id", "name");
            ViewBag.arrivalCity_id = new SelectList(db.Cities, "id", "name");
            ViewBag.originCity_id = new SelectList(db.Cities, "id", "name");
            return View();
        }

        // POST: Travel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,startDate,endDate,originCity_id,arrivalCity_id,briefcase_id")] Travel travel)
        {
            if (ModelState.IsValid)
            {
                db.Travels.Add(travel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.briefcase_id = new SelectList(db.Briefcases, "id", "name", travel.briefcase_id);
            ViewBag.arrivalCity_id = new SelectList(db.Cities, "id", "name", travel.arrivalCity_id);
            ViewBag.originCity_id = new SelectList(db.Cities, "id", "name", travel.originCity_id);
            return View(travel);
        }

        // GET: Travel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Travel travel = db.Travels.Find(id);
            if (travel == null)
            {
                return HttpNotFound();
            }
            ViewBag.briefcase_id = new SelectList(db.Briefcases, "id", "name", travel.briefcase_id);
            ViewBag.arrivalCity_id = new SelectList(db.Cities, "id", "name", travel.arrivalCity_id);
            ViewBag.originCity_id = new SelectList(db.Cities, "id", "name", travel.originCity_id);
            return View(travel);
        }

        // POST: Travel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,startDate,endDate,originCity_id,arrivalCity_id,briefcase_id")] Travel travel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(travel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.briefcase_id = new SelectList(db.Briefcases, "id", "name", travel.briefcase_id);
            ViewBag.arrivalCity_id = new SelectList(db.Cities, "id", "name", travel.arrivalCity_id);
            ViewBag.originCity_id = new SelectList(db.Cities, "id", "name", travel.originCity_id);
            return View(travel);
        }

        // GET: Travel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Travel travel = db.Travels.Find(id);
            if (travel == null)
            {
                return HttpNotFound();
            }
            return View(travel);
        }

        // POST: Travel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Travel travel = db.Travels.Find(id);
            db.Travels.Remove(travel);
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
