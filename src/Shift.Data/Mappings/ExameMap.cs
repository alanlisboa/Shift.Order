using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shift.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shift.Data.Mappings
{
    public class ExameMap : IEntityTypeConfiguration<Exame>
    {
        public void Configure(EntityTypeBuilder<Exame> builder)
        {
            builder.Property(c => c.Id)
                .IsRequired()
                .HasColumnName("Id");

            builder.Property(c => c.Descricao)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
