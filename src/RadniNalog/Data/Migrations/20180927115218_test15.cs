using Microsoft.EntityFrameworkCore.Migrations;

namespace RadniNalog.Data.Migrations
{
    public partial class test15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IspraveZaRadZ_IzjavaRukovoditelja",
                table: "RadniNalog",
                newName: "IspraveZaRad_IzjavaRukovoditelja");

            migrationBuilder.RenameColumn(
                name: "IspraveZaRadZ_DopusnicaZaRad",
                table: "RadniNalog",
                newName: "IspraveZaRad_DopusnicaZaRad");

            migrationBuilder.RenameColumn(
                name: "IspraveZaRadZ_DopusnicaIskljucenjeRad",
                table: "RadniNalog",
                newName: "IspraveZaRad_DopusnicaIskljucenjeRad");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IspraveZaRad_IzjavaRukovoditelja",
                table: "RadniNalog",
                newName: "IspraveZaRadZ_IzjavaRukovoditelja");

            migrationBuilder.RenameColumn(
                name: "IspraveZaRad_DopusnicaZaRad",
                table: "RadniNalog",
                newName: "IspraveZaRadZ_DopusnicaZaRad");

            migrationBuilder.RenameColumn(
                name: "IspraveZaRad_DopusnicaIskljucenjeRad",
                table: "RadniNalog",
                newName: "IspraveZaRadZ_DopusnicaIskljucenjeRad");
        }
    }
}
