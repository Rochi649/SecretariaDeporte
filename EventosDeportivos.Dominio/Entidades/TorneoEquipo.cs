using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventosDeportivos.Dominio
{
    public class TorneoEquipo
    {
        public TorneoEquipo()
        {
        }
        public int EquipoId { get; set; }

        public int TorneoId { get; set; }

        public Torneo Torneo { get; set; }

        public Equipo Equipo { get; set; }
    }
}
