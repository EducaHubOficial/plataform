using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<decimal>(type: "numeric(18,0)", nullable: false, comment: "Identificação do usuário")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    tratamento = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    dataNascimento = table.Column<DateTime>(type: "date", nullable: true),
                    dataCadastro = table.Column<DateTime>(type: "datetime", nullable: true),
                    sexo = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    salt = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    hash = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Acessos",
                columns: table => new
                {
                    id = table.Column<decimal>(type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    dataCadastro = table.Column<DateTime>(type: "datetime", nullable: true),
                    usuarioResponsavel = table.Column<decimal>(type: "numeric(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acessos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Acessos_Usuarios",
                        column: x => x.usuarioResponsavel,
                        principalTable: "Usuarios",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Grupos",
                columns: table => new
                {
                    id = table.Column<decimal>(type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    dataCadastro = table.Column<DateTime>(type: "datetime", nullable: true),
                    usuarioResponsavel = table.Column<decimal>(type: "numeric(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Grupos_Usuarios",
                        column: x => x.usuarioResponsavel,
                        principalTable: "Usuarios",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "AcessosGrupos",
                columns: table => new
                {
                    acessosId = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    gruposId = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    dataLancamento = table.Column<DateTime>(type: "datetime", nullable: true),
                    usuarioResponsavel = table.Column<decimal>(type: "numeric(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcessosGrupos", x => new { x.acessosId, x.gruposId });
                    table.ForeignKey(
                        name: "FK_AcessosGrupos_Acessos",
                        column: x => x.acessosId,
                        principalTable: "Acessos",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_AcessosGrupos_Usuarios",
                        column: x => x.usuarioResponsavel,
                        principalTable: "Usuarios",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "AcessosUsuarios",
                columns: table => new
                {
                    acessosId = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    usuariosId = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    dataLancamento = table.Column<DateTime>(type: "datetime", nullable: true),
                    usuarioResponsavel = table.Column<decimal>(type: "numeric(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcessosUsuarios", x => new { x.acessosId, x.usuariosId });
                    table.ForeignKey(
                        name: "FK_AcessosUsuarios_Acessos",
                        column: x => x.acessosId,
                        principalTable: "Acessos",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_AcessosUsuarios_Usuarios",
                        column: x => x.usuariosId,
                        principalTable: "Usuarios",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_AcessosUsuarios_Usuarios1",
                        column: x => x.usuarioResponsavel,
                        principalTable: "Usuarios",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "GruposUsuarios",
                columns: table => new
                {
                    gruposId = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    usuariosId = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    dataCadastro = table.Column<DateTime>(type: "datetime", nullable: true),
                    usuarioResponsavel = table.Column<decimal>(type: "numeric(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GruposUsuarios", x => new { x.gruposId, x.usuariosId });
                    table.ForeignKey(
                        name: "FK_GruposUsuarios_Grupos",
                        column: x => x.gruposId,
                        principalTable: "Grupos",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_GruposUsuarios_Usuarios",
                        column: x => x.usuariosId,
                        principalTable: "Usuarios",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_GruposUsuarios_Usuarios1",
                        column: x => x.usuarioResponsavel,
                        principalTable: "Usuarios",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acessos_usuarioResponsavel",
                table: "Acessos",
                column: "usuarioResponsavel");

            migrationBuilder.CreateIndex(
                name: "IX_AcessosGrupos_usuarioResponsavel",
                table: "AcessosGrupos",
                column: "usuarioResponsavel");

            migrationBuilder.CreateIndex(
                name: "IX_AcessosUsuarios_usuarioResponsavel",
                table: "AcessosUsuarios",
                column: "usuarioResponsavel");

            migrationBuilder.CreateIndex(
                name: "IX_AcessosUsuarios_usuariosId",
                table: "AcessosUsuarios",
                column: "usuariosId");

            migrationBuilder.CreateIndex(
                name: "IX_Grupos_usuarioResponsavel",
                table: "Grupos",
                column: "usuarioResponsavel");

            migrationBuilder.CreateIndex(
                name: "IX_GruposUsuarios_usuarioResponsavel",
                table: "GruposUsuarios",
                column: "usuarioResponsavel");

            migrationBuilder.CreateIndex(
                name: "IX_GruposUsuarios_usuariosId",
                table: "GruposUsuarios",
                column: "usuariosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcessosGrupos");

            migrationBuilder.DropTable(
                name: "AcessosUsuarios");

            migrationBuilder.DropTable(
                name: "GruposUsuarios");

            migrationBuilder.DropTable(
                name: "Acessos");

            migrationBuilder.DropTable(
                name: "Grupos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
