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
        private static IRepositorioMunicipio _repositorioMunicipio = new RepositorioMunicipio(new EventosDeportivos.Persistencia.AppContext());

        public IEnumerable<Municipio> municipios;
        public void OnGet()
        {
            municipios = listarMunicipios();
        }

        private static bool crearMunicipio()
        {
            Console.WriteLine("Ingrese el municipio");
            var municipio = new Municipio
            {
                Nombre = Console.ReadLine()
            };
            bool creado = _repositorioMunicipio.CrearMunicipio(municipio);

            return creado;

        }

        private static IEnumerable<Municipio> listarMunicipios()
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

        private static bool eliminarMunicipio()
        {
            Console.Write("Ingrese el Id del municipio a eliminar: ");
            int idMunicipio = int.Parse(Console.ReadLine());


            bool eliminado = _repositorioMunicipio.EliminarMunicipio(idMunicipio);

            return eliminado;
        }

        private static bool actualizarMunicipio()
        {
            Console.WriteLine("Ingrese el Id del municipio a actualizar");
            int idMunicipio = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el nombre del municipio");
            string nombreMunicipio = Console.ReadLine();

            var municipio = new Municipio
            {
                Id = idMunicipio,
                Nombre = nombreMunicipio
            };

            bool actualizado = _repositorioMunicipio.ActualizarMunicipio(municipio);

            return actualizado;
        }

        private static void buscarMunicipio()
        {
            Console.WriteLine("Ingrese el Id del municipio a buscar:");
            int idMunicipio = int.Parse(Console.ReadLine());

            Municipio municipio = _repositorioMunicipio.BuscarMunicipio(idMunicipio);
            if (municipio != null)
            {
                Console.WriteLine(municipio.Id + " " + municipio.Nombre);
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error al buscar el municipio");
            }
        }
    }
}
