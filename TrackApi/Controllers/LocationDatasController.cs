using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using TrackApi;
using TrackApi.Models;

namespace TrackApi.Controllers
{
    //[EnableCors("*","*","*")]
    public class LocationsController : ApiController
    {
        private TrackApiDbContext db = new TrackApiDbContext();

        // GET: api/LocationDatas
        public IQueryable<LocationData> GetLocations()
        {
            return db.Locations;
        }

        // GET: api/LocationDatas/5
        [ResponseType(typeof(LocationData))]
        public IHttpActionResult GetLocationData(Guid id)
        {
            LocationData locationData = db.Locations.Find(id);
            if (locationData == null)
            {
                return NotFound();
            }

            return Ok(locationData);
        }

        // PUT: api/LocationDatas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLocationData(Guid id, LocationData locationData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != locationData.Id)
            {
                return BadRequest();
            }

            db.Entry(locationData).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationDataExists(id))
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

        // POST: api/LocationDatas
        [ResponseType(typeof(LocationData))]
        public IHttpActionResult PostLocationData(LocationData locationData)
        {
            if (locationData == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            locationData.LoggedTime = DateTime.UtcNow;
            db.Locations.Add(locationData);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (LocationDataExists(locationData.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = locationData.Id }, locationData);
        }

        // DELETE: api/LocationDatas/5
        [ResponseType(typeof(LocationData))]
        public IHttpActionResult DeleteLocationData(Guid id)
        {
            LocationData locationData = db.Locations.Find(id);
            if (locationData == null)
            {
                return NotFound();
            }

            db.Locations.Remove(locationData);
            db.SaveChanges();

            return Ok(locationData);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LocationDataExists(Guid id)
        {
            return db.Locations.Count(e => e.Id == id) > 0;
        }
    }
}