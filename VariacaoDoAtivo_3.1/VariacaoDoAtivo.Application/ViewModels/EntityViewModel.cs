using System;
using System.Collections.Generic;
using System.Text;

namespace VariacaoDoAtivo.Application
{
    public class EntityViewModel
    {
        public Guid Id { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
