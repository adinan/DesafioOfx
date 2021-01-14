using AutoMapper;
using DesafioOfx.Application.Commands;
using DesafioOfx.Application.Queries.ViewModels;

namespace DesafioOfx.Application.AutoMapper
{
    public class ViewModelToCommandProfile : Profile
    {
        public ViewModelToCommandProfile()
        {
            CreateMap<TransacaoViewModel, AdicionarLancamentoFinanceiroContaCommand>()
               .ConstructUsing(tvm =>
                   new AdicionarLancamentoFinanceiroContaCommand(tvm.ContaId, tvm.TipoTransacao, tvm.DataLancamento, tvm.Valor, tvm.CodigoUnico, tvm.Protocolo, tvm.CodigoReferencia, tvm.Descricacao)
               );

            CreateMap<TransacaoViewModel, AtualizarLancamentoFinanceiroContaCommand>()
               .ConstructUsing(tvm =>
                   new AtualizarLancamentoFinanceiroContaCommand(tvm.TransacaoId, tvm.ContaId, tvm.TipoTransacao, tvm.DataLancamento, tvm.Valor, tvm.CodigoUnico, tvm.Protocolo, tvm.CodigoReferencia, tvm.Descricacao)
               );
        }
    }
}
