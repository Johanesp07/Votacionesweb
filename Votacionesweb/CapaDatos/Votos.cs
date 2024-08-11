using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Votacionesweb.CapaDatos
{
    public class Votos
    {
        public int IDVoto { get; set; }
        public int IDCandidato { get; set; }
        public int IDVotante { get; set; }
        public DateTime FechaVoto { get; set; }
    }
}