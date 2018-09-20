using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RadniNalog.Data.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KategorijaRadaID",
                table: "RadniNalog",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KrajRadova",
                table: "RadniNalog",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Napomena",
                table: "RadniNalog",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PocetakRadova",
                table: "RadniNalog",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prilog",
                table: "RadniNalog",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RadVezanUZ",
                table: "RadniNalog",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RadniZadatakBroj",
                table: "RadniNalog",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PodrucjeID",
                table: "MjestoRada",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "KategorijaRada",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BeznaponskoStanje = table.Column<bool>(nullable: false),
                    BlizinaNapona = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KategorijaRada", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Podrucje",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Podrucje", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RadniNalog_KategorijaRadaID",
                table: "RadniNalog",
                column: "KategorijaRadaID");

            migrationBuilder.CreateIndex(
                name: "IX_MjestoRada_PodrucjeID",
                table: "MjestoRada",
                column: "PodrucjeID");

            migrationBuilder.AddForeignKey(
                name: "FK_MjestoRada_Podrucje_PodrucjeID",
                table: "MjestoRada",
                column: "PodrucjeID",
                principalTable: "Podrucje",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RadniNalog_KategorijaRada_KategorijaRadaID",
                table: "RadniNalog",
                column: "KategorijaRadaID",
                principalTable: "KategorijaRada",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MjestoRada_Podrucje_PodrucjeID",
                table: "MjestoRada");

            migrationBuilder.DropForeignKey(
                name: "FK_RadniNalog_KategorijaRada_KategorijaRadaID",
                table: "RadniNalog");

            migrationBuilder.DropTable(
                name: "KategorijaRada");

            migrationBuilder.DropTable(
                name: "Podrucje");

            migrationBuilder.DropIndex(
                name: "IX_RadniNalog_KategorijaRadaID",
                table: "RadniNalog");

            migrationBuilder.DropIndex(
                name: "IX_MjestoRada_PodrucjeID",
                table: "MjestoRada");

            migrationBuilder.DropColumn(
                name: "KategorijaRadaID",
                table: "RadniNalog");

            migrationBuilder.DropColumn(
                name: "KrajRadova",
                table: "RadniNalog");

            migrationBuilder.DropColumn(
                name: "Napomena",
                table: "RadniNalog");

            migrationBuilder.DropColumn(
                name: "PocetakRadova",
                table: "RadniNalog");

            migrationBuilder.DropColumn(
                name: "Prilog",
                table: "RadniNalog");

            migrationBuilder.DropColumn(
                name: "RadVezanUZ",
                table: "RadniNalog");

            migrationBuilder.DropColumn(
                name: "RadniZadatakBroj",
                table: "RadniNalog");

            migrationBuilder.DropColumn(
                name: "PodrucjeID",
                table: "MjestoRada");
        }
    }
}
