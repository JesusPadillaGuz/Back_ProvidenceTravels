using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Agencia.Models
{
    public class Abono
    {
        [Key]
        public int ID { get; set; }
        public double Cantidad_Abono { get; set; }
        public int ContratoID { get; set; }
        public Contrato Contrato { get; set; }
        public int Folio_Abono { get; set; }
        public string Notas { get; set; }
        public double Saldo_Anterior { get; set; }
    }
}
