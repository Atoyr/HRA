﻿// <auto-generated />
using System;
using HRA.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HRA.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20210812143917_fix relation")]
    partial class fixrelation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HRA.Data.Horse", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("Father")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mother")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OriginPlace")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OriginRanch")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SexType")
                        .HasColumnType("int");

                    b.HasKey("Name");

                    b.ToTable("Horses");
                });

            modelBuilder.Entity("HRA.Data.Race", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Course")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<int>("Distance")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("No")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfHorse")
                        .HasColumnType("int");

                    b.Property<int>("Place")
                        .HasColumnType("int");

                    b.Property<int>("Round")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("HRA.Data.RaceCard", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<decimal>("BurdenWeight")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Driver")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Favorite")
                        .HasColumnType("int");

                    b.Property<decimal>("Fluctuation")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("GateNo")
                        .HasColumnType("int");

                    b.Property<string>("HorseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HorseNo")
                        .HasColumnType("int");

                    b.Property<string>("RaceID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResultHorseName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ResultRaceID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("SexType")
                        .HasColumnType("int");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("ResultRaceID", "ResultHorseName");

                    b.ToTable("RaceCards");
                });

            modelBuilder.Entity("HRA.Data.RaceResult", b =>
                {
                    b.Property<string>("RaceID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("HorseName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Diff")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Favorite")
                        .HasColumnType("int");

                    b.Property<decimal>("Last3F")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Last4F")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Ranking")
                        .HasColumnType("int");

                    b.Property<string>("ThroughRanking")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TimeHorseName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TimeRaceID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("TimeRange")
                        .HasColumnType("int");

                    b.HasKey("RaceID", "HorseName");

                    b.HasIndex("TimeRaceID", "TimeHorseName", "TimeRange");

                    b.ToTable("RaceResults");
                });

            modelBuilder.Entity("HRA.Data.RaceResultSummary", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RaceID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("RaceID")
                        .IsUnique()
                        .HasFilter("[RaceID] IS NOT NULL");

                    b.ToTable("RaceResultSummaries");
                });

            modelBuilder.Entity("HRA.Data.Time", b =>
                {
                    b.Property<string>("RaceID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("HorseName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Range")
                        .HasColumnType("int");

                    b.Property<string>("RaceResultSummaryID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("RaceTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SectionTime")
                        .HasColumnType("datetime2");

                    b.HasKey("RaceID", "HorseName", "Range");

                    b.HasIndex("RaceResultSummaryID");

                    b.ToTable("Times");
                });

            modelBuilder.Entity("HRA.Data.RaceCard", b =>
                {
                    b.HasOne("HRA.Data.RaceResult", "Result")
                        .WithMany()
                        .HasForeignKey("ResultRaceID", "ResultHorseName");

                    b.Navigation("Result");
                });

            modelBuilder.Entity("HRA.Data.RaceResult", b =>
                {
                    b.HasOne("HRA.Data.Time", "Time")
                        .WithMany()
                        .HasForeignKey("TimeRaceID", "TimeHorseName", "TimeRange");

                    b.Navigation("Time");
                });

            modelBuilder.Entity("HRA.Data.RaceResultSummary", b =>
                {
                    b.HasOne("HRA.Data.Race", null)
                        .WithOne("ResultSummary")
                        .HasForeignKey("HRA.Data.RaceResultSummary", "RaceID");
                });

            modelBuilder.Entity("HRA.Data.Time", b =>
                {
                    b.HasOne("HRA.Data.RaceResultSummary", null)
                        .WithMany("ThrohghTimes")
                        .HasForeignKey("RaceResultSummaryID");
                });

            modelBuilder.Entity("HRA.Data.Race", b =>
                {
                    b.Navigation("ResultSummary");
                });

            modelBuilder.Entity("HRA.Data.RaceResultSummary", b =>
                {
                    b.Navigation("ThrohghTimes");
                });
#pragma warning restore 612, 618
        }
    }
}
