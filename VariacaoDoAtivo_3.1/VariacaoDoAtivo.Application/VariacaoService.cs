using VariacaoDoAtivo.Domain;
using SS.Tecnologia.YahooFinance.Inferfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariacaoDoAtivo.Application
{
    public class VariacaoService : IVariacaoService
    {
        private readonly IVariacaoRepository variacaoRepository;
        private readonly IYahooFinanceService yahooFinanceService;
        private readonly IVariacaoBusiness variacaoBusiness;

        public VariacaoService(IVariacaoRepository variacaoRepository, IYahooFinanceService yahooFinanceService, IVariacaoBusiness variacaoBusiness)
        {
            this.variacaoRepository = variacaoRepository;
            this.yahooFinanceService = yahooFinanceService;
            this.variacaoBusiness = variacaoBusiness;
        }

        public List<VariacaoViewModel> Get()
        {
            List<VariacaoViewModel> _variacaoViewModels = new List<VariacaoViewModel>();

            IEnumerable<Variacao> _variacoes = this.variacaoRepository.GetAll();

            foreach(var item in _variacoes)
                _variacaoViewModels.Add(new VariacaoViewModel() { Dia = item.Dia, Data = item.Data, Valor = item.Valor, VariacaoRelacaoPrimeiraData = item.VariacaoRelacaoPrimeiraData, VaricaoRelacaoD1 = item.VaricaoRelacaoD1 });


            return _variacaoViewModels;
        }

        public bool Post(string identificacaoAtivo)
        {
            this.variacaoRepository.Create(this.variacaoBusiness.RetornaVariacoes(this.yahooFinanceService.ConsultaAtivo(identificacaoAtivo)));

            return true;
        }
    }
}
