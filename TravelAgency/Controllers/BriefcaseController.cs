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
    public class BriefcaseController : Controller
    {
        private TravelAgencyDBEntities db = new TravelAgencyDBEntities();

        // GET: Briefcase
        public ActionResult Index()
        {
            return View(db.Briefcases.ToList());
        }

        // GET: Briefcase/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Briefcase briefcase = db.Briefcases.Find(id);
            if (briefcase == null)
            {
                return HttpNotFound();
            }
            return View(briefcase);
        }

        // GET: Briefcase/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Briefcase/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,description,price,Travels_id")] Briefcase briefcase)
        {
            if (ModelState.IsValid)
            {
                db.Briefcases.Add(briefcase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(briefcase);
        }

        // GET: Briefcase/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Briefcase briefcase = db.Briefcases.Find(id);
            if (briefcase == null)
            {
                return HttpNotFound();
            }
            return View(briefcase);
        }

        // POST: Briefcase/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,description,price,Travels_id")] Briefcase briefcase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(briefcase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(briefcase);
        }

        // GET: Briefcase/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Briefcase briefcase = db.Briefcases.Find(id);
            if (briefcase == null)
            {
                return HttpNotFound();
            }
            return View(briefcase);
        }

        // POST: Briefcase/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Briefcase briefcase = db.Briefcases.Find(id);
            db.Briefcases.Remove(briefcase);
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
