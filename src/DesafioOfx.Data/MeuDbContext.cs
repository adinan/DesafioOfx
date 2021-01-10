using DesafioOfx.Core.Data;
using DesafioOfx.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioOfx.Data
{
    public class MeuDbContext : DbContext, IUnitOfWork
    {
        public MeuDbContext(DbContextOptions<MeuDbContext> options) : base(options) { }

        public DbSet<Banco> Bancos { get; set; }
        public DbSet<Agencia> Agencias { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ////Qndo não definir o tamanho das propriedades string Fluent API ou na data Notation a mesma será criada como varchar(100)
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            //modelBuilder.Ignore<Event>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> Commit()
        {
            //Alguma validação antes de salvar.

            return await base.SaveChangesAsync() > 0;
        }
    }
}
