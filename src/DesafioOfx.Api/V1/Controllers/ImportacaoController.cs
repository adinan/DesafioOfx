using DesafioOfx.Api.Controllers;
using DesafioOfx.Application.Queries;
using DesafioOfx.Core.Communication.Mediator;
using DesafioOfx.Core.Messages.CommonMessages.Notifications;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DesafioOfx.Api.V1.Controllers
{
    //[Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/importadores")]
    public class ImportacaoController : MainController
    {
        private IMediatorHandler _mediatorHandler;
        private readonly IContaQueries _contaQueries;

        public ImportacaoController(INotificationHandler<DomainNotification> notifications,
                              IMediatorHandler mediatorHandler,
                              IContaQueries contaQueries) : base(notifications, mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _contaQueries = contaQueries;
        }


        [RequestSizeLimit(40000000)]
        [HttpPost("importar-arquivoOfx")]
        public async Task<IActionResult> ImportarArquivoOfx(IFormFile file)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

           
            return CustomResponse();

        }

        [RequestSizeLimit(40000000)]
        //[DisableRequestSizeLimit]
        [HttpPost("imagem")]
        public ActionResult AdicionarImagem(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                NotificarErro(GetType().Name, "Arquivo vazio!");

                return CustomResponse();
            }

            return Ok(file);
        } 

    }
}
