using DesafioOfx.Core.Communication.Mediator;
using DesafioOfx.Core.Messages;
using DesafioOfx.Core.Messages.CommonMessages.Notifications;
using DesafioOfx.Domain;
using DesafioOfx.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DesafioOfx.Application.Commands
{
    public class LancamentoFinanceiroCommandHandler : IRequestHandler<AdicionarLancamentoFinanceiroCommand, bool>
    {
        private readonly IContaRepository _bancoRepository;
        private readonly IMediatorHandler _mediatorHandler;

        public LancamentoFinanceiroCommandHandler(IContaRepository pedidoRepository,
                                    IMediatorHandler mediatorHandler)
        {
            _bancoRepository = pedidoRepository;
            _mediatorHandler = mediatorHandler;
        }


        public async Task<bool> Handle(AdicionarLancamentoFinanceiroCommand message, CancellationToken cancellationToken)
        {
            if (!ValidarComando(message)) return false;

            var conta = await _bancoRepository.ObterContaPorId(message.ContaId);
            if (conta == null)
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification(GetType().Name, "Conta não encontrado!"));
                return false;
            }

            if (conta.CodigoUnidoEmUso(message.CodigoUnico))
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification(GetType().Name, $"Transação com o código {message.CodigoUnico} duplicado!"));
                return false;
            }

            var transacao = new Transacao(message.TipoTransacao, message.DataLancamento, message.Valor, message.CodigoUnico, message.Protocolo, message.CodigoReferencia, message.Descricacao);
            conta.AdicionarTransacao(transacao);

            conta.AdicionarEvento(new LancamentoFinanceiroAdicionadoEvent(conta.Id, transacao.Valor, transacao.DataLancamento));
            return await _bancoRepository.UnitOfWork.Commit();
        }

        private bool ValidarComando(Command message)
        {
            if (message.EhValido()) return true;

            foreach (var error in message.ValidationResult.Errors)
            {
                _mediatorHandler.PublicarNotificacao(new DomainNotification(message.MessageType, error.ErrorMessage));
            }

            return false;
        }
    }
}
