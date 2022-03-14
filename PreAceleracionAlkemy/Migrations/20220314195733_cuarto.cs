using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PreAceleracionAlkemy.Migrations
{
    public partial class cuarto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserId",
                schema: "usuarios",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_UserId",
                schema: "usuarios",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserId",
                schema: "usuarios",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "usuarios",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                schema: "usuarios",
                table: "Posts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_UserId",
                schema: "usuarios",
                table: "Posts",
                column: "UserId",
                principalSchema: "usuarios",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_UserId",
                schema: "usuarios",
                table: "Posts");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                schema: "usuarios",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "usuarios",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                schema: "usuarios",
                table: "Comments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserId",
                schema: "usuarios",
                table: "Comments",
                column: "UserId",
                principalSchema: "usuarios",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_UserId",
                schema: "usuarios",
                table: "Posts",
                column: "UserId",
                principalSchema: "usuarios",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
