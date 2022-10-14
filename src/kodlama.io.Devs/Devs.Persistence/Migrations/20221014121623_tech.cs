using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Devs.Persistence.Migrations
{
    public partial class tech : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProgramminLanguages",
                table: "ProgramminLanguages");

            migrationBuilder.RenameTable(
                name: "ProgramminLanguages",
                newName: "ProgrammingLanguages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProgrammingLanguages",
                table: "ProgrammingLanguages",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ProgrammingLanguageTechnologies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgrammingLanguageId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrammingLanguageTechnologies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgrammingLanguageTechnologies_ProgrammingLanguages_ProgrammingLanguageId",
                        column: x => x.ProgrammingLanguageId,
                        principalTable: "ProgrammingLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProgrammingLanguageTechnologies",
                columns: new[] { "Id", "Name", "ProgrammingLanguageId" },
                values: new object[] { 1, "Java", 1 });

            migrationBuilder.InsertData(
                table: "ProgrammingLanguageTechnologies",
                columns: new[] { "Id", "Name", "ProgrammingLanguageId" },
                values: new object[] { 2, "Asp.Net Core", 1 });

            migrationBuilder.InsertData(
                table: "ProgrammingLanguageTechnologies",
                columns: new[] { "Id", "Name", "ProgrammingLanguageId" },
                values: new object[] { 3, "Django", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammingLanguageTechnologies_ProgrammingLanguageId",
                table: "ProgrammingLanguageTechnologies",
                column: "ProgrammingLanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgrammingLanguageTechnologies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProgrammingLanguages",
                table: "ProgrammingLanguages");

            migrationBuilder.RenameTable(
                name: "ProgrammingLanguages",
                newName: "ProgramminLanguages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProgramminLanguages",
                table: "ProgramminLanguages",
                column: "Id");
        }
    }
}
