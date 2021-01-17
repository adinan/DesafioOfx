using DesafioOfx.Api.Controllers;
using DesafioOfx.Application.Queries;
using DesafioOfx.Application.Queries.ViewModels;
using DesafioOfx.Core.Communication.Mediator;
using DesafioOfx.Core.Messages.CommonMessages.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DesafioOfx.Api.V1.Controllers
{
    //[Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/relatorios")]
    public class RelatorioController : MainController
    {
        private IMediatorHandler _mediatorHandler;
        private readonly IContaQueries _contaQueries;

        public RelatorioController(INotificationHandler<DomainNotification> notifications,
                              IMediatorHandler mediatorHandler,
                              IContaQueries contaQueries) : base(notifications, mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _contaQueries = contaQueries;
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<ContaViewModel>> ExtratoCliente(int contaId, DateTime dataInicio, DateTime dataFim)
        {
            var conta = await _contaQueries.ObterContaId(contaId);

            if (conta == null) return NotFound();

            return conta;
        }
    }
}
