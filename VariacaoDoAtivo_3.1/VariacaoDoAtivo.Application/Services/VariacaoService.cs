using VariacaoDoAtivo.Domain;
using SS.Tecnologia.YahooFinance.Inferfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;

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

        public VariacaoViewModel GetById(int dia)
        {
            Variacao _variacao = this.variacaoRepository.Find(x => x.Dia == dia && !x.IsDeleted);

            if (null == _variacao)
                throw new Exception("Variação do ativo não encontrada");

            return mapper.Map<VariacaoViewModel>(_variacao);
        }

        public bool Post(string identificacaoAtivo)
        {
            this.variacaoRepository.Create(this.variacaoBusiness.RetornaVariacoes(this.yahooFinanceService.ConsultaAtivo(identificacaoAtivo)));

            return true;
        }

        public bool Put(VariacaoViewModel variacaoViewModel)
        {
            Variacao _variacao = this.variacaoRepository.Find(x => x.Id == variacaoViewModel.Id && !x.IsDeleted);

            if (null == _variacao)
                throw new Exception("Variação do ativo não encontrada");

            _variacao = mapper.Map<Variacao>(variacaoViewModel);

            this.variacaoRepository.Update(_variacao);

            return true;
        }

        public bool Delete(string id)
        {
            if (!Guid.TryParse(id, out Guid variacaoId))
                throw new Exception("A variação não possui um ID válido!");

            Variacao _variacao = this.variacaoRepository.Find(x => x.Id == variacaoId && !x.IsDeleted);

            if (null == _variacao)
                throw new Exception("Variação do ativo não encontrada");

            return this.variacaoRepository.Delete(_variacao);

        }

        public bool Delete()
        {
            this.variacaoRepository.DeleteAll();

            return true;
        }

    }
}
