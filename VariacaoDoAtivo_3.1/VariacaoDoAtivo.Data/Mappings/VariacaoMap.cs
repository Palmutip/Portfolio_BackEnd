using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VariacaoDoAtivo.Domain;

namespace VariacaoDoAtivo.Data
{
    public class VariacaoMap : IEntityTypeConfiguration<Variacao>
    {
        public void Configure(EntityTypeBuilder<Variacao> builder)
        {
            builder.Property(x => x.Dia).IsRequired();

            builder.Property(x => x.Data).HasMaxLength(20).IsRequired();
        }
    }
}
