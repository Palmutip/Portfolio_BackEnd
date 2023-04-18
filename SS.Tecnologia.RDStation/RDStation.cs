using Newtonsoft.Json;
using RestSharp;
using SS.Tecnologia.RDStation.Model;
using System.Net;
using System.Text;

namespace SS.Tecnologia.RDStation
{
    public class RDStation
    {
        private static HttpClient client = new HttpClient();

        #region Chamadas Sícronas
        public string Integrar(ClientCredential credenciais, ContatosBenner dadosContato)
        {
            string log = "";

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

        public string Integrar(KeyValuePair<ClientCredential, ContatosBenner> par)
        {
            string log = "";

            try
            {
                Token GetAccessToken =  GetToken(par.Key);

                string token = GetAccessToken.AccessToken;

                EnviarContato(token, par.Value);

                return token;
            }
            catch (Exception e)
            {
                log = e.Message;
                throw new ArgumentException(log);
            }
        }

        public static Token GetToken(ClientCredential credential)
        {
            try
            {
                //Definição de protocolo de segurança
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

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
                {
                    throw new ArgumentException("Não foi possivel encontrar um Token para realizar a autenticacao." + Environment.NewLine + response.ReasonPhrase);
                }

                //Capturando o retorno da API como objeto Token
                Token retorno = JsonConvert.DeserializeObject<Token>(response.Content.ReadAsStringAsync().Result);

                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception(JsonConvert.SerializeObject(new { status = "Erro", code = HttpStatusCode.InternalServerError, message = ex.Message }));
            }
        }

        public static void EnviarContato(string token, ContatosBenner contato)
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
        public async Task<string> IntegrarAsync(ClientCredential credenciais, ContatosBenner dadosContato)
        {
            string log = "";

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

        public async Task<string> IntegrarAsync(KeyValuePair<ClientCredential, ContatosBenner> par)
        {
            string log = "";

            try
            {
                Token GetAccessToken = await GetTokenAsync(par.Key);

                string token = GetAccessToken.AccessToken;

                await EnviarContatoAsync(token, par.Value);

                return token;
            }
            catch (Exception e)
            {
                log = e.Message;
                throw new ArgumentException(log);
            }
        }

        public async static Task<Token> GetTokenAsync(ClientCredential credential)
        {
            try
            {
                //Definição de protocolo de segurança
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

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
                {
                    throw new ArgumentException("Não foi possivel encontrar um Token para realizar a autenticacao." + Environment.NewLine + response.ReasonPhrase);
                }

                //Capturando o retorno da API como objeto Token
                Token retorno = JsonConvert.DeserializeObject<Token>(response.Content.ReadAsStringAsync().Result);

                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception(JsonConvert.SerializeObject(new { status = "Erro", code = HttpStatusCode.InternalServerError, message = ex.Message }));
            }
        }

        public async static Task EnviarContatoAsync(string token, ContatosBenner contato)
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