using System.Collections.Generic;
using EventosDeportivos.Dominio;
using System.Linq;

namespace EventosDeportivos.Persistencia
{
    public class RepositorioMunicipio : IRepositorioMunicipio
    {
        //Propiedades
        private readonly AppContext _dataBaseContext;

        //Metodos
        //Constructor
        public RepositorioMunicipio(AppContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }   

        //Implementación métodos de la Interfaz RepositorioMunicipio
        
        bool IRepositorioMunicipio.CrearMunicipio(Municipio municipio)
        {
            bool creado = false;
            try
            {
                 _dataBaseContext.Municipios.Add(municipio);
                 _dataBaseContext.SaveChanges();
                 creado = true;
            }
            catch (System.Exception)
            {
                creado = false;
            }

            return creado;
        }

        bool IRepositorioMunicipio.EliminarMunicipio(int idMunicipio)
        {
            bool eliminado = false;
            var municipio = _dataBaseContext.Municipios.Find(idMunicipio);

            if (municipio != null)
            {
                try
            {

                 _dataBaseContext.Municipios.Remove(municipio);
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

        bool IRepositorioMunicipio.ActualizarMunicipio(Municipio municipio)
        {
            bool actualizado = false;
            var municipio_a_actualizar = _dataBaseContext.Municipios.Find(municipio.Id);

            if (municipio_a_actualizar != null)
            {
               try
            {
                municipio_a_actualizar.Nombre = municipio.Nombre;
                municipio_a_actualizar.Torneos = municipio.Torneos;

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

        Municipio IRepositorioMunicipio.BuscarMunicipio(int idMunicipio)
        {
            Municipio municipio = _dataBaseContext.Municipios.Find(idMunicipio);

            return municipio;
        }

        IEnumerable<Municipio> IRepositorioMunicipio.ListarMunicipios()
        {
            return _dataBaseContext.Municipios;
        }
    }
}