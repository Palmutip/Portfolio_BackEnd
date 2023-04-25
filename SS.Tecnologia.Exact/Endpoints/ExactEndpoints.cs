namespace SS.Tecnologia.Exact.Endpoints
{
    public static class ExactEndpoints
    {
        public static async Task<HttpResponseMessage> RetornoAgendadosExact(HttpClient client, string stage)
        {
            HttpResponseMessage dados = await client.GetAsync("http://api.exactspotter.com/v3/Leads?$filter=contains(stage,'" + stage + "')");
            return dados;
        }

        public static async Task<HttpResponseMessage> RetornoDataAgendadaExact(HttpClient client, string exactID)
        {
            HttpResponseMessage dados = await client.GetAsync("http://api.exactspotter.com/v3/Meetings?$filter=contains(type,'Vigente')+and+lead/id+eq+" + exactID);
            return dados;
        }

        public static async Task<HttpResponseMessage> RetornoVerticalLead(HttpClient client, string exactID)
        {
            HttpResponseMessage dados = await client.GetAsync("http://api.exactspotter.com/v3/LeadsCustomFields?$filter=leadId+eq+" + exactID + "+and+id+eq+'_verticaldaoportunidade'");
            return dados;
        }

        public static async Task<HttpResponseMessage> RetornoContatosLead(HttpClient client, string exactID)
        {
            HttpResponseMessage dados = await client.GetAsync("http://api.exactspotter.com/v3/Persons?$filter=leadId+eq+" + exactID);
            return dados;
        }

        public static async Task<HttpResponseMessage> RetornoRamoAtividadeLead(HttpClient client, string exactID)
        {
            HttpResponseMessage dados = await client.GetAsync("http://api.exactspotter.com/v3/LeadsCustomFields?$filter=leadId+eq+" + exactID + "+and+id+eq+'_ramodeatividade1'");
            return dados;
        }

        public static async Task<HttpResponseMessage> RetornoFaixaFaturamentoLead(HttpClient client, string exactID)
        {
            HttpResponseMessage dados = await client.GetAsync("http://api.exactspotter.com/v3/LeadsCustomFields?$filter=leadId+eq+" + exactID + "+and+id+eq+'_faixadefaturamento'");
            return dados;
        }

        public static async Task<HttpResponseMessage> RetornoFaixaFuncionariosLead(HttpClient client, string exactID)
        {
            HttpResponseMessage dados = await client.GetAsync("http://api.exactspotter.com/v3/LeadsCustomFields?$filter=leadId+eq+" + exactID + "+and+id+eq+'_faixadefuncionarios'");
            return dados;
        }

        public static async Task<HttpResponseMessage> RetornoPorteLead(HttpClient client, string exactID)
        {
            HttpResponseMessage dados = await client.GetAsync("http://api.exactspotter.com/v3/LeadsCustomFields?$filter=leadId+eq+" + exactID + "+and+id+eq+'_portedaempresa'");
            return dados;
        }

        public static async Task<HttpResponseMessage> RetornoSegmentoLead(HttpClient client, string exactID)
        {
            HttpResponseMessage dados = await client.GetAsync("http://api.exactspotter.com/v3/LeadsCustomFields?$filter=leadId+eq+" + exactID + "+and+id+eq+'_segmento'");
            return dados;
        }

        public static async Task<HttpResponseMessage> RetornoSubsegmentoLead(HttpClient client, string exactID)
        {
            HttpResponseMessage dados = await client.GetAsync("http://api.exactspotter.com/v3/LeadsCustomFields?$filter=leadId+eq+" + exactID + "+and+id+eq+'_subsegmento'");
            return dados;
        }
    }
}
