using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Agencia.Models
{
    public class Usuario
    {
        [Key]
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public bool IsEnabled { get; set; }
        public int TipoUsuarioID { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public int AccesoID { get; set; }
        public Acceso Acceso { get; set; }
        public ICollection<Sesion> Sesiones { get; set; }
        public ICollection<Contrato> Contratos { get; set; }
        public ICollection<Abono> Abonos { get; set; }

    }
}
