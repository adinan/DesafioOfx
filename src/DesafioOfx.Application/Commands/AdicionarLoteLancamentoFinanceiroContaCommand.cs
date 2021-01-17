using DesafioOfx.Core.Messages;
using FluentValidation;
using System.Collections.Generic;

namespace DesafioOfx.Application.Commands
{


    public class AdicionarLoteLancamentoFinanceiroContaCommand : Command
    {
        public int ContaId { get; set; }
        private readonly List<AdicionarLancamentoFinanceiroContaCommand> _listaListaLancamentoFinanceiroContaCommand;
        public IReadOnlyCollection<AdicionarLancamentoFinanceiroContaCommand> ListaLancamentoFinanceiroContaCommand => _listaListaLancamentoFinanceiroContaCommand;

        public AdicionarLoteLancamentoFinanceiroContaCommand(int contaId)
        {
            _listaListaLancamentoFinanceiroContaCommand = new List<AdicionarLancamentoFinanceiroContaCommand>();
            ContaId = contaId;
        }

        public override bool EhValido()
        {
            ValidationResult = new AdicionarLoteLancamentoFinanceirValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        internal void AdicionarComando(AdicionarLancamentoFinanceiroContaCommand command)
        {
            if (!command.EhValido()) return;
            _listaListaLancamentoFinanceiroContaCommand.Add(command);
        }
    }

    public class AdicionarLoteLancamentoFinanceirValidation : AbstractValidator<AdicionarLoteLancamentoFinanceiroContaCommand>
    {
        public AdicionarLoteLancamentoFinanceirValidation()
        {
            RuleFor(c => c.ListaLancamentoFinanceiroContaCommand.Count)
               .NotEqual(0)
               .WithMessage(c => "O lote de lancamento financeiro  está vazio ou invalido");

        }
    }
}
