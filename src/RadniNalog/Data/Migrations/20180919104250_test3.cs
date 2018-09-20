using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RadniNalog.Data.Migrations
{
    public partial class test3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RadniNalog_KategorijaRada_KategorijaRadaID",
                table: "RadniNalog");

            migrationBuilder.DropTable(
                name: "KategorijaRada");

            migrationBuilder.DropIndex(
                name: "IX_RadniNalog_KategorijaRadaID",
                table: "RadniNalog");

            migrationBuilder.DropColumn(
                name: "KategorijaRadaID",
                table: "RadniNalog");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KategorijaRadaID",
                table: "RadniNalog",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_RadniNalog_KategorijaRadaID",
                table: "RadniNalog",
                column: "KategorijaRadaID");

            migrationBuilder.AddForeignKey(
                name: "FK_RadniNalog_KategorijaRada_KategorijaRadaID",
                table: "RadniNalog",
                column: "KategorijaRadaID",
                principalTable: "KategorijaRada",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
