namespace SS.Tecnologia.Exact.Interface
{
    public interface IConexao
    {
        string InsertLead(string output);

        string UpdateLead(string output);

        string ListLeads();

        string GetLead(string id);

        string AtualizaTimeline(string id);
    }
}
