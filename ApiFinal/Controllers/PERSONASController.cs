using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ApiFinal.Models;

namespace ApiFinal.Controllers
{
    public class PERSONASController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/PERSONAS
        public IQueryable<PERSONAS> GetPERSONAS()
        {
            return db.PERSONAS;
        }

        // GET: api/PERSONAS/5
        [ResponseType(typeof(PERSONAS))]
        public async Task<IHttpActionResult> GetPERSONAS(decimal id)
        {
            PERSONAS pERSONAS = await db.PERSONAS.FindAsync(id);
            if (pERSONAS == null)
            {
                return NotFound();
            }

            return Ok(pERSONAS);
        }

        // PUT: api/PERSONAS/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPERSONAS(decimal id, PERSONAS pERSONAS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pERSONAS.PERS_CODIGO)
            {
                return BadRequest();
            }

            db.Entry(pERSONAS).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PERSONASExists(id))
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

        // POST: api/PERSONAS
        [ResponseType(typeof(PERSONAS))]
        public async Task<IHttpActionResult> PostPERSONAS(PERSONAS pERSONAS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PERSONAS.Add(pERSONAS);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PERSONASExists(pERSONAS.PERS_CODIGO))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pERSONAS.PERS_CODIGO }, pERSONAS);
        }

        // DELETE: api/PERSONAS/5
        [ResponseType(typeof(PERSONAS))]
        public async Task<IHttpActionResult> DeletePERSONAS(decimal id)
        {
            PERSONAS pERSONAS = await db.PERSONAS.FindAsync(id);
            if (pERSONAS == null)
            {
                return NotFound();
            }

            db.PERSONAS.Remove(pERSONAS);
            await db.SaveChangesAsync();

            return Ok(pERSONAS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PERSONASExists(decimal id)
        {
            return db.PERSONAS.Count(e => e.PERS_CODIGO == id) > 0;
        }
    }
}