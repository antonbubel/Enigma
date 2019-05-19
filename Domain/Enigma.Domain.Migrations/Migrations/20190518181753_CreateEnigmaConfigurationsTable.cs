using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Enigma.Domain.Migrations.Migrations
{
    public partial class CreateEnigmaConfigurationsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnigmaConfigurations",
                columns: table => new
                {
                    EnigmaConfigurationId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    FirstRotor = table.Column<int>(nullable: false),
                    SecondRotor = table.Column<int>(nullable: false),
                    ThirdRotor = table.Column<int>(nullable: false),
                    Reflector = table.Column<int>(nullable: false),
                    PlugboardMap = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnigmaConfigurations", x => x.EnigmaConfigurationId);
                    table.ForeignKey(
                        name: "FK_EnigmaConfigurations_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnigmaConfigurations_ApplicationUserId",
                table: "EnigmaConfigurations",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnigmaConfigurations");
        }
    }
}
