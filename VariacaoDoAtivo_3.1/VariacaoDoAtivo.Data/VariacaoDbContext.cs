using Microsoft.EntityFrameworkCore;
using VariacaoDoAtivo.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace VariacaoDoAtivo.Data
{
    public class VariacaoDbContext : DbContext
    {
        public VariacaoDbContext(DbContextOptions<VariacaoDbContext> option) : base(option)
        {

        }

        #region DB SETs

        public DbSet<Variacao> Variacoes => Set<Variacao>();

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VariacaoMap());

            modelBuilder.SeedData();

            base.OnModelCreating(modelBuilder);
        }
    }
}
