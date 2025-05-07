using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Freelancer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Languages2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Languages_FreelancerUser_FreelancerUserId",
                table: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_Languages_FreelancerUserId",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "FreelancerUserId",
                table: "Languages");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FreelancerUserLanguages");

            migrationBuilder.AddColumn<int>(
                name: "FreelancerUserId",
                table: "Languages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Languages_FreelancerUserId",
                table: "Languages",
                column: "FreelancerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Languages_FreelancerUser_FreelancerUserId",
                table: "Languages",
                column: "FreelancerUserId",
                principalTable: "FreelancerUser",
                principalColumn: "Id");
        }
    }
}
