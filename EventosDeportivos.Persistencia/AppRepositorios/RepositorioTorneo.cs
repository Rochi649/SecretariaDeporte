using System.Collections.Generic;
using EventosDeportivos.Dominio;
using System.Linq;

namespace EventosDeportivos.Persistencia
{
    public class RepositorioTorneo : IRepositorioTorneo
    {
        //Propiedades
        private readonly AppContext _dataBaseContext;

        //Metodos
        //Constructor
        public RepositorioTorneo(AppContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }   

        //Implementación métodos de la Interfaz RepositorioTorneo
        
        bool IRepositorioTorneo.CrearTorneo(Torneo torneo)
        {
            bool creado = false;
            try
            {
                 _dataBaseContext.Torneos.Add(torneo);
                 _dataBaseContext.SaveChanges();
                 creado = true;
            }
            catch (System.Exception)
            {
                creado = false;
            }

            return creado;
        }

        bool IRepositorioTorneo.EliminarTorneo(int idTorneo)
        {
            bool eliminado = false;
            var torneo = _dataBaseContext.Torneos.Find(idTorneo);

            if (torneo != null)
            {
                try
            {

                 _dataBaseContext.Torneos.Remove(torneo);
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

        bool IRepositorioTorneo.ActualizarTorneo(Torneo torneo)
        {
            bool actualizado = false;
            var torneo_a_actualizar = _dataBaseContext.Torneos.Find(torneo.Id);

            if (torneo_a_actualizar != null)
            {
               try
            {
                torneo_a_actualizar.Nombre = torneo.Nombre;
                torneo_a_actualizar.Categoria = torneo.Categoria;
                torneo_a_actualizar.FechaInicio = torneo.FechaInicio;
                torneo_a_actualizar.FechaFin = torneo.FechaFin;
                torneo_a_actualizar.Tipo = torneo.Tipo;
                torneo_a_actualizar.MunicipioId = torneo.MunicipioId;
                torneo_a_actualizar.TorneoEquipo = torneo.TorneoEquipo;
                torneo_a_actualizar.Escenarios = torneo.Escenarios;
                torneo_a_actualizar.Arbitros = torneo.Arbitros;

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

        Torneo IRepositorioTorneo.BuscarTorneo(int idTorneo)
        {
            Torneo torneo = _dataBaseContext.Torneos.Find(idTorneo);

            return torneo;
        }

        IEnumerable<Torneo> IRepositorioTorneo.ListarTorneos()
        {
            return _dataBaseContext.Torneos;
        }
    }
}