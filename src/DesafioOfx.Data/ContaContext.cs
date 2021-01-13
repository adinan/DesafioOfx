using DesafioOfx.Core.Communication.Mediator;
using DesafioOfx.Core.Data;
using DesafioOfx.Core.Messages;
using DesafioOfx.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioOfx.Data
{
    public class ContaContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;

        public ContaContext(DbContextOptions<ContaContext> options, IMediatorHandler rebusHandler) : base(options) 
        { 
            _mediatorHandler = rebusHandler ?? throw new ArgumentNullException(nameof(rebusHandler));

        }

        public DbSet<Banco> Bancos { get; set; }
        public DbSet<Agencia> Agencias { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ////Qndo não definir o tamanho das propriedades string Fluent API ou na data Notation a mesma será criada como varchar(100)
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.Ignore<Event>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContaContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> Commit()
        {
            var sucesso = await base.SaveChangesAsync() > 0;
            if (sucesso) await _mediatorHandler.PublicarEventos(this);

            return sucesso;
        }
    }
}
