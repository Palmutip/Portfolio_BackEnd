using Newtonsoft.Json;
using RestSharp;
using SS.Tecnologia.RDStation.Model;
using System.Net;
using System.Text;
using SS.Tecnologia.RDStation.Interfaces;

namespace SS.Tecnologia.RDStation
{
    /// <summary>
    /// Serviço responsável por integrar com a RD Station
    /// </summary>
    public class RDStation : IRDStation
    {
        #region Chamadas Sícronas
        /// <summary>
        /// Responsavel por enviar o contato para a plataforma RD Station de forma Sícrona
        /// </summary>
        /// <param name="credenciais">Credencias do cliente fornecidas pela RD Station em sua plataforma</param>
        /// <param name="dadosContato">Classe referente aos dados que se dejesa enviar para a RD Station</param>
        /// <returns>retorna o token de acesso referente às credenciais fornecidas</returns>
        /// <exception cref="ArgumentException">Armazena o log e joga a excessão caso tenha algum erro</exception>
        public string Integrar(ClientCredential credenciais, ContatosBenner dadosContato)
        {
            string log = string.Empty;

            try
            {
                Token GetAccessToken = GetToken(credenciais);

                string token = GetAccessToken.AccessToken;

                EnviarContato(token, dadosContato);

                return token;
            }
            catch (Exception e)
            {
                log = e.Message;
                throw new ArgumentException(log);
            }
        }

        /// <summary>
        /// Responsável por realizar um post na API da RD Station e capturar o token do usuário para acesso à API
        /// </summary>
        /// <param name="credential">Credencias do cliente fornecidas pela RD Station em sua plataforma</param>
        /// <returns>retorna o objeto</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="HttpRequestException"></exception>
        /// <exception cref="Exception"></exception>
        private static Token GetToken(ClientCredential credential)
        {
            try
            {
                //Definição de protocolo de segurança
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                using (var client = new HttpClient())
                {
                    //Corpo da requisição à API
                    string conteudo =
                    "{ \"client_id\": \"" + credential.ClientId + "\", " +
                    "\"client_secret\": \"" + credential.ClientSecret + "\", " +
                    "\"refresh_token\": \"" + credential.RefreshToken + "\" }";

                    //Formatando a requisição com o formato JSON
                    StringContent data = new StringContent(conteudo, Encoding.UTF8, "application/json");

                    //Realizando o método POST na API e já coletando o resultado para chamada permanecer sícrona
                    HttpResponseMessage response = client.PostAsync("https://api.rd.services/auth/token", data).Result;

                    //Verificando o Codigo de status HTTP da requisicao
                    if (!response.IsSuccessStatusCode)
                        throw new ArgumentException("Não foi possivel encontrar um Token para realizar a autenticacao." + Environment.NewLine + response.ReasonPhrase);

                    //Atribuindo o Content referente ao retorno da chamada
                    var content = response.Content.ReadAsStringAsync();

                    //Validando se o retorno da API é diferente de nulo
                    if (null == content)
                        throw new HttpRequestException("A chamada à API teve retorno nulo!");

                    //Atribuindo o result referente ao retorno do conteudo da requisição
                    string result = content.Result ?? string.Empty;

                    //Validando se o resultado não é nulo   
                    if (!string.IsNullOrEmpty(result))
                    {
                        //Capturando o retorno da API como objeto Token
                        Token retorno = JsonConvert.DeserializeObject<Token>(result);

                        return retorno;
                    }
                    throw new HttpRequestException("A chamada à API teve como resultado um valor nulo!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(JsonConvert.SerializeObject(new { status = "Erro", code = HttpStatusCode.InternalServerError, message = ex.Message }));
            }
        }

        /// <summary>
        /// Responsável por enviar o contato para a plataforma RD conforme os campos definidos pelo cliente
        /// </summary>
        /// <param name="token">Propriedade AccessToken referente o objeto Token</param>
        /// <param name="contato">Credencias do cliente fornecidas pela RD Station em sua plataforma</param>
        /// <exception cref="ArgumentException"></exception>
        private static void EnviarContato(string token, ContatosBenner contato)
        {
            var rsClient = new RestClient("https://api.rd.services/platform/contacts");
            RestRequest request = new RestRequest();
            request.AddHeader("Authorization", "Bearer " + token);
            var body = JsonConvert.SerializeObject(contato);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = rsClient.PatchAsync(request).Result;

            if (!response.StatusCode.Equals(HttpStatusCode.OK))
            {
                throw new ArgumentException("Não foi possivel enviar o contato para RD." + Environment.NewLine + response.ErrorMessage);
            }
        }
        #endregion

        #region Chamadas Assícronas
        /// <summary>
        /// Responsavel por enviar o contato para a plataforma RD Station de forma Assícrona
        /// </summary>
        /// <param name="credenciais">Credencias do cliente fornecidas pela RD Station em sua plataforma</param>
        /// <param name="dadosContato">Classe referente aos dados que se dejesa enviar para a RD Station</param>
        /// <returns>retorna o token de acesso referente às credenciais fornecidas</returns>
        /// <exception cref="ArgumentException">Armazena o log e joga a excessão caso tenha algum erro</exception>
        public async Task<string> IntegrarAsync(ClientCredential credenciais, ContatosBenner dadosContato)
        {
            string log = string.Empty;

            try
            {
                Token GetAccessToken = await GetTokenAsync(credenciais);

                string token = GetAccessToken.AccessToken;

                await EnviarContatoAsync(token, dadosContato);

                return token;
            }
            catch (Exception e)
            {
                log = e.Message;
                throw new ArgumentException(log);
            }
        }

        /// <summary>
        /// Responsável por realizar um post na API da RD Station e capturar o token do usuário para acesso à API
        /// </summary>
        /// <param name="credential">Credencias do cliente fornecidas pela RD Station em sua plataforma</param>
        /// <returns>retorna o objeto</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="HttpRequestException"></exception>
        /// <exception cref="Exception"></exception>
        private async static Task<Token> GetTokenAsync(ClientCredential credential)
        {
            try
            {
                //Definição de protocolo de segurança
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                using (var client = new HttpClient())
                {
                    //Corpo da requisição à API
                    string conteudo =
                    "{ \"client_id\": \"" + credential.ClientId + "\", " +
                    "\"client_secret\": \"" + credential.ClientSecret + "\", " +
                    "\"refresh_token\": \"" + credential.RefreshToken + "\" }";

                    //Formatando a requisição com o formato JSON
                    StringContent data = new StringContent(conteudo, Encoding.UTF8, "application/json");

                    //Realizando o método POST na API e já coletando o resultado para chamada permanecer sícrona
                    HttpResponseMessage response = await client.PostAsync("https://api.rd.services/auth/token", data);

                    //Verificando o Codigo de status HTTP da requisicao
                    if (!response.IsSuccessStatusCode)
                        throw new ArgumentException("Não foi possivel encontrar um Token para realizar a autenticacao." + Environment.NewLine + response.ReasonPhrase);

                    //Atribuindo o Content referente ao retorno da chamada
                    var content = response.Content.ReadAsStringAsync();

                    //Validando se o retorno da API é diferente de nulo
                    if (null == content)
                        throw new HttpRequestException("A chamada à API teve retorno nulo!");

                    //Atribuindo o result referente ao retorno do conteudo da requisição
                    string result = content.Result ?? string.Empty;

                    //Validando se o resultado não é nulo   
                    if (!string.IsNullOrEmpty(result))
                    {
                        //Capturando o retorno da API como objeto Token
                        Token retorno = JsonConvert.DeserializeObject<Token>(result);

                        return retorno;
                    }
                    throw new HttpRequestException("A chamada à API teve como resultado um valor nulo!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(JsonConvert.SerializeObject(new { status = "Erro", code = HttpStatusCode.InternalServerError, message = ex.Message }));
            }
        }

        /// <summary>
        /// Responsável por enviar o contato para a plataforma RD conforme os campos definidos pelo cliente
        /// </summary>
        /// <param name="token">Propriedade AccessToken referente o objeto Token</param>
        /// <param name="contato">Credencias do cliente fornecidas pela RD Station em sua plataforma</param>
        /// <exception cref="ArgumentException"></exception>
        private async static Task EnviarContatoAsync(string token, ContatosBenner contato)
        {
            var rsClient = new RestClient("https://api.rd.services/platform/contacts");
            RestRequest request = new RestRequest();
            request.AddHeader("Authorization", "Bearer " + token);
            var body = JsonConvert.SerializeObject(contato);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = await rsClient.PatchAsync(request);

            if (!response.StatusCode.Equals(HttpStatusCode.OK))
            {
                throw new ArgumentException("Não foi possivel enviar o contato para RD." + Environment.NewLine + response.ErrorMessage);
            }
        }
        #endregion
    }
}