using CadastroClientes.Objetos;
using CadastroClientes.Regras;
using DataAccessADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadastroClientes.Controllers
{
    public class ClientesController : Controller, ICrudController<ClienteDTO>
    {
        public ActionResult Index()
        {
            try
            {
                if (!User.Identity.IsAuthenticated)
                {
                    return RedirectToAction("Login", "Usuarios");
                }
            }
            catch
            {
                return RedirectToAction("Login", "Usuarios");
            }

            return View(new ClienteBLL().Buscar());
        }

        [HttpGet]
        public ActionResult Criar()
        {
            try
            {
                if (!User.Identity.IsAuthenticated)
                {
                    return RedirectToAction("Login", "Usuarios");
                }
            }
            catch
            {
                return RedirectToAction("Login", "Usuarios");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Criar(ClienteDTO clienteDTO)
        {
            try
            {
                if (!User.Identity.IsAuthenticated)
                {
                    return RedirectToAction("Login", "Usuarios");
                }
            }
            catch
            {
                return RedirectToAction("Login", "Usuarios");
            }

            if (ModelState.IsValid)
            {
                new ClienteBLL().Inserir(clienteDTO);

                return RedirectToAction("Index");
            }

            return View(clienteDTO);
        }

        [HttpGet]
        public ActionResult Editar(int ID)
        {
            try
            {
                if (!User.Identity.IsAuthenticated)
                {
                    return RedirectToAction("Login", "Usuarios");
                }
            }
            catch
            {
                return RedirectToAction("Login", "Usuarios");
            }

            return View(new ClienteBLL().Buscar(ID));
        }

        [HttpPost]
        public ActionResult Editar(ClienteDTO clienteDTO)
        {
            try
            {
                if (!User.Identity.IsAuthenticated)
                {
                    return RedirectToAction("Login", "Usuarios");
                }
            }
            catch
            {
                return RedirectToAction("Login", "Usuarios");
            }

            new ClienteBLL().Atualizar(clienteDTO);

            return RedirectToAction("Index");
        }

        public ActionResult Detalhes(int ID)
        {
            try
            {
                if (!User.Identity.IsAuthenticated)
                {
                    return RedirectToAction("Login", "Usuarios");
                }
            }
            catch
            {
                return RedirectToAction("Login", "Usuarios");
            }

            return View(new ClienteBLL().Buscar(ID));
        }

        public ActionResult Deletar(ClienteDTO clienteDTO)
        {
            try
            {
                if (!User.Identity.IsAuthenticated)
                {
                    return RedirectToAction("Login", "Usuarios");
                }
            }
            catch
            {
                return RedirectToAction("Login", "Usuarios");
            }

            new ClienteBLL().Deletar(clienteDTO);

            return RedirectToAction("Index");
        }
    }
}