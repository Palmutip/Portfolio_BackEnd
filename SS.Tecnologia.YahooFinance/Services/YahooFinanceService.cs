using Newtonsoft.Json;
using SS.Tecnologia.YahooFinance.Inferfaces;
using SS.Tecnologia.YahooFinance.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SS.Tecnologia.YahooFinance.Services
{
    /// <summary>
    /// Classe responsável por realizar as chamadas à API
    /// </summary>
    public class YahooFinanceService : IYahooFinanceService
    {
        /// <summary>
        /// Método responsável por consultar a variação de determinado ativo conforme seu nome de identificaçã
        /// </summary>
        /// <param name="identificacaoAtivo">Identificação do ativo. Ex: NUBR33.SA / PETR4.SA </param>
        /// <param name="intervalo">Intervalo entre cada pregão: Ex 1 dia, 1 semana, 1 ano ...</param>
        /// <param name="range">Range de dados que se deseja obter conforme o intervalo. Ex: intervalo 1d no range de 30d (ultimos 30 dias)</param>
        /// <returns>Lista de variações dos pregões conforme o ativo</returns>
        /// <exception cref="Exception"></exception>
        public async Task<Ativo> ConsultaAtivoAsync(string identificacaoAtivo, Intervalo intervalo, string range = "")
        {
            try
            {
                using (var client = new HttpClient())
                {
                    StringBuilder sb = new StringBuilder("https://query2.finance.yahoo.com/v8/finance/chart/");
                    sb.Append(identificacaoAtivo);

                    sb.Append("?");
                    sb.Append("interval=");

                    switch (intervalo)
                    {
                        case Intervalo.m1:
                            sb.Append("1m");
                            break;
                        case Intervalo.d1:
                            sb.Append("1d");
                            break;
                        case Intervalo.wk1:
                            sb.Append("1wk");
                            break;
                        case Intervalo.mo1:
                            sb.Append("1mo");
                            break;
                        case Intervalo.y1:
                            sb.Append("1y");
                            break;
                        default:
                            sb.Append("1m");
                            break;
                    }

                    if (!range.Equals(""))
                    {
                        sb.Append("&range=");
                        sb.Append(range);
                    }

                    var response = await client.GetAsync(sb.ToString());

                    if (response.StatusCode != System.Net.HttpStatusCode.OK)
                        throw new Exception("Retorno da API foi diferente de OK");

                    //Captura o 'Content' retornado pela consulta
                    var content = await response.Content.ReadAsStringAsync();

                    //Deserializa o objeto 
                    var result = JsonConvert.DeserializeObject<Ativo>(content);

                    //Verifica se houve retorno da API
                    if (result == null)
                        throw new ArgumentNullException(nameof(result), "Retorno da API foi nulo");

                    return result;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// Método responsável por consultar a variação de determinado ativo conforme seu nome de identificaçã
        /// </summary>
        /// <param name="identificacaoAtivo">Identificação do ativo. Ex: NUBR33.SA / PETR4.SA </param>
        /// <param name="intervalo">Intervalo entre cada pregão: Ex 1 dia, 1 semana, 1 ano ...</param>
        /// <param name="range">Range de dados que se deseja obter conforme o intervalo. Ex: intervalo 1d no range de 30d (ultimos 30 dias)</param>
        /// <returns>Lista de variações dos pregões conforme o ativo</returns>
        /// <exception cref="Exception"></exception>
        public Ativo ConsultaAtivo(string identificacaoAtivo, Intervalo intervalo, string range = "")
        {
            try
            {
                using (var client = new HttpClient())
                {
                    StringBuilder sb = new StringBuilder("https://query2.finance.yahoo.com/v8/finance/chart/");
                    sb.Append(identificacaoAtivo);

                    sb.Append("?");
                    sb.Append("interval=");

                    switch (intervalo)
                    {
                        case Intervalo.m1:
                            sb.Append("1m");
                            break;
                        case Intervalo.d1:
                            sb.Append("1d");
                            break;
                        case Intervalo.wk1:
                            sb.Append("1wk");
                            break;
                        case Intervalo.mo1:
                            sb.Append("1mo");
                            break;
                        case Intervalo.y1:
                            sb.Append("1y");
                            break;
                        default:
                            sb.Append("1m");
                            break;
                    }

                    if (!range.Equals(""))
                    {
                        sb.Append("&range=");
                        sb.Append(range);
                    }

                    var response = client.GetAsync(sb.ToString());

                    if (response.Result.StatusCode != System.Net.HttpStatusCode.OK)
                        throw new Exception("Retorno da API foi diferente de OK");

                    //Captura o 'Content' retornado pela consulta
                    var content = response.Result.Content.ReadAsStringAsync();

                    //Deserializa o objeto 
                    var result = JsonConvert.DeserializeObject<Ativo>(content.Result);

                    //Verifica se houve retorno da API
                    if (result == null)
                        throw new ArgumentNullException(nameof(result), "Retorno da API foi nulo");

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
