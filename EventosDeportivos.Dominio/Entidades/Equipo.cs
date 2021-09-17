using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventosDeportivos.Dominio
{
    public class Equipo
    {
        public Equipo()
        {
        }

        public int Id { get; set; }

        public string Nombre { get; set; }

        public int CantidadDeportistas { get; set; }

        public string Deporte { get; set; }

        public int PatrocinadorId { get; set; }

        public List<TorneoEquipo> TorneoEquipo { get; set; }

        public List<Deportista> Deportistas { get; set; }

        public Entrenador Entrenador { get; set; }
    }
}
