using System.Collections.Generic;
using EventosDeportivos.Dominio;
using System.Linq;

namespace EventosDeportivos.Persistencia
{
    public class RepositorioTorneoEquipo : IRepositorioTorneoEquipo
    {
        //Atributos
        private readonly AppContext _dataBaseContext;
        //Metodos
        //Constructor
        public RepositorioTorneoEquipo(AppContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        bool IRepositorioTorneoEquipo.InscribirEquipoATorneo(int idEquipo, int idTorneo)
        {
            bool inscrito = false;

            try
            {
                _dataBaseContext.TorneosEquipos.Add(new TorneoEquipo()
                {
                    EquipoId = idEquipo,
                    TorneoId = idTorneo
                });
                _dataBaseContext.SaveChanges();
                inscrito = true;
            }
            catch (System.Exception)
            {

                inscrito = false;
            }

            return inscrito;
        }

         IEnumerable<TorneoEquipo> IRepositorioTorneoEquipo.ListarInscritos()
         {
            return _dataBaseContext.TorneosEquipos;
         }
    }
}