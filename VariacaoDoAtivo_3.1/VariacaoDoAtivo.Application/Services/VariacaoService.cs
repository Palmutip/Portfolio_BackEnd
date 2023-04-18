using VariacaoDoAtivo.Domain;
using SS.Tecnologia.YahooFinance.Inferfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace VariacaoDoAtivo.Application
{
    public class VariacaoService : IVariacaoService
    {
        private readonly IVariacaoRepository variacaoRepository;
        private readonly IYahooFinanceService yahooFinanceService;
        private readonly IVariacaoBusiness variacaoBusiness;
        private readonly IMapper mapper;

        public VariacaoService(IVariacaoRepository variacaoRepository, IYahooFinanceService yahooFinanceService, IVariacaoBusiness variacaoBusiness, IMapper mapper)
        {
            this.variacaoRepository = variacaoRepository;
            this.yahooFinanceService = yahooFinanceService;
            this.variacaoBusiness = variacaoBusiness;
            this.mapper = mapper;
        }

        public List<VariacaoViewModel> Get()
        {
            List<VariacaoViewModel> _variacaoViewModels = new List<VariacaoViewModel>();

            IEnumerable<Variacao> _variacoes = this.variacaoRepository.GetAll();

            _variacaoViewModels = mapper.Map<List<VariacaoViewModel>>(_variacoes);

            return _variacaoViewModels;
        }

        public bool Post(string identificacaoAtivo)
        {
            this.variacaoRepository.Create(this.variacaoBusiness.RetornaVariacoes(this.yahooFinanceService.ConsultaAtivo(identificacaoAtivo)));

            return true;
        }
    }
}
