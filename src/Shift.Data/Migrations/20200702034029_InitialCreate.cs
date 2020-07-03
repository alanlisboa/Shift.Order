using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shift.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Convenio",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Convenio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Especialidade",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    IBGE = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exame",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CodigoANS = table.Column<string>(maxLength: 100, nullable: true),
                    Descricao = table.Column<string>(maxLength: 150, nullable: false),
                    Valor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exame", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medico",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    CRM = table.Column<string>(maxLength: 100, nullable: true),
                    EspecialidadeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medico_Especialidade_EspecialidadeId",
                        column: x => x.EspecialidadeId,
                        principalTable: "Especialidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cidade",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    IBGE = table.Column<string>(maxLength: 100, nullable: true),
                    EstadoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cidade_Estado",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Logradouro = table.Column<string>(maxLength: 100, nullable: false),
                    Numero = table.Column<int>(nullable: true),
                    Complemento = table.Column<string>(maxLength: 100, nullable: true),
                    Bairro = table.Column<string>(maxLength: 100, nullable: true),
                    Cep = table.Column<string>(maxLength: 100, nullable: true),
                    CidadeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Endereco_Cidade_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Documento = table.Column<string>(maxLength: 100, nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Sexo = table.Column<int>(nullable: false),
                    EnderecoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paciente_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostoColeta",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 100, nullable: false),
                    EnderecoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostoColeta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostoColeta_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrdemServico",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Numero = table.Column<int>(nullable: false),
                    DataOrdem = table.Column<DateTime>(nullable: false),
                    PacienteId = table.Column<Guid>(nullable: false),
                    ConvenioId = table.Column<Guid>(nullable: false),
                    PostoColetaId = table.Column<Guid>(nullable: false),
                    MedicoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdemServico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdemServico_Convenio_ConvenioId",
                        column: x => x.ConvenioId,
                        principalTable: "Convenio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdemServico_Medico_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdemServico_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdemServico_PostoColeta_PostoColetaId",
                        column: x => x.PostoColetaId,
                        principalTable: "PostoColeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrdemServicoExame",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OrdemServicoId = table.Column<Guid>(nullable: false),
                    ExameId = table.Column<Guid>(nullable: false),
                    Valor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdemServicoExame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdemServicoExame_Exame_ExameId",
                        column: x => x.ExameId,
                        principalTable: "Exame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdemServico_OrdemServicoExame",
                        column: x => x.OrdemServicoId,
                        principalTable: "OrdemServico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Convenio",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { new Guid("3f8c80c3-d61c-404f-b955-6b5930443b5c"), "Particular" },
                    { new Guid("ff6a905f-41e1-4dc7-90d1-e11e09d811d1"), "Unimed" },
                    { new Guid("690b5ff0-ecbb-4960-bc02-a3a4ad61a4a4"), "HB Saúde" },
                    { new Guid("f970def0-a027-4fc8-a1d7-60f5ae3568ab"), "Padre Albino" },
                    { new Guid("d345f4b9-46ae-4ee1-85b0-3311c5ef2b16"), "Cassi" }
                });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { new Guid("6d39a0d8-5102-4da2-8620-12af15626968"), "Clínico Geral" },
                    { new Guid("c79dd214-bec3-4717-b598-5a71d66d5e63"), "Oncologia" },
                    { new Guid("9022b816-4b85-46bb-b92c-70a858ad0ce2"), "Pediatria" }
                });

            migrationBuilder.InsertData(
                table: "Estado",
                columns: new[] { "Id", "IBGE", "Nome" },
                values: new object[] { new Guid("653214e2-bd65-48f5-9ba1-dda462a4c2ae"), "35", "São Paulo" });

            migrationBuilder.InsertData(
                table: "Exame",
                columns: new[] { "Id", "CodigoANS", "Descricao", "Valor" },
                values: new object[,]
                {
                    { new Guid("30b098e7-b431-4cd4-8f55-f10f774435ba"), "10010", "PSA", 60.0 },
                    { new Guid("a282fe62-aa5e-40c1-854b-145d46f2306a"), "10201", "Hemograma", 35.0 },
                    { new Guid("f5075ef1-eced-41f1-8e83-a5f1a0c63de7"), "12111", "Beta HCG", 40.0 },
                    { new Guid("4c01d50f-e84d-4f62-9a3b-4bf937eb1d65"), "10115", "Urina I", 80.0 }
                });

            migrationBuilder.InsertData(
                table: "Cidade",
                columns: new[] { "Id", "EstadoId", "IBGE", "Nome" },
                values: new object[] { new Guid("a8b44372-64ec-4e88-bd9e-eff26ce1a238"), new Guid("653214e2-bd65-48f5-9ba1-dda462a4c2ae"), "3589505", "São José do Rio Preto" });

            migrationBuilder.InsertData(
                table: "Medico",
                columns: new[] { "Id", "CRM", "EspecialidadeId", "Nome" },
                values: new object[,]
                {
                    { new Guid("dd2f5629-2e68-4a1e-898c-b7724c72441e"), "110012", new Guid("6d39a0d8-5102-4da2-8620-12af15626968"), "Fernando Carvalho de Souza" },
                    { new Guid("ed6d55d6-d08c-4f30-b317-387bf03b27ff"), "110012", new Guid("c79dd214-bec3-4717-b598-5a71d66d5e63"), "Eduardo Ferraz" },
                    { new Guid("628e4867-b913-4c90-8d78-d89c2ce4aeb7"), "110012", new Guid("9022b816-4b85-46bb-b92c-70a858ad0ce2"), "Sonia Hildenburg" }
                });

            migrationBuilder.InsertData(
                table: "Endereco",
                columns: new[] { "Id", "Bairro", "Cep", "CidadeId", "Complemento", "Logradouro", "Numero" },
                values: new object[,]
                {
                    { new Guid("bf7b1fc7-4fc5-4a47-a2b3-d595ab79f72c"), "Centro", null, new Guid("a8b44372-64ec-4e88-bd9e-eff26ce1a238"), "", "Av. Bernardino de Campos", 330 },
                    { new Guid("16cfb302-b06e-4c96-9f8a-8c052a43f723"), "Centro", null, new Guid("a8b44372-64ec-4e88-bd9e-eff26ce1a238"), "Sala 1", "Rua General Glicério", 1050 },
                    { new Guid("35928392-069d-4719-bcc8-9a965fbc2278"), "Vila Diniz", null, new Guid("a8b44372-64ec-4e88-bd9e-eff26ce1a238"), "", "Av. Fernando Costa", 117 },
                    { new Guid("59bd56a3-c295-45c6-91d7-0fe4f3648de3"), "Higienopólis", null, new Guid("a8b44372-64ec-4e88-bd9e-eff26ce1a238"), "Apto. 55", "Rua Vírgilio Varzea", 119 },
                    { new Guid("ca19f566-b325-4f9b-ab75-6b2b3e0042e2"), "Centro", null, new Guid("a8b44372-64ec-4e88-bd9e-eff26ce1a238"), "Apto. 11", "Av. Bernardino de Campos", 580 }
                });

            migrationBuilder.InsertData(
                table: "Paciente",
                columns: new[] { "Id", "DataNascimento", "Documento", "EnderecoId", "Nome", "Sexo" },
                values: new object[,]
                {
                    { new Guid("a28be555-079e-4aae-80a7-ed8a78732a97"), new DateTime(1980, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "28771-0", new Guid("35928392-069d-4719-bcc8-9a965fbc2278"), "Fábio Fernandez da Silva", 0 },
                    { new Guid("5114ec9c-1c6e-429f-8dac-fd5e00becae4"), new DateTime(1997, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "11231-7", new Guid("59bd56a3-c295-45c6-91d7-0fe4f3648de3"), "Mariana Mendes de Souze", 1 },
                    { new Guid("bf8a6523-8914-4cf7-9b8c-01ee2df7f858"), new DateTime(1983, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "199112-7", new Guid("ca19f566-b325-4f9b-ab75-6b2b3e0042e2"), "Ernani de Castro", 0 }
                });

            migrationBuilder.InsertData(
                table: "PostoColeta",
                columns: new[] { "Id", "Descricao", "EnderecoId" },
                values: new object[,]
                {
                    { new Guid("5394d9a4-fa0c-4450-836f-5c3a05b21602"), "Laboratório Tabajara", new Guid("bf7b1fc7-4fc5-4a47-a2b3-d595ab79f72c") },
                    { new Guid("96a32d6c-c783-4ddc-9e9d-f820c7a4090f"), "Laboratório Vita", new Guid("16cfb302-b06e-4c96-9f8a-8c052a43f723") }
                });

            migrationBuilder.InsertData(
                table: "OrdemServico",
                columns: new[] { "Id", "ConvenioId", "DataOrdem", "MedicoId", "Numero", "PacienteId", "PostoColetaId" },
                values: new object[] { new Guid("20fd99ee-caa1-4c16-abc4-d51aac4bbbd8"), new Guid("ff6a905f-41e1-4dc7-90d1-e11e09d811d1"), new DateTime(2020, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ed6d55d6-d08c-4f30-b317-387bf03b27ff"), 1, new Guid("5114ec9c-1c6e-429f-8dac-fd5e00becae4"), new Guid("96a32d6c-c783-4ddc-9e9d-f820c7a4090f") });

            migrationBuilder.InsertData(
                table: "OrdemServicoExame",
                columns: new[] { "Id", "ExameId", "OrdemServicoId", "Valor" },
                values: new object[] { new Guid("a6667d69-aa90-4d5d-8b92-3bf601d8847f"), new Guid("a282fe62-aa5e-40c1-854b-145d46f2306a"), new Guid("20fd99ee-caa1-4c16-abc4-d51aac4bbbd8"), 35.0 });

            migrationBuilder.CreateIndex(
                name: "IX_Cidade_EstadoId",
                table: "Cidade",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_CidadeId",
                table: "Endereco",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Medico_EspecialidadeId",
                table: "Medico",
                column: "EspecialidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemServico_ConvenioId",
                table: "OrdemServico",
                column: "ConvenioId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemServico_MedicoId",
                table: "OrdemServico",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemServico_PacienteId",
                table: "OrdemServico",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemServico_PostoColetaId",
                table: "OrdemServico",
                column: "PostoColetaId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemServicoExame_ExameId",
                table: "OrdemServicoExame",
                column: "ExameId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemServicoExame_OrdemServicoId",
                table: "OrdemServicoExame",
                column: "OrdemServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_EnderecoId",
                table: "Paciente",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_PostoColeta_EnderecoId",
                table: "PostoColeta",
                column: "EnderecoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdemServicoExame");

            migrationBuilder.DropTable(
                name: "Exame");

            migrationBuilder.DropTable(
                name: "OrdemServico");

            migrationBuilder.DropTable(
                name: "Convenio");

            migrationBuilder.DropTable(
                name: "Medico");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "PostoColeta");

            migrationBuilder.DropTable(
                name: "Especialidade");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Cidade");

            migrationBuilder.DropTable(
                name: "Estado");
        }
    }
}
