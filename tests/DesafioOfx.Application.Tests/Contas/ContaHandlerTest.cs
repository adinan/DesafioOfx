using DesafioOfx.Application.Commands;
using DesafioOfx.Core.Messages.CommonMessages.Notifications;
using DesafioOfx.Domain;
using DesafioOfx.Domain.Interfaces;
using MediatR;
using Moq;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DesafioOfx.Application.Tests.Contas
{
    public class ContaHandlerTest
    {
        private readonly AutoMocker _mocker;
        private readonly ContaCommandHandler _contaHandler;

        public ContaHandlerTest()
        {
            _mocker = new AutoMocker();
            
            _mocker.Use<INotificationHandler<DomainNotification>>(new DomainNotificationHandler());

            _contaHandler = _mocker.CreateInstance<ContaCommandHandler>();
        }

        [Fact(DisplayName = "Adicionar Lancamento Financeiro Válido")]
        [Trait("Categoria", "Conta Handler")]
        public async void AdicionarLancamentoFinanceiro_NovaTransacao_DeveExecutarComSucesso()
        {
            // Arrange
            var contaId = 1;
            var LancamentoFinanceiroCommand = new AdicionarLancamentoFinanceiroContaCommand(contaId, "TipoTransacao", DateTime.Now, 1, "CodigoUnico", "Protocolo", "CodigoReferencia", "Descricao");

            _mocker.GetMock<IContaRepository>().Setup(r => r.UnitOfWork.Commit()).Returns(Task.FromResult(true)); 
            _mocker.GetMock<IContaRepository>().Setup(r => r.ObterContaPorId(contaId).Result).Returns(new Conta(1, "",""));
            
            // Act
             var result = await _contaHandler.Handle(LancamentoFinanceiroCommand, CancellationToken.None);

            // Assert
            Assert.True(result);
            _mocker.GetMock<IContaRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }
    }
}
