using System.Collections.Generic;
using EventosDeportivos.Dominio;
using System.Linq;

namespace EventosDeportivos.Persistencia
{
    public class RepositorioArbitro : IRepositorioArbitro
    {
       //Propiedades
        private readonly AppContext _dataBaseContext;

        //Metodos
        //Constructor
        public RepositorioArbitro(AppContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }    

        //Se van a implementar los métodos de la Interfaz RepositorioArbitro
        //tipodedato nombredelainterfaz.nombredelmetodo(argumentos)

        bool IRepositorioArbitro.CrearArbitro(Arbitro arbitro)
        {
            bool creado = false;
            try
            {
                 _dataBaseContext.Arbitros.Add(arbitro);
                 _dataBaseContext.SaveChanges();
                 creado = true;
            }
            catch (System.Exception)
            {
                creado = false;
            }

            return creado;
        }

        bool IRepositorioArbitro.EliminarArbitro(int idArbitro)
        {
            bool eliminado = false;
            var arbitro = _dataBaseContext.Arbitros.Find(idArbitro);

            if (arbitro != null)
            {
                try
            {

                 _dataBaseContext.Arbitros.Remove(arbitro);
                 _dataBaseContext.SaveChanges();
                 eliminado = true;
            }
            catch (System.Exception)
            {
                eliminado = false;
            }

            }
            return eliminado;
        }

        bool IRepositorioArbitro.ActualizarArbitro(Arbitro arbitro)
        {
            bool actualizado = false;
            var arbitro_a_actualizar = _dataBaseContext.Arbitros.Find(arbitro.Id);

            if (arbitro_a_actualizar != null)
            {
               try
            {
                arbitro_a_actualizar.Documento = arbitro.Documento;
                arbitro_a_actualizar.Nombre = arbitro.Nombre;
                arbitro_a_actualizar.Apellido = arbitro.Apellido;
                arbitro_a_actualizar.Genero = arbitro.Genero;
                arbitro_a_actualizar.Telefono = arbitro.Telefono;
                arbitro_a_actualizar.Correo = arbitro.Correo;
                arbitro_a_actualizar.Deporte = arbitro.Deporte;
                arbitro_a_actualizar.TorneoId = arbitro.TorneoId;
                arbitro_a_actualizar.EscuelaArbitroId = arbitro.EscuelaArbitroId;

                _dataBaseContext.SaveChanges();
                 actualizado = true;
            }
            catch (System.Exception)
            {
                actualizado = false;
            }

            }
            return actualizado; 
        }

        Arbitro IRepositorioArbitro.BuscarArbitro(int idArbitro)
        {
            Arbitro arbitro = _dataBaseContext.Arbitros.Find(idArbitro);

            return arbitro;
        }

        IEnumerable<Arbitro> IRepositorioArbitro.ListarArbitros()
        {
            return _dataBaseContext.Arbitros;
        }
    }
}