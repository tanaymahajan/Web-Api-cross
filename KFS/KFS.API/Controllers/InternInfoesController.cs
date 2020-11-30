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
using KFS.BAL;

namespace KFS.API.Controllers
{
    public class InternInfoesController : ApiController
    {
        private praticedbEntities db = new praticedbEntities();

        // GET: api/InternInfoes
        public IQueryable<InternInfo> GetInternInfoes()
        {
            return db.InternInfoes;
        }

        // GET: api/InternInfoes/5
        [ResponseType(typeof(InternInfo))]
        public IHttpActionResult GetInternInfo(int id)
        {
            InternInfo internInfo = db.InternInfoes.Find(id);
            if (internInfo == null)
            {
                return NotFound();
            }

            return Ok(internInfo);
        }

        // PUT: api/InternInfoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInternInfo(int id, InternInfo internInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != internInfo.Id)
            {
                return BadRequest();
            }

            db.Entry(internInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InternInfoExists(id))
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

        // POST: api/InternInfoes
        [ResponseType(typeof(InternInfo))]
        public IHttpActionResult PostInternInfo(InternInfo internInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.InternInfoes.Add(internInfo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = internInfo.Id }, internInfo);
        }

        // DELETE: api/InternInfoes/5
        [ResponseType(typeof(InternInfo))]
        public IHttpActionResult DeleteInternInfo(int id)
        {
            InternInfo internInfo = db.InternInfoes.Find(id);
            if (internInfo == null)
            {
                return NotFound();
            }

            db.InternInfoes.Remove(internInfo);
            db.SaveChanges();

            return Ok(internInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InternInfoExists(int id)
        {
            return db.InternInfoes.Count(e => e.Id == id) > 0;
        }
    }
}