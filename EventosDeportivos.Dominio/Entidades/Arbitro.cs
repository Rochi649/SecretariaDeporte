using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventosDeportivos.Dominio
{
    public class Arbitro
    {
        public Arbitro()
        {
        }

        public int Id { get; set; }

        public string Documento { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Genero { get; set; }

        public string Telefono { get; set; }

        public string Correo { get; set; }

        public string Deporte { get; set; }

        public int TorneoId { get; set; }

        public int EscuelaArbitroId { get; set; }
    }
}
