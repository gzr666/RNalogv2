using Microsoft.EntityFrameworkCore.Migrations;

namespace RadniNalog.Data.Migrations
{
    public partial class test12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "nalog_isprava_rad");

            migrationBuilder.AddColumn<bool>(
                name: "DopusnicaIskljucenjeRad",
                table: "RadniNalog",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DopusnicaZaRad",
                table: "RadniNalog",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IzjavaRukovoditelja",
                table: "RadniNalog",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DopusnicaIskljucenjeRad",
                table: "RadniNalog");

            migrationBuilder.DropColumn(
                name: "DopusnicaZaRad",
                table: "RadniNalog");

            migrationBuilder.DropColumn(
                name: "IzjavaRukovoditelja",
                table: "RadniNalog");

            migrationBuilder.CreateTable(
                name: "nalog_isprava_rad",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    DopusnicaIskljucenjeRad = table.Column<bool>(nullable: false),
                    DopusnicaZaRad = table.Column<bool>(nullable: false),
                    IzjavaRukovoditelja = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nalog_isprava_rad", x => x.ID);
                    table.ForeignKey(
                        name: "FK_nalog_isprava_rad_RadniNalog_ID",
                        column: x => x.ID,
                        principalTable: "RadniNalog",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
