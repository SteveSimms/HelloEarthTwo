using Microsoft.EntityFrameworkCore.Migrations;

namespace HelloEarthTwo.Migrations
{
    public partial class HeroesDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Heroes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Powers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecretId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeWorld = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeamAffiliation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsClone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heroes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Heroes");
        }
    }
}
