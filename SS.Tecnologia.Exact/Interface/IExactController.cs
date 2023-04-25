using SS.Tecnologia.Exact.Model;

namespace SS.Tecnologia.Exact.Interface
{
    public interface IExactController
    {
        Task<List<ExactLeads>> GetLeadsAgendados(string stage);
    }
}
