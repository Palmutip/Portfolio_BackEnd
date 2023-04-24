using SS.Tecnologia.HCIEnviaZAP.Models;

namespace SS.Tecnologia.HCIEnviaZAP.Interfaces
{
    public interface IEnviaZap
    {
        string EnviarMensagem(EnviaZapDTO enviaZap, string token);
        Task<string> EnviarMensagemAsync(EnviaZapDTO enviaZap, string token);
    }
}