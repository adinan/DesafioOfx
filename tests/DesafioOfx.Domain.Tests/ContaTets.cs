using System;
using Xunit;

namespace DesafioOfx.Domain.Tests
{
    public class ContaTets
    {
        [Fact(DisplayName = "Adicionar Transacao a Nova Conta")]
        [Trait("Categoria", "Conta Tests")]
        public void AdicionarTransacao_NovaConta_DeveAdicionarTransacao()
        {
            //Arrange
            var banco = new Banco(1, "Banco do Brasil");
            var agencia = new Agencia(1, "0001", "1", "Agenda do Parque dos Poderes");
            var transacao = new Transacao("deby", DateTime.Now, (decimal)260.00, "202012030260000", "031000019472", "601.031.000.019.472", "Transferência recebida - 03/12 1031      19472-7 KEMILA PELLIN");


            var conta = new Conta(1, "1234", "1");

            //Act
            conta.AdicionarTransacao(transacao);


            //Assert
            Assert.Single(conta.Transacaos);

        }

    }
}
