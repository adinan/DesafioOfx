using DesafioOfx.Core.Messages;
using System;

namespace DesafioOfx.Application.Commands
{
    public class LancamentoFinanceiroAdicionadoEvent : Event
    {
        public int ContaId { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataLancamento { get; set; }

        public LancamentoFinanceiroAdicionadoEvent(int contaId, decimal valor, DateTime dataLancamento)
        {
            ContaId = contaId;
            Valor = valor;
            DataLancamento = dataLancamento;
        }
    }
}
