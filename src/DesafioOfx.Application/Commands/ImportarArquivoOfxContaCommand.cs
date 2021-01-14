using DesafioOfx.Core.Messages;
using FluentValidation;
using System;

namespace DesafioOfx.Application.Commands
{


    public class ImportarArquivoOfxContaCommand : Command
    {
        public string NomeArquivo { get; private set; } //



        public ImportarArquivoOfxContaCommand(string nomeArquivo)
        {
            NomeArquivo = nomeArquivo;
        }

        public override bool EhValido()
        {
            ValidationResult = new ImportarArquivoOfxContaValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class ImportarArquivoOfxContaValidation : AbstractValidator<ImportarArquivoOfxContaCommand>
    {
        public ImportarArquivoOfxContaValidation()
        {
            RuleFor(c => c.NomeArquivo)
              .NotEmpty()
              .WithMessage("{PropertyName} inválido");

        }
    }
}
