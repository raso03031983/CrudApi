using Data.Context.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Data.Context
{
    public class DefaultContext : DbContext
    {

        public DefaultContext(DbContextOptions<DefaultContext> options) : base(options) { }
     
        public DbSet<Livro> Livro { get; set; }
        public DbSet<LivroAssunto> LivroAssunto { get; set; }
        public DbSet<LivroAutor> LivroAutor { get; set; }
        public DbSet<Assunto> Assunto { get; set; }
        public DbSet<Autor> Autor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }

    }
}
