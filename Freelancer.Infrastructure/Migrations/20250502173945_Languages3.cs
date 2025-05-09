using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Freelancer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Languages3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FreelancerUserLanguages");

            migrationBuilder.DropColumn(
                name: "isSelected",
                table: "Languages");

            migrationBuilder.CreateTable(
                name: "ProgrammingSkill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    languageId = table.Column<int>(type: "int", nullable: false),
                    ExperienceLevel = table.Column<int>(type: "int", nullable: false),
                    FreelancerUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrammingSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgrammingSkill_FreelancerUser_FreelancerUserId",
                        column: x => x.FreelancerUserId,
                        principalTable: "FreelancerUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProgrammingSkill_Languages_languageId",
                        column: x => x.languageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammingSkill_FreelancerUserId",
                table: "ProgrammingSkill",
                column: "FreelancerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammingSkill_languageId",
                table: "ProgrammingSkill",
                column: "languageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgrammingSkill");

            migrationBuilder.AddColumn<bool>(
                name: "isSelected",
                table: "Languages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "FreelancerUserLanguages",
                columns: table => new
                {
                    LanguagesId = table.Column<int>(type: "int", nullable: false),
                    usersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreelancerUserLanguages", x => new { x.LanguagesId, x.usersId });
                    table.ForeignKey(
                        name: "FK_FreelancerUserLanguages_FreelancerUser_usersId",
                        column: x => x.usersId,
                        principalTable: "FreelancerUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FreelancerUserLanguages_Languages_LanguagesId",
                        column: x => x.LanguagesId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FreelancerUserLanguages_usersId",
                table: "FreelancerUserLanguages",
                column: "usersId");
        }
    }
}
