using System;
using EventosDeportivos.Dominio;
using EventosDeportivos.Persistencia;
using System.Collections.Generic;

namespace EventosDeportivos.Consola
{
    class Program
    {
        private static IRepositorioMunicipio _repositorioMunicipio = new RepositorioMunicipio(new EventosDeportivos.Persistencia.AppContext());
        private static IRepositorioTorneo _repositorioTorneo = new RepositorioTorneo(new EventosDeportivos.Persistencia.AppContext());
        static void Main(string[] args)
        {
            /*
            bool creado = crearMunicipio();

            if (creado)
            {
                Console.WriteLine("Se ha creado satisfactoriamente el municipio");
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error en la creacion del municipio");
            }
            

            bool actualizado = actualizarMunicipio();

            if (actualizado)
            {
                Console.WriteLine("Se ha actualizado satisfactoriamente el municipio");
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error en la actualizacion del municipio");
            }
            
            //bool eliminado = eliminarMunicipio();
            listarMunicipios();
            buscarMunicipio();
            */

            bool creado = crearTorneo();

            if (creado)
            {
                Console.WriteLine("Se ha creado satisfactoriamente el torneo");
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error en la creacion del torneo");
            }
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

        private static void listarMunicipios()
        {
            IEnumerable<Municipio> municipios = _repositorioMunicipio.ListarMunicipios();
            foreach (var municipio in municipios)
            {
                Console.WriteLine(municipio.Id + " " + municipio.Nombre);
            }
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

        private static bool crearTorneo()
        {
            Console.WriteLine("Ingrese el nombre del torneo: ");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese su categoria: ");
            string categoria = Console.ReadLine();
            Console.WriteLine("Ingrese la fecha de inicio del torneo");
            var fechaInicial = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Ingrese la fecha de terminacion del torneo");
            var fechaFinal = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Ingrese el tipo del torneo");
            string tipo = Console.ReadLine();
            Console.WriteLine("Ingrese el numero del municipio en que se va a realizar el torneo del torneo");
            listarMunicipios();
            int municipioId = int.Parse(Console.ReadLine());


            var torneo = new Torneo
            {
                Nombre = nombre,
                Categoria = categoria,
                FechaInicio = fechaInicial,
                FechaFin = fechaFinal,
                Tipo = tipo,
                MunicipioId = municipioId
            };
            bool creado = _repositorioTorneo.CrearTorneo(torneo);

            return creado;

        }
    }
}
