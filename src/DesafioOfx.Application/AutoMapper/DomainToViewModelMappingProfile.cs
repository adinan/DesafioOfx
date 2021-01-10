using AutoMapper;
using DesafioOfx.Application.ViewModels;
using DesafioOfx.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
