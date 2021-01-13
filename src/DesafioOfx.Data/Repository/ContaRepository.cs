using DesafioOfx.Core.Data;
using DesafioOfx.Domain;
using DesafioOfx.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DesafioOfx.Data.Repository
{
    public class ContaRepository : IContaRepository
    {
        private readonly ContaContext _context;

        public ContaRepository(ContaContext context)
        {
            _context = context;
        }
        public IUnitOfWork UnitOfWork => _context;

        public async Task<Conta> ObterContaPorId(int contaId)
        {
            var conta = await _context.Contas.FirstOrDefaultAsync(c => c.Id == contaId);
            if (conta == null) return null;

            await _context.Entry(conta)
               .Collection(i => i.Transacaos).LoadAsync();

            return conta;
        }

        public Task<IEnumerable<Conta>> ObterContaPredicado(Expression<Func<Conta, bool>> predicate)
        {
            throw new NotImplementedException();
        }


        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<Conta> ObterContaPorIdAsNoTracking(int contaId)
        {
            return await _context.Contas.AsNoTracking().FirstOrDefaultAsync(c => c.Id == contaId);
        }
    }
}
