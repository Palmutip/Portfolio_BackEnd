﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VariacaoDoAtivo.Application;

namespace VariacaoDoAtivo.Controllers
{
    [Route("api/[controller]"), ApiController]
    public class VariacaoController : ControllerBase
    {
        private readonly IVariacaoService variacaoService;

        public VariacaoController(IVariacaoService variacaoService)
        {
            this.variacaoService = variacaoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.variacaoService.Get());
        }

        [HttpGet("{dia}")]
        public IActionResult GetById(int dia)
        {
            return Ok(this.variacaoService.GetById(dia));
        }

        [HttpPost]
        public IActionResult Post(string identificacaoAtivo)
        {
            return Ok(this.variacaoService.Post(identificacaoAtivo));
        }

        [HttpPut]
        public IActionResult Put(VariacaoViewModel variacaoViewModel)
        {
            return Ok(this.variacaoService.Put(variacaoViewModel));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            return Ok(this.variacaoService.Delete(id));
        }
    }
}
