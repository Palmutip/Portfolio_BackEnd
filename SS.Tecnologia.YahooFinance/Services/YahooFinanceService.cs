using Newtonsoft.Json;
using SS.Tecnologia.YahooFinance.Inferfaces;
using SS.Tecnologia.YahooFinance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        /// Método responsável por consultar a variação de determinado ativo conforme seu nome de identificação
        /// </summary>
        /// <param name="identificacaoAtivo">Identificação do ativo. Ex: NUBR33.SA / PETR4.SA </param>
        /// <returns>Lista de variações nos últimos 30 pregões conforme o ativo</returns>
        /// <exception cref="Exception"></exception>
        public async Task<Ativo> ConsultaAtivoAsync(string identificacaoAtivo)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    // Cria um objeto DateTime com a data/hora especificada
                    DateTime data = new DateTime(2023, 01, 01, 0, 1, 0);

                    // Obtém uma instância do fuso horário -03:00
                    TimeZoneInfo fusoHorario = TimeZoneInfo.Local;

                    // Converte a data/hora para o fuso horário -03:00
                    DateTime dataFusoHorario = TimeZoneInfo.ConvertTime(data, fusoHorario);

                    // Cria um objeto DateTimeOffset com a data/hora e o fuso horário especificados
                    DateTimeOffset dateTimeOffset = new DateTimeOffset(dataFusoHorario, fusoHorario.GetUtcOffset(dataFusoHorario));

                    //Formata o datetime em segundos a partir da data de 01/01/1970 00:00:00
                    long timestamp = dateTimeOffset.ToUnixTimeSeconds();

                    //Realiza a consulta na API finance.yahoo
                    var response = await client.GetAsync($"https://query2.finance.yahoo.com/v8/finance/chart/{identificacaoAtivo}?period1={timestamp}&period2=9999999999&interval=1d");

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
        /// Método responsável por consultar a variação de determinado ativo conforme seu nome de identificação
        /// </summary>
        /// <param name="identificacaoAtivo">Identificação do ativo. Ex: NUBR33.SA / PETR4.SA </param>
        /// <returns>Lista de variações nos últimos 30 pregões conforme o ativo</returns>
        /// <exception cref="Exception"></exception>
        public Ativo ConsultaAtivo(string identificacaoAtivo)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    // Cria um objeto DateTime com a data/hora especificada
                    DateTime data = new DateTime(2023, 01, 01, 0, 1, 0);

                    // Obtém uma instância do fuso horário -03:00
                    TimeZoneInfo fusoHorario = TimeZoneInfo.Local;

                    // Converte a data/hora para o fuso horário -03:00
                    DateTime dataFusoHorario = TimeZoneInfo.ConvertTime(data, fusoHorario);

                    // Cria um objeto DateTimeOffset com a data/hora e o fuso horário especificados
                    DateTimeOffset dateTimeOffset = new DateTimeOffset(dataFusoHorario, fusoHorario.GetUtcOffset(dataFusoHorario));

                    //Formata o datetime em segundos a partir da data de 01/01/1970 00:00:00
                    long timestamp = dateTimeOffset.ToUnixTimeSeconds();

                    //Realiza a consulta na API finance.yahoo
                    var response = client.GetAsync($"https://query2.finance.yahoo.com/v8/finance/chart/{identificacaoAtivo}?period1={timestamp}&period2=9999999999&interval=1d");

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
