using Microsoft.EntityFrameworkCore.Migrations;

namespace RadniNalog.Data.Migrations
{
    public partial class test16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IspraveZaRad_DopusnicaIskljucenjeRad",
                table: "RadniNalog");

            migrationBuilder.DropColumn(
                name: "IspraveZaRad_DopusnicaZaRad",
                table: "RadniNalog");

            migrationBuilder.DropColumn(
                name: "IspraveZaRad_IzjavaRukovoditelja",
                table: "RadniNalog");

            migrationBuilder.CreateTable(
                name: "nalog_isprava_rad",
                columns: table => new
                {
                    DopusnicaZaRad = table.Column<bool>(nullable: false),
                    DopusnicaIskljucenjeRad = table.Column<bool>(nullable: false),
                    IzjavaRukovoditelja = table.Column<bool>(nullable: false),
                    RNalogID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nalog_isprava_rad", x => x.RNalogID);
                    table.ForeignKey(
                        name: "FK_nalog_isprava_rad_RadniNalog_RNalogID",
                        column: x => x.RNalogID,
                        principalTable: "RadniNalog",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "nalog_isprava_rad");

            migrationBuilder.AddColumn<bool>(
                name: "IspraveZaRad_DopusnicaIskljucenjeRad",
                table: "RadniNalog",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IspraveZaRad_DopusnicaZaRad",
                table: "RadniNalog",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IspraveZaRad_IzjavaRukovoditelja",
                table: "RadniNalog",
                nullable: false,
                defaultValue: false);
        }
    }
}
