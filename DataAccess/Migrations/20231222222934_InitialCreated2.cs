using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreated2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PetId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PetId",
                table: "Users",
                column: "PetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Pets_PetId",
                table: "Users",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Pets_PetId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PetId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PetId",
                table: "Users");
        }
    }
}
