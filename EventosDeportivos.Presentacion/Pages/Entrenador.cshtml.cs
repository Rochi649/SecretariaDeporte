using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using EventosDeportivos.Dominio;
using EventosDeportivos.Persistencia;

namespace EventosDeportivos.Presentacion.Pages
{
    public class EntrenadorModel : PageModel
    {
        private static IRepositorioEntrenador _repositorioEntrenador;
        private static IRepositorioEquipo _repositorioEquipo = new RepositorioEquipo(new EventosDeportivos.Persistencia.AppContext());

        public IEnumerable<Entrenador> entrenadores { get; set; }

        public IEnumerable<Equipo> equipos { get; set; }

        [BindProperty]
        public Entrenador Entrenador { get; set; }

        public Equipo Equipo { get; set; }

        public List<string> nombreEquipos = new List<string>();

        //Constructor
        public EntrenadorModel(IRepositorioEntrenador repositorioEntrenador)
        {
            _repositorioEntrenador = repositorioEntrenador;
        }

        public void OnGet()
        {
            entrenadores = _repositorioEntrenador.ListarEntrenadores();
            foreach (var entrenador in entrenadores)
            {
                Equipo = _repositorioEquipo.BuscarEquipo(entrenador.EquipoId);
                nombreEquipos.Add(Equipo.Nombre);
            }
            equipos = _repositorioEquipo.ListarEquipos();
        }
    }
}
