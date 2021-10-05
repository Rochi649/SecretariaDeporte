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
    public class TorneoModel : PageModel
    {
        private static IRepositorioTorneo _repositorioTorneo = new RepositorioTorneo(new EventosDeportivos.Persistencia.AppContext());
        private static IRepositorioMunicipio _repositorioMunicipio = new RepositorioMunicipio(new EventosDeportivos.Persistencia.AppContext());
        public IEnumerable<Torneo> torneos;
        public IEnumerable<Municipio> municipios;

        [BindProperty]
        public Torneo Torneo { get; set; }

        [BindProperty]
        public Municipio Municipio { get; set; }

        public List<string> nombreMunicipios = new List<string>();

        public void OnGet()
        {
            torneos = listarTorneos();
            foreach (var torneo in torneos)
            {
                Municipio = _repositorioMunicipio.BuscarMunicipio(torneo.MunicipioId);
                nombreMunicipios.Add(Municipio.Nombre);
            }
            municipios = _repositorioMunicipio.ListarMunicipios();
        }

        public ActionResult OnPost()
        {
            if (Torneo.Id > 0)
            {
                _repositorioTorneo.ActualizarTorneo(Torneo);
            }
            else
            {
                bool creado = _repositorioTorneo.CrearTorneo(Torneo);
                if (creado)
                {
                    Console.WriteLine("El torneo ha sido creado");
                }
                else
                {
                    Console.WriteLine("Ha ocurrido un error durante la creacion");
                }
            }
            return RedirectToPage("Torneo");
        }

        public IActionResult OnGetEliminar(int Id)
        {
            bool eliminado = _repositorioTorneo.EliminarTorneo(Id);
            if (eliminado)
            {
                Console.WriteLine("Se ha eliminado el registro");
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error en el proceso");
            }
            return Redirect("Torneo");
        }
        public IEnumerable<Torneo> listarTorneos()
        {
            IEnumerable<Torneo> torneos = _repositorioTorneo.ListarTorneos();
            Console.WriteLine(String.Format("{0,-5} | {1,-22} | {2,-16} | {3,-16} | {4,-16} | ", "Id", "Nombre", "Categoria", "Tipo", "Ciudad Anfitriona"));
            Console.WriteLine(String.Format("{0,-5} | {1,-22} | {2,-16} | {3,-16} | {4,-16} | ", "-----", "---------------------", "----------------", "---------", "---------"));
            foreach (var torneo in torneos)
            {
                Municipio = _repositorioMunicipio.BuscarMunicipio(torneo.MunicipioId);
                Console.WriteLine(String.Format("{0,-5} | {1,-22} | {2,-16} | {3,-16} | {4,-16} |", torneo.Id, torneo.Nombre, torneo.Categoria, torneo.Tipo, Municipio.Nombre));
                Console.WriteLine(String.Format("{0,-5} | {1,-22} | {2,-16} | {3,-16} | {4,-16} |", "-----", "---------------------", "----------------", "---------", "---------"));
            }

            return torneos;
        }

        
    }
}
