using ControlePendencias.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ControlePendencias.Data.Firebird.Mappings
{
    public class PendenciaMapping : EntityTypeConfiguration<Pendencia>
    {
        public PendenciaMapping()
        {
            this.ToTable("PENDENCIA");
            this.HasKey(p => p.Id);
            this.Property(p => p.Id).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.Titulo).IsRequired().HasColumnName("TITULO").HasMaxLength(100);
            this.Property(p => p.Descricao).IsRequired().HasColumnName("DESCRICAO").HasMaxLength(300);
            this.Property(p => p.DataCadastro).IsRequired().HasColumnName("DT_CADASTRO");
            this.Property(p => p.DataFinal).IsRequired().HasColumnName("DT_FINAL");
            this.Property(p => p.Status).IsRequired().HasColumnName("STATUS");
            this.Property(p => p.Prioridade).IsRequired().HasColumnName("PRIORIDADE");
            this.Property(p => p.Complexidade).IsRequired().HasColumnName("COMPLEXIDADE");
            this.Property(p => p.ResponsavelId).IsRequired().HasColumnName("ID_RESPONSAVEL");

        }
    }
}
