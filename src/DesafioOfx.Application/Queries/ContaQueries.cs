using AutoMapper;
using DesafioOfx.Application.Queries.ViewModels;
using DesafioOfx.Domain.Interfaces;
using System;
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

        public async Task<ContaViewModel> ObterContaId(int contId)
        {
            var conta = await _contaRepository.ObterContaPorIdAsNoTracking(contId);
            return _mapper.Map<ContaViewModel>(conta);
        }

        public Task<RelatorioViewModel> ObteRelatorio(int ContId)
        {
            throw new NotImplementedException();
        }
    }
}
