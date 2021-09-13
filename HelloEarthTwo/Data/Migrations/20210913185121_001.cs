using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HelloEarthTwo.Data.Migrations
{
    public partial class _001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Heroes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CodeName = table.Column<string>(type: "text", nullable: true),
                    Powers = table.Column<string>(type: "text", nullable: true),
                    SecretId = table.Column<string>(type: "text", nullable: true),
                    HomeWorld = table.Column<string>(type: "text", nullable: true),
                    TeamAffiliation = table.Column<string>(type: "text", nullable: true),
                    IsClone = table.Column<string>(type: "text", nullable: true),
                    TimeStamp = table.Column<string>(type: "text", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    IsAntiHero = table.Column<bool>(type: "boolean", nullable: true),
                    IsVillian = table.Column<bool>(type: "boolean", nullable: true)
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
