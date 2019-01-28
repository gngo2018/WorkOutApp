using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkOut.Database.Migrations
{
    public partial class SetInfoAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExerciseTransactionTableAccess",
                columns: table => new
                {
                    ExerciseTransactionEntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SetInfoEntityId = table.Column<int>(nullable: false),
                    WorkOutEntityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseTransactionTableAccess", x => x.ExerciseTransactionEntityId);
                });

            migrationBuilder.CreateTable(
                name: "SetInfoTableAccess",
                columns: table => new
                {
                    SetInfoEntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Set = table.Column<string>(nullable: true),
                    OwnerId = table.Column<int>(nullable: false),
                    Rep = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetInfoTableAccess", x => x.SetInfoEntityId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseTransactionTableAccess");

            migrationBuilder.DropTable(
                name: "SetInfoTableAccess");
        }
    }
}
