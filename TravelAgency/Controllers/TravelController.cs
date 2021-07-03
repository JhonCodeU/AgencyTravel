using AgencyData;
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
    public class TravelController : Controller
    {
        private const string URL = "http://localhost:81/servicio_ucaldas/api/";
        // GET: Travel
        public Travel SearchTravel(int? id)
        {
            var client = new RestClient(URL + "TravelApi/" + id);
            var request = new RestRequest(RestSharp.Method.GET);
            var response = client.Execute(request);
            var data = response.Content;
            Travel travel = JsonConvert.DeserializeObject<Travel>(data);

            return travel;
        }
        public ActionResult Index()
        {
            var client = new RestClient(URL + "TravelApi/");
            var request = new RestRequest(RestSharp.Method.GET);
            var response = client.Execute(request);
            var data = response.Content;
            var dataJson = JsonConvert.DeserializeObject<List<Travel>>(data);
            return View(dataJson);
        }

        // GET: Travel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Travel travel = SearchTravel(id);
            if (travel == null)
            {
                return HttpNotFound();
            }
            return View(travel);
        }

        // GET: Travel/Create
        public ActionResult Create()
        {
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
                var client = new RestClient(URL + "TravelApi");
                var request = new RestRequest(RestSharp.Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("", JsonConvert.SerializeObject(travel), ParameterType.RequestBody);
                var response = client.Execute(request);//
                return RedirectToAction("Index");
            }

            return View(travel);
        }

        // GET: Travel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Travel travel = this.SearchTravel(id);
            if (travel == null)
            {
                return HttpNotFound();
            }
            //ViewBag.briefcase_id = new SelectList(db.Briefcases, "id", "name", travel.briefcase_id);
            //ViewBag.arrivalCity_id = new SelectList(db.Cities, "id", "name", travel.arrivalCity_id);
            //ViewBag.originCity_id = new SelectList(db.Cities, "id", "name", travel.originCity_id);
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
                var client = new RestClient(URL + "travelApi" + travel.id);
                var request = new RestRequest(RestSharp.Method.PUT);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("", JsonConvert.SerializeObject(travel), ParameterType.RequestBody);
                var response = client.Execute(request);//
            }
            //ViewBag.briefcase_id = new SelectList(db.Briefcases, "id", "name", travel.briefcase_id);
            //ViewBag.arrivalCity_id = new SelectList(db.Cities, "id", "name", travel.arrivalCity_id);
            //ViewBag.originCity_id = new SelectList(db.Cities, "id", "name", travel.originCity_id);
            return View(travel);
        }

        // GET: Travel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Travel travel = this.SearchTravel(id);
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
            var client = new RestClient(URL + "travelApi" + id);
            var request = new RestRequest(RestSharp.Method.PUT);
            var response = client.Execute(request);//
            return RedirectToAction("Index");
        }
    }
}
