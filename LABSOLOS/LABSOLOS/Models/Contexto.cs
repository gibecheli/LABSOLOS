using Microsoft.EntityFrameworkCore;

namespace LABSOLOS.Models
{
    public class Contexto : DbContext
    {

        public Contexto(DbContextOptions<Contexto> options) :
    base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Analise> Analises { get; set; }
        public DbSet<Solicitacao> Solicitacoes { get; set; }
        public DbSet<Financeiro> Financas { get; set; }

    }
}