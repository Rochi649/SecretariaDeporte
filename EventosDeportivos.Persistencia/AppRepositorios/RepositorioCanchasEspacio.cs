using System.Collections.Generic;
using EventosDeportivos.Dominio;
using System.Linq;

namespace EventosDeportivos.Persistencia
{
    public class RepositorioCanchasEspacio : IRepositorioCanchasEspacio
    {
        //Propiedades
        private readonly AppContext _dataBaseContext;

        //Metodos
        //Constructor
        public RepositorioCanchasEspacio(AppContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }   

        //Implementción métodos de la Interfaz RepositorioCanchasEspacio
        
        bool IRepositorioCanchasEspacio.CrearCanchasEspacio(CanchasEspacio canchasEspacio)
        {
            bool creado = false;
            try
            {
                //objetoappcontext.nombredelatablaenBD.Add(argumento);
                 _dataBaseContext.CanchasEspacios.Add(canchasEspacio);
                 _dataBaseContext.SaveChanges();
                 creado = true;
            }
            catch (System.Exception)
            {
                creado = false;
            }

            return creado;
        }
 
         bool IRepositorioCanchasEspacio.EliminarCanchasEspacio(int idCanchasEspacio)
        {
            bool eliminado = false;
            var canchasEspacio = _dataBaseContext.CanchasEspacios.Find(idCanchasEspacio);

            if (canchasEspacio != null)
            {
                try
            {

                 _dataBaseContext.CanchasEspacios.Remove(canchasEspacio);
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

        bool IRepositorioCanchasEspacio.ActualizarCanchasEspacio(CanchasEspacio canchasEspacio)
        {
            bool actualizado = false;
            var canchas_a_actualizar = _dataBaseContext.CanchasEspacios.Find(canchasEspacio.Id);

            if (canchas_a_actualizar != null)
            {
               try
            {
                canchas_a_actualizar.Deporte = canchasEspacio.Deporte;
                canchas_a_actualizar.Estado = canchasEspacio.Estado;
                canchas_a_actualizar.Medidas = canchasEspacio.Medidas;
                canchas_a_actualizar.CapacidadEspectadores = canchasEspacio.CapacidadEspectadores;
                canchas_a_actualizar.EscenarioId = canchasEspacio.EscenarioId;
                
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

        CanchasEspacio IRepositorioCanchasEspacio.BuscarCanchasEspacio(int idCanchasEspacio)
        {
            CanchasEspacio canchasEspacio = _dataBaseContext.CanchasEspacios.Find(idCanchasEspacio);

            return canchasEspacio;
        }

        IEnumerable<CanchasEspacio> IRepositorioCanchasEspacio.ListarCanchasEspacios()
        {
            return _dataBaseContext.CanchasEspacios;
        }


    }
}