using SS.Tecnologia.RDStation.Model;

namespace SS.Tecnologia.RDStation.Interfaces
{
    /// <summary>
    /// Interface de acesso ao serviço para integrar com a RD Station
    /// </summary>
    public interface IRDStation
    {
        /// <summary>
        /// Responsavel por enviar o contato para a plataforma RD Station de forma Sícrona
        /// </summary>
        /// <param name="credenciais">Credencias do cliente fornecidas pela RD Station em sua plataforma</param>
        /// <param name="dadosContato">Classe referente aos dados que se dejesa enviar para a RD Station</param>
        /// <returns>retorna o token de acesso referente às credenciais fornecidas</returns>
        /// <exception cref="ArgumentException">Armazena o log e joga a excessão caso tenha algum erro</exception>
        string Integrar(ClientCredential credenciais, ContatosBenner dadosContato);

        /// <summary>
        /// Responsavel por enviar o contato para a plataforma RD Station de forma Assícrona
        /// </summary>
        /// <param name="credenciais">Credencias do cliente fornecidas pela RD Station em sua plataforma</param>
        /// <param name="dadosContato">Classe referente aos dados que se dejesa enviar para a RD Station</param>
        /// <returns>retorna o token de acesso referente às credenciais fornecidas</returns>
        /// <exception cref="ArgumentException">Armazena o log e joga a excessão caso tenha algum erro</exception>
        Task<string> IntegrarAsync(ClientCredential credenciais, ContatosBenner dadosContato);
    }
}