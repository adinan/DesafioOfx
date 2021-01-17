using AutoMapper;
using DesafioOfx.Application.Commands;
using DesafioOfx.Application.Queries.ViewModels;

namespace DesafioOfx.Application.AutoMapper
{
    class ViewModelToCommandMappingProfile : Profile
    {
        public ViewModelToCommandMappingProfile()
        {
            CreateMap<TransacaoViewModel, AdicionarLancamentoFinanceiroContaCommand>()
               .ConstructUsing(tvm =>
                   new AdicionarLancamentoFinanceiroContaCommand(tvm.ContaId, tvm.TipoTransacao, tvm.DataLancamento, tvm.Valor, tvm.CodigoUnico, tvm.Protocolo, tvm.CodigoReferencia, tvm.Descricacao)
               );
        }
    }
}
