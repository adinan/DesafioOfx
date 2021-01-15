using AutoMapper;
using DesafioOfx.Application.Queries.ViewModels;
using DesafioOfx.Domain;

namespace DesafioOfx.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Banco, BancoViewModel>();
            CreateMap<Agencia, AgenciaViewModel>();
            CreateMap<Conta, ContaViewModel>()
                .ForMember(cvm => cvm.Transacoes, o => o.MapFrom(s => s.Transacaos))
                .ForMember(tvm => tvm.ContaId, o => o.MapFrom(s => s.Id));


            CreateMap<Transacao, TransacaoViewModel>()
                .ForMember(tvm => tvm.TransacaoId, o => o.MapFrom(s => s.Id));
        }
    }
}
