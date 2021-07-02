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
using WebServiceAgency.Models;

namespace WebServiceAgency.Controllers
{
    public class ClientApiController : ApiController
    {
        private TravelAgencyDBEntitiesDBB db = new TravelAgencyDBEntitiesDBB();

        // GET: api/Client
        public IQueryable<client> Getclients()
        {
            return db.clients;
        }

        // GET: api/Client/5
        [ResponseType(typeof(client))]
        public IHttpActionResult Getclient(int id)
        {
            client client = db.clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        // PUT: api/Client/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putclient(int id, client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != client.id)
            {
                return BadRequest();
            }

            db.Entry(client).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!clientExists(id))
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

        // POST: api/Client
        [ResponseType(typeof(client))]
        public IHttpActionResult Postclient(client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.clients.Add(client);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = client.id }, client);
        }

        // DELETE: api/Client/5
        [ResponseType(typeof(client))]
        public IHttpActionResult Deleteclient(int id)
        {
            client client = db.clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            db.clients.Remove(client);
            db.SaveChanges();

            return Ok(client);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool clientExists(int id)
        {
            return db.clients.Count(e => e.id == id) > 0;
        }
    }
}