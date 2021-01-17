using DesafioOfx.Core.Messages;
using FluentValidation;

namespace DesafioOfx.Application.Commands
{


    public class ImportarArquivoOfxCommand : Command
    {
        public string NomeArquivo { get; private set; } //



        public ImportarArquivoOfxCommand(string nomeArquivo)
        {
            NomeArquivo = nomeArquivo;
        }

        public override bool EhValido()
        {
            ValidationResult = new ImportarArquivoOfxValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class ImportarArquivoOfxValidation : AbstractValidator<ImportarArquivoOfxCommand>
    {
        public ImportarArquivoOfxValidation()
        {
            RuleFor(c => c.NomeArquivo)
              .NotEmpty()
              .WithMessage("{PropertyName} inválido");

        }
    }
}
