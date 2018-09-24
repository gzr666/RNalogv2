using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RadniNalog.Data.Migrations
{
    public partial class test6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "NadzorZaposlenika_NadzornaOsoba",
                table: "RadniNalog",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "NadzorZaposlenika_Povremeni",
                table: "RadniNalog",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "NadzorZaposlenika_Trajni",
                table: "RadniNalog",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ObukaZaposlenika_Nepoduceni",
                table: "RadniNalog",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ObukaZaposlenika_Poduceni",
                table: "RadniNalog",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ObukaZaposlenika_Pripravnici",
                table: "RadniNalog",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ObukaZaposlenika_Strucni",
                table: "RadniNalog",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OsiguranjeMjestaRada_SN",
                table: "RadniNalog",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OsiguranjeMjestaRada_VN",
                table: "RadniNalog",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TipRada_Neplanirani",
                table: "RadniNalog",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TipRada_Planirani",
                table: "RadniNalog",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TipRada_Posebni",
                table: "RadniNalog",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TipRada_Slozeni",
                table: "RadniNalog",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TipPostrojenjaID",
                table: "MjestoRada",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TipPostrojenja",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipPostrojenja", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MjestoRada_TipPostrojenjaID",
                table: "MjestoRada",
                column: "TipPostrojenjaID");

            migrationBuilder.AddForeignKey(
                name: "FK_MjestoRada_TipPostrojenja_TipPostrojenjaID",
                table: "MjestoRada",
                column: "TipPostrojenjaID",
                principalTable: "TipPostrojenja",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MjestoRada_TipPostrojenja_TipPostrojenjaID",
                table: "MjestoRada");

            migrationBuilder.DropTable(
                name: "TipPostrojenja");

            migrationBuilder.DropIndex(
                name: "IX_MjestoRada_TipPostrojenjaID",
                table: "MjestoRada");

            migrationBuilder.DropColumn(
                name: "IspraveZaRad_DopusnicaIskljucenjeRad",
                table: "RadniNalog");

            migrationBuilder.DropColumn(
                name: "IspraveZaRad_DopusnicaZaRad",
                table: "RadniNalog");

            migrationBuilder.DropColumn(
                name: "IspraveZaRad_IzjavaRukovoditelja",
                table: "RadniNalog");

            migrationBuilder.DropColumn(
                name: "NadzorZaposlenika_NadzornaOsoba",
                table: "RadniNalog");

            migrationBuilder.DropColumn(
                name: "NadzorZaposlenika_Povremeni",
                table: "RadniNalog");

            migrationBuilder.DropColumn(
                name: "NadzorZaposlenika_Trajni",
                table: "RadniNalog");

            migrationBuilder.DropColumn(
                name: "ObukaZaposlenika_Nepoduceni",
                table: "RadniNalog");

            migrationBuilder.DropColumn(
                name: "ObukaZaposlenika_Poduceni",
                table: "RadniNalog");

            migrationBuilder.DropColumn(
                name: "ObukaZaposlenika_Pripravnici",
                table: "RadniNalog");

            migrationBuilder.DropColumn(
                name: "ObukaZaposlenika_Strucni",
                table: "RadniNalog");

            migrationBuilder.DropColumn(
                name: "OsiguranjeMjestaRada_SN",
                table: "RadniNalog");

            migrationBuilder.DropColumn(
                name: "OsiguranjeMjestaRada_VN",
                table: "RadniNalog");

            migrationBuilder.DropColumn(
                name: "TipRada_Neplanirani",
                table: "RadniNalog");

            migrationBuilder.DropColumn(
                name: "TipRada_Planirani",
                table: "RadniNalog");

            migrationBuilder.DropColumn(
                name: "TipRada_Posebni",
                table: "RadniNalog");

            migrationBuilder.DropColumn(
                name: "TipRada_Slozeni",
                table: "RadniNalog");

            migrationBuilder.DropColumn(
                name: "TipPostrojenjaID",
                table: "MjestoRada");
        }
    }
}
