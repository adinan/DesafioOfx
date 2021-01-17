using AutoMapper;
using DesafioOfx.Application.Events;
using DesafioOfx.Application.Queries;
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
    public class ContaCommandHandler :
        IRequestHandler<AdicionarLancamentoFinanceiroContaCommand, bool>,
        IRequestHandler<AtualizarLancamentoFinanceiroContaCommand, bool>,
        IRequestHandler<AdicionarLoteLancamentoFinanceiroContaCommand, bool>

        
    {
        private readonly IContaRepository _contaRepository;
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IContaQueries _contaQueries;
        private readonly DomainNotificationHandler _notifications;
        private readonly IMapper _mapper;


        public ContaCommandHandler(IContaRepository pedidoRepository,
                                   IMediatorHandler mediatorHandler,
                                   IMapper mapper,
                                   INotificationHandler<DomainNotification> notifications,
                                   IContaQueries contaQueries)
        {
            _contaRepository = pedidoRepository;
            _mediatorHandler = mediatorHandler;
            _mapper = mapper;
            _notifications = (DomainNotificationHandler)notifications;
            _contaQueries = contaQueries;
        }


        public async Task<bool> Handle(AdicionarLancamentoFinanceiroContaCommand message, CancellationToken cancellationToken)
        {
            if (!ValidarComando(message)) return false;

            var conta = await _contaRepository.ObterContaPorId(message.ContaId);
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

            conta.AdicionarEvento(new LancamentoFinanceiroAdicionadoContaEvent(conta.Id, transacao.Valor, transacao.DataLancamento));
            return await _contaRepository.UnitOfWork.Commit();
        }


        public async Task<bool> Handle(AtualizarLancamentoFinanceiroContaCommand message, CancellationToken cancellationToken)
        {
            if (!ValidarComando(message)) return false;

            var conta = await _contaRepository.ObterContaPorId(message.ContaId);
            if (conta == null)
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification(GetType().Name, "Conta não encontrado!"));
                return false;
            }

            if (!conta.TransacaoExistente(message.TransacaoId))
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification(GetType().Name, $"Transação com id:{message.TransacaoId} não encontrada!"));
                return false;
            }

            if (conta.CodigoUnidoEmUso(message.CodigoUnico, message.TransacaoId))
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification(GetType().Name, $"Transação com o código {message.CodigoUnico} duplicado!"));
                return false;
            }


            var transacao = new Transacao(message.TipoTransacao, message.DataLancamento, message.Valor, message.CodigoUnico, message.Protocolo, message.CodigoReferencia, message.Descricacao);
            conta.AtualizarTransacao(message.TransacaoId, transacao);

            conta.AdicionarEvento(new LancamentoFinanceiroAtualizadoContaEvent(conta.Id, transacao.Id, transacao.Valor, transacao.DataLancamento)); ;
            return await _contaRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(AdicionarLoteLancamentoFinanceiroContaCommand request, CancellationToken cancellationToken)
        {
            if (!ValidarComando(request)) return false;

            var conta = await _contaRepository.ObterContaPorId(request.ContaId);
            if (conta == null)
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification(GetType().Name, "Conta não encontrado!"));
                return false;
            }

            foreach (var message in request.ListaLancamentoFinanceiroContaCommand)
            {
                if (conta.CodigoUnidoEmUso(message.CodigoUnico))
                {
                    await _mediatorHandler.PublicarNotificacao(new DomainNotification(GetType().Name, $"Transação com o código {message.CodigoUnico} duplicado!"));
                    continue;
                }

                var transacao = new Transacao(message.TipoTransacao, message.DataLancamento, message.Valor, message.CodigoUnico, message.Protocolo, message.CodigoReferencia, message.Descricacao);
                conta.AdicionarTransacao(transacao);

                conta.AdicionarEvento(new LancamentoFinanceiroAdicionadoContaEvent(conta.Id, transacao.Valor, transacao.DataLancamento));
            }

            //Regra: não salvar nada do arquivo caso exista alguma transacao invalida
            if (_notifications.TemNotificacao()) return false;

            return await _contaRepository.UnitOfWork.Commit();
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
