using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RadniNalog.Data.Migrations
{
    public partial class AddedTipDAS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipDasID",
                table: "MjestoRada",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TipDas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipDas", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MjestoRada_TipDasID",
                table: "MjestoRada",
                column: "TipDasID");

            migrationBuilder.AddForeignKey(
                name: "FK_MjestoRada_TipDas_TipDasID",
                table: "MjestoRada",
                column: "TipDasID",
                principalTable: "TipDas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MjestoRada_TipDas_TipDasID",
                table: "MjestoRada");

            migrationBuilder.DropTable(
                name: "TipDas");

            migrationBuilder.DropIndex(
                name: "IX_MjestoRada_TipDasID",
                table: "MjestoRada");

            migrationBuilder.DropColumn(
                name: "TipDasID",
                table: "MjestoRada");
        }
    }
}
