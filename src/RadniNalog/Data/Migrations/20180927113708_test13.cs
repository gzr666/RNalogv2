using Microsoft.EntityFrameworkCore.Migrations;

namespace RadniNalog.Data.Migrations
{
    public partial class test13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IzjavaRukovoditelja",
                table: "RadniNalog",
                newName: "IzjavaRukovoditelja1");

            migrationBuilder.RenameColumn(
                name: "DopusnicaZaRad",
                table: "RadniNalog",
                newName: "DopusnicaZaRad1");

            migrationBuilder.RenameColumn(
                name: "DopusnicaIskljucenjeRad",
                table: "RadniNalog",
                newName: "DopusnicaIskljucenjeRad1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IzjavaRukovoditelja1",
                table: "RadniNalog",
                newName: "IzjavaRukovoditelja");

            migrationBuilder.RenameColumn(
                name: "DopusnicaZaRad1",
                table: "RadniNalog",
                newName: "DopusnicaZaRad");

            migrationBuilder.RenameColumn(
                name: "DopusnicaIskljucenjeRad1",
                table: "RadniNalog",
                newName: "DopusnicaIskljucenjeRad");
        }
    }
}
