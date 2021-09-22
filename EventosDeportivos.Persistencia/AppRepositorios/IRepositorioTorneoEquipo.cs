using System.Collections.Generic;
using EventosDeportivos.Dominio;

namespace EventosDeportivos.Persistencia
{
    public interface IRepositorioTorneoEquipo
    {
        bool InscribirEquipoATorneo(int idEquipo, int idTorneo);
        IEnumerable<TorneoEquipo> ListarInscritos();
         
    }
}