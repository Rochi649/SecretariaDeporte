using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventosDeportivos.Dominio;
using EventosDeportivos.Persistencia;

namespace EventosDeportivos.Presentacion.Pages
{
    public class MunicipioModel : PageModel
    {
        private static IRepositorioMunicipio _repositorioMunicipio; // = new RepositorioMunicipio(new EventosDeportivos.Persistencia.AppContext());

        public IEnumerable<Municipio> municipios { get; set; }
        [BindProperty]
        public Municipio Municipio { get; set; }

        public MunicipioModel(IRepositorioMunicipio repositorioMunicipio)
        {
            //Constructor
            _repositorioMunicipio = repositorioMunicipio;
        }
        public void OnGet(int? MunicipioId)
        {
            if (MunicipioId.HasValue)
            {
                Municipio = _repositorioMunicipio.BuscarMunicipio(MunicipioId.Value);
            }
            else
            {
                municipios = listarMunicipios();
            }
        }

        public ActionResult OnPost()
        {

            if (Municipio.Id > 0)
            {
                _repositorioMunicipio.ActualizarMunicipio(Municipio);
            }
            else
            {
                bool creado = _repositorioMunicipio.CrearMunicipio(new Municipio{
                    Nombre = Municipio.Nombre
                });
                if (creado)
                {
                    Console.WriteLine("El municipio ha sido creado");
                }
                else
                {
                    Console.WriteLine("Ha ocurrido un error durante la creacion");
                }
            }
            return RedirectToPage("Municipio");
        }

        public IActionResult OnGetEliminar(int Id)
        {
            bool eliminado = _repositorioMunicipio.EliminarMunicipio(Id);
            if(eliminado)
            {
                Console.WriteLine("Se ha eliminado el registro");
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error en el proceso");
            }
            return Redirect("Municipio");
        }

        private IEnumerable<Municipio> listarMunicipios()
        {
            IEnumerable<Municipio> municipios = _repositorioMunicipio.ListarMunicipios();
            Console.WriteLine(String.Format("{0,-5} | {1,-16} |", "ID", "Nombre"));
            Console.WriteLine(String.Format("{0,-5} | {1,-16} |", "-----", "----------------"));
            foreach (var municipio in municipios)
            {
                Console.WriteLine(String.Format("{0,-5} | {1,-16} |", municipio.Id, municipio.Nombre));
                Console.WriteLine(String.Format("{0,-5} | {1,-16} |", "-----", "----------------"));
            }

            return municipios;
        }
    }
}
