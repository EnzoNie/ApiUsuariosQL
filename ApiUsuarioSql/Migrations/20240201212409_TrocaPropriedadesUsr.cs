using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiUsuarioSql.Migrations
{
    /// <inheritdoc />
    public partial class TrocaPropriedadesUsr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sobrenome",
                table: "Usuarios",
                newName: "Senha");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Senha",
                table: "Usuarios",
                newName: "Sobrenome");
        }
    }
}
