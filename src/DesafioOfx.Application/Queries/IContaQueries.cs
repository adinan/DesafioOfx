﻿using DesafioOfx.Application.Queries.ViewModels;
using System.Threading.Tasks;

namespace DesafioOfx.Application.Queries
{
    public interface  IContaQueries
    {
        Task<ContaViewModel> ObterContaId(int ContId);

        Task<RelatorioViewModel> ObteRelatorio(int ContId);
    }
}
