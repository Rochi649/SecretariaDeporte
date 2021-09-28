using System.Collections.Generic;
using EventosDeportivos.Dominio;

namespace EventosDeportivos.Persistencia
{
    public interface IRepositorioPatrocinador
    {
        bool CrearPatrocinador (Patrocinador patrocinador);
        bool EliminarPatrocinador (int idPatrocinador);
        bool ActualizarPatrocinador (Patrocinador patrocinador);
        Patrocinador BuscarPatrocinador (int idPatrocinador);
        IEnumerable<Patrocinador> ListarPatrocinadores();
    }
}