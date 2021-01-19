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
    public class TiposServicioController : ControllerBase
    {
        private AppDbContext context;
        public TiposServicioController(AppDbContext appDbContext)
        {
            this.context = appDbContext;
        }
        // GET: api/<TiposServicioController>
        [HttpGet]
        public IEnumerable<TipoServicio> Get()
        {
            List<TipoServicio> responseTiposServicio;
            var query = context.TiposServicio.ToList();
            responseTiposServicio = query;

            return responseTiposServicio;
        }

        // GET api/<TiposServicioController>/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}")]
        public TipoServicio Get(int id)
        {
            TipoServicio responseTipoServicio;
            responseTipoServicio = context.TiposServicio.Where(x => x.ID == id).FirstOrDefault();
            return responseTipoServicio;
        }

        // POST api/<TiposServicioController>
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public ActionResult Post([FromBody] TipoServicio tipoServicio)
        {
            try
            {
                context.TiposServicio.Add(tipoServicio);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        // PUT api/<TiposServicioController>/5
        [EnableCors("AnotherPolicy")]
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TipoServicio tipoServicio)
        {
            if (tipoServicio.ID == id)
            {
                context.Entry(tipoServicio).State = EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<TiposServicioController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var tipoServicio = context.TiposServicio.Where(x => x.ID == id).FirstOrDefault();
            if (tipoServicio != null)
            {
                //here wanna make logic delete
                Action<TipoServicio> action = x => x.IsEnabled = false;
                action(tipoServicio);
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
