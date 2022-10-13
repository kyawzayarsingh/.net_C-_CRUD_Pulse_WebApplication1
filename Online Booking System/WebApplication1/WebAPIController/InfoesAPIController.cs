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
using WebApplication1.Data;
using WebApplication1.DTOs.Info;
using WebApplication1.Interface;
using WebApplication1.Models;
using WebApplication1.Respositories;

namespace WebApplication1.WebAPIController
{
    public class InfoesAPIController : ApiController
    {
        private TravelTourDBContext db = new TravelTourDBContext();
        private readonly IEmployeeRepository _employeeRepository=new EmployeeRespository();

        //public InfoesAPIController(IEmployeeRepository employeeRepository)
        //{
        //    _employeeRepository = employeeRepository;
        //}

        //GET: api/InfoesAPI
        //public IQueryable<Info> GetAllInfos()
        //{
        //    return db.Infos;
        //}
        [Route("api/GetAllInfo")]
        [ResponseType(typeof(IList<Info>))]
        public async Task<IHttpActionResult> GetInfos()
        {
            var response = await _employeeRepository.GetAllInfoesAsync();

            if (response == null)
            {
                return BadRequest();
            }

            return Ok(response);
        }

        // GET: api/InfoesAPI/5
        [ResponseType(typeof(Info))]
        public async Task<IHttpActionResult> GetInfo(int id)
        {
            Info info = await db.Infos.FindAsync(id);
            if (info == null)
            {
                return NotFound();
            }

            return Ok(info);
        }

        // PUT: api/InfoesAPI/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutInfo(int id, Info info)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != info.Id)
            {
                return BadRequest();
            }

            db.Entry(info).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InfoExists(id))
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

        // POST: api/InfoesAPI
        [ResponseType(typeof(Info))]
        public async Task<IHttpActionResult> PostInfo(Info info)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Infos.Add(info);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = info.Id }, info);
        }

        // DELETE: api/InfoesAPI/5
        [ResponseType(typeof(Info))]
        public async Task<IHttpActionResult> DeleteInfo(int id)
        {
            Info info = await db.Infos.FindAsync(id);
            if (info == null)
            {
                return NotFound();
            }

            db.Infos.Remove(info);
            await db.SaveChangesAsync();

            return Ok(info);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InfoExists(int id)
        {
            return db.Infos.Count(e => e.Id == id) > 0;
        }
    }
}