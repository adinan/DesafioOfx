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
            CreateMap<Conta, ContaViewModel>();
            CreateMap<Transacao, TransacaoViewModel>();
        }
    }
}
