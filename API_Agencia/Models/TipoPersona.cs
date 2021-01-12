using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Agencia.Models
{
    public class TipoPersona
    {
        [Key]
        public int ID { get; set; }
        public string Nombre { get; set; }
        public ICollection<PersonaExtra> PersonasExtra { get; set; }
    }
}
