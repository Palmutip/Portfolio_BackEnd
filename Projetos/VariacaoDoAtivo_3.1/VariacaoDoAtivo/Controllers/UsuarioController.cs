using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VariacaoDoAtivo.Application;
using VariacaoDoAtivo.Auth.Services;

namespace VariacaoDoAtivo.Controllers
{
    [Route("api/[controller]"), ApiController, Authorize]
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

        [HttpPost, AllowAnonymous]
        public IActionResult Post(UsuarioViewModel usuarioViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(this.usuarioService.Post(usuarioViewModel));
        }

        [HttpPost("autenticate"), AllowAnonymous]
        public IActionResult Autenticar(UserAuthenticateRequestViewModel usuarioViewModel)
        {
            return Ok(this.usuarioService.Authenticate(usuarioViewModel));
        }

        [HttpPut]
        public IActionResult Put(UsuarioViewModel usuarioViewModel)
        {
            return Ok(this.usuarioService.Put(usuarioViewModel));
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            var _idUsuario = TokenService.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.NameIdentifier);

            return Ok(this.usuarioService.Delete(_idUsuario));
        }
    }
}
