using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SIGO.Migrations
{
    /// <inheritdoc />
    public partial class addFuncionario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "funcionario",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    cpf = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false),
                    cargo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    situacao = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_funcionario", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "marca",
                columns: table => new
                {
                    idMarca = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nomeMarca = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    descMarca = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    tipoMarca = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marca", x => x.idMarca);
                });

            migrationBuilder.CreateTable(
                name: "servico",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    descricao = table.Column<string>(type: "text", nullable: false),
                    valor = table.Column<double>(type: "double precision", nullable: false),
                    garantia = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_servico", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "veiculo",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    tipo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    placa = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    chassi = table.Column<string>(type: "character varying(17)", maxLength: 17, nullable: false),
                    ano = table.Column<int>(type: "integer", nullable: false),
                    quilometragem = table.Column<int>(type: "integer", nullable: false),
                    combustivel = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    seguro = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_veiculo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    senha = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    cpf_cnpj = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    obs = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    razao = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    datanasc = table.Column<DateOnly>(type: "date", nullable: true),
                    sexo = table.Column<int>(type: "integer", nullable: false),
                    numero = table.Column<int>(type: "integer", nullable: false),
                    rua = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    cidade = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    cep = table.Column<int>(type: "integer", nullable: false),
                    bairro = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    estado = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    pais = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    complemento = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    tipocliente = table.Column<int>(type: "integer", nullable: false),
                    situacao = table.Column<int>(type: "integer", nullable: false),
                    VeiculoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.id);
                    table.ForeignKey(
                        name: "FK_cliente_veiculo_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "veiculo",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Cores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeCor = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    VeiculoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cores_veiculo_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "veiculo",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "telefone",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    numero = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: false),
                    ddd = table.Column<int>(type: "integer", maxLength: 3, nullable: false),
                    clienteid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_telefone", x => x.id);
                    table.ForeignKey(
                        name: "FK_telefone_cliente_clienteid",
                        column: x => x.clienteid,
                        principalTable: "cliente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cliente_VeiculoId",
                table: "cliente",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cores_VeiculoId",
                table: "Cores",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_telefone_clienteid",
                table: "telefone",
                column: "clienteid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cores");

            migrationBuilder.DropTable(
                name: "funcionario");

            migrationBuilder.DropTable(
                name: "marca");

            migrationBuilder.DropTable(
                name: "servico");

            migrationBuilder.DropTable(
                name: "telefone");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "veiculo");
        }
    }
}
