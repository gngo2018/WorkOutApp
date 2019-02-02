using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkOut.Database.Migrations
{
    public partial class OwnerIdAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "ExerciseTransactionTableAccess",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "ExerciseTransactionTableAccess");
        }
    }
}
