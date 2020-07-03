using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shift.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shift.Data.Mappings
{
    public class PacienteMap : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.Property(c => c.Id)
                .IsRequired()
                .HasColumnName("Id");

            builder.Property(p => p.Nome)
                .IsRequired();
        }
    }
}
