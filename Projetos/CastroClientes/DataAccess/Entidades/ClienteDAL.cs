using CadastroClientes.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    /// <summary>
    /// Realiza as operações, no Banco de Dados, na tabela Clientes, com Entity Framework
    /// </summary>
    public class ClienteDAL : ICrud<ClienteDTO>
    {
        private DevleanTestEntities objCliente;

        public ClienteDAL()
        {
            objCliente = new DevleanTestEntities();
        }

        public Retorno Atualizar(ClienteDTO entidade)
        {
            var retorno = new Retorno();

            var _cliente = objCliente.Clientes.Find(entidade.ID);

            if (_cliente != null)
            {
                _cliente.Nome = entidade.Nome;
                _cliente.Tipo = (byte)(TipoOpcoes)entidade.Tipo;
                _cliente.Data_Nascimento = entidade.Data_Nascimento;
                _cliente.Data_Cadastro = entidade.Data_Cadastro;

                int qtdRetorno = objCliente.SaveChanges();

                if (qtdRetorno > 0)
                {
                    retorno.Mensagem = "Cliente atualizado com sucesso!";
                    retorno.RegistroID = qtdRetorno;
                }
                else
                {
                    retorno.Mensagem = "Houve um problema ao atualizar o cliente.";
                    retorno.RegistroID = qtdRetorno;
                }
            }
            else
            {
                retorno.Mensagem = "Cliente não encontrado.";
                retorno.RegistroID = 0;
            }

            return retorno;
        }

        public List<ClienteDTO> Buscar()
        {
            var clientes = new List<ClienteDTO>();

            foreach (var cliente in objCliente.Clientes.ToList())
            {
                clientes.Add(new ClienteDTO()
                {
                    ID = cliente.ID,
                    Nome = cliente.Nome,
                    Tipo = (TipoOpcoes)(byte)cliente.Tipo/* == 0 ? new TipoOpcoes() { Nome = "CNPJ", Valor = 0} : new TipoOpcoes() { Nome = "CPF", Valor = 1 }*/,
                    Data_Nascimento = cliente.Data_Nascimento,
                    Data_Cadastro = cliente.Data_Cadastro
                });
            }

            return clientes;
        }

        public ClienteDTO Buscar(int ID)
        {
            var _cliente = objCliente.Clientes.Find(ID);

            if (_cliente != null)
            {
                return new ClienteDTO()
                {
                    ID = _cliente.ID,
                    Nome = _cliente.Nome,
                    Tipo = (TipoOpcoes)(byte)_cliente.Tipo/* == 0 ? new TipoOpcoes() { Nome = "CNPJ", Valor = 0 } : new TipoOpcoes() { Nome = "CPF", Valor = 1 }*/,
                    Data_Nascimento = _cliente.Data_Nascimento,
                    Data_Cadastro = _cliente.Data_Cadastro
                };
            }

            return null;
        }

        public Retorno Deletar(ClienteDTO entidade)
        {
            var retorno = new Retorno();

            var _cliente = objCliente.Clientes.Find(entidade.ID);

            if (_cliente != null)
            {
                objCliente.Clientes.Remove(_cliente);

                int qtdRetorno = objCliente.SaveChanges();

                if (qtdRetorno > 0)
                {
                    retorno.Mensagem = "Cliente deletado com sucesso!";
                    retorno.RegistroID = qtdRetorno;
                }
                else
                {
                    retorno.Mensagem = "Houve um problema ao deletar o cliente.";
                    retorno.RegistroID = qtdRetorno;
                }
            }
            else
            {
                retorno.Mensagem = "Cliente não encontrado.";
                retorno.RegistroID = 0;
            }

            return retorno;
        }

        public Retorno Inserir(ClienteDTO entidade)
        {
            var retorno = new Retorno();
            var _cliente = new Cliente()
            {
                Nome = entidade.Nome,
                Tipo = ((byte)entidade.Tipo),
                Data_Nascimento = entidade.Data_Nascimento,
                Data_Cadastro = DateTime.Now
            };

            objCliente.Clientes.Add(_cliente);
            int qtdRetorno = objCliente.SaveChanges();

            if (qtdRetorno > 0)
            {
                retorno.Mensagem = "Cliente adicionado com sucesso!";
                retorno.RegistroID = qtdRetorno;
            }
            else
            {
                retorno.Mensagem = "Houve um problema ao incluir o cliente.";
                retorno.RegistroID = qtdRetorno;
            }

            return retorno;
        }
    }
}
