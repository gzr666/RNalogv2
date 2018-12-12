using Microsoft.EntityFrameworkCore.Migrations;

namespace RadniNalog.Data.Migrations
{
    public partial class IzvjesceNalog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IzvjIzdatnice",
                table: "RadniNalog",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IzvjNapomena",
                table: "RadniNalog",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IzvjNeizvedeniRadovi",
                table: "RadniNalog",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IzvjOpisIzvRadova",
                table: "RadniNalog",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IzvjOstaliTroskovi",
                table: "RadniNalog",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IzvjPodnio",
                table: "RadniNalog",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IzvjPovratnice",
                table: "RadniNalog",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IzvjPreglEvident",
                table: "RadniNalog",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IzvjPrijevoz",
                table: "RadniNalog",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IzvjPrimio",
                table: "RadniNalog",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IzvjRadnoVrijeme",
                table: "RadniNalog",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IzvjUoceniNedostaci",
                table: "RadniNalog",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IzvjIzdatnice",
                table: "RadniNalog");

            migrationBuilder.DropColumn(
                name: "IzvjNapomena",
                table: "RadniNalog");

            migrationBuilder.DropColumn(
                name: "IzvjNeizvedeniRadovi",
                table: "RadniNalog");

            migrationBuilder.DropColumn(
                name: "IzvjOpisIzvRadova",
                table: "RadniNalog");

            migrationBuilder.DropColumn(
                name: "IzvjOstaliTroskovi",
                table: "RadniNalog");

            migrationBuilder.DropColumn(
                name: "IzvjPodnio",
                table: "RadniNalog");

            migrationBuilder.DropColumn(
                name: "IzvjPovratnice",
                table: "RadniNalog");

            migrationBuilder.DropColumn(
                name: "IzvjPreglEvident",
                table: "RadniNalog");

            migrationBuilder.DropColumn(
                name: "IzvjPrijevoz",
                table: "RadniNalog");

            migrationBuilder.DropColumn(
                name: "IzvjPrimio",
                table: "RadniNalog");

            migrationBuilder.DropColumn(
                name: "IzvjRadnoVrijeme",
                table: "RadniNalog");

            migrationBuilder.DropColumn(
                name: "IzvjUoceniNedostaci",
                table: "RadniNalog");
        }
    }
}
