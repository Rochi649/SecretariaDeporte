using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventosDeportivos.Dominio
{
    public class Deportista
    {
        public Deportista()
        {
        }

        public int Id { get; set; }

        public string Documento { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Genero { get; set; }

        public string Rh { get; set; }

        public string EPS { get; set; }

        public string FechaNacimiento { get; set; }

        public string Deporte { get; set; }

        public string Direccion { get; set; }

        public string NumeroEmergencia { get; set; }

        public int EquipoId { get; set; }
    }
}
