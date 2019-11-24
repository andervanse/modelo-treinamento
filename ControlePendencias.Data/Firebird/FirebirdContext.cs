using System.Data.Entity;
using ControlePendencias.Data.Firebird.Mappings;
using ControlePendencias.Domain;

namespace ControlePendencias.Data.Firebird
{
    public class FirebirdContext : DbContext
    {

        public FirebirdContext() : base("fbConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PendenciaMapping());
            modelBuilder.Configurations.Add(new ResponsavelMapping());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Responsavel> Responsaveis { get; set; }
        public DbSet<Pendencia> Pendencias { get; set; }

    }
}
