using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CadastroClientes.Objetos
{
    public class ClienteDTO : Entidade
    {
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Display(Name = "Tipo")]
        public TipoOpcoes Tipo { get; set; }
        [Display(Name = "Data de Nascimento"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data_Nascimento { get; set; }
        [Display(Name = "Data de Cadastro")]
        public DateTime Data_Cadastro { get; set; }
    }
    public enum TipoOpcoes
    {
        CNPJ = 0,
        CPF = 1
    }
}
