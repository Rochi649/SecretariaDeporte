using System.Collections.Generic;
using EventosDeportivos.Dominio;
using System.Linq;

namespace EventosDeportivos.Persistencia
{
    public class RepositorioEquipo : IRepositorioEquipo
    {
        //Propiedades
        private readonly AppContext _dataBaseContext;

        //Metodos
        //Constructor
        public RepositorioEquipo(AppContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }   

        //Implementación métodos de la Interfaz RepositorioEquipo
        
        bool IRepositorioEquipo.CrearEquipo(Equipo equipo)
        {
            bool creado = false;
            try
            {
                 _dataBaseContext.Equipos.Add(equipo);
                 _dataBaseContext.SaveChanges();
                 creado = true;
            }
            catch (System.Exception)
            {
                creado = false;
            }

            return creado;
        }

        bool IRepositorioEquipo.EliminarEquipo(int idEquipo)
        {
            bool eliminado = false;
            var equipo = _dataBaseContext.Equipos.Find(idEquipo);

            if (equipo != null)
            {
                try
            {

                 _dataBaseContext.Equipos.Remove(equipo);
                 _dataBaseContext.SaveChanges();
                 eliminado = true;
            }
            catch (System.Exception)
            {
                eliminado = false;
            }

            }
            return eliminado;
        }

        bool IRepositorioEquipo.ActualizarEquipo(Equipo equipo)
        {
            bool actualizado = false;
            var equipo_a_actualizar = _dataBaseContext.Equipos.Find(equipo.Id);

            if (equipo_a_actualizar != null)
            {
               try
            {
                equipo_a_actualizar.Nombre = equipo.Nombre;
                equipo_a_actualizar.CantidadDeportistas = equipo.CantidadDeportistas;
                equipo_a_actualizar.Deporte = equipo.Deporte;
                equipo_a_actualizar.PatrocinadorId = equipo.PatrocinadorId;
                equipo_a_actualizar.TorneoEquipo = equipo.TorneoEquipo;
                equipo_a_actualizar.Deportistas = equipo.Deportistas;
                equipo_a_actualizar.Entrenador = equipo.Entrenador;

                _dataBaseContext.SaveChanges();
                 actualizado = true;
            }
            catch (System.Exception)
            {
                actualizado = false;
            }

            }
            return actualizado; 
        }

        Equipo IRepositorioEquipo.BuscarEquipo(int idEquipo)
        {
            Equipo equipo = _dataBaseContext.Equipos.Find(idEquipo);

            return equipo;
        }

        IEnumerable<Equipo> IRepositorioEquipo.ListarEquipos()
        {
            return _dataBaseContext.Equipos;
        }


    }
}