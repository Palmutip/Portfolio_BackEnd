using CadastroClientes.Objetos;
using CadastroClientes.Regras;
using DataAccessADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CadastroClientes.Controllers
{
    public class UsuariosController : Controller, ICrudController<UsuarioDTO>
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

            return View(new UsuarioBLL().Buscar());
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
        public ActionResult Criar(UsuarioDTO usuarioDTO)
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
                new UsuarioBLL().Inserir(usuarioDTO);

                return RedirectToAction("Index");
            }

            return View(usuarioDTO);
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

            return View(new UsuarioBLL().Buscar(ID));
        }

        [HttpPost]
        public ActionResult Editar(UsuarioDTO usuarioDTO)
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

            new UsuarioBLL().Atualizar(usuarioDTO);

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

            return View(new UsuarioBLL().Buscar(ID));
        }

        public ActionResult Deletar(UsuarioDTO usuarioDTO)
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

            new UsuarioBLL().Deletar(usuarioDTO);

            return RedirectToAction("Index");
        }
    
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UsuarioDTO usuarioDTO)
        {
            if (!new UsuarioBLL().Buscar(usuarioDTO))
                TempData["mensagem"] = "Usuario/Senha inválido!";
            else
            {
                FormsAuthentication.SetAuthCookie(usuarioDTO.Email, false);
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View("Login");
        }

        public ActionResult CadastrarNovo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarNovo(UsuarioDTO usuarioDTO)
        {
            if (ModelState.IsValid)
            {
                new UsuarioBLL().Inserir(usuarioDTO);

                return RedirectToAction("Index");
            }

            return View(usuarioDTO);
        }
    }
}