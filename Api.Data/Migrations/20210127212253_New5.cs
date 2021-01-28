using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class New5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gernero",
                table: "Filmes");

            migrationBuilder.AlterColumn<string>(
                name: "Imagem",
                table: "Filmes",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(254)",
                oldMaxLength: 254,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Genero",
                table: "Filmes",
                maxLength: 254,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genero",
                table: "Filmes");

            migrationBuilder.AlterColumn<string>(
                name: "Imagem",
                table: "Filmes",
                type: "nvarchar(254)",
                maxLength: 254,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gernero",
                table: "Filmes",
                type: "nvarchar(254)",
                maxLength: 254,
                nullable: false,
                defaultValue: "");
        }
    }
}
