using Newtonsoft.Json;
using SS.Tecnologia.HCIEnviaZAP.Interfaces;
using SS.Tecnologia.HCIEnviaZAP.Models;
using System.Net;
using System.Text;

namespace SS.Tecnologia.HCIEnviaZAP.Services
{
    /// <summary>
    /// Classe responsável por enviar a mensagem via HCI EnviaZap
    /// </summary>
    public class EnviaZap : IEnviaZap
    {
        /// <summary>
        /// Método para enviar a mensagem utilizando a API da HCI - EnviaZAP
        /// </summary>
        /// <param name="enviaZap">Classe contendo os dados necessários para a integração, sendo eles o DDI, DDD, Nº do telefone e conteúdo da mensagem.</param>
        /// <param name="token">Token fornecido pela plataforma da HCI - Enviazap</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        public string EnviarMensagem(EnviaZapDTO enviaZap, string token)
        {
            try
            {
                //Valida se o numero possui 9 ou 8 digitos e já incrementa o DDD
                ValidarNumero(enviaZap, token);

                //Definição de protocolo de segurança
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                using (var client = new HttpClient())
                {
                    //Corpo da requisição à API
                    string conteudo =
                    "{ \"ddi\": \"" + enviaZap.DDI + "\", " +
                        "\"phoneDest\": \"" + enviaZap.NumeroTelefone + "\", " +
                        "\"message\": \"" + enviaZap.Mensagem + "\", " +
                    "\"webhookUrl\": \"\" }";

                    //Formatando a requisição com o formato JSON
                    var data = new StringContent(conteudo, Encoding.UTF8, "application/json");

                    //Realizando o método POST na API e já coletando o resultado para chamada permanecer sícrona
                    HttpResponseMessage dados = client.PostAsync("https://api.hcisistemas.com.br/sendMessage?token=" + token, data).Result;

                    //Intervalo em segundos para ler o conteúdo e para enviar a proxima mensagem caso este método esteja dentro de um laço de repetição
                    Thread.Sleep(enviaZap.IntervaloDisparo * 1000);

                    //Capturando o retorno da API como string
                    string retorno = dados.Content.ReadAsStringAsync().Result;

                    //Verificando se a mensagem de retorno da API coincide com a que devemos receber quando a mensagem for enviada com sucesso.
                    if (retorno != "{\"message\":\"Message sent successfully\"}")
                    {
                        throw new ArgumentException("Erro no disparo da API: " + retorno);
                    }

                    //Caso o método tenha chegado com sucesso até o final, retorne um JSON com os dados do envio.
                    return JsonConvert.SerializeObject(new { status = "Sucesso", code = HttpStatusCode.OK, message = retorno });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(JsonConvert.SerializeObject(new { status = "Erro", code = HttpStatusCode.InternalServerError, message = ex.Message }));
            }
        }

        /// <summary>
        /// Método para enviar a mensagem utilizando a API da HCI - EnviaZAP
        /// </summary>
        /// <param name="enviaZap">Classe contendo os dados necessários para a integração, sendo eles o DDI, DDD, Nº do telefone e conteúdo da mensagem.</param>
        /// <param name="token">Token fornecido pela plataforma da HCI - Enviazap</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<string> EnviarMensagemAsync(EnviaZapDTO enviaZap, string token)
        {
            try
            {
                //Valida se o numero possui 9 ou 8 digitos e já incrementa o DDD
                ValidarNumero(enviaZap, token);

                //Definição de protocolo de segurança
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                using (var client = new HttpClient())
                {
                    //Corpo da requisição à API
                    string conteudo =
                        "{ \"ddi\": \"" + enviaZap.DDI + "\", " +
                        "\"phoneDest\": \"" + enviaZap.NumeroTelefone + "\", " +
                        "\"message\": \"" + enviaZap.Mensagem + "\", " +
                        "\"webhookUrl\": \"\" }";

                    //Formatando a requisição com o formato JSON
                    var data = new StringContent(conteudo, Encoding.UTF8, "application/json");

                    //Realizando o método POST na API e já coletando o resultado para chamada permanecer sícrona
                    HttpResponseMessage dados = await client.PostAsync("https://api.hcisistemas.com.br/sendMessage?token=" + token, data);

                    //Intervalo em segundos para ler o conteúdo e para enviar a proxima mensagem caso este método esteja dentro de um laço de repetição
                    Thread.Sleep(enviaZap.IntervaloDisparo * 1000);

                    //Capturando o retorno da API como string
                    string retorno = dados.Content.ReadAsStringAsync().Result;

                    //Verificando se a mensagem de retorno da API coincide com a que devemos receber quando a mensagem for enviada com sucesso.
                    if (retorno != "{\"message\":\"Message sent successfully\"}")
                    {
                        throw new ArgumentException("Erro no disparo da API: " + retorno);
                    }

                    //Caso o método tenha chegado com sucesso até o final, retorne um JSON com os dados do envio.
                    return JsonConvert.SerializeObject(new { status = "Sucesso", code = HttpStatusCode.OK, message = retorno });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(JsonConvert.SerializeObject(new { status = "Erro", code = HttpStatusCode.InternalServerError, message = ex.Message }));
            }
        }

        /// <summary>
        /// Valida se o numero possui 9 ou 8 digitos e já incrementa o DDD
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        private void ValidarNumero(EnviaZapDTO enviaZap, string token)
        {
            try
            {
                ValidarClasse(enviaZap, token);

                enviaZap.NumeroTelefone = enviaZap.NumeroTelefone.Trim(',', '-', '(', ')', ' ');

                if (enviaZap.NumeroTelefone.Length == 8)
                {
                    if (enviaZap.DDD.Substring(0, 1) == "1" || enviaZap.DDD.Substring(0, 1) == "2")
                    {
                        enviaZap.NumeroTelefone = enviaZap.DDD + "9" + enviaZap.NumeroTelefone;
                    }
                    else
                    {
                        enviaZap.NumeroTelefone = enviaZap.DDD + enviaZap.NumeroTelefone;
                    }
                }
                else if (enviaZap.NumeroTelefone.Length == 9)
                {
                    if (enviaZap.DDD.Substring(0, 1) == "1" || enviaZap.DDD.Substring(0, 1) == "2")
                    {
                        enviaZap.NumeroTelefone = enviaZap.DDD + enviaZap.NumeroTelefone;
                    }
                    else
                    {
                        enviaZap.NumeroTelefone = enviaZap.DDD + enviaZap.NumeroTelefone.Substring(1);
                    }
                }
                else
                {
                    throw new Exception("Não é permitido definir um número de telefone maior que 9 digitos.");
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        /// <summary>
        /// Verifique se existem elementos obrigatórios que estão nulos ou vazios.
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        private void ValidarClasse(EnviaZapDTO enviaZap, string token)
        {
            try
            {
                if (enviaZap.IntervaloDisparo == 0)
                    enviaZap.IntervaloDisparo = 5;

                if (null == token || "" == token)
                    throw new Exception("O token é obrigatório para o funcionamento da integração.");

                if (null == enviaZap.DDD || null == enviaZap.DDI || null == enviaZap.NumeroTelefone || null == enviaZap.Mensagem)
                    throw new ArgumentException("Classe não permite que nenhuma propriedade esteja nula.");

                if ("" == enviaZap.DDD || "" == enviaZap.DDI || "" == enviaZap.NumeroTelefone || "" == enviaZap.Mensagem )
                    throw new ArgumentException("Classe não permite que nenhuma propriedade esteja em branco.");
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}