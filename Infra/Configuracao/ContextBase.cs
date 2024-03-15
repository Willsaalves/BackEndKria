using Entities.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infra.Configuracao
{
    public class ContextBase : IdentityDbContext
    {
        public ContextBase(DbContextOptions options) 
        {


        }

        public DbSet<Favorite> Favorites { get; set; }
        public object ExampleEntities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("FileName=database", option => {
                    option.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
                    ;
                });
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Favorite>().ToTable("Favorite");
            modelBuilder.Entity<Favorite>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Id).IsUnique();
            });







            base.OnModelCreating(modelBuilder);
        }





    }
}
