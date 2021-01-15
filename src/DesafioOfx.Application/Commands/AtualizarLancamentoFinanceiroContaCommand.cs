using DesafioOfx.Core.Messages;
using FluentValidation;
using System;

namespace DesafioOfx.Application.Commands
{


    public class AtualizarLancamentoFinanceiroContaCommand : Command
    {
        public int ContaId { get; private set; }
        public int TransacaoId { get; private set; }
        public string TipoTransacao { get; private set; } //TRNTYPE
        public DateTime DataLancamento { get; private set; }//DTPOSTED
        public decimal Valor { get; private set; } //TRNAMT
        public string CodigoUnico { get; private set; } //FITID
        public string Protocolo { get; private set; } //CHECKNUM
        public string CodigoReferencia { get; private set; } //REFNUM
        public string Descricacao { get; private set; } //MEMO

        public AtualizarLancamentoFinanceiroContaCommand(int transacaoId, int contaId, string tipoTransacao, DateTime dataLancamento,
            decimal valor, string codigoUnico, string protocolo, string codigoReferencia, string descricacao)
        {
            TransacaoId = transacaoId;
            ContaId = contaId;
            TipoTransacao = tipoTransacao;
            DataLancamento = dataLancamento;
            Valor = valor;
            CodigoUnico = codigoUnico;
            Protocolo = protocolo;
            CodigoReferencia = codigoReferencia;
            Descricacao = descricacao;
        }


        public override bool EhValido()
        {
            ValidationResult = new AtualizarLancamentoFinanceiroValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AtualizarLancamentoFinanceiroValidation : AbstractValidator<AtualizarLancamentoFinanceiroContaCommand>
    {
        public AtualizarLancamentoFinanceiroValidation()
        {
            RuleFor(c => c.TransacaoId)
               .GreaterThan(0)
               .WithMessage("{PropertyName} inválido");

            RuleFor(c => c.TipoTransacao)
                .NotEmpty()
                .WithMessage("{PropertyName} inválido");

            RuleFor(c => c.DataLancamento)
               .NotEqual(DateTime.MinValue)
               .WithMessage("{PropertyName} inválido");

            RuleFor(c => c.Valor)
               .NotEqual(0)
               .WithMessage("{PropertyName} inválido");

            RuleFor(c => c.CodigoUnico)
               .NotEmpty()
               .WithMessage("{PropertyName} inválido");

            RuleFor(c => c.Protocolo)
               .NotEmpty()
               .WithMessage("{PropertyName} inválido");

            RuleFor(c => c.CodigoReferencia)
                .NotEmpty()
                .WithMessage("{PropertyName} inválido");

            RuleFor(c => c.Descricacao)
             .NotEmpty()
             .WithMessage("{PropertyName} inválido");
        }
    }
}
