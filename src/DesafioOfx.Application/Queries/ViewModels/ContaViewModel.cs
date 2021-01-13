using System.Collections.Generic;

namespace DesafioOfx.Application.Queries.ViewModels
{
    public class ContaViewModel
    {
        public int AgenciaId { get; private set; }
        public string Codigo { get; private set; }
        public string Digito { get; private set; }

        public List<TransacaoViewModel> Transacoes { get; set; }
    }
}