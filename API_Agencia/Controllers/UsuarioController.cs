using API_Agencia.Context;
using API_Agencia.Models;
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
    public class UsuarioController : ControllerBase
    {
        private AppDbContext context;
        public UsuarioController(AppDbContext appDbContext)
        {
            this.context = appDbContext;
        }
        // GET: api/<UsuarioController>
        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            List<Usuario> responseUsuarios;
            var query = context.Usuarios;
            query.Include(x => x.TipoUsuario);
            query.Include(x => x.Acceso);
            responseUsuarios = query.ToList();

            return responseUsuarios;
           
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public Usuario Get(int id)
        {
            Usuario responseUsuario;
            var usuario = context.Usuarios.Where(x => x.ID == id);
            usuario = usuario.Include(x => x.TipoUsuario);
            usuario = usuario.Include(x => x.Acceso);
             responseUsuario = usuario.FirstOrDefault();

            return responseUsuario;
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public ActionResult Post([FromBody] Usuario usuario)
        {
            try
            {
                context.Usuarios.Add(usuario);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
           
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Usuario usuario)
        {
            if (usuario.ID == id)
            {
                context.Entry(usuario).State = EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var usuario = context.Usuarios.Where(x => x.ID == id).FirstOrDefault();
            if (usuario != null)
            {
                //here wanna make logic delete
                Action<Usuario> action = x => x.IsEnabled = false;
                action(usuario);
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
