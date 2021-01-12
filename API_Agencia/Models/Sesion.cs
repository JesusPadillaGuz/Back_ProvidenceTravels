using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Agencia.Models
{
    public class Sesion
    {
        [Key]
        public int ID { get; set; }
        public string Token { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public DateTime Fecha_Terminacion { get; set; }
        public bool IsEnabled { get; set; }
        public int UsuarioID { get; set; }
        public Usuario Usuario { get; set; }
    }
}
