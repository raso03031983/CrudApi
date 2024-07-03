using Data.Context.Model;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class DefaultContext : DbContext
    {

        public DefaultContext(DbContextOptions<DefaultContext> options) : base(options) { }
       
        public DbSet<TipoTransacao> TipoTransacao { get; set; }
        public DbSet<Conta> Conta { get; set; }
        public DbSet<Transacao> Transacao { get; set; }

    }
}
