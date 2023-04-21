using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VariacaoDoAtivo.Application;
using VariacaoDoAtivo.Domain;
    
namespace VariacaoDoAtivo.Controllers
{
    [Route("api/[controller]"), ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.usuarioService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            return Ok(this.usuarioService.GetById(id));
        }

        [HttpPost]
        public IActionResult Post(UsuarioViewModel usuarioViewModel)
        {
            return Ok(this.usuarioService.Post(usuarioViewModel));
        }

        [HttpPut]
        public IActionResult Put(UsuarioViewModel usuarioViewModel)
        {
            return Ok(this.usuarioService.Put(usuarioViewModel));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            return Ok(this.usuarioService.Delete(id));
        }
    }
}
