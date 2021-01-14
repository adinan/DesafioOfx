using DesafioOfx.Core.Messages;
using System;

namespace DesafioOfx.Application.Events
{
    public class LancamentoFinanceiroAtualizadoContaEvent : Event
    {
        public int ContaId { get; set; }
        public int TransacaoId { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataLancamento { get; set; }

        public LancamentoFinanceiroAtualizadoContaEvent(int contaId, int transacaoId, decimal valor, DateTime dataLancamento)
        {
            ContaId = contaId;
            TransacaoId = transacaoId;
            Valor = valor;
            DataLancamento = dataLancamento;
        }
    }
}
