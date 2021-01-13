using DesafioOfx.Core.DomainObjects;
using System;

namespace DesafioOfx.Domain
{
    public class Transacao : Entity
    {
        public int ContaId { get; private set; }
        public int TipoTransacao { get; private set; } //TRNTYPE
        public DateTime DataLancamento { get; private set; }//DTPOSTED
        public decimal Valor { get; private set; }
        public string CodigoUnico { get; private set; }
        public string Protocolo { get; private set; } //CHECKNUM
        public string CodigoReferencia { get; private set; } //REFNUM
        public string Descricacao { get; private set; } //MEMO

        public Conta Conta { get; private set; }


        public Transacao(int tipoTransacao, DateTime dataLancamento, decimal valor, string codigoUnico, string protocolo, string codigoReferencia, string descricacao)
        {
            TipoTransacao = tipoTransacao;
            DataLancamento = dataLancamento;
            Valor = valor;
            CodigoUnico = codigoUnico;
            Protocolo = protocolo;
            CodigoReferencia = codigoReferencia;
            Descricacao = descricacao;
        }


        internal void AssociarConta(int condaId)
        {
            ContaId = condaId;
        }

        public override bool EhValido()
        {
            //regras de commands
            return true;
        }

    }
}
