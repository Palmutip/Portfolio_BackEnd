using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VariacaoDoAtivo.Domain
{
    public class Entity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public bool IsDeleted { get; set; }
    }
}
