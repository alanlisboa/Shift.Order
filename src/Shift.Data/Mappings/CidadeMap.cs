using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shift.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shift.Data.Mappings
{
    public class CidadeMap : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.Property(c => c.Id)
                .IsRequired()
                .HasColumnName("Id");

            builder.Property(c => c.Nome)
                .IsRequired();

            builder.HasOne(c => c.Estado)
                .WithMany(c => c.Cidades)
                .HasForeignKey(c => c.EstadoId)
                .HasConstraintName("FK_Cidade_Estado");
        }
    }
}
