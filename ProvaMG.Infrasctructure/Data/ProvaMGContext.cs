using Microsoft.EntityFrameworkCore;
using ProvaMG.Domain;

namespace ProvaMG.Infrasctructure.Data
{
    public class ProvaMGContext : DbContext
    {
        public static string DEFAULT_SCHEMA = "dbo";
        public static string MUNICIPIOS_TABLE = "tb_tipo_municipio";
        public const string USUARIOS_TABLE = "tb_usuario";
        
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Municipio> Municipios { get; set; }

        public ProvaMGContext(DbContextOptions<ProvaMGContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new MunicipioConfiguration());
        }
        
    }
}