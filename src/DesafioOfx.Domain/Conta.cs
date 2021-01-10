using DesafioOfx.Core.DomainObjects;
using System.Collections.Generic;

namespace DesafioOfx.Domain
{
    public class Conta : Entity
    {
        public int AgenciaId { get; private set; }
        public string Codigo { get; private set; }
        public string Digito { get; private set; }
        public Agencia Agencia { get; private set; }

        private List<Transacao> _transacaos;

        public Conta(int agenciaId, string codigo, string digito)
        {
            AgenciaId = agenciaId;
            Codigo = codigo;
            Digito = digito;
        }

        public IReadOnlyCollection<Transacao> Transacaos => _transacaos;

        

        public void AdicionarTransacao(Transacao transacao)
        {
            _transacaos.Add(transacao);
        }
    }
}
