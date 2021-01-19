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
    public class TiposUsuarioController : ControllerBase
    {
        private AppDbContext context;
        public TiposUsuarioController(AppDbContext appDbContext)
        {
            this.context = appDbContext;
        }
        // GET: api/<TiposUsuarioController>
        //api/TiposUsuario
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public IEnumerable<TipoUsuario> Get()
        {
            List<TipoUsuario> responseTiposUsuario;
            var query = context.TiposUsuario.ToList();
            responseTiposUsuario = query;

            return responseTiposUsuario;

        }

        // GET api/<TiposUsuarioController>/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}")]
        public TipoUsuario Get(int id)
        {
            TipoUsuario responseTipoUsuario;
            responseTipoUsuario = context.TiposUsuario.Where(x => x.ID == id).FirstOrDefault();
            return responseTipoUsuario;
        }

        // POST api/<TiposUsuarioController>
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public ActionResult Post([FromBody] TipoUsuario tipoUsuario)
        {
            try
            {
                context.TiposUsuario.Add(tipoUsuario);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }

        }

        // PUT api/<TiposUsuarioController>/5
        [EnableCors("AnotherPolicy")]
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TipoUsuario tipoUsuario)
        {
            if (tipoUsuario.ID == id)
            {
                context.Entry(tipoUsuario).State = EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<TiposUsuarioController>/5
        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var tipoUsuario = context.TiposUsuario.Where(x => x.ID == id).FirstOrDefault();
            if (tipoUsuario != null)
            {
                //here wanna make logic delete
                Action<TipoUsuario> action = x => x.IsEnabled = false;
                action(tipoUsuario);
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
