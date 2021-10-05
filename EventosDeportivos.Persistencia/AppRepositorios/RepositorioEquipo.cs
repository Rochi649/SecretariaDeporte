//la clase que implementa las firmas
using System.Collections.Generic;
using EventosDeportivos.Dominio;
using System.Linq;

namespace EventosDeportivos.Persistencia
{
    public class RepositorioEquipo : IRepositorioEquipo
    {
        //Atributos
        private readonly AppContext _dataBaseContext;
        //Metodos
        //Constructor
        public RepositorioEquipo(AppContext appContext)
        {
            _dataBaseContext = appContext;
        }
        //Implementación de los métodos de la interfaz IRepositorioMunicipio

        bool IRepositorioEquipo.CrearEquipo(Equipo equipo)
        {
            bool creado = false;
            try
            {
                _dataBaseContext.Equipos.Add(equipo);
                //Es necesario guardar los cambios cada vez que se modifica informacion en la base de datos
                _dataBaseContext.SaveChanges();
                creado = true;
            }
            catch (System.Exception)
            {
                creado = false;
            }
            return creado;
        }
        bool IRepositorioEquipo.ActualizarEquipo(Equipo equipo)
        {
            return true;
        }
        bool IRepositorioEquipo.EliminarEquipo(int idEquipo)
        {
            {
                bool eliminado = false;
                //Se busca el municipio que se va a eliminar
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
