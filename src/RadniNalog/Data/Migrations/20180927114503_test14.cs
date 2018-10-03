using Microsoft.EntityFrameworkCore.Migrations;

namespace RadniNalog.Data.Migrations
{
    public partial class test14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IzjavaRukovoditelja1",
                table: "RadniNalog",
                newName: "IspraveZaRadZ_IzjavaRukovoditelja");

            migrationBuilder.RenameColumn(
                name: "DopusnicaZaRad1",
                table: "RadniNalog",
                newName: "IspraveZaRadZ_DopusnicaZaRad");

            migrationBuilder.RenameColumn(
                name: "DopusnicaIskljucenjeRad1",
                table: "RadniNalog",
                newName: "IspraveZaRadZ_DopusnicaIskljucenjeRad");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IspraveZaRadZ_IzjavaRukovoditelja",
                table: "RadniNalog",
                newName: "IzjavaRukovoditelja1");

            migrationBuilder.RenameColumn(
                name: "IspraveZaRadZ_DopusnicaZaRad",
                table: "RadniNalog",
                newName: "DopusnicaZaRad1");

            migrationBuilder.RenameColumn(
                name: "IspraveZaRadZ_DopusnicaIskljucenjeRad",
                table: "RadniNalog",
                newName: "DopusnicaIskljucenjeRad1");
        }
    }
}
