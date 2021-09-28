using System.Collections.Generic;
using EventosDeportivos.Dominio;

namespace EventosDeportivos.Persistencia
{
    public interface IRepositorioDeportista
    {
        bool CrearDeportista (Deportista deportista);
        bool EliminarDeportista (int idDeportista);
        bool ActualizarDeportista (Deportista deportista);
        Deportista BuscarDeportista (int idDeportista);
        IEnumerable<Deportista> ListarDeportistas();
    }
}