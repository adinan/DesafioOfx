using AutoMapper;
using DesafioOfx.Application.ViewModels;
using DesafioOfx.Domain;

namespace DesafioOfx.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<BancoViewModel, Banco>()
                .ConstructUsing(bvm =>
                    new Banco(bvm.Codigo, bvm.Nome)
                );

            CreateMap<AgenciaViewModel, Agencia>()
               .ConstructUsing(avm =>
                   new Agencia(avm.BancoId, avm.Codigo, avm.Digito, avm.Nome)
               );

            CreateMap<ContaViewModel, Conta>()
               .ConstructUsing(cvm =>
                   new Conta(cvm.AgenciaId, cvm.Codigo, cvm.Digito)
               );

            CreateMap<TransacaoViewModel, Transacao>()
               .ConstructUsing(tvm =>
                   new Transacao(tvm.TipoTransacao, tvm.DataLancamento, tvm.Valor, tvm.CodigoUnico, tvm.Protocolo, tvm.CodigoReferencia, tvm.Descricacao)
               );
        }
    }
}
