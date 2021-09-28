using System.Collections.Generic;
using EventosDeportivos.Dominio;
using System.Linq;

namespace EventosDeportivos.Persistencia
{
    public class RepositorioEscenario : IRepositorioEscenario
    {
        //Propiedades
        private readonly AppContext _dataBaseContext;

        //Metodos
        //Constructor
        public RepositorioEscenario(AppContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }   

        //Implementación métodos de la Interfaz RepositorioEscenario
        
        bool IRepositorioEscenario.CrearEscenario(Escenario escenario)
        {
            bool creado = false;
            try
            {
                 _dataBaseContext.Escenarios.Add(escenario);
                 _dataBaseContext.SaveChanges();
                 creado = true;
            }
            catch (System.Exception)
            {
                creado = false;
            }

            return creado;
        }

        bool IRepositorioEscenario.EliminarEscenario(int idEscenario)
        {
            bool eliminado = false;
            var escenario = _dataBaseContext.Escenarios.Find(idEscenario);

            if (escenario != null)
            {
                try
            {

                 _dataBaseContext.Escenarios.Remove(escenario);
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

        bool IRepositorioEscenario.ActualizarEscenario(Escenario escenario)
        {
            bool actualizado = false;
            var escenario_a_actualizar = _dataBaseContext.Escenarios.Find(escenario.Id);

            if (escenario_a_actualizar != null)
            {
               try
            {
                escenario_a_actualizar.Nombre = escenario.Nombre;
                escenario_a_actualizar.Direccion = escenario.Direccion;
                escenario_a_actualizar.Telefono = escenario.Telefono;
                escenario_a_actualizar.Horario = escenario.Horario;
                escenario_a_actualizar.TorneoId = escenario.TorneoId;
                escenario_a_actualizar.Canchas = escenario.Canchas;

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

        Escenario IRepositorioEscenario.BuscarEscenario(int idEscenario)
        {
            Escenario escenario = _dataBaseContext.Escenarios.Find(idEscenario);

            return escenario;
        }

        IEnumerable<Escenario> IRepositorioEscenario.ListarEscenarios()
        {
            return _dataBaseContext.Escenarios;
        }
    }
}