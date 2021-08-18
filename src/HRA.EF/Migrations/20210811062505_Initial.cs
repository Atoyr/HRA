using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRA.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Horses",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SexType = table.Column<int>(type: "int", nullable: false),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Father = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mother = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginRanch = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horses", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "RaceResultSummaries",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RaceID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceResultSummaries", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    No = table.Column<int>(type: "int", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false),
                    Round = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Course = table.Column<int>(type: "int", nullable: false),
                    Distance = table.Column<int>(type: "int", nullable: false),
                    NumberOfHorse = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Times",
                columns: table => new
                {
                    RaceID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Range = table.Column<int>(type: "int", nullable: false),
                    RaceTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SectionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RaceResultSummaryID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Times", x => x.RaceID);
                    table.ForeignKey(
                        name: "FK_Times_RaceResultSummaries_RaceResultSummaryID",
                        column: x => x.RaceResultSummaryID,
                        principalTable: "RaceResultSummaries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RaceResults",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RaceID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ranking = table.Column<int>(type: "int", nullable: false),
                    GateNo = table.Column<int>(type: "int", nullable: false),
                    HorseNo = table.Column<int>(type: "int", nullable: false),
                    HorseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SexType = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    BurdenWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fluctuation = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Driver = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeRaceID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Diff = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThroughRanking = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Last3F = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Favorite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceResults", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RaceResults_Times_TimeRaceID",
                        column: x => x.TimeRaceID,
                        principalTable: "Times",
                        principalColumn: "RaceID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RaceResults_TimeRaceID",
                table: "RaceResults",
                column: "TimeRaceID");

            migrationBuilder.CreateIndex(
                name: "IX_Times_RaceResultSummaryID",
                table: "Times",
                column: "RaceResultSummaryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Horses");

            migrationBuilder.DropTable(
                name: "RaceResults");

            migrationBuilder.DropTable(
                name: "Races");

            migrationBuilder.DropTable(
                name: "Times");

            migrationBuilder.DropTable(
                name: "RaceResultSummaries");
        }
    }
}
