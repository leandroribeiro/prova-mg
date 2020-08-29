using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProvaMG.Domain;

namespace ProvaMG.Infrasctructure.Data
{
    public class MunicipioConfiguration: IEntityTypeConfiguration<Municipio>
    {
        public void Configure(EntityTypeBuilder<Municipio> builder)
        {
            builder.ToTable(ProvaMGContext.MUNICIPIOS_TABLE, ProvaMGContext.DEFAULT_SCHEMA);

            builder.HasKey(u => u.Codigo);
            builder.Property(u => u.Codigo)
                .HasColumnName("tipo_municipio_cod");
            builder.Property(u => u.Nome)
                .HasColumnName("tipo_municipio_nome")
                .HasMaxLength(255)
                .IsRequired();
            builder.Property(m => m.UFCodigo)
                .HasColumnName("tipo_uf_cod")
                .IsRequired();
            builder.Property(m => m.MunicipioFazenda)
                .HasColumnName("tipo_municipio_fazenda")
                .HasMaxLength(5);
            builder.Property(m => m.Ativo)
                .HasColumnName("tipo_municipio_ativo")
                .IsRequired();
            builder.Property(m => m.CodigoExt)
                .HasColumnName("tipo_municipio_cod_ext")
                .IsRequired()
                .HasMaxLength(5);
            builder.Property(m => m.RendimentoId)
                .HasColumnName("tipo_municipio_id_rendimento");
            builder.Property(m => m.UF)
                .HasColumnName("tipo_municipio_uf")
                .HasMaxLength(2);
            builder.Ignore(m => m.Editavel);

        }
    }
}