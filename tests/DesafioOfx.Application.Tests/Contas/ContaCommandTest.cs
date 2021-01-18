using DesafioOfx.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace DesafioOfx.Application.Tests.Contas
{
    public class ContaCommandTest
    {
        [Fact(DisplayName = "Adicionar Lancamento Financeiro Válido")]
        [Trait("Categoria", "Conta Commands")]
        public void AdicionarLancamentoFinanceiroCommand_CommandoEstaValido_DevePassarNaValidacao()
        {
            // Arrange
            var LancamentoFinanceiroCommand = new AdicionarLancamentoFinanceiroContaCommand(1, "TipoTransacao", DateTime.Now, 1, "CodigoUnico", "Protocolo", "CodigoReferencia", "Descricao");

            // Act
            var result = LancamentoFinanceiroCommand.EhValido();

            // Assert
            Assert.True(result);
            Assert.Equal(0, LancamentoFinanceiroCommand.ValidationResult.Errors.Count);

        }

        [Fact(DisplayName = "Adicionar Lancamento Financeiro Inválido")]
        [Trait("Categoria", "Conta Commands")]
        public void AdicionarLancamentoFinanceiroCommand_CommandoEstaInvalido_NaoDevePassarNaValidacao()
        {
            // Arrange
            var lancamentoFinanceiroCommand = new AdicionarLancamentoFinanceiroContaCommand(0, "", DateTime.MinValue, 0, "", "", "", "");

            // Act
            var result = lancamentoFinanceiroCommand.EhValido();

            // Assert
            Assert.False(result);
            Assert.Equal(7, lancamentoFinanceiroCommand.ValidationResult.Errors.Count);

        }

        [Fact(DisplayName = "Adicionar Lancamento Financeiro Válido em lote")]
        [Trait("Categoria", "Conta Commands")]
        public void AdicionarLoteLancamentoFinanceiroCommand_CommandoEstaValido_DevePassarNaValidacao()
        {
            // Arrange
            var loteCommand = new AdicionarLoteLancamentoFinanceiroContaCommand(1);
            var lancamentoCommand = new AdicionarLancamentoFinanceiroContaCommand(1, "TipoTransacao", DateTime.Now, 1, "CodigoUnico", "Protocolo", "CodigoReferencia", "Descricao");

            // Act
            //loteCommand.AdicionarComando(lancamentoCommand);
            loteCommand.AdicionarComando(lancamentoCommand);
            var result = loteCommand.EhValido();


            // Assert
            Assert.True(result);
            Assert.Equal(0, loteCommand.ValidationResult.Errors.Count);
            Assert.Equal(1, loteCommand.ListaLancamentoFinanceiroContaCommand.Count);
        }


        [Fact(DisplayName = "Adicionar Lancamento Financeiro Inválido em lote")]
        [Trait("Categoria", "Conta Commands")]
        public void AdicionarLoteLancamentoFinanceiroCommand_CommandoEstaInValido_NaoDevePassarNaValidacao()
        {
            // Arrange
            var loteCommand = new AdicionarLoteLancamentoFinanceiroContaCommand(1);
            var lancamentoFinanceiroCommand = new AdicionarLancamentoFinanceiroContaCommand(0, "", DateTime.MinValue, 0, "", "", "", "");

            // Act
            //loteCommand.AdicionarComando(lancamentoCommand);
            loteCommand.AdicionarComando(lancamentoFinanceiroCommand);
            var result = loteCommand.EhValido();

            // Assert
            Assert.False(result);
            Assert.Equal(1, loteCommand.ValidationResult.Errors.Count);
            Assert.Equal(0, loteCommand.ListaLancamentoFinanceiroContaCommand.Count);
        }

    }
}
