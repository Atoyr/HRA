using Microsoft.EntityFrameworkCore.Migrations;

namespace HRA.Migrations
{
    public partial class fixrelation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "MareOnly",
                table: "Races",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "RaceClass",
                table: "Races",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Races",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "RaceID",
                table: "RaceCards",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HorseName",
                table: "RaceCards",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CoatColor",
                table: "RaceCards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "RaceCards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RaceRecord",
                table: "RaceCards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "RaceCards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Trainer",
                table: "RaceCards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RaceCards_HorseName",
                table: "RaceCards",
                column: "HorseName");

            migrationBuilder.CreateIndex(
                name: "IX_RaceCards_RaceID",
                table: "RaceCards",
                column: "RaceID");

            migrationBuilder.AddForeignKey(
                name: "FK_RaceCards_Horses_HorseName",
                table: "RaceCards",
                column: "HorseName",
                principalTable: "Horses",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RaceCards_Races_RaceID",
                table: "RaceCards",
                column: "RaceID",
                principalTable: "Races",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaceCards_Horses_HorseName",
                table: "RaceCards");

            migrationBuilder.DropForeignKey(
                name: "FK_RaceCards_Races_RaceID",
                table: "RaceCards");

            migrationBuilder.DropIndex(
                name: "IX_RaceCards_HorseName",
                table: "RaceCards");

            migrationBuilder.DropIndex(
                name: "IX_RaceCards_RaceID",
                table: "RaceCards");

            migrationBuilder.DropColumn(
                name: "MareOnly",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "RaceClass",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "CoatColor",
                table: "RaceCards");

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "RaceCards");

            migrationBuilder.DropColumn(
                name: "RaceRecord",
                table: "RaceCards");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "RaceCards");

            migrationBuilder.DropColumn(
                name: "Trainer",
                table: "RaceCards");

            migrationBuilder.AlterColumn<string>(
                name: "RaceID",
                table: "RaceCards",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HorseName",
                table: "RaceCards",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
