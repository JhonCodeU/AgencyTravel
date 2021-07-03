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
    public class ServiceTypeController : Controller
    {
        private const string URL = "http://localhost-webservices.com/api/";

        // GET: ServiceType
        public ServiceType SearchServiceType(int? id)
        {
            var client = new RestClient(URL + "ServiceTypeApi/" + id);
            var request = new RestRequest(RestSharp.Method.GET);
            var response = client.Execute(request);
            var data = response.Content;
            ServiceType serviceType = JsonConvert.DeserializeObject<ServiceType>(data);

            return serviceType;
        }
        public ActionResult Index()
        {
            var client = new RestClient(URL + "ServiceTypeApi/");
            var request = new RestRequest(RestSharp.Method.GET);
            var response = client.Execute(request);
            var data = response.Content;
            var dataJson = JsonConvert.DeserializeObject<List<ServiceType>>(data);
            return View(dataJson);
        }

        // GET: ServiceType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceType serviceType = this.SearchServiceType(id);
            if (serviceType == null)
            {
                return HttpNotFound();
            }
            return View(serviceType);
        }

        // GET: ServiceType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServiceType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name")] ServiceType serviceType)
        {
            if (ModelState.IsValid)
            {
                var client = new RestClient(URL + "ServiceTypeApi");
                var request = new RestRequest(RestSharp.Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("", JsonConvert.SerializeObject(serviceType), ParameterType.RequestBody);
                var response = client.Execute(request);//
                return RedirectToAction("Index");

            }

            return View(serviceType);
        }

        // GET: ServiceType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceType serviceType = this.SearchServiceType(id);
            if (serviceType == null)
            {
                return HttpNotFound();
            }
            return View(serviceType);
        }

        // POST: ServiceType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name")] ServiceType serviceType)
        {
            if (ModelState.IsValid)
            {
                var client = new RestClient(URL + "ServiceTypeApi" + serviceType.id);
                var request = new RestRequest(RestSharp.Method.PUT);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("", JsonConvert.SerializeObject(serviceType), ParameterType.RequestBody);
                var response = client.Execute(request);//
            }
            return View(serviceType);
        }

        // GET: ServiceType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceType serviceType = this.SearchServiceType(id);
            if (serviceType == null)
            {
                return HttpNotFound();
            }
            return View(serviceType);
        }

        // POST: ServiceType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var client = new RestClient(URL + "ServiceTypeApi" + id);
            var request = new RestRequest(RestSharp.Method.PUT);
            var response = client.Execute(request);//
            return RedirectToAction("Index");
        }
    }
}
