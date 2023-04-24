using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SS.Tecnologia.YahooFinance.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;

namespace VariacaoDoAtivo.Domain.Business
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
            var variacoes = new List<Variacao>();

            var chart = dadosYahoo.Chart?.Result?.FirstOrDefault();

            if (chart == null)
            {
                return new List<Variacao>();
            }

            var periodos = chart.Timestamp;

            var numPeriodos = periodos?.Count;

            var openList = chart.Indicators?.Quote?.FirstOrDefault()?.Open;

            if (null != openList && null != periodos && periodos.Count == openList.Count)
            {
                for (int i = 0; i < openList.Count; i++)
                {
                    Variacao nova = new Variacao();

                    nova.Dia = i + 1;
                    nova.Data = DateTimeOffset.FromUnixTimeSeconds(periodos[i]).LocalDateTime.ToString("dd/MM/yyyy HH:mm:ss");
                    nova.Valor = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", openList[i]);

                    if (i.Equals(0))
                    {
                        nova.VaricaoRelacaoD1 = "-";
                        nova.VariacaoRelacaoPrimeiraData = "-";
                        variacoes.Add(nova);
                        continue;
                    }

                    var openD1 = openList[i - 1];
                    var PorcentagemDiaMenosUm = openList[i] * 100 / openD1 - 100;
                    var PorcentagemEmRelacaoAPrimeiraData = openList[i] * 100 / openList[0] - 100;
                    nova.VaricaoRelacaoD1 = (Convert.ToDecimal(PorcentagemDiaMenosUm) / 100).ToString("P2", CultureInfo.GetCultureInfo("pt-BR")) ?? "-";
                    nova.VariacaoRelacaoPrimeiraData = (Convert.ToDecimal(PorcentagemEmRelacaoAPrimeiraData) / 100).ToString("P2", CultureInfo.GetCultureInfo("pt-BR")) ?? "-";
                    variacoes.Add(nova);
                }
            }

            if (null == variacoes)
                throw new ArgumentException($"Não foram encontradas variações de preço nos ultimos 30 pregões do ativo {chart.Meta}!");

            return variacoes;
        }
    }
}
