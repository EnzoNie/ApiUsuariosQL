using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiUsuarioSql.Migrations
{
    /// <inheritdoc />
    public partial class NovaFk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListaTarefas_Usuarios_UsuarioId",
                table: "ListaTarefas");

            migrationBuilder.DropColumn(
                name: "UsuariosId",
                table: "ListaTarefas");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "ListaTarefas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ListaTarefas_Usuarios_UsuarioId",
                table: "ListaTarefas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListaTarefas_Usuarios_UsuarioId",
                table: "ListaTarefas");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "ListaTarefas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UsuariosId",
                table: "ListaTarefas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ListaTarefas_Usuarios_UsuarioId",
                table: "ListaTarefas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }
    }
}
