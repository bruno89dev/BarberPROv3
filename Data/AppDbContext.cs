using BarberPROv3.Models;
using Microsoft.EntityFrameworkCore;

namespace BarberPROv3.Data {
    public class AppDbContext : DbContext {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
        }

        public DbSet<Barbeiro> Barbeiros { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Atendimento> Atendimentos { get; set; }
        public DbSet<AtendimentoItem> AtendimentoItens { get; set; }
        public DbSet<Caixa> Caixas { get; set; }
        public DbSet<MovCaixa> MovimentacoesCaixa { get; set; }

    }
}
