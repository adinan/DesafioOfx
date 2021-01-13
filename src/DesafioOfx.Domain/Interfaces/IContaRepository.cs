using DesafioOfx.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DesafioOfx.Domain.Interfaces
{
    public interface IContaRepository : IRepository<Conta>
    {
        Task<Conta> ObterContaPorId(int contaId);
        Task<Conta> ObterContaPorIdAsNoTracking(int contaId);
        Task<IEnumerable<Conta>> ObterContaPredicado(Expression<Func<Conta, bool>> predicate);
    }
}
