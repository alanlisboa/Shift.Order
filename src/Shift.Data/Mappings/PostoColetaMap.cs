using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shift.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shift.Data.Mappings
{
    public class PostoColetaMap : IEntityTypeConfiguration<PostoColeta>
    {
        public void Configure(EntityTypeBuilder<PostoColeta> builder)
        {
            builder.Property(c => c.Id)
                .IsRequired()
                .HasColumnName("Id");

            builder.Property(p => p.Descricao)
                .IsRequired();
        }
    }
}
