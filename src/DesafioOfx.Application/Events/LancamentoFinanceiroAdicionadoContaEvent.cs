using DesafioOfx.Core.Messages;
using System;

namespace DesafioOfx.Application.Events
{
    public class LancamentoFinanceiroAdicionadoContaEvent : Event
    {
        public int ContaId { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataLancamento { get; set; }

        public LancamentoFinanceiroAdicionadoContaEvent(int contaId, decimal valor, DateTime dataLancamento)
        {
            ContaId = contaId;
            Valor = valor;
            DataLancamento = dataLancamento;
        }
    }
}
