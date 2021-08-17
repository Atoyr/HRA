using Microsoft.EntityFrameworkCore.Migrations;

namespace HRA.Migrations
{
    public partial class fixrelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaceResults_Times_TimeRaceID",
                table: "RaceResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Times",
                table: "Times");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RaceResults",
                table: "RaceResults");

            migrationBuilder.DropIndex(
                name: "IX_RaceResults_TimeRaceID",
                table: "RaceResults");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "RaceResults");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "RaceResults");

            migrationBuilder.DropColumn(
                name: "BurdenWeight",
                table: "RaceResults");

            migrationBuilder.DropColumn(
                name: "Driver",
                table: "RaceResults");

            migrationBuilder.DropColumn(
                name: "Fluctuation",
                table: "RaceResults");

            migrationBuilder.DropColumn(
                name: "GateNo",
                table: "RaceResults");

            migrationBuilder.DropColumn(
                name: "HorseNo",
                table: "RaceResults");

            migrationBuilder.DropColumn(
                name: "SexType",
                table: "RaceResults");

            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "RaceResults",
                newName: "Last4F");

            migrationBuilder.AddColumn<string>(
                name: "HorseName",
                table: "Times",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Place",
                table: "Races",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "RaceID",
                table: "RaceResultSummaries",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RaceID",
                table: "RaceResults",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HorseName",
                table: "RaceResults",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TimeHorseName",
                table: "RaceResults",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TimeRange",
                table: "RaceResults",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Times",
                table: "Times",
                columns: new[] { "RaceID", "HorseName", "Range" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_RaceResults",
                table: "RaceResults",
                columns: new[] { "RaceID", "HorseName" });

            migrationBuilder.CreateTable(
                name: "RaceCards",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RaceID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GateNo = table.Column<int>(type: "int", nullable: false),
                    HorseNo = table.Column<int>(type: "int", nullable: false),
                    HorseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SexType = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    BurdenWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fluctuation = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Driver = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Favorite = table.Column<int>(type: "int", nullable: false),
                    ResultRaceID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ResultHorseName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceCards", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RaceCards_RaceResults_ResultRaceID_ResultHorseName",
                        columns: x => new { x.ResultRaceID, x.ResultHorseName },
                        principalTable: "RaceResults",
                        principalColumns: new[] { "RaceID", "HorseName" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RaceResultSummaries_RaceID",
                table: "RaceResultSummaries",
                column: "RaceID",
                unique: true,
                filter: "[RaceID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RaceResults_TimeRaceID_TimeHorseName_TimeRange",
                table: "RaceResults",
                columns: new[] { "TimeRaceID", "TimeHorseName", "TimeRange" });

            migrationBuilder.CreateIndex(
                name: "IX_RaceCards_ResultRaceID_ResultHorseName",
                table: "RaceCards",
                columns: new[] { "ResultRaceID", "ResultHorseName" });

            migrationBuilder.AddForeignKey(
                name: "FK_RaceResults_Times_TimeRaceID_TimeHorseName_TimeRange",
                table: "RaceResults",
                columns: new[] { "TimeRaceID", "TimeHorseName", "TimeRange" },
                principalTable: "Times",
                principalColumns: new[] { "RaceID", "HorseName", "Range" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RaceResultSummaries_Races_RaceID",
                table: "RaceResultSummaries",
                column: "RaceID",
                principalTable: "Races",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaceResults_Times_TimeRaceID_TimeHorseName_TimeRange",
                table: "RaceResults");

            migrationBuilder.DropForeignKey(
                name: "FK_RaceResultSummaries_Races_RaceID",
                table: "RaceResultSummaries");

            migrationBuilder.DropTable(
                name: "RaceCards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Times",
                table: "Times");

            migrationBuilder.DropIndex(
                name: "IX_RaceResultSummaries_RaceID",
                table: "RaceResultSummaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RaceResults",
                table: "RaceResults");

            migrationBuilder.DropIndex(
                name: "IX_RaceResults_TimeRaceID_TimeHorseName_TimeRange",
                table: "RaceResults");

            migrationBuilder.DropColumn(
                name: "HorseName",
                table: "Times");

            migrationBuilder.DropColumn(
                name: "Place",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "TimeHorseName",
                table: "RaceResults");

            migrationBuilder.DropColumn(
                name: "TimeRange",
                table: "RaceResults");

            migrationBuilder.RenameColumn(
                name: "Last4F",
                table: "RaceResults",
                newName: "Weight");

            migrationBuilder.AlterColumn<string>(
                name: "RaceID",
                table: "RaceResultSummaries",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HorseName",
                table: "RaceResults",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "RaceID",
                table: "RaceResults",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ID",
                table: "RaceResults",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "RaceResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "BurdenWeight",
                table: "RaceResults",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Driver",
                table: "RaceResults",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Fluctuation",
                table: "RaceResults",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "GateNo",
                table: "RaceResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HorseNo",
                table: "RaceResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SexType",
                table: "RaceResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Times",
                table: "Times",
                column: "RaceID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RaceResults",
                table: "RaceResults",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_RaceResults_TimeRaceID",
                table: "RaceResults",
                column: "TimeRaceID");

            migrationBuilder.AddForeignKey(
                name: "FK_RaceResults_Times_TimeRaceID",
                table: "RaceResults",
                column: "TimeRaceID",
                principalTable: "Times",
                principalColumn: "RaceID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
