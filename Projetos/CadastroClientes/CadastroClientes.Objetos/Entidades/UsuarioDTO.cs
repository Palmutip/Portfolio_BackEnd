using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroClientes.Objetos
{
    public class UsuarioDTO : Entidade
    {
        [Display(Name = "Nome"), Required(ErrorMessage = "O campo nome é obrigatório.")]
        public string Nome { get; set; }
        [Display(Name = "E-mail"), Required(ErrorMessage = "O campo e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Favor informe um e-mail válido.")]
        public string Email { get; set; }
        [Display(Name = "Senha"), Required(ErrorMessage = "O campo senha é obrigatório.")]
        public string Senha { get; set; }
    }
}
