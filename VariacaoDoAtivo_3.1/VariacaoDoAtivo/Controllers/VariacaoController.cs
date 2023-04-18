using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VariacaoDoAtivo.Application;
using VariacaoDoAtivo.Domain;
using SS.Tecnologia.YahooFinance.Inferfaces;

namespace VariacaoDoAtivo.Controllers
{
    [Route("api/[controller]"), ApiController]
    public class VariacaoController : ControllerBase
    {
        private readonly IVariacaoService variacaoService;
        private readonly IYahooFinanceService yahooFinanceService;
        private readonly IVariacaoBusiness variacaoBusiness;

        public VariacaoController(IVariacaoService variacaoService, IYahooFinanceService yahooFinanceService, IVariacaoBusiness variacaoBusiness)
        {
            this.variacaoService = variacaoService;
            this.yahooFinanceService = yahooFinanceService;
            this.variacaoBusiness = variacaoBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.variacaoService.Get());
        }

        [HttpPost]
        public IActionResult Post(string identificacaoAtivo)
        {
            return Ok(this.variacaoService.Post(identificacaoAtivo));
        }
    }
}
