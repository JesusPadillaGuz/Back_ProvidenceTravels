using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Agencia.Models
{
    public class TipoUsuario
    {
        [Key]
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool IsEnabled { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
    }
}
