using AutoMapper;
using DesafioOfx.Api.Controllers;
using DesafioOfx.Application.Commands;
using DesafioOfx.Application.Queries;
using DesafioOfx.Application.Queries.ViewModels;
using DesafioOfx.Core.Communication.Mediator;
using DesafioOfx.Core.Messages.CommonMessages.Notifications;
using DesafioOfx.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DesafioOfx.Api.V1.Controllers
{
    [Authorize]
    public class ContaController : MainController
    {
        private IMediatorHandler _mediatorHandler;
        private readonly IMapper _mapper;
        private readonly IContaQueries _contaQueries;



        public ContaController(INotificationHandler<DomainNotification> notifications,
                              IMediatorHandler mediatorHandler,
                              IMapper mapper,
                              IUser user,
                              IContaQueries contaQueries) : base(notifications, mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _mapper = mapper;
            _contaQueries = contaQueries;
        }


        [HttpPost("adicionar-lancamento-financeiro")]
        public async Task<IActionResult> AdicionarLancamentoFinanceiro(TransacaoViewModel transacaoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var conta = await _contaQueries.ObterContaId(transacaoViewModel.ContaId);
            if (conta == null)
            {
                NotificarErro(GetType().Name, "Conta não encontrada");
                return BadRequest();
            };

            await _mediatorHandler.EnviarComando(_mapper.Map<AdicionarLancamentoFinanceiroCommand>(transacaoViewModel));

            //if (OperacaoValida())
            //{
            //    return RedirectToAction("Index");
            //}

            return CustomResponse(transacaoViewModel);

        }
    }
}
