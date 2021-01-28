using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class New6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "Name", "Role", "Senha" },
                values: new object[] { 49, "jpkabral@live.com", "Administrador", "Adm", "Vur67203" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 49);
        }
    }
}
