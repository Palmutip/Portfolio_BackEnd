using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace SS.Tecnologia.HCIEnviaZAP
{
    public class EnviaZap
    {
        private static HttpClient client = new();

        private int intervaloDisparo;
        private string Ddi;
        private string Ddd;
        private string numeroTelefone;
        private string mensagem;
        private string token;

        /// <summary>
        /// Numero inteiro que representa o intervalo em segundos entre o disparo entre mais de uma mensagem
        /// </summary>
        public int IntervaloDisparo 
        {
            get
            {
                return intervaloDisparo;
            }
            set
            {
                if(value > 30)
                {
                    throw new Exception("Não é possivel definir um intervalo de disparo superior a 30 segundos");
                }
                else if (value < 0)
                {
                    throw new Exception("Não é possivel definir um intervalo de disparo inferior a zero.");
                }
                else if (value == 0 || (value > 0 && value <= 30) )
                {
                    value = 5;
                    this.intervaloDisparo = value;
                }
            }
        }

        /// <summary>
        /// Código do País Brasil (+55)
        /// </summary>
        public string DDI 
        {
            get
            {
                return Ddi;
            }
            set
            {
                this.Ddi = value; 
            }
        }

        /// <summary>
        /// Código de área da região (11,21,35, etc)
        /// </summary>
        public string DDD
        {
            get
            {
                return Ddd;
            }
            set
            {
                this.Ddd = value;
            }
        }

        /// <summary>
        /// Numero de telefone que está associado ao aplicativo WhatsApp
        /// </summary>
        public string NumeroTelefone 
        {
            get
            {
                return numeroTelefone;
            }
            set
            {
                this.numeroTelefone = value;
            }
        }

        /// <summary>
        /// Mensagem a ser enviada para o numero de telefone que foi definido
        /// </summary>
        public string Mensagem
        {
            get
            {
                return mensagem;
            }
            set
            {
                this.mensagem = value;
            }
        }

        /// <summary>
        /// Token de autorização da plataforma HCI - EnviaZAP
        /// </summary>
        public string Token
        {
            get
            {
                return token;
            }
            set
            {
                this.token = value;
            }
        }

        /// <summary>
        /// Método para enviar a mensagem utilizando a API da HCI - EnviaZAP
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        public string EnviarMensagem()
        {
            try
            {
                //Valida se o numero possui 9 ou 8 digitos e já incrementa o DDD
                ValidarNumero();

                //Definição de protocolo de segurança
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                //Corpo da requisição à API
                string conteudo = 
                    "{ \"ddi\": \"" + Ddi + "\", " +
                    "\"phoneDest\": \"" + numeroTelefone + "\", " +
                    "\"message\": \"" + mensagem + "\", " +
                    "\"webhookUrl\": \"\" }";

                //Formatando a requisição com o formato JSON
                var data = new StringContent(conteudo, Encoding.UTF8, "application/json");

                //Realizando o método POST na API e já coletando o resultado para chamada permanecer sícrona
                HttpResponseMessage dados = client.PostAsync("https://api.hcisistemas.com.br/sendMessage?token=" + token, data).Result;

                //Intervalo em segundos para ler o conteúdo e para enviar a proxima mensagem caso este método esteja dentro de um laço de repetição
                Thread.Sleep(intervaloDisparo * 1000);

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
            catch (Exception ex)
            {
                throw new Exception(JsonConvert.SerializeObject(new { status = "Erro", code = HttpStatusCode.InternalServerError, message = ex.Message }));
            }
        }

        /// <summary>
        /// Método para enviar a mensagem utilizando a API da HCI - EnviaZAP
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<string> EnviarMensagemAsync()
        {
            try
            {
                //Valida se o numero possui 9 ou 8 digitos e já incrementa o DDD
                ValidarNumero();

                //Definição de protocolo de segurança
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                //Corpo da requisição à API
                string conteudo =
                    "{ \"ddi\": \"" + Ddi + "\", " +
                    "\"phoneDest\": \"" + numeroTelefone + "\", " +
                    "\"message\": \"" + mensagem + "\", " +
                    "\"webhookUrl\": \"\" }";

                //Formatando a requisição com o formato JSON
                var data = new StringContent(conteudo, Encoding.UTF8, "application/json");

                //Realizando o método POST na API e já coletando o resultado para chamada permanecer sícrona
                HttpResponseMessage dados = await client.PostAsync("https://api.hcisistemas.com.br/sendMessage?token=" + token, data);

                //Intervalo em segundos para ler o conteúdo e para enviar a proxima mensagem caso este método esteja dentro de um laço de repetição
                Thread.Sleep(intervaloDisparo * 1000);

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
            catch (Exception ex)
            {
                throw new Exception(JsonConvert.SerializeObject(new { status = "Erro", code = HttpStatusCode.InternalServerError, message = ex.Message }));
            }
        }

        /// <summary>
        /// Valida se o numero possui 9 ou 8 digitos e já incrementa o DDD
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        private void ValidarNumero()
        {
            try
            {
                ValidarClasse();

                numeroTelefone = numeroTelefone.Trim(',', '-', '(', ')', ' ');

                if(numeroTelefone.Length == 8)
                {
                    if (Ddd.Substring(0, 1) == "1" || Ddd.Substring(0, 1) == "2")
                    {
                        numeroTelefone = Ddd + "9" + numeroTelefone;
                    }
                    else
                    {
                        numeroTelefone = Ddd + numeroTelefone;
                    }
                }
                else if (numeroTelefone.Length == 9)
                {
                    if (Ddd.Substring(0, 1) == "1" || Ddd.Substring(0, 1) == "2")
                    {
                        numeroTelefone = Ddd + numeroTelefone;
                    }
                    else
                    {
                        numeroTelefone = Ddd + numeroTelefone.Substring(1);
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
        private void ValidarClasse()
        {
            try
            {
                if(intervaloDisparo == 0)
                    intervaloDisparo = 5;

                if (null == Ddd || null == Ddi || null == numeroTelefone || null == mensagem || null == token)
                    throw new ArgumentException("Classe não permite que nenhuma propriedade esteja nula.");

                if ("" == Ddd || "" == Ddi || "" == numeroTelefone || "" == mensagem || "" == token)
                    throw new ArgumentException("Classe não permite que nenhuma propriedade esteja em branco.");
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}