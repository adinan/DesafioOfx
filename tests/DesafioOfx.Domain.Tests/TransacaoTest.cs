using System;
using Xunit;

namespace DesafioOfx.Domain.Tests
{
    public class TransacaoTest
    {
        [Fact(DisplayName = "Adicionar Nova Transacao Válido")]
        [Trait("Categoria", "Transacao Tests")]
        public void AdicionarTransacao_NovaTransacao_DeveAdicionarNovaTransacao()
        {
            //Arrange
            /*
             TRNTYPE>OTHER</TRNTYPE>
            <DTPOSTED>20201203120000[-3:BRT]</DTPOSTED>
            <TRNAMT>260.00</TRNAMT>
            <FITID>202012030260000</FITID>
            <CHECKNUM>031000019472</CHECKNUM>
            <REFNUM>601.031.000.019.472</REFNUM>
            <MEMO>Transferência recebida - 03/12 1031      19472-7 KEMILA PELLIN</MEMO>
             */

            var transacao = new Transacao("debt", DateTime.Now, (decimal)260.00, "202012030260000", "031000019472", "601.031.000.019.472", "Transferência recebida - 03/12 1031      19472-7 KEMILA PELLIN");

            //Act
            //var result = transacao.IsValid();

            //Assert
            //Assert.True(result);

        }

        [Fact(DisplayName = "Adicionar Nova Transacao Inválido")]
        [Trait("Categoria", "Transacao Tests")]
        public void AdicionarTransacao_NovaTransacao_NaoDeveAdicionarNovaTransacaoInvalida()
        {
            //Arrange
            /*
             TRNTYPE>OTHER</TRNTYPE>
            <DTPOSTED>20201203120000[-3:BRT]</DTPOSTED>
            <TRNAMT>260.00</TRNAMT>
            <FITID>202012030260000</FITID>
            <CHECKNUM>031000019472</CHECKNUM>
            <REFNUM>601.031.000.019.472</REFNUM>
            <MEMO>Transferência recebida - 03/12 1031      19472-7 KEMILA PELLIN</MEMO>
             */

            var transacao = new Transacao("deby", DateTime.MinValue, (decimal)260.00, "", "", "", "");

            //Act
            //var result = transacao.IsValid();

            //Assert
            //Assert.False(result);

        }

    }
}
