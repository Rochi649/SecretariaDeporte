using System.Collections.Generic;
using EventosDeportivos.Dominio;

namespace EventosDeportivos.Persistencia
{
    public interface IRepositorioEscenario
    {
        bool CrearEscenario (Escenario escenario);
        bool EliminarEscenario (int idEscenario);
        bool ActualizarEscenario (Escenario escenario);
        Escenario BuscarEscenario(int idEscenario);
        IEnumerable<Escenario> ListarEscenarios();
    }
}