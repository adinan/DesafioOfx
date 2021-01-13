using DesafioOfx.Core.DomainObjects;
using System.Collections.Generic;

namespace DesafioOfx.Domain
{
    public class Agencia : Entity
    {

        public int BancoId { get; private set; }
        public string Codigo { get; private set; }
        public string Digito { get; private set; }
        public string Nome { get; private set; }
        public Banco Banco { get; private set; }
        public List<Conta> Contas { get; private set; }


        public Agencia(int bancoId, string codigo, string digito, string nome)
        {
            BancoId = bancoId;
            Codigo = codigo;
            Digito = digito;
            Nome = nome;
        }
    }
}
