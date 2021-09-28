using System.Collections.Generic;
using EventosDeportivos.Dominio;

namespace EventosDeportivos.Persistencia
{
    public interface IRepositorioCanchasEspacio
    {
        bool CrearCanchasEspacio (CanchasEspacio canchasEspacio);
        bool EliminarCanchasEspacio (int idCanchasEspacio);
        bool ActualizarCanchasEspacio (CanchasEspacio canchasEspacio);
        CanchasEspacio BuscarCanchasEspacio (int idCanchasEspacio);
        IEnumerable<CanchasEspacio> ListarCanchasEspacios();
    }
}