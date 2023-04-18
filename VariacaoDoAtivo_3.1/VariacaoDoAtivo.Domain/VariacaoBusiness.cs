using SS.Tecnologia.YahooFinance.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace VariacaoDoAtivo.Domain
{
    /// <summary>
    /// Classe responsável por formatar os resultados após obter os dados da API
    /// </summary>
    public class VariacaoBusiness : IVariacaoBusiness
    {
        /// <summary>
        /// Formata o objeto de Variação conforme os dados recebidos pela API
        /// </summary>
        /// <param name="dadosYahoo">Content do retorno da chamada à API</param>
        /// <returns>Retorna o objeto formatado conforme os requisitos da operação</returns>
        public List<Variacao> RetornaVariacoes(Ativo dadosYahoo)
        {
            var chart = dadosYahoo.Chart?.Result?.FirstOrDefault();

            if (chart == null)
            {
                return new List<Variacao>();
            }

            var periodos = chart.Timestamp;

            var numPeriodos = periodos?.Count;
            if (numPeriodos < 30)
            {
                return new List<Variacao>();
            }

            var openList = chart.Indicators?.Quote?.FirstOrDefault()?.Open;

            var variacoes = openList?
                .Skip(Math.Max(0, openList.Count() - 30))
                .Select((open, index) =>
                {
                    var variacao = new Variacao
                    {
                        Dia = index + 1,
                        Data = DateTimeOffset.FromUnixTimeSeconds(periodos[periodos.Count() - 30 + index]).LocalDateTime.ToString("dd/MM/yyyy"),
                        Valor = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", open)
                    };

                    if (index == 0)
                    {
                        variacao.VaricaoRelacaoD1 = "-";
                        variacao.VariacaoRelacaoPrimeiraData = "-";
                    }
                    else
                    {
                        var openD1 = chart.Indicators?.Quote?.FirstOrDefault()?.Open?[periodos.Count - 31 + index];
                        var PorcentagemDiaMenosUm = ((open * 100) / openD1) - 100;
                        var PorcentagemEmRelacaoAPrimeiraData = ((open * 100) / chart.Indicators?.Quote?.FirstOrDefault()?.Open?[periodos.Count() - 30]) - 100;
                        variacao.VaricaoRelacaoD1 = (Convert.ToDecimal(PorcentagemDiaMenosUm) / 100).ToString("P2", CultureInfo.GetCultureInfo("pt-BR")) ?? "-";
                        variacao.VariacaoRelacaoPrimeiraData = (Convert.ToDecimal(PorcentagemEmRelacaoAPrimeiraData) / 100).ToString("P2", CultureInfo.GetCultureInfo("pt-BR")) ?? "-";
                    }

                    return variacao;
                })
                .ToList();

            if (null == variacoes)
                throw new ArgumentException($"Não foram encontradas variações de preço nos ultimos 30 pregões do ativo {chart.Meta}!");

            return variacoes;
        }
    }
}
