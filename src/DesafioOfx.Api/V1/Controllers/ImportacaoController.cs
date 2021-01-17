using DesafioOfx.Api.Controllers;
using DesafioOfx.Application.Commands;
using DesafioOfx.Core.Communication.Mediator;
using DesafioOfx.Core.Messages.CommonMessages.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DesafioOfx.Api.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/importadores")]
    public class ImportacaoController : MainController
    {
        private IMediatorHandler _mediatorHandler;

        public ImportacaoController(INotificationHandler<DomainNotification> notifications,
                              IMediatorHandler mediatorHandler) : base(notifications, mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }


        [RequestSizeLimit(10000000)]
        [HttpPost("importar-arquivoOfx")]
        public async Task<IActionResult> ImportarArquivoOfx(IFormFile arquivo)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (arquivo == null || arquivo.Length == 0)
            {
                NotificarErro(GetType().Name, "Forneça um arquivo!");
                return CustomResponse();
            }


            var nomeArquivo = Guid.NewGuid().ToString();
            var caminho = Path.Combine(Directory.GetCurrentDirectory(), "ofxFiles", $"{nomeArquivo}.ofx");

            try
            {
                using (var stream = new FileStream(caminho, FileMode.Create))
                {
                    await arquivo.CopyToAsync(stream);
                }

                await _mediatorHandler.EnviarComando(new ImportarArquivoOfxCommand(nomeArquivo));
            }
            finally
            {
                System.IO.File.Delete(caminho);
            }

            return CustomResponse();
        }

    }
}
