using AgencyLibrary.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace TravelAgency.Controllers
{
    public class BriefcaseController : Controller
    {
        private const string URL = "http://localhost-webservices.com/api/";
        // GET: Briefcase

        public Briefcase SearchBriefcase(int? id)
        {
            var client = new RestClient(URL + "BriefcaseApi/" + id);
            var request = new RestRequest(RestSharp.Method.GET);
            var response = client.Execute(request);
            var data = response.Content;
            Briefcase travel = JsonConvert.DeserializeObject<Briefcase>(data);

            return travel;
        }
        public ActionResult Index()
        {
            var client = new RestClient(URL + "BriefcaseApi/");
            var request = new RestRequest(RestSharp.Method.GET);
            var response = client.Execute(request);
            var data = response.Content;
            var dataJson = JsonConvert.DeserializeObject<List<Briefcase>>(data);
            return View(dataJson);
        }

        // GET: Briefcase/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Briefcase briefcase = this.SearchBriefcase(id);
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
                var client = new RestClient(URL + "BriefcaseApi");
                var request = new RestRequest(RestSharp.Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("", JsonConvert.SerializeObject(briefcase), ParameterType.RequestBody);
                var response = client.Execute(request);//
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
            Briefcase briefcase = SearchBriefcase(id);
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
                var client = new RestClient(URL + "BriefcaseApi" + briefcase.id);
                var request = new RestRequest(RestSharp.Method.PUT);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("", JsonConvert.SerializeObject(briefcase), ParameterType.RequestBody);
                var response = client.Execute(request);//

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
            Briefcase briefcase = this.SearchBriefcase(id);
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
            var client = new RestClient(URL + "BriefcaseApi" + id);
            var request = new RestRequest(RestSharp.Method.PUT);
            var response = client.Execute(request);//
            return RedirectToAction("Index");
        }
    }
}
