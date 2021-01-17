using AutoMapper;
using DesafioOfx.Application.Queries.ViewModels;
using DesafioOfx.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioOfx.Application.Queries
{
    public class ContaQueries : IContaQueries
    {
        private readonly IContaRepository _contaRepository;
        private readonly IMapper _mapper;

        public ContaQueries(IContaRepository contaRepository,
                            IMapper mapper)
        {
            _contaRepository = contaRepository;
            _mapper = mapper;
        }

        public async Task<ContaViewModel> ObterConta(InformacaoContaPessoaViewModel vm)
        {
            if (string.IsNullOrWhiteSpace(vm.AgenciaCodigo))
            {
                vm.AgenciaCodigo = "0001";
                vm.AgenciaDigito = null;
            }
            var conta = await _contaRepository.ObterContaPredicado(c =>
                            c.Agencia.Banco.Codigo == vm.BancoCodigo &&
                            c.Agencia.Codigo == vm.AgenciaCodigo && c.Agencia.Digito == vm.AgenciaDigito &&
                            c.Codigo == vm.ContaCodigo && c.Digito == vm.ContaDigito);

            return _mapper.Map<ContaViewModel>(conta.FirstOrDefault());
        }

        public async Task<ContaViewModel> ObterContaId(int contId)
        {
            var conta = await _contaRepository.ObterContaPorId(contId);
            return _mapper.Map<ContaViewModel>(conta);
        }

        public Task<RelatorioViewModel> ObterExtratoCliente(int ContId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TransacaoViewModel>> ObterExtratoCliente(int contaId, DateTime dataIncio, DateTime dataFim)
        {
            return _mapper.Map<List<TransacaoViewModel>>(await _contaRepository.ObterTransacaoPredicado(t => t.ContaId == contaId &&
                                                  t.DataLancamento >= dataIncio &&
                                                  t.DataLancamento <= dataFim));
        }

        public async Task<TransacaoViewModel> ObterTransacaoPorCodigoUnico(string codigoUnico)
        {
            return _mapper.Map<TransacaoViewModel>(await _contaRepository.ObterTransacaoPorCodigoUnico(codigoUnico));

        }
    }
}
