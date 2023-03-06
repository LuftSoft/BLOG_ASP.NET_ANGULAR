using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogAppAPI.Migrations
{
    /// <inheritdoc />
    public partial class blog_v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Author_Users_CustomUserId",
                table: "Author");

            migrationBuilder.DropIndex(
                name: "IX_Author_CustomUserId",
                table: "Author");

            migrationBuilder.AlterColumn<string>(
                name: "CustomUserId",
                table: "Author",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Author_CustomUserId",
                table: "Author",
                column: "CustomUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Author_Users_CustomUserId",
                table: "Author",
                column: "CustomUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Author_Users_CustomUserId",
                table: "Author");

            migrationBuilder.DropIndex(
                name: "IX_Author_CustomUserId",
                table: "Author");

            migrationBuilder.AlterColumn<string>(
                name: "CustomUserId",
                table: "Author",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Author_CustomUserId",
                table: "Author",
                column: "CustomUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Author_Users_CustomUserId",
                table: "Author",
                column: "CustomUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
