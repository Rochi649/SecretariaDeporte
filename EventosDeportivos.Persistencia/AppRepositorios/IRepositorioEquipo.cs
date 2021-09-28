using System.Collections.Generic;
using EventosDeportivos.Dominio;

namespace EventosDeportivos.Persistencia
{
    public interface IRepositorioEquipo
    {
        bool CrearEquipo (Equipo equipo);
        bool EliminarEquipo (int idEquipo);
        bool ActualizarEquipo (Equipo equipo);
        Equipo BuscarEquipo (int idEquipo);
        IEnumerable<Equipo> ListarEquipos();
    }
}