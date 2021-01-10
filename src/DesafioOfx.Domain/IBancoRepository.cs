using DesafioOfx.Core.Data;
using DesafioOfx.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DesafioOfx.Domain
{
    public interface IBancoRepository : IRepository<Banco>
    { 
        Task<IEnumerable<Conta>> ObterContaPorIdComTransacoes(int contaId);
        Task<IEnumerable<Conta>> ObterContaPredicadoComTransacoes(Expression<Func<Conta, bool>> predicate);
        void AdicionarTransacao(Transacao transacao);
        void AtualizarTransacao(Transacao transacao);
    }
}
