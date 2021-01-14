using AutoMapper;
using DesafioOfx.Application.Queries.ViewModels;
using OfxNet;

namespace DesafioOfx.Application.AutoMapper
{
    public class ViewModelToCommandProfile : Profile
    {
        public ViewModelToCommandProfile()
        {
            CreateMap<OfxStatementTransaction, TransacaoViewModel>()
               .ForMember(dest => dest.TipoTransacao, opt => opt.MapFrom(src => src.Amount))
               .ForMember(dest => dest.DataLancamento, opt => opt.MapFrom(src => src.DatePosted))
               .ForMember(dest => dest.Valor, opt => opt.MapFrom(src => src.Amount))
               .ForMember(dest => dest.CodigoUnico, opt => opt.MapFrom(src => src.Amount))
               .ForMember(dest => dest.Protocolo, opt => opt.MapFrom(src => ""))
               .ForMember(dest => dest.CodigoReferencia, opt => opt.MapFrom(src => ""))
               .ForMember(dest => dest.Descricacao, opt => opt.MapFrom(src => ""));

            /*
             public int TransacaoId { get; set; }
            public int ContaId { get; set; }
            public int TipoTransacao { get; set; } //TRNTYPE
            public DateTime DataLancamento { get; set; }//DTPOSTED
            public decimal Valor { get; set; }
            public string CodigoUnico { get; set; }
            public string Protocolo { get; set; } //CHECKNUM
            public string CodigoReferencia { get; set; } //REFNUM
            public string Descricacao { get; set; } //MEMO
             */
        }
    }
}
