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
using APIRegistro.Models;

namespace APIRegistro.Controllers
{
    public class RegistroesController : ApiController
    {
        private DataContext db = new DataContext();

        public object GetRegistro()
        {
            throw new NotImplementedException();
        }

        // GET: api/Registroes
        [Authorize]
        public IQueryable<Registro> GetRegistroes()
        {
            return db.Registroes;
        }

        // GET: api/Registroes/5
        [Authorize]
        [ResponseType(typeof(Registro))]
        public IHttpActionResult GetRegistro(int id)
        {
            Registro registro = db.Registroes.Find(id);
            if (registro == null)
            {
                return NotFound();
            }

            return Ok(registro);
        }

        // PUT: api/Registroes/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRegistro(int id, Registro registro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != registro.SalmonID)
            {
                return BadRequest();
            }

            db.Entry(registro).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistroExists(id))
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

        // POST: api/Registroes
        [Authorize]
        [ResponseType(typeof(Registro))]
        public IHttpActionResult PostRegistro(Registro registro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Registroes.Add(registro);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = registro.SalmonID }, registro);
        }

        // DELETE: api/Registroes/5
        [Authorize]
        [ResponseType(typeof(Registro))]
        public IHttpActionResult DeleteRegistro(int id)
        {
            Registro registro = db.Registroes.Find(id);
            if (registro == null)
            {
                return NotFound();
            }

            db.Registroes.Remove(registro);
            db.SaveChanges();

            return Ok(registro);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RegistroExists(int id)
        {
            return db.Registroes.Count(e => e.SalmonID == id) > 0;
        }
    }
}