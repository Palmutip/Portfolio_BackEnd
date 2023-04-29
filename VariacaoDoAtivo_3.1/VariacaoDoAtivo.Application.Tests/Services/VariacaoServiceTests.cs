using AutoMapper;
using Moq;
using SS.Tecnologia.YahooFinance;
using SS.Tecnologia.YahooFinance.Inferfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VariacaoDoAtivo.Domain;
using Xunit;

namespace VariacaoDoAtivo.Application.Tests
{
    public class VariacaoServiceTests
    {
        private VariacaoService variacaoService;

        public VariacaoServiceTests()
        {
            variacaoService = new VariacaoService(new Mock<IVariacaoRepository>().Object, new Mock<IYahooFinanceService>().Object, new Mock<IVariacaoBusiness>().Object, new Mock<IMapper>().Object);
        }

        [Fact]
        public void GetById_EnviandoDiaInvalido()
        {
            var exception = Assert.Throws<Exception>(() => variacaoService.GetById(1));
            Assert.Equal("Variação do ativo não encontrada", exception.Message);
        }

        [Fact]
        public void Post_EnviandoObjetoValido()
        {
            var result = variacaoService.Post(new VariacaoRequestViewModel { IdentificacaoAtivo = "NUBR33.SA", Intervalo = Intervalo.d1, Range = "30d" });
            Assert.True(result);
        }

        [Fact]
        public void Post_EnviandoObjetoInvalido()
        {
            var exception = Assert.Throws<ValidationException>(() => variacaoService.Post(new VariacaoRequestViewModel()));
            Assert.Equal("The IdentificacaoAtivo field is required.", exception.Message);
        }

        [Fact]
        public void Put_EnviandoGuidVazio()
        {
            var exception = Assert.Throws<Exception>(() => variacaoService.Put(new VariacaoViewModel()));
            Assert.Equal("Variação do ativo não encontrada", exception.Message);
        }

        [Fact]
        public void Delete_EnviandoGuidVazio()
        {
            var exception = Assert.Throws<Exception>(() => variacaoService.Delete(""));
            Assert.Equal("A variação não possui um ID válido!", exception.Message);
        }
    }
}
