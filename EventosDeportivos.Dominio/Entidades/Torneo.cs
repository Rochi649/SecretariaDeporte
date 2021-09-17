using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventosDeportivos.Dominio
{
    public class Torneo
    {
        public Torneo()
        {
        }

        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Categoria { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public string Tipo { get; set; }

        public int MunicipioId { get; set; }

        public List<TorneoEquipo> TorneoEquipo { get; set; }

        public List<Escenario> Escenarios { get; set; }

        public List<Arbitro> Arbitros { get; set; }
    }
}
