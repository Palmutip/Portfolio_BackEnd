using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VariacaoDoAtivo.Application
{
    public class UsuarioViewModel /*: EntityViewModel*/
    {
        public Guid Id { get; set; }

        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        /*[Required]
        public string Senha { get; set; }*/
    }
}
