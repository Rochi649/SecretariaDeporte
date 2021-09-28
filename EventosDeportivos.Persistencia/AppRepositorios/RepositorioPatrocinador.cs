using System.Collections.Generic;
using EventosDeportivos.Dominio;
using System.Linq;

namespace EventosDeportivos.Persistencia
{
    public class RepositorioPatrocinador : IRepositorioPatrocinador
    {
        //Propiedades
        private readonly AppContext _dataBaseContext;

        //Metodos
        //Constructor
        public RepositorioPatrocinador(AppContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }   

        //Implementación métodos de la Interfaz RepositorioPatrocinador
        
        bool IRepositorioPatrocinador.CrearPatrocinador(Patrocinador patrocinador)
        {
            bool creado = false;
            try
            {
                 _dataBaseContext.Patrocinadores.Add(patrocinador);
                 _dataBaseContext.SaveChanges();
                 creado = true;
            }
            catch (System.Exception)
            {
                creado = false;
            }

            return creado;
        }

        bool IRepositorioPatrocinador.EliminarPatrocinador(int idPatrocinador)
        {
            bool eliminado = false;
            var patrocinador = _dataBaseContext.Patrocinadores.Find(idPatrocinador);

            if (patrocinador != null)
            {
                try
            {

                 _dataBaseContext.Patrocinadores.Remove(patrocinador);
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

        bool IRepositorioPatrocinador.ActualizarPatrocinador(Patrocinador patrocinador)
        {
            bool actualizado = false;
            var patrocinador_a_actualizar = _dataBaseContext.Patrocinadores.Find(patrocinador.Id);

            if (patrocinador_a_actualizar != null)
            {
               try
            {
                patrocinador_a_actualizar.Identificacion = patrocinador.Identificacion;
                patrocinador_a_actualizar.Nombre = patrocinador.Nombre;
                patrocinador_a_actualizar.TipoPersona = patrocinador.TipoPersona;
                patrocinador_a_actualizar.Direccion = patrocinador.Direccion;
                patrocinador_a_actualizar.Equipos = patrocinador.Equipos;

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

        Patrocinador IRepositorioPatrocinador.BuscarPatrocinador(int idPatrocinador)
        {
            Patrocinador patrocinador = _dataBaseContext.Patrocinadores.Find(idPatrocinador);

            return patrocinador;
        }

        IEnumerable<Patrocinador> IRepositorioPatrocinador.ListarPatrocinadores()
        {
            return _dataBaseContext.Patrocinadores;
        }
    }
}