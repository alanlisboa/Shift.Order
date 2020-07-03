using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shift.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shift.Data.Mappings
{
    public class OrdemServicoExameMap : IEntityTypeConfiguration<OrdemServicoExame>
    {
        public void Configure(EntityTypeBuilder<OrdemServicoExame> builder)
        {
            builder.Property(c => c.Id)
                .IsRequired()
                .HasColumnName("Id");

            builder.Property(c => c.ExameId)
                .IsRequired();

            builder.HasOne(i => i.OrdemServico)
                .WithMany(i => i.Exames)
                .HasForeignKey(i => i.OrdemServicoId)
                .HasConstraintName("FK_OrdemServico_OrdemServicoExame");
        }
    }
}
