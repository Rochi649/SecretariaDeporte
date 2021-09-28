using System.Collections.Generic;
using EventosDeportivos.Dominio;

namespace EventosDeportivos.Persistencia
{
    public interface IRepositorioEscuelaArbitro
    {
        bool CrearEscuelaArbitro (EscuelaArbitro escuelaArbitro);
        bool EliminarEscuelaArbitro(int idEscuelaArbitro);
        bool ActualizarEscuelaArbitro (EscuelaArbitro escuelaArbitro);
        EscuelaArbitro BuscarEscuelaArbitro (int idEscuelaArbitro);
        IEnumerable<EscuelaArbitro> ListarEscuelas();
    }
}