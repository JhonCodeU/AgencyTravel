using AgencyData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebServiceAgency.Controllers
{
    public class Client_has_TravelApiController : ApiController
    {
        private TravelAgencyDBEntities db = new TravelAgencyDBEntities();

        // GET: api/Client_has_Travel
        public IQueryable<client_has_Travels> Getclient_has_Travels()
        {
            return db.client_has_Travels;
        }

        // GET: api/Client_has_Travel/5
        [ResponseType(typeof(client_has_Travels))]
        public IHttpActionResult Getclient_has_Travels(int id)
        {
            client_has_Travels client_has_Travels = db.client_has_Travels.Find(id);
            if (client_has_Travels == null)
            {
                return NotFound();
            }

            return Ok(client_has_Travels);
        }

        // PUT: api/Client_has_Travel/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putclient_has_Travels(int id, client_has_Travels client_has_Travels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != client_has_Travels.id)
            {
                return BadRequest();
            }

            db.Entry(client_has_Travels).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!client_has_TravelsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Client_has_Travel
        [ResponseType(typeof(client_has_Travels))]
        public IHttpActionResult Postclient_has_Travels(client_has_Travels client_has_Travels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.client_has_Travels.Add(client_has_Travels);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = client_has_Travels.id }, client_has_Travels);
        }

        // DELETE: api/Client_has_Travel/5
        [ResponseType(typeof(client_has_Travels))]
        public IHttpActionResult Deleteclient_has_Travels(int id)
        {
            client_has_Travels client_has_Travels = db.client_has_Travels.Find(id);
            if (client_has_Travels == null)
            {
                return NotFound();
            }

            db.client_has_Travels.Remove(client_has_Travels);
            db.SaveChanges();

            return Ok(client_has_Travels);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool client_has_TravelsExists(int id)
        {
            return db.client_has_Travels.Count(e => e.id == id) > 0;
        }
    }
}