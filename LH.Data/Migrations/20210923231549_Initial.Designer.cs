﻿// <auto-generated />
using System;
using LH.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LH.Data.Migrations
{
    [DbContext(typeof(LifeHackDbContext))]
    [Migration("20210923231549_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LH.Business.Events.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int?>("RepeatPatternId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RepeatPatternId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("LH.Business.Events.EventRepeatPattern", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int?>("DayOfMonth")
                        .HasColumnType("int");

                    b.Property<int?>("DayOfWeek")
                        .HasColumnType("int");

                    b.Property<int?>("MaxNumberOfRepeats")
                        .HasColumnType("int");

                    b.Property<int?>("MonthOfYear")
                        .HasColumnType("int");

                    b.Property<int?>("RepeatType")
                        .HasColumnType("int");

                    b.Property<int?>("SeperationCount")
                        .HasColumnType("int");

                    b.Property<int?>("WeekOfMonth")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("EventRepeatPattern");
                });

            modelBuilder.Entity("LH.Business.Schedules.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("LH.Business.Events.ScheduleEvent", b =>
                {
                    b.HasBaseType("LH.Business.Events.Event");

                    b.Property<int>("ScheduleId")
                        .HasColumnType("int");

                    b.HasIndex("ScheduleId");

                    b.ToTable("ScheduleEvents");
                });

            modelBuilder.Entity("LH.Business.Events.Event", b =>
                {
                    b.HasOne("LH.Business.Events.EventRepeatPattern", "RepeatPattern")
                        .WithMany()
                        .HasForeignKey("RepeatPatternId");

                    b.Navigation("RepeatPattern");
                });

            modelBuilder.Entity("LH.Business.Events.ScheduleEvent", b =>
                {
                    b.HasOne("LH.Business.Events.Event", null)
                        .WithOne()
                        .HasForeignKey("LH.Business.Events.ScheduleEvent", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("LH.Business.Schedules.Schedule", "Schedule")
                        .WithMany("ScheduleEvents")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("LH.Business.Schedules.Schedule", b =>
                {
                    b.Navigation("ScheduleEvents");
                });
#pragma warning restore 612, 618
        }
    }
}