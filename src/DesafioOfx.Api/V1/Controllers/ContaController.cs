using AutoMapper;
using DesafioOfx.Api.Controllers;
using DesafioOfx.Application.Commands;
using DesafioOfx.Application.Queries;
using DesafioOfx.Application.Queries.ViewModels;
using DesafioOfx.Core.Communication.Mediator;
using DesafioOfx.Core.Messages.CommonMessages.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DesafioOfx.Api.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/contas")]
    public class ContaController : MainController
    {
        private IMediatorHandler _mediatorHandler;
        private readonly IMapper _mapper;
        private readonly IContaQueries _contaQueries;

        public ContaController(INotificationHandler<DomainNotification> notifications,
                              IMediatorHandler mediatorHandler,
                              IMapper mapper,
                              IContaQueries contaQueries) : base(notifications, mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _mapper = mapper;
            _contaQueries = contaQueries;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ContaViewModel>> ObterPorId(int id)
        {
            var conta = await _contaQueries.ObterContaId(id);

            if (conta == null) return NotFound();

            return conta;
        }

        [HttpGet("obter-conta")]
        public async Task<ActionResult<ContaViewModel>> ObterConta(int bancoCodigo, string agenciaCodigo, string agenciaDigito, string contaCodigo, string contaDigito)
        {
            var viewModel = new InformacaoContaPessoaViewModel
            {
                BancoCodigo = bancoCodigo,
                AgenciaCodigo = agenciaCodigo,
                AgenciaDigito = agenciaDigito,
                ContaCodigo = contaCodigo,
                ContaDigito = contaDigito
            };


            var conta = await _contaQueries.ObterConta(viewModel);

            if (conta == null) return NotFound();

            return conta;
        }


        [HttpPost("adicionar-lancamento-financeiro")]
        public async Task<IActionResult> AdicionarLancamentoFinanceiro(TransacaoViewModel transacaoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _mediatorHandler.EnviarComando(_mapper.Map<AdicionarLancamentoFinanceiroContaCommand>(transacaoViewModel));

            if (OperacaoValida())
            {
                var testetetete = await _contaQueries.ObterTransacaoPorCodigoUnico(transacaoViewModel.CodigoUnico);
                return CustomResponse(testetetete);
            }
            else
                return CustomResponse(transacaoViewModel);

        }

        [HttpPatch("alterar-lancamento-financeiro/{transacaoId:int}")]
        public async Task<IActionResult> AlterarLancamentoFinanceiro(int transacaoId, TransacaoViewModel transacaoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (transacaoId != transacaoViewModel.TransacaoId)
            {
                NotificarErro(GetType().Name, "O id informado não é o mesmo que foi passado na query");
                return CustomResponse(transacaoViewModel);
            }


            await _mediatorHandler.EnviarComando(_mapper.Map<AtualizarLancamentoFinanceiroContaCommand>(transacaoViewModel));

            return CustomResponse(transacaoViewModel);
        }
    }
}
