using DesafioOfx.Application.Queries.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioOfx.Application.Services
{
    public interface IBancoService : IDisposable
    {
        Task<IEnumerable<ContaViewModel>> ObterContaPorIdComLancamentosBancarios(int contaId);
        Task AdicionarLancamentoFinanceiro(TransacaoViewModel transacaoViewModel);
        Task AtualizarLancamentoFinanceiro(TransacaoViewModel transacaoViewModel);
        Task<IEnumerable<ContaViewModel>> ObterExtratoConta(int contaId, DateTime dataInicioExtrato, DateTime dataFimExtrato);
        Task ImportarOfx(string arquivoOfx);

    }
}
