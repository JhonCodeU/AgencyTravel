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
    public class clientController : Controller
    {
        private const string URL = "http://localhost-webservices.com/api/";
        // GET: client

        public Client SearchClient(int? id)
        {
            var client = new RestClient(URL + "ClientApi/" + id);
            var request = new RestRequest(RestSharp.Method.GET);
            var response = client.Execute(request);
            var data = response.Content;
            Client clientOb = JsonConvert.DeserializeObject<Client>(data);

            return clientOb;
        }
        public ActionResult Index()
        {
            var client = new RestClient(URL + "ClientApi/");
            var request = new RestRequest(RestSharp.Method.GET);
            var response = client.Execute(request);
            var data = response.Content;
            var dataJson = JsonConvert.DeserializeObject<List<Client>>(data);
            return View(dataJson);
        }

        // GET: client/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = this.SearchClient(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: client/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fullName,email,phone,gender,address")] Client client)
        {
            if (ModelState.IsValid)
            {
                var clientUrl = new RestClient(URL + "ClientApi");
                var request = new RestRequest(RestSharp.Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("", JsonConvert.SerializeObject(client), ParameterType.RequestBody);
                var response = clientUrl.Execute(request);//
                return RedirectToAction("Index");
            }

            return View(client);
        }

        // GET: client/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = this.SearchClient(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: client/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fullName,email,phone,gender,address")] Client client)
        {
            if (ModelState.IsValid)
            {
                var clientUrl = new RestClient(URL + "travelApi" + client.id);
                var request = new RestRequest(RestSharp.Method.PUT);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("", JsonConvert.SerializeObject(client), ParameterType.RequestBody);
                var response = clientUrl.Execute(request);//
            }
            return View(client);
        }

        // GET: client/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = this.SearchClient(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var client = new RestClient(URL + "ClientApi" + id);
            var request = new RestRequest(RestSharp.Method.PUT);
            var response = client.Execute(request);//
            return RedirectToAction("Index");
        }
    }
}
