using SS.Tecnologia.HCIEnviaZAP.Models;

namespace SS.Tecnologia.HCIEnviaZAP.Interfaces
{
    public interface IEnviaZap
    {
        string EnviarMensagem(EnviaZapDTO enviaZap);
        Task<string> EnviarMensagemAsync(EnviaZapDTO enviaZap);
    }
}