using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventosDeportivos.Dominio
{
    public class Patrocinador
    {
        public Patrocinador()
        {
        }

        public int Id { get; set; }

        public string Identificacion { get; set; }

        public string Nombre { get; set; }

        public string TipoPersona { get; set; }

        public string Direccion { get; set; }

        public List<Equipo> Equipos { get; set; }
    }
}
