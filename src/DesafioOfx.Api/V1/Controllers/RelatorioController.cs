using DesafioOfx.Api.Controllers;
using DesafioOfx.Application.Queries;
using DesafioOfx.Application.Queries.ViewModels;
using DesafioOfx.Core.Communication.Mediator;
using DesafioOfx.Core.Messages.CommonMessages.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
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


        [HttpGet("extrato-cliente")]
        public async Task<ActionResult<List<TransacaoViewModel>>> ExtratoCliente(int contaId, DateTime dataInicio, DateTime dataFim)
        {
            ValidarRequisacao(contaId, dataInicio, dataFim);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var transacoes = await _contaQueries.ObterExtratoCliente(contaId, dataInicio, dataFim);

            if (transacoes == null || !transacoes.Any()) return NotFound();

            return transacoes;
        }

        private void ValidarRequisacao(int contaId, DateTime dataInicio, DateTime dataFim)
        { 
            if (contaId < 1) ModelState.AddModelError("contaId", "contaId inválido");
            if (dataInicio < SqlDateTime.MinValue.Value) ModelState.AddModelError("dataInicio", "dataInicio inválido");
            if (dataFim == DateTime.MinValue) ModelState.AddModelError("dataFim", "dataFim inválido");
        }
    }
}
