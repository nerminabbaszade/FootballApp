﻿// <auto-generated />
using System;
using FA.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FA.DAL.Migrations
{
    [DbContext(typeof(FADbContext))]
    [Migration("20240521225441_last")]
    partial class last
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FA.DAL.Model.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("CreateDate")
                        .HasColumnType("date");

                    b.Property<int>("GuestTeamGoalCount")
                        .HasColumnType("int");

                    b.Property<int>("GuestTeamId")
                        .HasColumnType("int");

                    b.Property<int>("HostTeamGoalCount")
                        .HasColumnType("int");

                    b.Property<int>("HostTeamId")
                        .HasColumnType("int");

                    b.Property<string>("StadiumName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WeekNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GuestTeamId");

                    b.HasIndex("HostTeamId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("FA.DAL.Model.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("CreateDate")
                        .HasColumnType("date");

                    b.Property<int>("FormNumber")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("GoalCount")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("FA.DAL.Model.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ConcededGoalCCount")
                        .HasColumnType("int");

                    b.Property<DateOnly>("CreateDate")
                        .HasColumnType("date");

                    b.Property<int>("DrawCount")
                        .HasColumnType("int");

                    b.Property<int>("LostCount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Point")
                        .HasColumnType("int");

                    b.Property<int>("ScoredGoalCount")
                        .HasColumnType("int");

                    b.Property<int>("WinCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("FA.DAL.Model.Game", b =>
                {
                    b.HasOne("FA.DAL.Model.Team", "GuestTeam")
                        .WithMany("GuestGames")
                        .HasForeignKey("GuestTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FA.DAL.Model.Team", "HostTeam")
                        .WithMany("HostGames")
                        .HasForeignKey("HostTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GuestTeam");

                    b.Navigation("HostTeam");
                });

            modelBuilder.Entity("FA.DAL.Model.Player", b =>
                {
                    b.HasOne("FA.DAL.Model.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("FA.DAL.Model.Team", b =>
                {
                    b.Navigation("GuestGames");

                    b.Navigation("HostGames");

                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}