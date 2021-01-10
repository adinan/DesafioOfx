﻿using System;

namespace DesafioOfx.Application.ViewModels
{
    public class TransacaoViewModel
    {
        public int ContaId { get; set; }
        public int TipoTransacao { get; set; } //TRNTYPE
        public DateTime DataLancamento { get; set; }//DTPOSTED
        public decimal Valor { get; set; }
        public string CodigoUnico { get; set; }
        public string Protocolo { get; set; } //CHECKNUM
        public string CodigoReferencia { get; set; } //REFNUM
        public string Descricacao { get; set; } //MEMO
    }
}
