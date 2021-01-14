using DesafioOfx.Api.Controllers;
using DesafioOfx.Application.Commands;
using DesafioOfx.Application.Queries;
using DesafioOfx.Core.Communication.Mediator;
using DesafioOfx.Core.Messages.CommonMessages.Notifications;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
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


        [RequestSizeLimit(100000000)]
        [HttpPost("importar-arquivoOfx")]
        public async Task<IActionResult> ImportarArquivoOfx(IFormFile arquivo)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var stream = arquivo.OpenReadStream();

            var nomeArquivo = new Guid().ToString();
            if (!await UploadArquivoAlternativo(arquivo, nomeArquivo))
                return CustomResponse(ModelState);

            await _mediatorHandler.EnviarComando(new ImportarArquivoOfxContaCommand(nomeArquivo));

            //Assert.AreEqual(8976, statement.TransactionList.Transactions.Count());

            return CustomResponse();
        }

        private async Task<bool> UploadArquivoAlternativo(IFormFile arquivo, string nomeArquivo)
        {
            if (arquivo == null || arquivo.Length == 0)
            {
                NotificarErro(GetType().Name, "Forneça uma imagem para este produto!");
                return false;
            }

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", nomeArquivo);
            

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await arquivo.CopyToAsync(stream);
            }

            return true;
        }

    }
}
