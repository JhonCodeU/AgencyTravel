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
    public class BriefcaseApiController : ApiController
    {
        private TravelAgencyDBEntities db = new TravelAgencyDBEntities();

        // GET: api/Briefcase
        public IQueryable<Briefcase> GetBriefcases()
        {
            return db.Briefcases;
        }

        // GET: api/Briefcase/5
        [ResponseType(typeof(Briefcase))]
        public IHttpActionResult GetBriefcase(int id)
        {
            Briefcase briefcase = db.Briefcases.Find(id);
            if (briefcase == null)
            {
                return NotFound();
            }

            return Ok(briefcase);
        }

        // PUT: api/Briefcase/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBriefcase(int id, Briefcase briefcase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != briefcase.id)
            {
                return BadRequest();
            }

            db.Entry(briefcase).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BriefcaseExists(id))
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

        // POST: api/Briefcase
        [ResponseType(typeof(Briefcase))]
        public IHttpActionResult PostBriefcase(Briefcase briefcase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Briefcases.Add(briefcase);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (BriefcaseExists(briefcase.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = briefcase.id }, briefcase);
        }

        // DELETE: api/Briefcase/5
        [ResponseType(typeof(Briefcase))]
        public IHttpActionResult DeleteBriefcase(int id)
        {
            Briefcase briefcase = db.Briefcases.Find(id);
            if (briefcase == null)
            {
                return NotFound();
            }

            db.Briefcases.Remove(briefcase);
            db.SaveChanges();

            return Ok(briefcase);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BriefcaseExists(int id)
        {
            return db.Briefcases.Count(e => e.id == id) > 0;
        }
    }
}