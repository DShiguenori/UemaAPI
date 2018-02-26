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
using UemaAPI.DAO;
using UemaAPI.Models;

namespace UemaAPI.Controllers
{
    public class CDZProdutosController : ApiController
    {
        private CDZContext db = new CDZContext();

        // GET: api/CDZProdutos
        public IQueryable<CDZProduto> GetProdutos()
        {
            return db.Produtos;
        }

        // GET: api/CDZProdutos/5
        [ResponseType(typeof(CDZProduto))]
        public IHttpActionResult GetCDZProduto(int id)
        {
            CDZProduto cDZProduto = db.Produtos.Find(id);
            if (cDZProduto == null)
            {
                return NotFound();
            }

            return Ok(cDZProduto);
        }

        // PUT: api/CDZProdutos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCDZProduto(int id, CDZProduto cDZProduto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cDZProduto.ID)
            {
                return BadRequest();
            }

            db.Entry(cDZProduto).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CDZProdutoExists(id))
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

        // POST: api/CDZProdutos
        [ResponseType(typeof(CDZProduto))]
        public IHttpActionResult PostCDZProduto(CDZProduto cDZProduto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Produtos.Add(cDZProduto);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cDZProduto.ID }, cDZProduto);
        }

        // DELETE: api/CDZProdutos/5
        [ResponseType(typeof(CDZProduto))]
        public IHttpActionResult DeleteCDZProduto(int id)
        {
            CDZProduto cDZProduto = db.Produtos.Find(id);
            if (cDZProduto == null)
            {
                return NotFound();
            }

            db.Produtos.Remove(cDZProduto);
            db.SaveChanges();

            return Ok(cDZProduto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CDZProdutoExists(int id)
        {
            return db.Produtos.Count(e => e.ID == id) > 0;
        }
    }
}