using System.Collections.Generic;
using EventosDeportivos.Dominio;

namespace EventosDeportivos.Persistencia
{
    public interface IRepositorioMunicipio
    {
        bool CrearMunicipio (Municipio municipio);
        bool EliminarMunicipio (int idMunicipio);
        bool ActualizarMunicipio (Municipio municipio);
        Municipio BuscarMunicipio (int idMunicipio);
        IEnumerable<Municipio> ListarMunicipios();
    }
}