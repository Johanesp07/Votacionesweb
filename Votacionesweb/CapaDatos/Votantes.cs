using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Votacionesweb.CapaDatos
{
    public class Votantes
    {
        public int IDVotante { get; set; }
        public string NombreVotante { get; set; }
        public string ApellidoVotante { get; set; }
        public string Correo { get; set;}
        public string Contrasena { get; set; }
    }
}