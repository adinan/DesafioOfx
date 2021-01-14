﻿using DesafioOfx.Core.Messages;
using FluentValidation;
using System;

namespace DesafioOfx.Application.Commands
{


    public class AdicionarLancamentoFinanceiroContaCommand : Command
    {
        public int ContaId { get; private set; } //TRNTYPE
        public int TipoTransacao { get; private set; } //TRNTYPE
        public DateTime DataLancamento { get; private set; }//DTPOSTED
        public decimal Valor { get; private set; } //TRNAMT
        public string CodigoUnico { get; private set; } //FITID
        public string Protocolo { get; private set; } //CHECKNUM
        public string CodigoReferencia { get; private set; } //REFNUM
        public string Descricacao { get; private set; } //MEMO


        public AdicionarLancamentoFinanceiroContaCommand(int contaId, int tipoTransacao, DateTime dataLancamento, decimal valor, string codigoUnico, string protocolo, string codigoReferencia, string descricacao)
        {
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
            ValidationResult = new AdicionarLancamentoFinanceiroValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AdicionarLancamentoFinanceiroValidation : AbstractValidator<AdicionarLancamentoFinanceiroContaCommand>
    {
        public AdicionarLancamentoFinanceiroValidation()
        {
            RuleFor(c => c.ContaId)
               .GreaterThan(0)
               .WithMessage("{PropertyName} inválido");

            RuleFor(c => c.TipoTransacao)
                .GreaterThan(0)
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