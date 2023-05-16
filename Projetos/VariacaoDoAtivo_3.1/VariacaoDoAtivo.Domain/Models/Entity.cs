using System;
using System.ComponentModel.DataAnnotations;

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
