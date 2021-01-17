using DesafioOfx.Application.Queries.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioOfx.Application.Queries
{
    public interface  IContaQueries
    {
        Task<ContaViewModel> ObterContaId(int ContId);

        Task<List<TransacaoViewModel>> ObterExtratoCliente(int contId, DateTime dataIncio, DateTime dataFim);
        Task<ContaViewModel> ObterConta(InformacaoContaPessoaViewModel viewModel);
        Task<TransacaoViewModel> ObterTransacaoPorCodigoUnico(string codigoUnico);
    }
}
