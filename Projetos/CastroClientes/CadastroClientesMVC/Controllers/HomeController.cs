using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadastroClientes.Controllers
{
    public class HomeController : Controller
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

            return View();
        }
    }
}