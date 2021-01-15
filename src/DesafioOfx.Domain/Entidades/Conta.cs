using DesafioOfx.Core.DomainObjects;
using System.Collections.Generic;
using System.Linq;

namespace DesafioOfx.Domain
{
    public class Conta : Entity
    {
        public int? AgenciaId { get; private set; }
        public int BancoId { get; private set; }
        public string Codigo { get; private set; }
        public string Digito { get; private set; }
        public Agencia Agencia { get; private set; }
        public Banco Banco { get; private set; }??

        private readonly List<Transacao> _transacaos;

        public IReadOnlyCollection<Transacao> Transacaos => _transacaos;

        public Conta(int agenciaId, string codigo, string digito)
        {
            AgenciaId = agenciaId;
            Codigo = codigo;
            Digito = digito;
            _transacaos = new List<Transacao>();
        }


        public bool TransacaoExistente(int transacaoId)
        {
            return _transacaos.Any(p => p.Id == transacaoId);
        }

        public void AdicionarTransacao(Transacao transacao)
        {
            if (!transacao.EhValido()) return;

            var transacaoExistente = Transacaos.Any(p => p.CodigoUnico == transacao.CodigoUnico);
            if (CodigoUnidoEmUso(transacao.CodigoUnico)) throw new DomainException($"Transação com o código {transacao.CodigoUnico} duplicado");

            _transacaos.Add(transacao);
        }

        public void AtualizarTransacao(int transacaoId, Transacao transacao)
        {
            if (!transacao.EhValido()) return;

            if (CodigoUnidoEmUso(transacao.CodigoUnico, transacaoId)) throw new DomainException($"Transação com o código {transacao.CodigoUnico} duplicado");

            var transacaoExistente = Transacaos.FirstOrDefault(p => p.Id == transacaoId);
            if (transacaoExistente == null) throw new DomainException("A transacao não pertence a conta");

            transacaoExistente.AtualizarTipoTransacao(transacao.TipoTransacao);
            transacaoExistente.AtualizarDataLancamento(transacao.DataLancamento);
            transacaoExistente.AtualizarValor(transacao.Valor);
            transacaoExistente.AtualizarCodigoUnico(transacao.CodigoUnico);
            transacaoExistente.AtualizarProtocolo(transacao.Protocolo);
            transacaoExistente.AtualizarCodigoReferencia(transacao.CodigoReferencia);
            transacaoExistente.AtualizarDescricacao(transacao.Descricacao);
        }

        public bool CodigoUnidoEmUso(string codigoUnico, int excluirTransacaoId = 0)
        {
            return Transacaos.Any(t => t.CodigoUnico == codigoUnico && (excluirTransacaoId == 0 || t.Id != excluirTransacaoId));
        }


        public void RemoverTransacao(Transacao transacao)
        {
            if (!transacao.EhValido()) return;

            var itemExistente = Transacaos.FirstOrDefault(p => p.Id == transacao.Id);

            if (itemExistente == null) throw new DomainException("A transacao não pertence a conta");
            _transacaos.Remove(itemExistente);
        }

        public override bool EhValido()
        {
            //regras de commands
            return true;
        }
    }
}
