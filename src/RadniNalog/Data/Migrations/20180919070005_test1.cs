using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RadniNalog.Data.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "Izvrsitelj2",
                table: "RadniNalog");

            migrationBuilder.DropColumn(
                name: "Izvrsitelj3",
                table: "RadniNalog");

            migrationBuilder.DropColumn(
                name: "Rukovoditelj",
                table: "RadniNalog");

            migrationBuilder.AlterColumn<string>(
                name: "Datum",
                table: "RadniNalog",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<int>(
                name: "Izvrsitelj2ID",
                table: "RadniNalog",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Izvrsitelj3ID",
                table: "RadniNalog",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RukovoditeljID",
                table: "RadniNalog",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RadniNalog_Izvrsitelj2ID",
                table: "RadniNalog",
                column: "Izvrsitelj2ID");

            migrationBuilder.CreateIndex(
                name: "IX_RadniNalog_Izvrsitelj3ID",
                table: "RadniNalog",
                column: "Izvrsitelj3ID");

            migrationBuilder.CreateIndex(
                name: "IX_RadniNalog_RukovoditeljID",
                table: "RadniNalog",
                column: "RukovoditeljID");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RadniNalog_Zaposlenik_Izvrsitelj2ID",
                table: "RadniNalog",
                column: "Izvrsitelj2ID",
                principalTable: "Zaposlenik",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RadniNalog_Zaposlenik_Izvrsitelj3ID",
                table: "RadniNalog",
                column: "Izvrsitelj3ID",
                principalTable: "Zaposlenik",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RadniNalog_Zaposlenik_RukovoditeljID",
                table: "RadniNalog",
                column: "RukovoditeljID",
                principalTable: "Zaposlenik",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_RadniNalog_Zaposlenik_Izvrsitelj2ID",
                table: "RadniNalog");

            migrationBuilder.DropForeignKey(
                name: "FK_RadniNalog_Zaposlenik_Izvrsitelj3ID",
                table: "RadniNalog");

            migrationBuilder.DropForeignKey(
                name: "FK_RadniNalog_Zaposlenik_RukovoditeljID",
                table: "RadniNalog");

            migrationBuilder.DropIndex(
                name: "IX_RadniNalog_Izvrsitelj2ID",
                table: "RadniNalog");

            migrationBuilder.DropIndex(
                name: "IX_RadniNalog_Izvrsitelj3ID",
                table: "RadniNalog");

            migrationBuilder.DropIndex(
                name: "IX_RadniNalog_RukovoditeljID",
                table: "RadniNalog");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "Izvrsitelj2ID",
                table: "RadniNalog");

            migrationBuilder.DropColumn(
                name: "Izvrsitelj3ID",
                table: "RadniNalog");

            migrationBuilder.DropColumn(
                name: "RukovoditeljID",
                table: "RadniNalog");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Datum",
                table: "RadniNalog",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Izvrsitelj2",
                table: "RadniNalog",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Izvrsitelj3",
                table: "RadniNalog",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rukovoditelj",
                table: "RadniNalog",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }
    }
}
