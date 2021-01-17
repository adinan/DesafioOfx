using AutoMapper;
using DesafioOfx.Application.Queries.ViewModels;
using OfxNet;
using System;

namespace DesafioOfx.Application.AutoMapper
{
    public class OfxNetToViewModelProfile : Profile
    {
        public OfxNetToViewModelProfile()
        {

            CreateMap<OfxBankAccount, InformacaoContaPessoaViewModel>()
                .ForMember(dest => dest.BancoCodigo, opt => opt.MapFrom(src => src.BankId))
                .ForMember(dest => dest.AgenciaCodigo, opt => opt.MapFrom(src => src.BranchId.Split("-", StringSplitOptions.None)[0]))
                .ForMember(dest => dest.AgenciaDigito, opt => opt.MapFrom(src => src.BranchId.Contains("-") ? src.BranchId.Split("-", StringSplitOptions.None)[1] : null))
                .ForMember(dest => dest.ContaCodigo, opt => opt.MapFrom(src => src.AccountNumber.Split("-", StringSplitOptions.None)[0]))
                .ForMember(dest => dest.ContaDigito, opt => opt.MapFrom(src => src.BranchId.Contains("-") ? src.AccountNumber.Split("-", StringSplitOptions.None)[1] : null));

        }
    }
}
