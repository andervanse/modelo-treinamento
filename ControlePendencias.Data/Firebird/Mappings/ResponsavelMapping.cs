using ControlePendencias.Domain;
using System.Data.Entity.ModelConfiguration;

namespace ControlePendencias.Data.Firebird.Mappings
{
    public class ResponsavelMapping : EntityTypeConfiguration<Responsavel>
    {
        public ResponsavelMapping()
        {
            this.ToTable("RESPONSAVEL");
            this.HasKey(r => r.Id);
            this.Property(r => r.Id).HasColumnName("ID");
            this.Property(r => r.Nome).HasColumnName("NOME").HasMaxLength(100).IsRequired();
            this.Property(r => r.Email).HasColumnName("EMAIL").HasMaxLength(60).IsRequired();
            this.Property(r => r.Funcao).HasColumnName("FUNCAO").IsRequired();
        }
    }
}
