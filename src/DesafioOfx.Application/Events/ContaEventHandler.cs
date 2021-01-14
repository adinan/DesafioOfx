using MediatR;
using System.Threading;
using System.Threading.Tasks;
/*
 TODO implementar salvar no em um banco de leitura NoSql 
 */
namespace DesafioOfx.Application.Events
{
    public class ContaEventHandler :
        INotificationHandler<LancamentoFinanceiroAdicionadoContaEvent>,
        INotificationHandler<LancamentoFinanceiroAtualizadoContaEvent>
    {
        public Task Handle(LancamentoFinanceiroAdicionadoContaEvent notification, CancellationToken cancellationToken)
        {

            return Task.CompletedTask;
        }

        public Task Handle(LancamentoFinanceiroAtualizadoContaEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
