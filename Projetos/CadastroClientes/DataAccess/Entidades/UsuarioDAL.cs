using CadastroClientes.Objetos;
using Comuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    /// <summary>
    /// Realiza as operações, no Banco de Dados, na tabela Usuarios, com Entity Framework
    /// </summary>
    public class UsuarioDAL : ICrud<UsuarioDTO>
    {
        private DevleanTestEntities objUsuario;

        public UsuarioDAL()
        {
            objUsuario = new DevleanTestEntities();
        }

        public Retorno Inserir(UsuarioDTO usuario)
        {
            var retorno = new Retorno();
            var _usuario = new Usuario()
            {
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = Criptografia.Cript(usuario.Senha)
            };

            objUsuario.Usuarios.Add(_usuario);
            int qtdRetorno = objUsuario.SaveChanges();

            if (qtdRetorno > 0)
            {
                retorno.Mensagem = "Usuário adicionado com sucesso!";
                retorno.RegistroID = qtdRetorno;
            }
            else
            {
                retorno.Mensagem = "Houve um problema ao incluir o usuario.";
                retorno.RegistroID = qtdRetorno;
            }

            return retorno;
        }

        public List<UsuarioDTO> Buscar()
        {
            var usuarios = new List<UsuarioDTO>();

            foreach (var usuario in objUsuario.Usuarios.ToList())
            {
                usuarios.Add(new UsuarioDTO()
                {
                    ID = usuario.ID,
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    Senha = usuario.Senha
                });
            }

            return usuarios;
        }
        
        public UsuarioDTO Buscar(int ID)
        {
            var _usuario = objUsuario.Usuarios.Find(ID);

            if (_usuario != null)
            {
                return new UsuarioDTO()
                {
                    ID = _usuario.ID,
                    Nome = _usuario.Nome,
                    Email = _usuario.Email,
                    Senha = _usuario.Senha
                };
            }

            return null;
        }

        public bool Buscar(UsuarioDTO usuario)
        {
            var _senha = Criptografia.Cript(usuario.Senha);
            var _usuario = objUsuario.Usuarios.Where(x => x.Email == usuario.Email && x.Senha == _senha);

            if (_usuario.Count() > 0)
            {
                return true;
            }

            return false;
        }

        public Retorno Atualizar(UsuarioDTO usuario)
        {
            var retorno = new Retorno();

            var _usuario = objUsuario.Usuarios.Find(usuario.ID);

            if (_usuario != null)
            {
                _usuario.Nome = usuario.Nome;
                _usuario.Email = usuario.Email;
                _usuario.Senha = Criptografia.Cript(usuario.Senha);

                int qtdRetorno = objUsuario.SaveChanges();

                if (qtdRetorno > 0)
                {
                    retorno.Mensagem = "Usuário atualizado com sucesso!";
                    retorno.RegistroID = qtdRetorno;
                }
                else
                {
                    retorno.Mensagem = "Houve um problema ao atualizar o usuário.";
                    retorno.RegistroID = qtdRetorno;
                }
            }
            else
            {
                retorno.Mensagem = "Usuário não encontrado.";
                retorno.RegistroID = 0;
            }

            return retorno;
        }

        public Retorno Deletar(UsuarioDTO usuario)
        {
            var retorno = new Retorno();

            var _usuario = objUsuario.Usuarios.Find(usuario.ID);

            if (_usuario != null)
            {
                objUsuario.Usuarios.Remove(_usuario);

                int qtdRetorno = objUsuario.SaveChanges();

                if (qtdRetorno > 0)
                {
                    retorno.Mensagem = "Usuário deletado com sucesso!";
                    retorno.RegistroID = qtdRetorno;
                }
                else
                {
                    retorno.Mensagem = "Houve um problema ao deletar o usuário.";
                    retorno.RegistroID = qtdRetorno;
                }
            }
            else
            {
                retorno.Mensagem = "Usuário não encontrado.";
                retorno.RegistroID = 0;
            }

            return retorno;
        }
    }
}
