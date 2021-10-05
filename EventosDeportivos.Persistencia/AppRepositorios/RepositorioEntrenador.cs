using System.Collections.Generic;
using EventosDeportivos.Dominio;
using System.Linq;

namespace EventosDeportivos.Persistencia
{
    public class RepositorioEntrenador : IRepositorioEntrenador
    {
        //Atributos
        private readonly AppContext _dataBaseContext;
        //Metodos
        //Constructor
        public RepositorioEntrenador(AppContext appContext)
        {
            _dataBaseContext = appContext;
        }
        //Implementación de los métodos de la interfaz IRepositorioMunicipio

        bool IRepositorioEntrenador.CrearEntrenador(Entrenador entrenador)
        {
            bool creado = false;
            try
            {
                _dataBaseContext.Entrenadores.Add(entrenador);
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
        bool IRepositorioEntrenador.ActualizarEntrenador(Entrenador entrenador)
        {
            return true;
        }
        bool IRepositorioEntrenador.EliminarEntrenador(int idEntrenador)
        {
            {
                bool eliminado = false;
                //Se busca el municipio que se va a eliminar
                var entrenador = _dataBaseContext.Entrenadores.Find(idEntrenador);

                if (entrenador != null)
                {
                    try
                    {
                        _dataBaseContext.Entrenadores.Remove(entrenador);
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
        Entrenador IRepositorioEntrenador.BuscarEntrenador(int idEntrenador)
        {
            Entrenador entrenador = _dataBaseContext.Entrenadores.Find(idEntrenador);
            return entrenador;
        }
        IEnumerable<Entrenador> IRepositorioEntrenador.ListarEntrenadores()
        {
            return _dataBaseContext.Entrenadores;
        }
    }
}