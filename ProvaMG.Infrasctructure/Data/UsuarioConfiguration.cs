using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProvaMG.Domain;

namespace ProvaMG.Infrasctructure.Data
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable(ProvaMGContext.USUARIOS_TABLE, ProvaMGContext.DEFAULT_SCHEMA);

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).IsRequired();
            builder.Property(u => u.Email)
                .HasColumnName("mail")
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(u => u.Password)
                .HasColumnName("password")
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(u => u.IsActive)
                .HasColumnName("is_active")
                .IsRequired()
                .HasDefaultValue(1);
        }
    }
}