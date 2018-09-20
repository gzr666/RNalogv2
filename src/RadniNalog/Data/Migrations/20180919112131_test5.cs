using Microsoft.EntityFrameworkCore.Migrations;

namespace RadniNalog.Data.Migrations
{
    public partial class test5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KategorijaRada_BeznaponskoStanje",
                table: "RadniNalog");

            migrationBuilder.DropColumn(
                name: "KategorijaRada_BlizinaNapona",
                table: "RadniNalog");
        }
    }
}
