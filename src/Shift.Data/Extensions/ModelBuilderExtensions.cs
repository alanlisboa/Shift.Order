using Microsoft.EntityFrameworkCore;
using Shift.Domain.Models;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Shift.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Estado
            Guid estadoId = Guid.Parse("653214E2-BD65-48F5-9BA1-DDA462A4C2AE");
            modelBuilder.Entity<Estado>().HasData(new Estado(estadoId, "São Paulo", "35"));

            // Cidade
            Guid cidadeId = Guid.Parse("A8B44372-64EC-4E88-BD9E-EFF26CE1A238");
            modelBuilder.Entity<Cidade>().HasData(new Cidade(cidadeId, "São José do Rio Preto", "3589505", estadoId));

            // Endereços
            modelBuilder.Entity<Endereco>().HasData(
                new Endereco(Guid.Parse("BF7B1FC7-4FC5-4A47-A2B3-D595AB79F72C"), "Av. Bernardino de Campos", 330, "", "Centro", cidadeId),
                new Endereco(Guid.Parse("16CFB302-B06E-4C96-9F8A-8C052A43F723"), "Rua General Glicério", 1050, "Sala 1", "Centro", cidadeId),
                new Endereco(Guid.Parse("35928392-069D-4719-BCC8-9A965FBC2278"), "Av. Fernando Costa", 117, "", "Vila Diniz", cidadeId),
                new Endereco(Guid.Parse("59BD56A3-C295-45C6-91D7-0FE4F3648DE3"), "Rua Vírgilio Varzea", 119, "Apto. 55", "Higienopólis", cidadeId),
                new Endereco(Guid.Parse("CA19F566-B325-4F9B-AB75-6B2B3E0042E2"), "Av. Bernardino de Campos", 580, "Apto. 11", "Centro", cidadeId)
            );

            // Especialidades
            modelBuilder.Entity<Especialidade>().HasData(
                new Especialidade(Guid.Parse("6D39A0D8-5102-4DA2-8620-12AF15626968"), "Clínico Geral"),
                new Especialidade(Guid.Parse("C79DD214-BEC3-4717-B598-5A71D66D5E63"), "Oncologia"),
                new Especialidade(Guid.Parse("9022B816-4B85-46BB-B92C-70A858AD0CE2"), "Pediatria")
            );

            // Exames
            modelBuilder.Entity<Exame>().HasData(
                new Exame(Guid.Parse("30B098E7-B431-4CD4-8F55-F10F774435BA"), "10010", "PSA", 60),
                new Exame(Guid.Parse("A282FE62-AA5E-40C1-854B-145D46F2306A"), "10201", "Hemograma", 35),
                new Exame(Guid.Parse("F5075EF1-ECED-41F1-8E83-A5F1A0C63DE7"), "12111", "Beta HCG", 40),
                new Exame(Guid.Parse("4C01D50F-E84D-4F62-9A3B-4BF937EB1D65"), "10115", "Urina I", 80)
            );

            // Médicos
            modelBuilder.Entity<Medico>().HasData(
                new Medico(Guid.Parse("DD2F5629-2E68-4A1E-898C-B7724C72441E"), "Fernando Carvalho de Souza", "110012", Guid.Parse("6D39A0D8-5102-4DA2-8620-12AF15626968")),
                new Medico(Guid.Parse("ED6D55D6-D08C-4F30-B317-387BF03B27FF"), "Eduardo Ferraz", "110012", Guid.Parse("C79DD214-BEC3-4717-B598-5A71D66D5E63")),
                new Medico(Guid.Parse("628E4867-B913-4C90-8D78-D89C2CE4AEB7"), "Sonia Hildenburg", "110012", Guid.Parse("9022B816-4B85-46BB-B92C-70A858AD0CE2"))
            );

            // Pacientes
            modelBuilder.Entity<Paciente>().HasData(
                new Paciente(Guid.Parse("A28BE555-079E-4AAE-80A7-ED8A78732A97"), "Fábio Fernandez da Silva", "28771-0", new DateTime(1980, 4, 13), Sexo.Masculino, Guid.Parse("35928392-069D-4719-BCC8-9A965FBC2278")),
                new Paciente(Guid.Parse("5114EC9C-1C6E-429F-8DAC-FD5E00BECAE4"), "Mariana Mendes de Souze", "11231-7", new DateTime(1997, 5, 22), Sexo.Feminino, Guid.Parse("59BD56A3-C295-45C6-91D7-0FE4F3648DE3")),
                new Paciente(Guid.Parse("BF8A6523-8914-4CF7-9B8C-01EE2DF7F858"), "Ernani de Castro", "199112-7", new DateTime(1983, 9, 5), Sexo.Masculino, Guid.Parse("CA19F566-B325-4F9B-AB75-6B2B3E0042E2"))
            );

            // Postos de Coleta
            modelBuilder.Entity<PostoColeta>().HasData(
                new PostoColeta(Guid.Parse("5394D9A4-FA0C-4450-836F-5C3A05B21602"), "Laboratório Tabajara", Guid.Parse("BF7B1FC7-4FC5-4A47-A2B3-D595AB79F72C")),
                new PostoColeta(Guid.Parse("96A32D6C-C783-4DDC-9E9D-F820C7A4090F"), "Laboratório Vita", Guid.Parse("16CFB302-B06E-4C96-9F8A-8C052A43F723"))
            );

            // Convênios
            modelBuilder.Entity<Convenio>().HasData(
                new Convenio(Guid.Parse("3F8C80C3-D61C-404F-B955-6B5930443B5C"), "Particular"),
                new Convenio(Guid.Parse("FF6A905F-41E1-4DC7-90D1-E11E09D811D1"), "Unimed"),
                new Convenio(Guid.Parse("690B5FF0-ECBB-4960-BC02-A3A4AD61A4A4"), "HB Saúde"),
                new Convenio(Guid.Parse("F970DEF0-A027-4FC8-A1D7-60F5AE3568AB"), "Padre Albino"),
                new Convenio(Guid.Parse("D345F4B9-46AE-4EE1-85B0-3311C5EF2B16"), "Cassi")
            );

            // Ordem de Serviço
            modelBuilder.Entity<OrdemServico>().HasData(
                new OrdemServico(Guid.Parse("20FD99EE-CAA1-4C16-ABC4-D51AAC4BBBD8"), 1, new DateTime(2020, 7, 1), Guid.Parse("5114EC9C-1C6E-429F-8DAC-FD5E00BECAE4"), Guid.Parse("FF6A905F-41E1-4DC7-90D1-E11E09D811D1"), Guid.Parse("96A32D6C-C783-4DDC-9E9D-F820C7A4090F"), Guid.Parse("ED6D55D6-D08C-4F30-B317-387BF03B27FF"))
            );

            modelBuilder.Entity<OrdemServicoExame>().HasData(
                new OrdemServicoExame(Guid.Parse("A6667D69-AA90-4D5D-8B92-3BF601D8847F"), Guid.Parse("20FD99EE-CAA1-4C16-ABC4-D51AAC4BBBD8"), Guid.Parse("A282FE62-AA5E-40C1-854B-145D46F2306A"), 35)
            );
        }
    }
}
