using CooperativaAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CooperativaAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<Cooperativa> Cooperativas { get; set; }
        public DbSet<Cooperado> Cooperados { get; set; }
        public DbSet<ContatoFavorito> ContatosFavoritos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cooperativa>().HasData(
                new Cooperativa { Id = 1, Descricao = "Cooperativa A" },
                new Cooperativa { Id = 2, Descricao = "Cooperativa B" },
                new Cooperativa { Id = 3, Descricao = "Cooperativa C" }
            );
            
            base.OnModelCreating(modelBuilder);
        }
    }
}