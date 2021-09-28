using System.Collections.Generic;
using EventosDeportivos.Dominio;

namespace EventosDeportivos.Persistencia
{
    public interface IRepositorioArbitro
    {
        bool CrearArbitro (Arbitro arbitro);
        bool EliminarArbitro (int idArbitro);
        bool ActualizarArbitro (Arbitro arbitro);
        Arbitro BuscarArbitro (int idArbitro);
        IEnumerable<Arbitro> ListarArbitros();
    }
}