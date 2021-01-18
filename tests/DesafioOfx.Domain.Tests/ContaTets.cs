using DesafioOfx.Core.DomainObjects;
using System;
using System.Linq;
using Xunit;

namespace DesafioOfx.Domain.Tests
{
    public class ContaTets
    {
        [Fact(DisplayName = "Adicionar Transacao a uma Conta sem Transacao")]
        [Trait("Categoria", "Conta Tests")]
        public void AdicionarTransacao_ContaVazia_DeveAdicionarTransacao()
        {
            //Arrange
            var conta = new Conta(1, "1234", "1");
            var transacao = new Transacao("debito", DateTime.Now, (decimal)260.00, "202012030260000", "031000019472", "601.031.000.019.472", "Transferência recebida - 03/12 1031      19472-7 KEMILA PELLIN");

            //Act
            conta.AdicionarTransacao(transacao);


            //Assert
            Assert.Single(conta.Transacaos);

        }

        [Fact(DisplayName = "Adicionar Transacao Código Unico Repedito")]
        [Trait("Categoria", "Conta Tests")]
        public void AdicionarTransacao_ContaPossuiCodigoEmUso_DeveRetornarExcpetion()
        {
            //Arrange
            var conta = new Conta(1, "1234", "1");
            conta.AdicionarTransacao(new Transacao("debito", DateTime.Now, (decimal)260.00, "202012030260000", "031000019472", "601.031.000.019.472", "transacao descricao"));
            var transacao = new Transacao("debito", DateTime.Now, (decimal)261.00, "202012030260000", "031000019472", "601.031.000.019.472", "Transferência recebida - 03/12 1031      19472-7 KEMILA PELLIN");


            //Act e Assert
            Assert.Throws<DomainException>(() => conta.AdicionarTransacao(transacao));

        }

        [Fact(DisplayName = "Atualizar Transacao Código Unico Repedito")]
        [Trait("Categoria", "Conta Tests")]
        public void AtualizarTransacao_ContaPossuiCodigoEmUso_DeveRetornarExcpetion()
        {
            //Arrange
            var conta = new Conta(1, "1234", "1");

            var transacao1 = new Transacao("debito", DateTime.Now, (decimal)260.00, "CodigoUnico1", "031000019472", "601.031.000.019.472", "transacao descricao");
            var transacao2 = new Transacao("debito", DateTime.Now, (decimal)260.00, "CodigoUnico2", "031000019472", "601.031.000.019.472", "transacao descricao");
            
            conta.AdicionarTransacao(Transacao.TransacaoFactory.AdicionarIdTransacao(transacao1, 1));
            conta.AdicionarTransacao(Transacao.TransacaoFactory.AdicionarIdTransacao(transacao2, 2));
            

            //Act e Assert
            Assert.Throws<DomainException>(() => conta.AtualizarTransacao(1, transacao2));

        }

        [Fact(DisplayName = "Remover Transacao não Existente")]
        [Trait("Categoria", "Conta Tests")]
        public void RemoverTransacao_ContaNaoPossuiTransacaoInformada_DeveRetornarExcpetion()
        {
            //Arrange
            var conta = new Conta(1, "1234", "1");
            var transacao = new Transacao("debito", DateTime.Now, (decimal)260.00, "CodigoUnico1", "031000019472", "601.031.000.019.472", "transacao descricao");
            

            //Act e Assert
            Assert.Throws<DomainException>(() => conta.RemoverTransacao(transacao));

        }

        [Fact(DisplayName = "Conta possui Transacao com Código Unico Existente")]
        [Trait("Categoria", "Conta Tests")]
        public void CodigoUnicoTransacao_ContaPossuiCodigoUnicoUtilizado_DeveRetornarTrue()
        {
            //Arrange
            var codigoUnico = "codigoUnico";
            var conta = new Conta(1, "1234", "1");
            var transacao = new Transacao("debito", DateTime.Now, (decimal)260.00, codigoUnico, "031000019472", "601.031.000.019.472", "transacao descricao");

            //Act
            conta.AdicionarTransacao(transacao);

            // Assert
            Assert.True(conta.CodigoUnidoEmUso(codigoUnico));

        }


    }
}
