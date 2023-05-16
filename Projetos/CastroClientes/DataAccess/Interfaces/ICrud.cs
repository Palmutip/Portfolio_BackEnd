using CadastroClientes.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface ICrud<T>
    {
        Retorno Inserir(T entidade);
        List<T> Buscar();
        T Buscar(int ID);
        Retorno Atualizar(T entidade);
        Retorno Deletar(T entidade);
    }
}
