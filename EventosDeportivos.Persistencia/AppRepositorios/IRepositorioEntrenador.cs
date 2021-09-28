using System.Collections.Generic;
using EventosDeportivos.Dominio;

namespace EventosDeportivos.Persistencia
{
    public interface IRepositorioEntrenador
    {   
        bool CrearEntrenador (Entrenador entrenador);
        bool EliminarEntrenador (int idEntrenador);
        bool ActualizarEntrenador (Entrenador entrenador);
        Entrenador BuscarEntrenador (int idEntrenador);
        IEnumerable<Entrenador> ListarEntrenadores();
        
                 
    }
}