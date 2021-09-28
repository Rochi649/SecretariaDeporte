using System.Collections.Generic;
using EventosDeportivos.Dominio;

namespace EventosDeportivos.Persistencia
{
    public interface IRepositorioTorneo
    {
        bool CrearTorneo (Torneo torneo);
        bool EliminarTorneo (int idTorneo);
        bool ActualizarTorneo (Torneo torneo);
        Torneo BuscarTorneo (int idTorneo);
        IEnumerable<Torneo> ListarTorneos();
    }
}