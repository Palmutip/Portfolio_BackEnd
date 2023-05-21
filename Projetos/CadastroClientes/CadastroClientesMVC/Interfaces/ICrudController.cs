using CadastroClientes.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadastroClientes
{
    public interface ICrudController<T>
    {
        ActionResult Index(); 
        ActionResult Criar();
        ActionResult Criar(T clienteDTO);
        ActionResult Editar(int dataTransferObject);
        ActionResult Editar(T dataTransferObject);
        ActionResult Detalhes(int ID);
        ActionResult Deletar(T dataTransferObject);
    }
}