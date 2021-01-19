using API_Agencia.Context;
using API_Agencia.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Agencia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private AppDbContext context { get; set; }
        public ServicioController(AppDbContext appDbContext)
        {
            this.context = appDbContext;
        }
        // GET: api/<ServicioController>
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<Servicio> Get()
        {
            List<Servicio> responseServicios;
            try
            {
                var query = context.Servicios;
                //review 
                query = (DbSet<Servicio>)query.Include(x => x.TipoServicio);
                responseServicios = query.ToList();
            }
            catch (Exception)
            {
                return null;
            }

            return responseServicios;
        }

        // GET api/<ServicioController>/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}")]
        public Servicio Get(int id)
        {
            Servicio responseServicio;
            var query = context.Servicios.Where(x => x.ID == id);
            query = query.Include(x => x.TipoServicio);

            responseServicio = query.FirstOrDefault();

            return responseServicio;
        }

        // POST api/<ServicioController>
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public ActionResult Post([FromBody] Servicio servicio)
        {
            try
            {
                context.Servicios.Add(servicio);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        // PUT api/<ServicioController>/5
        [EnableCors("AnotherPolicy")]
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Servicio servicio)
        {
            if (servicio.ID == id)
            {
                context.Entry(servicio).State = EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<ServicioController>/5
        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var servicio = context.Servicios.Where(x => x.ID == id).FirstOrDefault();
            if (servicio != null)
            {
                //here wanna make physical delete
                context.Servicios.Remove(servicio);
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
