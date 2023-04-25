using Newtonsoft.Json;
using SS.Tecnologia.Exact.Interface;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace SS.Tecnologia.Exact.Services
{
    public class Conexao : IConexao
    {
        private string token = string.Empty;
        private static string _URL_lead = "https://api.exactsales.com.br/v2/leads";
        private static string _URL_edit_lead = "https://api.exactsales.com.br/v2/editarlead";
        private static string _URL_list_lead = "https://api.exactsales.com.br/v2/listarlead";
        private static string _URL_timeline_lead = "https://api.exactsales.com.br/v3/Timelines";

        public Conexao()
        {

        }

        public string InsertLead(string output)
        {
            try
            {
                if (token.Equals(string.Empty))
                {
                    Dictionary<string, object> dic = new Dictionary<string, object>
                    {
                        { "code", 400 },
                        { "status", "error" },
                        { "message", "Token não encontrado" }
                    };

                    return JsonConvert.SerializeObject(dic);
                }

                using (var client = new HttpClient())
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                    client.DefaultRequestHeaders.Accept.Clear();

                    var content = new StringContent(output, Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Add("token_exact", token);

                    var result = client.PostAsync(_URL_lead, content).Result;
                    string resultContent = result.Content.ReadAsStringAsync().Result;

                    Dictionary<string, object> dic = new Dictionary<string, object>
                    {
                        { "code", 200 },
                        { "status", "success" },
                        { "message", "Lead inserido com sucesso!" },
                        { "data", resultContent }
                    };

                    return JsonConvert.SerializeObject(dic);
                }
            }
            catch (Exception e)
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendLine(e.Message);
                builder.AppendLine(e.StackTrace);

                Dictionary<string, object> dic = new Dictionary<string, object>
                {
                    { "code", 400 },
                    { "status", "error" },
                    { "message", builder.ToString() }
                };

                return JsonConvert.SerializeObject(dic);
            }
        }

        public string UpdateLead(string output)
        {
            try
            {
                if (token.Equals(string.Empty))
                {
                    Dictionary<string, object> dic = new Dictionary<string, object>
                    {
                        { "code", 400 },
                        { "status", "error" },
                        { "message", "Token não encontrado" }
                    };

                    return JsonConvert.SerializeObject(dic);
                }

                using (var client = new HttpClient())
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                    client.DefaultRequestHeaders.Accept.Clear();

                    var content = new StringContent(output, Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Add("token_exact", token);
                    var req = new HttpRequestMessage(HttpMethod.Put, _URL_edit_lead)
                    {
                        Content = content
                    };
                    var result = client.SendAsync(req).Result;
                    string resultContent = result.Content.ReadAsStringAsync().Result;

                    Dictionary<string, object> dic = new Dictionary<string, object>
                    {
                        { "code", 200 },
                        { "status", "success" },
                        { "message", "Lead alterado com sucesso!" },
                        { "data", resultContent }
                    };

                    return JsonConvert.SerializeObject(dic);
                }
            }
            catch (Exception e)
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendLine(e.Message);
                builder.AppendLine(e.StackTrace);

                Dictionary<string, object> dic = new Dictionary<string, object>
                {
                    { "code", 400 },
                    { "status", "error" },
                    { "message", builder.ToString() }
                };

                return JsonConvert.SerializeObject(dic);
            }

        }

        public string ListLeads()
        {
            try
            {
                if (token.Equals(string.Empty))
                {
                    Dictionary<string, object> dic = new Dictionary<string, object>
                    {
                        { "code", 400 },
                        { "status", "error" },
                        { "message", "Token não encontrado" }
                    };

                    return JsonConvert.SerializeObject(dic);
                }
                using (var client = new HttpClient())
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                    client.DefaultRequestHeaders.Accept.Clear();

                    client.DefaultRequestHeaders.Add("token_exact", token);

                    HttpResponseMessage dados = client.GetAsync(_URL_list_lead + "?max_results=10000").Result;
                    dados.Content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                    //se retornar com sucesso busca os dados
                    if (dados.IsSuccessStatusCode)
                    {
                        //Pegando os dados do resultado e armazenando 
                        string resultContent = dados.Content.ReadAsStringAsync().Result;

                        Dictionary<string, object> dic = new Dictionary<string, object>
                        {
                            { "code", 200 },
                            { "status", "success" },
                            { "message", "Lista de leads recuperados com sucesso!" },
                            { "data", resultContent }
                        };

                        return JsonConvert.SerializeObject(dic);
                    }

                    Dictionary<string, object> dic2 = new Dictionary<string, object>
                    {
                        { "code", 400 },
                        { "status", "error" },
                        { "message", "Erro ao realizar a requisição HTTP" }
                    };

                    return JsonConvert.SerializeObject(dic2);
                }
            }
            catch (Exception e)
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendLine(e.Message);
                builder.AppendLine(e.StackTrace);

                Dictionary<string, object> dic = new Dictionary<string, object>
                {
                    { "code", 400 },
                    { "status", "error" },
                    { "message", builder.ToString() }
                };

                return JsonConvert.SerializeObject(dic);
            }

        }

        public string GetLead(string id)
        {
            try
            {
                if (token.Equals(string.Empty))
                {
                    Dictionary<string, object> dic = new Dictionary<string, object>
                    {
                        { "code", 400 },
                        { "status", "error" },
                        { "message", "Token não encontrado" }
                    };

                    return JsonConvert.SerializeObject(dic);
                }

                using (var client = new HttpClient())
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                    client.DefaultRequestHeaders.Accept.Clear();

                    client.DefaultRequestHeaders.Add("token_exact", token);

                    HttpResponseMessage dados = client.GetAsync(_URL_lead + "/" + id).Result;
                    dados.Content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                    //se retornar com sucesso busca os dados
                    if (dados.IsSuccessStatusCode)
                    {
                        //Pegando os dados do resultado e armazenando 
                        string resultContent = dados.Content.ReadAsStringAsync().Result;

                        Dictionary<string, object> dic = new Dictionary<string, object>
                        {
                            { "code", 200 },
                            { "status", "success" },
                            { "message", "Lead recuperado com sucesso!" },
                            { "data", resultContent }
                        };

                        return JsonConvert.SerializeObject(dic);
                    }

                    Dictionary<string, object> dic2 = new Dictionary<string, object>
                    {
                        { "code", 400 },
                        { "status", "error" },
                        { "message", "Erro ao realizar a requisição HTTP" }
                    };

                    return JsonConvert.SerializeObject(dic2);
                }
            }
            catch (Exception e)
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendLine(e.Message);
                builder.AppendLine(e.StackTrace);

                Dictionary<string, object> dic = new Dictionary<string, object>
                {
                    { "code", 400 },
                    { "status", "error" },
                    { "message", builder.ToString() }
                };

                return JsonConvert.SerializeObject(dic);

            }

        }

        public string AtualizaTimeline(string id)
        {
            try
            {
                if (token.Equals(string.Empty))
                {
                    Dictionary<string, object> dic = new Dictionary<string, object>
                    {
                        { "code", 400 },
                        { "status", "error" },
                        { "message", "Token não encontrado" }
                    };

                    return JsonConvert.SerializeObject(dic);
                }

                using (var client = new HttpClient())
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                    client.DefaultRequestHeaders.Accept.Clear();

                    client.DefaultRequestHeaders.Add("token_exact", token);

                    HttpResponseMessage dados = client.GetAsync(_URL_timeline_lead + "/" + id).Result;
                    dados.Content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                    //se retornar com sucesso busca os dados
                    if (dados.IsSuccessStatusCode)
                    {
                        //Pegando os dados do resultado e armazenando 
                        string resultContent = dados.Content.ReadAsStringAsync().Result;

                        Dictionary<string, object> dic = new Dictionary<string, object>
                        {
                            { "code", 200 },
                            { "status", "success" },
                            { "message", "Timeline recuperada com sucesso!" },
                            { "data", resultContent }
                        };

                        return JsonConvert.SerializeObject(dic);
                    }

                    Dictionary<string, object> dic2 = new Dictionary<string, object>
                    {
                        { "code", 400 },
                        { "status", "error" },
                        { "message", "Erro ao realizar a requisição HTTP" }
                    };

                    return JsonConvert.SerializeObject(dic2);
                }
            }
            catch (Exception e)
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendLine(e.Message);
                builder.AppendLine(e.StackTrace);

                Dictionary<string, object> dic = new Dictionary<string, object>
                {
                    { "code", 400 },
                    { "status", "error" },
                    { "message", builder.ToString() }
                };

                return JsonConvert.SerializeObject(dic);

            }

        }
    }
}
