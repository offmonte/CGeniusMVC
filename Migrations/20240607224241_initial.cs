using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CGenius.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tabela_De_Atualizacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Cidade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Porto = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    pH = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    OxigenioDissolvido = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Nitrato = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Fosfato = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Microplasticos = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Salinidade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tabela_De_Atualizacoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tabela_Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome_De_Usuario = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Nick = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Foto_De_Perfil = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Hash_da_senha = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Data_do_registro = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Usuario_Ativo = table.Column<bool>(type: "NUMBER(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tabela_Usuarios", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tabela_De_Atualizacoes");

            migrationBuilder.DropTable(
                name: "Tabela_Usuarios");
        }
    }
}
