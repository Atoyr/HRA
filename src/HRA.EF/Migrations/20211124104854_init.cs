using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRA.EF.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Horses",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Father = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mother = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherMother = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherFather = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginRanch = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horses", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "RaceCards",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RaceID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GateNo = table.Column<int>(type: "int", nullable: false),
                    No = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Blinkers = table.Column<bool>(type: "bit", nullable: false),
                    SexType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Jokey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BurdenWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HorseWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fluctuation = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Trainer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Favorite = table.Column<int>(type: "int", nullable: false),
                    Ranking = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Margin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RaceRecord = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Last3F = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceCards", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgeCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pattern = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeightRule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    No = table.Column<int>(type: "int", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false),
                    Place = table.Column<int>(type: "int", nullable: false),
                    Round = table.Column<int>(type: "int", nullable: false),
                    Distance = table.Column<int>(type: "int", nullable: false),
                    Course = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rotate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Wether = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Baba = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Up4F = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Up3F = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FurlongTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfHorse = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Horses");

            migrationBuilder.DropTable(
                name: "RaceCards");

            migrationBuilder.DropTable(
                name: "Races");
        }
    }
}
