using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogAppAPI.Migrations
{
    /// <inheritdoc />
    public partial class blog_v6_add_uniquekey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TagDescription",
                table: "Tag",
                type: "ntext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "ntext");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_TagName",
                table: "Tag",
                column: "TagName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Category_CategorySlug",
                table: "Category",
                column: "CategorySlug",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserName",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Tag_TagName",
                table: "Tag");

            migrationBuilder.DropIndex(
                name: "IX_Category_CategorySlug",
                table: "Category");

            migrationBuilder.AlterColumn<string>(
                name: "TagDescription",
                table: "Tag",
                type: "ntext",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "ntext",
                oldNullable: true);
        }
    }
}
