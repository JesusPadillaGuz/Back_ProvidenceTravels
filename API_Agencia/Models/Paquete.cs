using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Agencia.Models
{
    public class Paquete
    {
        [Key]
        public int ID { get; set; }
        public string Nombre { get; set; }
        public bool IsEnabled { get; set; }
        public string Descripcion { get; set; }
        public int ServicioID { get; set; }
        public Servicio Servicio { get; set; }
        public string ImagenesURL { get; set; }
        public double Precio_Ad { get; set; }
        public double Precio_Jr { get; set; }
        public double Precio_Mr { get; set; }
        public string Notas { get; set; }

        
    }
}
