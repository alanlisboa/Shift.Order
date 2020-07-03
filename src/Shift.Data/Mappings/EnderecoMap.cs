using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shift.Domain.Models;

namespace Shift.Data.Mappings
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.Property(c => c.Id)
                .IsRequired()
                .HasColumnName("Id");

            builder.Property(c => c.Logradouro)
                .IsRequired();
        }
    }
}
