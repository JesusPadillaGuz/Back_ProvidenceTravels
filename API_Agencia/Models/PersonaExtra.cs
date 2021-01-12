using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Agencia.Models
{
    public class PersonaExtra
    {
        [Key]
        public int ID { get; set; }
        public int Edad { get; set; }
        public int ContratoID { get; set; }
        public Contrato Contrato { get; set; }
        public int TipoPersonaID { get; set; }
        public TipoPersona TipoPersona { get; set; }
    }
}
