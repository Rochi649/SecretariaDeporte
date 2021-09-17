using System;
using EventosDeportivos.Dominio;
using Microsoft.EntityFrameworkCore;

namespace EventosDeportivos.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Arbitro> Arbitros { get; set; }

        public DbSet<CanchasEspacio> CanchasEspacios { get; set; }

        public DbSet<Deportista> Deportistas { get; set; }

        public DbSet<Entrenador> Entrenadores { get; set; }

        public DbSet<Equipo> Equipos { get; set; }

        public DbSet<Escenario> Escenarios { get; set; }

        public DbSet<EscuelaArbitro> Escuelas { get; set; }

        public DbSet<Municipio> Municipios { get; set; }

        public DbSet<Patrocinador> Patrocinadores { get; set; }

        public DbSet<Torneo> Torneos { get; set; }

        public DbSet<TorneoEquipo> TorneosEquipos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder oBuilder)
        {
            if (!oBuilder.IsConfigured)
            {
                oBuilder
                    .UseSqlServer("Data Source = localhost; User ID = sa; Password = Leoandres123; Application Name = EventosDeportivos; Initial Catalog = EventosDeportivos");
            }
        }
    }
}
