using AutoMapper;
using DesafioOfx.Application.Events;
using DesafioOfx.Application.Queries;
using DesafioOfx.Application.Queries.ViewModels;
using DesafioOfx.Core.Communication.Mediator;
using DesafioOfx.Core.Messages;
using DesafioOfx.Core.Messages.CommonMessages.Notifications;
using DesafioOfx.Domain;
using DesafioOfx.Domain.Interfaces;
using MediatR;
using OfxNet;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DesafioOfx.Application.Commands
{
    public class ImportarArquivoOfxHandler : IRequestHandler<ImportarArquivoOfxCommand, bool>
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IContaQueries _contaQueries;
        private readonly IMapper _mapper;


        public ImportarArquivoOfxHandler(IMediatorHandler mediatorHandler,
                                         IMapper mapper,
                                         IContaQueries contaQueries)
        {
            _mediatorHandler = mediatorHandler;
            _mapper = mapper;
            _contaQueries = contaQueries;
        }


        public async Task<bool> Handle(ImportarArquivoOfxCommand message, CancellationToken cancellationToken)
        {
            if (!ValidarComando(message)) return false;

            if (!ValidarArquivo(out OfxStatement ofxNetInfo, message.NomeArquivo)) return false;

            var contaVm = await _contaQueries.ObterConta(_mapper.Map<InformacaoContaPessoaViewModel>((ofxNetInfo as OfxBankStatement).Account));
            if (contaVm == null)
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification(GetType().Name, "Conta não encontrado!"));
                return false;
            }


            var listaTransacoesCommand = new AdicionarLoteLancamentoFinanceiroContaCommand(contaVm.ContaId);
            foreach (var ofx in ofxNetInfo.TransactionList.Transactions)
            {
                var command = new AdicionarLancamentoFinanceiroContaCommand(contaVm.ContaId, ofx.TxType.ToString(), ofx.DatePosted.Date, ofx.Amount, ofx.FitId, ofx.ChequeNumber, ofx.ReferenceNumber, ofx.Memo);
                if (!ValidarComando(command)) continue;

                listaTransacoesCommand.AdicionarComando(command);
            }

            return await _mediatorHandler.EnviarComando(listaTransacoesCommand);
        }

        private bool ValidarArquivo(out OfxStatement ofxNetInfo, string nomeArquivo)
        {
            var enderecoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "ofxFiles", $"{nomeArquivo}.ofx");
            try
            {
                ofxNetInfo = OfxDocument.Load(enderecoArquivo)?.GetStatements()?.FirstOrDefault();
            }
            catch (Exception ex)
            {
                _mediatorHandler.PublicarNotificacao(new DomainNotification(GetType().Name, $"Erro ao converter o arquivo. Erro:{ex.Message}"));
                ofxNetInfo = new OfxStatement();
                return false;
            }

            if (ofxNetInfo == null ||
                ofxNetInfo.TransactionList == null ||
                ofxNetInfo.TransactionList.Transactions == null)
            {
                _mediatorHandler.PublicarNotificacao(new DomainNotification(GetType().Name, $"Arquivo inválido!"));
                return false;
            }

            return true;
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
