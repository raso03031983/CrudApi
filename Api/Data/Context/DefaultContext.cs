using Data.Context.Model;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class DefaultContext : DbContext
    {

        public DefaultContext(DbContextOptions<DefaultContext> options) : base(options) { }
       
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<RedeSocial> RedeSocial { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Telefone> Telefone { get; set; }
        public DbSet<ClienteEndereco> ClienteEndereco { get; set; }
        public DbSet<ClienteRedeSocial> ClienteRedeSocial { get; set; }
        public DbSet<ClienteRedeSocial> ClienteTelefone { get; set; }
    }
}
