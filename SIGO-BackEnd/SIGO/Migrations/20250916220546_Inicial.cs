using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SIGO.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    rua = table.Column<string>(type: "text", nullable: false),
                    cidade = table.Column<string>(type: "text", nullable: false),
                    cep = table.Column<int>(type: "integer", nullable: false),
                    bairro = table.Column<string>(type: "text", nullable: false),
                    estado = table.Column<string>(type: "text", nullable: false),
                    pais = table.Column<string>(type: "text", nullable: false),
                    TipoCliente = table.Column<int>(type: "integer", nullable: false),
                    situacao = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.id);
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
                name: "IX_telefone_clienteid",
                table: "telefone",
                column: "clienteid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "telefone");

            migrationBuilder.DropTable(
                name: "cliente");
        }
    }
}
