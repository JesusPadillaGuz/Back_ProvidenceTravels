using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Agencia.Models
{
    public class Cliente
    {
        [Key]
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public ICollection<Contrato> Contratos { get; set; }
        public ICollection<Abono> Abonos { get; set; }
    }
}
