using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventosDeportivos.Dominio
{
    public class Municipio
    {
        public Municipio()
        {
        }

        public int Id { get; set; }

        public string Nombre { get; set; }

        public List<Torneo> Torneos { get; set; }
    }
}
