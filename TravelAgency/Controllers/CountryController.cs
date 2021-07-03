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
    public class CountryController : Controller
    {
        private const string URL = "http://localhost-webservices.com/api/";
        // GET: Country

        public Country SearchCountry(int? id)
        {
            var client = new RestClient(URL + "TravelApi/" + id);
            var request = new RestRequest(RestSharp.Method.GET);
            var response = client.Execute(request);
            var data = response.Content;
            Country country = JsonConvert.DeserializeObject<Country>(data);

            return country;
        }
        public ActionResult Index()
        {
            var client = new RestClient(URL + "CountryApi/");
            var request = new RestRequest(RestSharp.Method.GET);
            var response = client.Execute(request);
            var data = response.Content;
            var dataJson = JsonConvert.DeserializeObject<List<Country>>(data);
            return View(dataJson);
        }

        // GET: Country/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = this.SearchCountry(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        // GET: Country/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Country/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,description")] Country country)
        {
            if (ModelState.IsValid)
            {
                var client = new RestClient(URL + "CountryApi");
                var request = new RestRequest(RestSharp.Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("", JsonConvert.SerializeObject(country), ParameterType.RequestBody);
                var response = client.Execute(request);//
                return RedirectToAction("Index");
            }

            return View(country);
        }

        // GET: Country/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = this.SearchCountry(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        // POST: Country/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,description")] Country country)
        {
            if (ModelState.IsValid)
            {
                var client = new RestClient(URL + "CountryApi" + country.id);
                var request = new RestRequest(RestSharp.Method.PUT);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("", JsonConvert.SerializeObject(country), ParameterType.RequestBody);
                var response = client.Execute(request);//
            }
            return View(country);
        }

        // GET: Country/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = this.SearchCountry(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        // POST: Country/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var client = new RestClient(URL + "CountryApi" + id);
            var request = new RestRequest(RestSharp.Method.PUT);
            var response = client.Execute(request);//
            return RedirectToAction("Index");
        }
    }
}
