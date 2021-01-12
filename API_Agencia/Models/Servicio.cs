using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Agencia.Models
{
    public class Servicio
    {
        [Key]
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Fin { get; set; }
        public int TipoServicioID { get; set; }
        public TipoServicio TipoServicio { get; set; }
        public ICollection<Paquete> Paquetes { get; set; }
        public ICollection<Contrato> Contratos { get; set; }

    }
}
