using Microsoft.EntityFrameworkCore.Migrations;

namespace RadniNalog.Data.Migrations
{
    public partial class test17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KategorijaRada_BeznaponskoStanje",
                table: "RadniNalog");

            migrationBuilder.DropColumn(
                name: "KategorijaRada_BlizinaNapona",
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

            migrationBuilder.CreateTable(
                name: "nalog_kategorija_rad",
                columns: table => new
                {
                    BeznaponskoStanje = table.Column<bool>(nullable: false),
                    BlizinaNapona = table.Column<bool>(nullable: false),
                    RNalogID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nalog_kategorija_rad", x => x.RNalogID);
                    table.ForeignKey(
                        name: "FK_nalog_kategorija_rad_RadniNalog_RNalogID",
                        column: x => x.RNalogID,
                        principalTable: "RadniNalog",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "nalog_nadzor_zaposlenika",
                columns: table => new
                {
                    Trajni = table.Column<bool>(nullable: false),
                    Povremeni = table.Column<bool>(nullable: false),
                    NadzornaOsoba = table.Column<string>(nullable: true),
                    RNalogID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nalog_nadzor_zaposlenika", x => x.RNalogID);
                    table.ForeignKey(
                        name: "FK_nalog_nadzor_zaposlenika_RadniNalog_RNalogID",
                        column: x => x.RNalogID,
                        principalTable: "RadniNalog",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "nalog_obuka_zaposlenika",
                columns: table => new
                {
                    Strucni = table.Column<bool>(nullable: false),
                    Poduceni = table.Column<bool>(nullable: false),
                    Nepoduceni = table.Column<bool>(nullable: false),
                    Pripravnici = table.Column<bool>(nullable: false),
                    RNalogID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nalog_obuka_zaposlenika", x => x.RNalogID);
                    table.ForeignKey(
                        name: "FK_nalog_obuka_zaposlenika_RadniNalog_RNalogID",
                        column: x => x.RNalogID,
                        principalTable: "RadniNalog",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "nalog_osiguranje_mjesta_rad",
                columns: table => new
                {
                    VN = table.Column<bool>(nullable: false),
                    SN = table.Column<bool>(nullable: false),
                    RNalogID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nalog_osiguranje_mjesta_rad", x => x.RNalogID);
                    table.ForeignKey(
                        name: "FK_nalog_osiguranje_mjesta_rad_RadniNalog_RNalogID",
                        column: x => x.RNalogID,
                        principalTable: "RadniNalog",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "nalog_tip_rad",
                columns: table => new
                {
                    Planirani = table.Column<bool>(nullable: false),
                    Neplanirani = table.Column<bool>(nullable: false),
                    Slozeni = table.Column<bool>(nullable: false),
                    Posebni = table.Column<bool>(nullable: false),
                    RNalogID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nalog_tip_rad", x => x.RNalogID);
                    table.ForeignKey(
                        name: "FK_nalog_tip_rad_RadniNalog_RNalogID",
                        column: x => x.RNalogID,
                        principalTable: "RadniNalog",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "nalog_kategorija_rad");

            migrationBuilder.DropTable(
                name: "nalog_nadzor_zaposlenika");

            migrationBuilder.DropTable(
                name: "nalog_obuka_zaposlenika");

            migrationBuilder.DropTable(
                name: "nalog_osiguranje_mjesta_rad");

            migrationBuilder.DropTable(
                name: "nalog_tip_rad");

            migrationBuilder.AddColumn<bool>(
                name: "KategorijaRada_BeznaponskoStanje",
                table: "RadniNalog",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "KategorijaRada_BlizinaNapona",
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
        }
    }
}
