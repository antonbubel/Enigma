using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Enigma.Domain.Migrations.Migrations
{
    public partial class CreateRotorsConfigurationsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RotorsConfigurations",
                columns: table => new
                {
                    RotorsConfigurationId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    FirstLetter = table.Column<char>(nullable: false),
                    SecondLetter = table.Column<char>(nullable: false),
                    ThirdLetter = table.Column<char>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RotorsConfigurations", x => x.RotorsConfigurationId);
                    table.ForeignKey(
                        name: "FK_RotorsConfigurations_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RotorsConfigurations_ApplicationUserId",
                table: "RotorsConfigurations",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RotorsConfigurations");
        }
    }
}
