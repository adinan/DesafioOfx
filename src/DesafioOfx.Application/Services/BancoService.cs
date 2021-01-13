namespace DesafioOfx.Application.Services
{
    public class BancoService //: IBancoService
    {
        /*
        private readonly IContaRepository _bancoRepository;
        private readonly IMapper _mapper;

        public BancoService(IContaRepository bancoRepository,
                            IMapper mapper)
        {
            _bancoRepository = bancoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ContaViewModel>> ObterContaPorIdComLancamentosBancarios(int contaId)
        {
            return _mapper.Map<IEnumerable<ContaViewModel>>(await _bancoRepository.ObterContaPorIdComTransacoes(contaId));
        }

        public async Task<IEnumerable<ContaViewModel>> ObterExtratoConta(int contaId, DateTime dataInicioExtrato, DateTime dataFimExtrato)
        {
            //todo
            var teste =  _bancoRepository
                .ObterContaPredicadoComTransacoes(c => c.Id == contaId && c.Transacaos.Any(t => t.DataLancamento > dataInicioExtrato && t.DataLancamento < dataFimExtrato)).Result;

            return _mapper.Map<IEnumerable<ContaViewModel>>(await _bancoRepository
                .ObterContaPredicadoComTransacoes(c => c.Id == contaId && c.Transacaos.Any(t => t.DataLancamento > dataInicioExtrato && t.DataLancamento < dataFimExtrato)));
        }


        public async Task AdicionarLancamentoFinanceiro(TransacaoViewModel transacaoViewModel)
        {
            var transacao = _mapper.Map<Transacao>(transacaoViewModel);
            _bancoRepository.AdicionarTransacao(transacao);

            await _bancoRepository.UnitOfWork.Commit();
        }

        public async Task AtualizarLancamentoFinanceiro(TransacaoViewModel transacaoViewModel)
        {
            var transacao = _mapper.Map<Transacao>(transacaoViewModel);
            _bancoRepository.AtualizarTransacao(transacao);

            await _bancoRepository.UnitOfWork.Commit();
        }


        public Task ImportarOfx(string arquivoOfx)
        {
            throw new NotImplementedException();
        }


        public void Dispose()
        {
            _bancoRepository?.Dispose();
        }*/
    }
}
