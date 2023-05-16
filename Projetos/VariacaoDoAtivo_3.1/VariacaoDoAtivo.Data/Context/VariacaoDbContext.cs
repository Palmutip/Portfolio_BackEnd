using Microsoft.EntityFrameworkCore;
using VariacaoDoAtivo.Domain;

namespace VariacaoDoAtivo.Data
{
    public class VariacaoDbContext : DbContext
    {
        public VariacaoDbContext(DbContextOptions<VariacaoDbContext> option) : base(option)
        {

        }

        #region DB SETs

        public DbSet<Variacao> Variacoes => Set<Variacao>();
        public DbSet<Usuario> Usuarios => Set<Usuario>();

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VariacaoMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());

            modelBuilder.ApplyGlobalConfigurations();
            modelBuilder.SeedData();

            base.OnModelCreating(modelBuilder);
        }
    }
}
