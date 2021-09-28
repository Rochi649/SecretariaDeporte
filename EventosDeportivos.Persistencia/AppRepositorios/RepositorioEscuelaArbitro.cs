using System.Collections.Generic;
using EventosDeportivos.Dominio;
using System.Linq;

namespace EventosDeportivos.Persistencia
{
    public class RepositorioEscuelaArbitro : IRepositorioEscuelaArbitro
    {
        //Propiedades
        private readonly AppContext _dataBaseContext;

        //Metodos
        //Constructor
        public RepositorioEscuelaArbitro(AppContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }   

        //Implementación métodos de la Interfaz RepositorioEscuelaArbitro
        
        bool IRepositorioEscuelaArbitro.CrearEscuelaArbitro(EscuelaArbitro escuelaArbitro)
        {
            bool creado = false;
            try
            {
                 _dataBaseContext.Escuelas.Add(escuelaArbitro);
                 _dataBaseContext.SaveChanges();
                 creado = true;
            }
            catch (System.Exception)
            {
                creado = false;
            }

            return creado;
        }

        bool IRepositorioEscuelaArbitro.EliminarEscuelaArbitro(int idEscuelaArbitro)
        {
            bool eliminado = false;
            var escuelaArbitro = _dataBaseContext.Escuelas.Find(idEscuelaArbitro);

            if (escuelaArbitro != null)
            {
                try
            {

                 _dataBaseContext.Escuelas.Remove(escuelaArbitro);
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

        bool IRepositorioEscuelaArbitro.ActualizarEscuelaArbitro(EscuelaArbitro escuelaArbitro)
        {
            bool actualizado = false;
            var escuelaArbitro_a_actualizar = _dataBaseContext.Escuelas.Find(escuelaArbitro.Id);

            if (escuelaArbitro_a_actualizar != null)
            {
               try
            {
                escuelaArbitro_a_actualizar.NIT = escuelaArbitro.NIT;
                escuelaArbitro_a_actualizar.Nombre = escuelaArbitro.Nombre;
                escuelaArbitro_a_actualizar.Direccion = escuelaArbitro.Direccion;
                escuelaArbitro_a_actualizar.Telefono = escuelaArbitro.Telefono;
                escuelaArbitro_a_actualizar.Correo = escuelaArbitro.Correo;
                escuelaArbitro_a_actualizar.Resolucion = escuelaArbitro.Resolucion;
                escuelaArbitro_a_actualizar.Arbitros = escuelaArbitro.Arbitros;
               
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

        EscuelaArbitro IRepositorioEscuelaArbitro.BuscarEscuelaArbitro(int idEscuelaArbitro)
        {
            EscuelaArbitro escuelaArbitro= _dataBaseContext.Escuelas.Find(idEscuelaArbitro);

            return escuelaArbitro;
        }

        IEnumerable<EscuelaArbitro> IRepositorioEscuelaArbitro.ListarEscuelas()
        {
            return _dataBaseContext.Escuelas;
        }
    }
}