using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
