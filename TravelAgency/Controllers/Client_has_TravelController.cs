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
    public class Client_has_TravelController : Controller
    {
        private TravelAgencyDBEntities db = new TravelAgencyDBEntities();

        // GET: Client_has_Travel
        public ActionResult Index()
        {
            var client_has_Travels = db.client_has_Travels.Include(c => c.client).Include(c => c.Travel);
            return View(client_has_Travels.ToList());
        }

        // GET: Client_has_Travel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            client_has_Travels client_has_Travels = db.client_has_Travels.Find(id);
            if (client_has_Travels == null)
            {
                return HttpNotFound();
            }
            return View(client_has_Travels);
        }

        // GET: Client_has_Travel/Create
        public ActionResult Create()
        {
            ViewBag.client_id = new SelectList(db.clients, "id", "fullName");
            ViewBag.Travels_id = new SelectList(db.Travels, "id", "id");
            return View();
        }

        // POST: Client_has_Travel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,client_id,Travels_id")] client_has_Travels client_has_Travels)
        {
            if (ModelState.IsValid)
            {
                db.client_has_Travels.Add(client_has_Travels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.client_id = new SelectList(db.clients, "id", "fullName", client_has_Travels.client_id);
            ViewBag.Travels_id = new SelectList(db.Travels, "id", "id", client_has_Travels.Travels_id);
            return View(client_has_Travels);
        }

        // GET: Client_has_Travel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            client_has_Travels client_has_Travels = db.client_has_Travels.Find(id);
            if (client_has_Travels == null)
            {
                return HttpNotFound();
            }
            ViewBag.client_id = new SelectList(db.clients, "id", "fullName", client_has_Travels.client_id);
            ViewBag.Travels_id = new SelectList(db.Travels, "id", "id", client_has_Travels.Travels_id);
            return View(client_has_Travels);
        }

        // POST: Client_has_Travel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,client_id,Travels_id")] client_has_Travels client_has_Travels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client_has_Travels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.client_id = new SelectList(db.clients, "id", "fullName", client_has_Travels.client_id);
            ViewBag.Travels_id = new SelectList(db.Travels, "id", "id", client_has_Travels.Travels_id);
            return View(client_has_Travels);
        }

        // GET: Client_has_Travel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            client_has_Travels client_has_Travels = db.client_has_Travels.Find(id);
            if (client_has_Travels == null)
            {
                return HttpNotFound();
            }
            return View(client_has_Travels);
        }

        // POST: Client_has_Travel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            client_has_Travels client_has_Travels = db.client_has_Travels.Find(id);
            db.client_has_Travels.Remove(client_has_Travels);
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
