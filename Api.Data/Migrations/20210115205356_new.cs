using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
  public partial class @new : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "Filmes",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            Name = table.Column<string>(maxLength: 100, nullable: false),
            Gernero = table.Column<string>(maxLength: 254, nullable: false),
            Diretor = table.Column<string>(nullable: true),
            Imagem = table.Column<string>(nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Filmes", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "User",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            Name = table.Column<string>(maxLength: 60, nullable: false),
            Email = table.Column<string>(maxLength: 100, nullable: false),
            Role = table.Column<string>(nullable: true),
            Senha = table.Column<string>(maxLength: 254, nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_User", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "Atores",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            Nome = table.Column<string>(maxLength: 60, nullable: false),
            FilmeEntityId = table.Column<int>(nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Atores", x => x.Id);
            table.ForeignKey(
                      name: "FK_Atores_Filmes_FilmeEntityId",
                      column: x => x.FilmeEntityId,
                      principalTable: "Filmes",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "Avaliacao",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            Avaliacao = table.Column<int>(nullable: false),
            FilmeEntityId = table.Column<int>(nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Avaliacao", x => x.Id);
            table.ForeignKey(
                      name: "FK_Avaliacao_Filmes_FilmeEntityId",
                      column: x => x.FilmeEntityId,
                      principalTable: "Filmes",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateIndex(
          name: "IX_Atores_FilmeEntityId",
          table: "Atores",
          column: "FilmeEntityId");

      migrationBuilder.CreateIndex(
          name: "IX_Avaliacao_FilmeEntityId",
          table: "Avaliacao",
          column: "FilmeEntityId");

      migrationBuilder.CreateIndex(
          name: "IX_User_Email",
          table: "User",
          column: "Email",
          unique: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "Atores");

      migrationBuilder.DropTable(
          name: "Avaliacao");

      migrationBuilder.DropTable(
          name: "User");

      migrationBuilder.DropTable(
          name: "Filmes");
    }
  }
}
