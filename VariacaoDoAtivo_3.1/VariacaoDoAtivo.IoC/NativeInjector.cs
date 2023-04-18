using Microsoft.Extensions.DependencyInjection;
using VariacaoDoAtivo.Application;
using VariacaoDoAtivo.Data;
using VariacaoDoAtivo.Domain;
using SS.Tecnologia.YahooFinance.Inferfaces;
using SS.Tecnologia.YahooFinance.Services;
using System;
using System.Collections.Generic;
using System.Text;
using VariacaoDoAtivo.Domain.Business;

namespace VariacaoDoAtivo.IoC
{
    public static class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Services

            services.AddScoped<IVariacaoService, VariacaoService>();
            services.AddScoped<IYahooFinanceService, YahooFinanceService>();

            #endregion

            #region Repositories

            services.AddScoped<IVariacaoRepository, VariacaoRepository>();

            #endregion

            #region Business

            services.AddScoped<IVariacaoBusiness, VariacaoBusiness>();

            #endregion

        }
    }
}
