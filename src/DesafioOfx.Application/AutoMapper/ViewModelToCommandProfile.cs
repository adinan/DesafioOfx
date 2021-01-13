using AutoMapper;
using DesafioOfx.Application.Commands;
using DesafioOfx.Application.Queries.ViewModels;

namespace DesafioOfx.Application.AutoMapper
{
    public class ViewModelToCommandProfile : Profile
    {
        public ViewModelToCommandProfile()
        {
            CreateMap<TransacaoViewModel, AdicionarLancamentoFinanceiroCommand>()
               .ConstructUsing(tvm =>
                   new AdicionarLancamentoFinanceiroCommand(tvm.TipoTransacao, tvm.DataLancamento, tvm.Valor, tvm.CodigoUnico, tvm.Protocolo, tvm.CodigoReferencia, tvm.Descricacao)
               );
        }
    }
}
