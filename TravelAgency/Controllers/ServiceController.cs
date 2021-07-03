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
    public class ServiceController : Controller
    {
        private const string URL = "http://localhost-webservices.com/api/";

        // GET: Service
        public Service SearchService(int? id)
        {
            var client = new RestClient(URL + "ServiceApi/" + id);
            var request = new RestRequest(RestSharp.Method.GET);
            var response = client.Execute(request);
            var data = response.Content;
            Service service = JsonConvert.DeserializeObject<Service>(data);

            return service;
        }
        public ActionResult Index()
        {
            var client = new RestClient(URL + "ServiceApi/");
            var request = new RestRequest(RestSharp.Method.GET);
            var response = client.Execute(request);
            var data = response.Content;
            var dataJson = JsonConvert.DeserializeObject<List<Service>>(data);
            return View(dataJson);
        }

        // GET: Service/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = this.SearchService(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // GET: Service/Create
        public ActionResult Create()
        {
            //ViewBag.ServiceType_id = new SelectList(db.ServiceTypes, "id", "name");
            return View();
        }

        // POST: Service/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,descripcion,image,ServiceType_id")] Service service)
        {
            if (ModelState.IsValid)
            {
                var client = new RestClient(URL + "ServicesApi");
                var request = new RestRequest(RestSharp.Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("", JsonConvert.SerializeObject(service), ParameterType.RequestBody);
                var response = client.Execute(request);//
                return RedirectToAction("Index");
            }

            //ViewBag.ServiceType_id = new SelectList(db.ServiceTypes, "id", "name", service.ServiceType_id);
            return View(service);
        }

        // GET: Service/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = this.SearchService(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            //ViewBag.ServiceType_id = new SelectList(db.ServiceTypes, "id", "name", service.ServiceType_id);
            return View(service);
        }

        // POST: Service/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,descripcion,image,ServiceType_id")] Service service)
        {
            if (ModelState.IsValid)
            {
                var client = new RestClient(URL + "ServiceApi" + service.id);
                var request = new RestRequest(RestSharp.Method.PUT);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("", JsonConvert.SerializeObject(service), ParameterType.RequestBody);
                var response = client.Execute(request);//
            }
            //ViewBag.ServiceType_id = new SelectList(db.ServiceTypes, "id", "name", service.ServiceType_id);
            return View(service);
        }

        // GET: Service/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = this.SearchService(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // POST: Service/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var client = new RestClient(URL + "ServiceApi" + id);
            var request = new RestRequest(RestSharp.Method.PUT);
            var response = client.Execute(request);//
            return RedirectToAction("Index");
        }
    }
}
