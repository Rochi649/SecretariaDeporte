using System.Collections.Generic;
using EventosDeportivos.Dominio;
using System.Linq;

namespace EventosDeportivos.Persistencia
{
    public class RepositorioDeportista : IRepositorioDeportista
    {
        //Propiedades
        private readonly AppContext _dataBaseContext;

        //Metodos
        //Constructor
        public RepositorioDeportista(AppContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }   

        //Implementción métodos de la Interfaz RepositorioDeportista

        bool IRepositorioDeportista.CrearDeportista(Deportista deportista)
        {
            bool creado = false;
            try
            {
                //objetoappcontext.nombredelatablaenBD.Add(argumento);
                 _dataBaseContext.Deportistas.Add(deportista);
                 _dataBaseContext.SaveChanges();
                 creado = true;
            }
            catch (System.Exception)
            {
                creado = false;
            }

            return creado;
        }

        bool IRepositorioDeportista.EliminarDeportista(int idDeportista)
        {
            bool eliminado = false;
            var deportista = _dataBaseContext.Deportistas.Find(idDeportista);

            if (deportista != null)
            {
                try
            {

                 _dataBaseContext.Deportistas.Remove(deportista);
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

        bool IRepositorioDeportista.ActualizarDeportista(Deportista deportista)
        {
            bool actualizado = false;
            var deportista_a_actualizar = _dataBaseContext.Deportistas.Find(deportista.Id);

            if (deportista_a_actualizar != null)
            {
               try
            {
                deportista_a_actualizar.Documento = deportista.Documento;
                deportista_a_actualizar.Nombre = deportista.Nombre;
                deportista_a_actualizar.Apellido = deportista.Apellido;
                deportista_a_actualizar.Genero = deportista.Genero;
                deportista_a_actualizar.Rh = deportista.Rh;
                deportista_a_actualizar.EPS = deportista.EPS;
                deportista_a_actualizar.FechaNacimiento = deportista.FechaNacimiento;
                deportista_a_actualizar.Deporte = deportista.Deporte;
                deportista_a_actualizar.Direccion = deportista.Direccion;
                deportista_a_actualizar.NumeroEmergencia = deportista.NumeroEmergencia;
                deportista_a_actualizar.EquipoId = deportista.EquipoId;

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

        Deportista IRepositorioDeportista.BuscarDeportista(int idDeportista)
        {
            Deportista deportista = _dataBaseContext.Deportistas.Find(idDeportista);

            return deportista;
        }

        IEnumerable<Deportista> IRepositorioDeportista.ListarDeportistas()
        {
            return _dataBaseContext.Deportistas;
        }




    }
}