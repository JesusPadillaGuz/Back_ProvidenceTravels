﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Agencia.Models
{
    public class Acceso
    {
        [Key]
        public int ID { get; set; }
        public string Email { get; set; }
        /*public string Password { get; set; }*/
        public ICollection<Usuario> Usuarios { get; set; }
    }
}
