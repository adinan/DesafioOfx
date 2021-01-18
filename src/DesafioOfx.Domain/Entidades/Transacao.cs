using DesafioOfx.Core.DomainObjects;
using System;

namespace DesafioOfx.Domain
{
    public class Transacao : Entity
    {
        public int ContaId { get; private set; }
        public string TipoTransacao { get; private set; } //TRNTYPE
        public DateTime DataLancamento { get; private set; }//DTPOSTED
        public decimal Valor { get; private set; }
        public string CodigoUnico { get; private set; } //FITID
        public string Protocolo { get; private set; } //CHECKNUM
        public string CodigoReferencia { get; private set; } //REFNUM
        public string Descricacao { get; private set; } //MEMO

        public Conta Conta { get; private set; }

        private Transacao(int transacaoId)
        {

        }

        public Transacao(string tipoTransacao, DateTime dataLancamento, decimal valor, string codigoUnico, string protocolo, string codigoReferencia, string descricacao)
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

        internal void AtualizarTipoTransacao(string tipoTransacao)
        {
            TipoTransacao = tipoTransacao;

        }

        internal void AtualizarDataLancamento(DateTime dataLancamento)
        {
            DataLancamento = dataLancamento;

        }

        internal void AtualizarValor(decimal valor)
        {
            Valor = valor;

        }

        internal void AtualizarCodigoUnico(string codigoUnico)
        {
            CodigoUnico = codigoUnico;

        }

        internal void AtualizarProtocolo(string protocolo)
        {
            Protocolo = protocolo;

        }

        internal void AtualizarCodigoReferencia(string codigoReferencia)
        {
            CodigoReferencia = codigoReferencia;

        }

        internal void AtualizarDescricacao(string descricacao)
        {
            Descricacao = descricacao;

        }

        private void AlterarId(int id)
        {
            Id = id;

        }

        public static class TransacaoFactory
        {
           
            public static Transacao AdicionarIdTransacao(Transacao transacao, int id)
            {
                transacao.AlterarId(id);
                return transacao;
            }
        }
    }
}
