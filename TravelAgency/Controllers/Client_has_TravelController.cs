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
    public class Client_has_TravelController : Controller
    {
        private const string URL = "http://localhost-webservices.com/api/";
        // GET: Client_has_Travel
        public Client_Has_Travels SearchClient(int? id)
        {
            var client = new RestClient(URL + "Client_Has_TravelsApi/" + id);
            var request = new RestRequest(RestSharp.Method.GET);
            var response = client.Execute(request);
            var data = response.Content;
            Client_Has_Travels client_Has_Travelsel = JsonConvert.DeserializeObject<Client_Has_Travels>(data);

            return client_Has_Travelsel;
        }
        public ActionResult Index()
        {
            var client = new RestClient(URL + "Client_Has_TravelsApi/");
            var request = new RestRequest(RestSharp.Method.GET);
            var response = client.Execute(request);
            var data = response.Content;
            var dataJson = JsonConvert.DeserializeObject<List<Client_Has_Travels>>(data);
            return View(dataJson);
        }

        // GET: Client_has_Travel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client_Has_Travels client_has_Travels = this.SearchClient(id);
            if (client_has_Travels == null)
            {
                return HttpNotFound();
            }
            return View(client_has_Travels);
        }

        // GET: Client_has_Travel/Create
        public ActionResult Create()
        {
            //ViewBag.client_id = new SelectList(db.clients, "id", "fullName");
            //ViewBag.Travels_id = new SelectList(db.Travels, "id", "id");
            return View();
        }

        // POST: Client_has_Travel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,client_id,Travels_id")] Client_Has_Travels client_has_Travels)
        {
            if (ModelState.IsValid)
            {
                var client = new RestClient(URL + "Client_Has_TravelsApi");
                var request = new RestRequest(RestSharp.Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("", JsonConvert.SerializeObject(client_has_Travels), ParameterType.RequestBody);
                var response = client.Execute(request);//
                return RedirectToAction("Index");
            }

            //ViewBag.client_id = new SelectList(db.clients, "id", "fullName", client_has_Travels.client_id);
            //ViewBag.Travels_id = new SelectList(db.Travels, "id", "id", client_has_Travels.Travels_id);
            return View(client_has_Travels);
        }

        // GET: Client_has_Travel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client_Has_Travels client_has_Travels = this.SearchClient(id);
            if (client_has_Travels == null)
            {
                return HttpNotFound();
            }
            //ViewBag.client_id = new SelectList(db.clients, "id", "fullName", client_has_Travels.client_id);
            //ViewBag.Travels_id = new SelectList(db.Travels, "id", "id", client_has_Travels.Travels_id);
            return View(client_has_Travels);
        }

        // POST: Client_has_Travel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,client_id,Travels_id")] Client_Has_Travels client_has_Travels)
        {
            if (ModelState.IsValid)
            {
                var client = new RestClient(URL + "Client_Has_TravelsApi" + client_has_Travels.id);
                var request = new RestRequest(RestSharp.Method.PUT);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("", JsonConvert.SerializeObject(client_has_Travels), ParameterType.RequestBody);
                var response = client.Execute(request);//
            }
            //ViewBag.client_id = new SelectList(db.clients, "id", "fullName", client_has_Travels.client_id);
            //ViewBag.Travels_id = new SelectList(db.Travels, "id", "id", client_has_Travels.Travels_id);
            return View(client_has_Travels);
        }

        // GET: Client_has_Travel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client_Has_Travels client_has_Travels = this.SearchClient(id);
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
            var client = new RestClient(URL + "Client_Has_TravelApi" + id);
            var request = new RestRequest(RestSharp.Method.PUT);
            var response = client.Execute(request);//
            return RedirectToAction("Index");
        }
    }
}
