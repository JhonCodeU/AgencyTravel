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
    public class ServiceTypeApiController : ApiController
    {
        private TravelAgencyDBEntities db = new TravelAgencyDBEntities();

        // GET: api/ServiceType
        public IQueryable<ServiceType> GetServiceTypes()
        {
            return db.ServiceTypes;
        }

        // GET: api/ServiceType/5
        [ResponseType(typeof(ServiceType))]
        public IHttpActionResult GetServiceType(int id)
        {
            ServiceType serviceType = db.ServiceTypes.Find(id);
            if (serviceType == null)
            {
                return NotFound();
            }

            return Ok(serviceType);
        }

        // PUT: api/ServiceType/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutServiceType(int id, ServiceType serviceType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != serviceType.id)
            {
                return BadRequest();
            }

            db.Entry(serviceType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceTypeExists(id))
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

        // POST: api/ServiceType
        [ResponseType(typeof(ServiceType))]
        public IHttpActionResult PostServiceType(ServiceType serviceType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ServiceTypes.Add(serviceType);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ServiceTypeExists(serviceType.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = serviceType.id }, serviceType);
        }

        // DELETE: api/ServiceType/5
        [ResponseType(typeof(ServiceType))]
        public IHttpActionResult DeleteServiceType(int id)
        {
            ServiceType serviceType = db.ServiceTypes.Find(id);
            if (serviceType == null)
            {
                return NotFound();
            }

            db.ServiceTypes.Remove(serviceType);
            db.SaveChanges();

            return Ok(serviceType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ServiceTypeExists(int id)
        {
            return db.ServiceTypes.Count(e => e.id == id) > 0;
        }
    }
}