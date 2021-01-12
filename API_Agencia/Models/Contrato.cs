using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Agencia.Models
{
    public class Contrato
    {
        [Key]
        public int ID { get; set; }
        public DateTime Fecha_Inicio_Contrato { get; set; }
        public int UsuarioID { get; set; }
        public Usuario Usuario { get; set; }
        public int ClienteID { get; set; }
        public Cliente Cliente { get; set; }
        public int ServicioID { get; set; }
        public Servicio Servicio { get; set; }
        public string Documento_ContratoURL { get; set; }
        public double CostoTotal { get; set; }
        public string Politicas_Pago { get; set; }
        public DateTime Fecha_LimPago { get; set; }
        public double Anticipo { get; set; }
        public string Folio_Contrato { get; set; }
        public string Notas { get; set; }
        public string Localizador { get; set; }
        public double Saldo_Restante { get; set; }
        public bool IsEnabled { get; set; }
        public ICollection<PersonaExtra> PersonasExtra { get; set; }
        public ICollection<Abono> Abonos { get; set; }



    }
}
