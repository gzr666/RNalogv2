using Microsoft.EntityFrameworkCore.Migrations;

namespace RadniNalog.Data.Migrations
{
    public partial class AddedTipDAS2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MjestoRada_TipDas_TipDasID",
                table: "MjestoRada");

            migrationBuilder.AddForeignKey(
                name: "FK_MjestoRada_TipDas_TipDasID",
                table: "MjestoRada",
                column: "TipDasID",
                principalTable: "TipDas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MjestoRada_TipDas_TipDasID",
                table: "MjestoRada");

            migrationBuilder.AddForeignKey(
                name: "FK_MjestoRada_TipDas_TipDasID",
                table: "MjestoRada",
                column: "TipDasID",
                principalTable: "TipDas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
