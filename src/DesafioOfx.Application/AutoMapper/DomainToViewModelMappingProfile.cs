using AutoMapper;
using DesafioOfx.Application.ViewModels;
using DesafioOfx.Domain;

namespace DesafioOfx.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Banco, BancoViewModel>();
            CreateMap<Agencia, AgenciaViewModel>();
            CreateMap<Conta, BancoViewModel>();
            CreateMap<Transacao, TransacaoViewModel>();
        }
    }
}
