using DesafioOfx.Core.Data;
using DesafioOfx.Domain;
using DesafioOfx.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DesafioOfx.Data.Repository
{
    public class BancoRepository : IBancoRepository
    {
        private readonly MeuDbContext _context;

        public BancoRepository(MeuDbContext context)
        {
            _context = context;
        }
        public IUnitOfWork UnitOfWork => _context;

        public void AdicionarTransacao(Transacao transacao)
        {
            _context.Transacoes.Add(transacao);
        }

        public void AtualizarTransacao(Transacao transacao)
        {
            _context.Transacoes.Update(transacao);
        }
        
        public async Task<IEnumerable<Conta>> ObterContaPorIdComTransacoes(int contaId)
        {
            return await _context.Contas.AsNoTracking().Include(c => c.Transacaos).Where(c => c.Id == contaId).ToListAsync();
        }

        public async Task<IEnumerable<Transacao>> ObterTransacoesPredicado(Expression<Func<Transacao, bool>> predicate)
        {
            return await _context.Transacoes.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<Conta>> ObterContaPredicadoComTransacoes(Expression<Func<Conta, bool>> predicate)
        {
            return await _context.Contas.AsNoTracking().Where(predicate).ToListAsync();
        }
        public void Dispose()
        {
            _context?.Dispose();
        }

        
    }
}
