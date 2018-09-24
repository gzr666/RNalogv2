using Microsoft.EntityFrameworkCore.Migrations;

namespace RadniNalog.Data.Migrations
{
    public partial class test7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MjestoRada_Podrucje_PodrucjeID",
                table: "MjestoRada");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Podrucje",
                table: "Podrucje");

            migrationBuilder.RenameTable(
                name: "Podrucje",
                newName: "Podrucja");

            migrationBuilder.AddColumn<string>(
                name: "Sifra",
                table: "VrstaRada",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Podrucja",
                table: "Podrucja",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_MjestoRada_Podrucja_PodrucjeID",
                table: "MjestoRada",
                column: "PodrucjeID",
                principalTable: "Podrucja",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MjestoRada_Podrucja_PodrucjeID",
                table: "MjestoRada");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Podrucja",
                table: "Podrucja");

            migrationBuilder.DropColumn(
                name: "Sifra",
                table: "VrstaRada");

            migrationBuilder.RenameTable(
                name: "Podrucja",
                newName: "Podrucje");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Podrucje",
                table: "Podrucje",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_MjestoRada_Podrucje_PodrucjeID",
                table: "MjestoRada",
                column: "PodrucjeID",
                principalTable: "Podrucje",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
