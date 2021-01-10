using System.Collections.Generic;

namespace DesafioOfx.Application.ViewModels
{
    public class BancoViewModel
    {
        public int Codigo { get;  set; }
        public string Nome { get;  set; }
        public IEnumerable<AgenciaViewModel> Agencias { get;  set; }
    }
}