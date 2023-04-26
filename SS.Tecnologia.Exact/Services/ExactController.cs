using Newtonsoft.Json;
using SS.Tecnologia.Exact.Endpoints;
using SS.Tecnologia.Exact.Interface;
using SS.Tecnologia.Exact.Model;
using System.Net;

namespace SS.Tecnologia.Exact.Services
{
    public class ExactController : IExactController
    {
        string token_exact = "";

        public ExactController()
        {

        }

        public ExactController(string token)
        {
            token_exact = token;
        }

        public async Task<List<ExactLeads>> GetAllLeads()
        {
            List<ExactLeads> listaLeads = new List<ExactLeads>();

            try
            {
                HttpClient client = new HttpClient();
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                client.DefaultRequestHeaders.Add("token_exact", token_exact);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("*/*"));
                HttpResponseMessage dados = await client.GetAsync("http://api.exactspotter.com/v3/Leads");

                if (dados.IsSuccessStatusCode)
                {
                    ExactLeads retorno = JsonConvert.DeserializeObject<ExactLeads>(dados.Content.ReadAsStringAsync().Result);

                    listaLeads.Add(retorno);

                    string proximoLink = retorno.OdataNextLink;

                    while (null != proximoLink)
                    {
                        HttpResponseMessage dadosAdicionais = await client.GetAsync(proximoLink);

                        ExactLeads retornoAdicional = JsonConvert.DeserializeObject<ExactLeads>(dadosAdicionais.Content.ReadAsStringAsync().Result);

                        if (retornoAdicional.value.Count == 0 || retornoAdicional.value == null)
                            break;

                        listaLeads.Add(retornoAdicional);

                        proximoLink = retornoAdicional.OdataNextLink;
                    }

                    return listaLeads;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Não foi possivel realizar a integração com a Exact Sales. " + ex.Message + ex.StackTrace, ex);
            }
            catch (Exception e)
            {
                throw new Exception("Não foi possivel realizar a integração com a Exact Sales. " + e.Message + e.StackTrace, e);
            }
            return listaLeads;
        }

        public async Task<List<ExactLeads>> GetLeadsAgendados(string stage)
        {
            List<ExactLeads> listaLeads = new List<ExactLeads>();

            try
            {
                HttpClient client = new HttpClient();
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                client.DefaultRequestHeaders.Add("token_exact", token_exact);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("*/*"));
                HttpResponseMessage dados = await ExactEndpoints.RetornoAgendadosExact(client, stage);

                if (dados.IsSuccessStatusCode)
                {
                    ExactLeads retorno = JsonConvert.DeserializeObject<ExactLeads>(dados.Content.ReadAsStringAsync().Result);

                    listaLeads.Add(retorno);

                    string proximoLink = retorno.OdataNextLink;

                    while (null != proximoLink)
                    {
                        HttpResponseMessage dadosAdicionais = await client.GetAsync(proximoLink);

                        ExactLeads retornoAdicional = JsonConvert.DeserializeObject<ExactLeads>(dadosAdicionais.Content.ReadAsStringAsync().Result);

                        if (retornoAdicional.value.Count == 0 || retornoAdicional.value == null)
                            break;

                        listaLeads.Add(retornoAdicional);

                        proximoLink = retornoAdicional.OdataNextLink;
                    }

                    return listaLeads;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Não foi possivel realizar a integração com a Exact Sales. " + ex.Message + ex.StackTrace, ex);
            }
            catch (Exception e)
            {
                throw new Exception("Não foi possivel realizar a integração com a Exact Sales. " + e.Message + e.StackTrace, e);
            }
            return listaLeads;
        }

        public async Task<DateTime?> GetDataAgendamento(string exactID)
        {
            ExactMeetings Agendamentos = new ExactMeetings();

            try
            {
                HttpClient client = new HttpClient();
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                client.DefaultRequestHeaders.Add("token_exact", token_exact);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("*/*"));
                HttpResponseMessage dados = await ExactEndpoints.RetornoDataAgendadaExact(client, exactID);

                if (dados.IsSuccessStatusCode)
                {
                    ExactMeetings retorno = JsonConvert.DeserializeObject<ExactMeetings>(dados.Content.ReadAsStringAsync().Result);

                    Agendamentos = retorno;

                    return Agendamentos.value.FirstOrDefault().startTime;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Não foi possivel realizar a integração com a Exact Sales. " + ex.Message + ex.StackTrace, ex);
            }
            catch (Exception e)
            {
                throw new Exception("Não foi possivel realizar a integração com a Exact Sales. " + e.Message + e.StackTrace, e);
            }
            return null;
        }

        public async Task<string> GetVerticalLead(string exactLead, string exactID)
        {
            ExactCustomFields retornoAPI = new ExactCustomFields();

            try
            {
                HttpClient client = new HttpClient();
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                client.DefaultRequestHeaders.Add("token_exact", token_exact);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("*/*"));

                //Consome de fato a API através do link fornecido
                HttpResponseMessage dados = await ExactEndpoints.RetornoVerticalLead(client, exactID);

                if (dados.IsSuccessStatusCode)
                {
                    ExactCustomFields retorno = JsonConvert.DeserializeObject<ExactCustomFields>(dados.Content.ReadAsStringAsync().Result);
                    retornoAPI = retorno;

                    return null == retornoAPI.value.FirstOrDefault().options.FirstOrDefault() ? null : retornoAPI.value.FirstOrDefault().options.FirstOrDefault();
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("• " + exactLead + " Não possui produto cadastrado. Verifique o cadastro do Lead na Exact Sales.<br>", ex);
            }
            catch (Exception e)
            {
                throw new Exception("• " + exactLead + " Não possui produto cadastrado. Verifique o cadastro do Lead na Exact Sales.<br>", e);
            }
            return null;
        }

        public async Task<List<ExactPersons>> GetContatosLeads(string exactID)
        {
            List<ExactPersons> listaLeads = new List<ExactPersons>();

            try
            {
                HttpClient client = new HttpClient();
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                client.DefaultRequestHeaders.Add("token_exact", token_exact);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("*/*"));
                HttpResponseMessage dados = await ExactEndpoints.RetornoContatosLead(client, exactID);

                if (dados.IsSuccessStatusCode)
                {
                    ExactPersons retorno = JsonConvert.DeserializeObject<ExactPersons>(dados.Content.ReadAsStringAsync().Result);
                    listaLeads.Add(retorno);

                    string proximoLink = retorno.OdataNextLink;

                    while (null != proximoLink)
                    {
                        HttpResponseMessage dadosAdicionais = await client.GetAsync(proximoLink);

                        ExactPersons retornoAdicional = JsonConvert.DeserializeObject<ExactPersons>(dadosAdicionais.Content.ReadAsStringAsync().Result);

                        if (retornoAdicional.value.Count == 0 || retornoAdicional.value == null)
                            break;

                        listaLeads.Add(retornoAdicional);

                        proximoLink = retornoAdicional.OdataNextLink;
                    }

                    return listaLeads;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Não foi possivel realizar a integração com a Exact Sales. " + ex.Message + ex.StackTrace, ex);
            }
            catch (Exception e)
            {
                throw new Exception("Não foi possivel realizar a integração com a Exact Sales. " + e.Message + e.StackTrace, e);
            }
            return listaLeads;
        }

        public async Task<string> GetRamoAtividadeLead(string exactLead, string exactID)
        {
            ExactCustomFields retornoAPI = new ExactCustomFields();

            try
            {
                HttpClient client = new HttpClient();
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                client.DefaultRequestHeaders.Add("token_exact", token_exact);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("*/*"));

                //Consome de fato a API através do link fornecido
                HttpResponseMessage dados = await ExactEndpoints.RetornoRamoAtividadeLead(client, exactID);

                if (dados.IsSuccessStatusCode)
                {
                    ExactCustomFields retorno = JsonConvert.DeserializeObject<ExactCustomFields>(dados.Content.ReadAsStringAsync().Result);

                    retornoAPI = retorno;

                    return null == retornoAPI.value.FirstOrDefault().options.FirstOrDefault() ? null : retornoAPI.value.FirstOrDefault().options.FirstOrDefault();
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("• " + exactLead + " Não possui produto cadastrado. Verifique o cadastro do Lead na Exact Sales.<br>", ex);
            }
            catch (Exception e)
            {
                throw new Exception("• " + exactLead + " Não possui produto cadastrado. Verifique o cadastro do Lead na Exact Sales.<br>", e);
            }
            return null;
        }

        public async Task<string> GetFaixaFaturamentoLead(string exactLead, string exactID)
        {
            ExactCustomFields retornoAPI = new ExactCustomFields();

            try
            {
                HttpClient client = new HttpClient();
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                client.DefaultRequestHeaders.Add("token_exact", token_exact);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("*/*"));

                //Consome de fato a API através do link fornecido
                HttpResponseMessage dados = await ExactEndpoints.RetornoFaixaFaturamentoLead(client, exactID);

                if (dados.IsSuccessStatusCode)
                {
                    ExactCustomFields retorno = JsonConvert.DeserializeObject<ExactCustomFields>(dados.Content.ReadAsStringAsync().Result);
                    //Thread.Sleep(4000);
                    retornoAPI = retorno;

                    return null == retornoAPI.value.FirstOrDefault().options.FirstOrDefault() ? null : retornoAPI.value.FirstOrDefault().options.FirstOrDefault();
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("• " + exactLead + " Não possui produto cadastrado. Verifique o cadastro do Lead na Exact Sales.<br>", ex);
            }
            catch (Exception e)
            {
                throw new Exception("• " + exactLead + " Não possui produto cadastrado. Verifique o cadastro do Lead na Exact Sales.<br>", e);
            }
            return null;
        }

        public async Task<string> GetFaixaFuncionarioLead(string exactLead, string exactID)
        {
            ExactCustomFields retornoAPI = new ExactCustomFields();

            try
            {
                HttpClient client = new HttpClient();
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                client.DefaultRequestHeaders.Add("token_exact", token_exact);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("*/*"));

                //Consome de fato a API através do link fornecido
                HttpResponseMessage dados = await ExactEndpoints.RetornoFaixaFuncionariosLead(client, exactID);

                if (dados.IsSuccessStatusCode)
                {
                    ExactCustomFields retorno = JsonConvert.DeserializeObject<ExactCustomFields>(dados.Content.ReadAsStringAsync().Result);

                    retornoAPI = retorno;

                    return null == retornoAPI.value.FirstOrDefault().options.FirstOrDefault() ? null : retornoAPI.value.FirstOrDefault().options.FirstOrDefault();
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("• " + exactLead + " Não possui produto cadastrado. Verifique o cadastro do Lead na Exact Sales.<br>", ex);
            }
            catch (Exception e)
            {
                throw new Exception("• " + exactLead + " Não possui produto cadastrado. Verifique o cadastro do Lead na Exact Sales.<br>", e);
            }
            return null;
        }

        public async Task<string> GetPorteLead(string exactLead, string exactID)
        {
            ExactCustomFields retornoAPI = new ExactCustomFields();

            try
            {
                HttpClient client = new HttpClient();
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                client.DefaultRequestHeaders.Add("token_exact", token_exact);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("*/*"));

                //Consome de fato a API através do link fornecido
                HttpResponseMessage dados = await ExactEndpoints.RetornoPorteLead(client, exactID);

                if (dados.IsSuccessStatusCode)
                {
                    ExactCustomFields retorno = JsonConvert.DeserializeObject<ExactCustomFields>(dados.Content.ReadAsStringAsync().Result);

                    retornoAPI = retorno;

                    return null == retornoAPI.value.FirstOrDefault().options.FirstOrDefault() ? null : retornoAPI.value.FirstOrDefault().options.FirstOrDefault();
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("• " + exactLead + " Não possui produto cadastrado. Verifique o cadastro do Lead na Exact Sales.<br>", ex);
            }
            catch (Exception e)
            {
                throw new Exception("• " + exactLead + " Não possui produto cadastrado. Verifique o cadastro do Lead na Exact Sales.<br>", e);
            }
            return null;
        }

        public async Task<string> GetSegmentoLead(string exactLead, string exactID)
        {
            ExactCustomFields retornoAPI = new ExactCustomFields();

            try
            {
                HttpClient client = new HttpClient();
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                client.DefaultRequestHeaders.Add("token_exact", token_exact);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("*/*"));

                //Consome de fato a API através do link fornecido
                HttpResponseMessage dados = await ExactEndpoints.RetornoSegmentoLead(client, exactID);

                if (dados.IsSuccessStatusCode)
                {
                    ExactCustomFields retorno = JsonConvert.DeserializeObject<ExactCustomFields>(dados.Content.ReadAsStringAsync().Result);

                    retornoAPI = retorno;

                    return null == retornoAPI.value.FirstOrDefault().options.FirstOrDefault() ? null : retornoAPI.value.FirstOrDefault().options.FirstOrDefault();
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("• " + exactLead + " Não possui produto cadastrado. Verifique o cadastro do Lead na Exact Sales.<br>", ex);
            }
            catch (Exception e)
            {
                throw new Exception("• " + exactLead + " Não possui produto cadastrado. Verifique o cadastro do Lead na Exact Sales.<br>", e);
            }
            return null;
        }

        public async Task<string> GetSubsegmentoLead(string exactLead, string exactID)
        {
            ExactCustomFields retornoAPI = new ExactCustomFields();

            try
            {
                HttpClient client = new HttpClient();
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                client.DefaultRequestHeaders.Add("token_exact", token_exact);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("*/*"));

                //Consome de fato a API através do link fornecido
                HttpResponseMessage dados = await ExactEndpoints.RetornoSubsegmentoLead(client, exactID);

                if (dados.IsSuccessStatusCode)
                {
                    ExactCustomFields retorno = JsonConvert.DeserializeObject<ExactCustomFields>(dados.Content.ReadAsStringAsync().Result);

                    retornoAPI = retorno;

                    return null == retornoAPI.value.FirstOrDefault().options.FirstOrDefault() ? null : retornoAPI.value.FirstOrDefault().options.FirstOrDefault();
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("• " + exactLead + " Não possui produto cadastrado. Verifique o cadastro do Lead na Exact Sales.<br>", ex);
            }
            catch (Exception e)
            {
                throw new Exception("• " + exactLead + " Não possui produto cadastrado. Verifique o cadastro do Lead na Exact Sales.<br>", e);
            }
            return null;
        }
    }
}
