using System;

namespace DesafioOfx.Application.Queries.ViewModels
{
    public class TransacaoViewModel
    {
        public int TransacaoId { get; set; }
        public int ContaId { get; set; }
        public string TipoTransacao { get; set; } //TRNTYPE
        public DateTime DataLancamento { get; set; }//DTPOSTED
        public decimal Valor { get; set; }
        public string CodigoUnico { get; set; }
        public string Protocolo { get; set; } //CHECKNUM
        public string CodigoReferencia { get; set; } //REFNUM
        public string Descricacao { get; set; } //MEMO
    }
}
