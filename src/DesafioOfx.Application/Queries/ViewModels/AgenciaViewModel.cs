using System.Collections.Generic;

namespace DesafioOfx.Application.Queries.ViewModels
{
    public class AgenciaViewModel
    {
        public int BancoId { get;  set; }
        public BancoViewModel Banco { get;  set; }
        public string Codigo { get;  set; }
        public string Digito { get;  set; }
        public string Nome { get;  set; }
        public IEnumerable<ContaViewModel> Contas { get;  set; }
    }
}