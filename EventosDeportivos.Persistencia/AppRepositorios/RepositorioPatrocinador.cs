using System.Collections.Generic;
using EventosDeportivos.Dominio;
using System.Linq;

namespace EventosDeportivos.Persistencia
{
    public class RepositorioPatrocinador : IRepositorioPatrocinador
    {
        //Atributo
        private readonly AppContext _dataBaseContext;

        //Metodos
        //Constructor
        public RepositorioPatrocinador(AppContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        IEnumerable<Patrocinador> IRepositorioPatrocinador.ListarPatrocinadores()
        {
            return _dataBaseContext.Patrocinadores;
        }

        Patrocinador IRepositorioPatrocinador.BuscarPatrocinador(int idPatrocinador)
        {
            var patrocinador = _dataBaseContext.Patrocinadores.Find(idPatrocinador);
            _dataBaseContext.SaveChanges();

            return patrocinador;
        }

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

            var patrocinador_a_eliminar = _dataBaseContext.Patrocinadores.Find(idPatrocinador);

            try
            {
                 _dataBaseContext.Patrocinadores.Remove(patrocinador_a_eliminar);
                 _dataBaseContext.SaveChanges();
                 eliminado = true;
            }
            catch (System.Exception)
            {
                eliminado = false;
            }
            return eliminado;
        }

        bool IRepositorioPatrocinador.ActualizarPatrocinador(Patrocinador patrocinador)
        {
            return true;
        }
    }
}