﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RITest.Database;

#nullable disable

namespace RITest.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230319204530_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RITest.Entities.DrillBlockEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("update_date");

                    b.HasKey("Id");

                    b.ToTable("DrillBlocks");
                });

            modelBuilder.Entity("RITest.Entities.DrillBlockPointEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DrillBlockId")
                        .HasColumnType("integer")
                        .HasColumnName("drill_block_id");

                    b.Property<int>("Sequence")
                        .HasColumnType("integer")
                        .HasColumnName("sequence");

                    b.Property<float>("X")
                        .HasColumnType("real")
                        .HasColumnName("x");

                    b.Property<float>("Y")
                        .HasColumnType("real")
                        .HasColumnName("y");

                    b.Property<float>("Z")
                        .HasColumnType("real")
                        .HasColumnName("z");

                    b.HasKey("Id");

                    b.HasIndex("DrillBlockId");

                    b.ToTable("DrillBlockPoints");
                });

            modelBuilder.Entity("RITest.Entities.HoleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DEPTH")
                        .HasColumnType("integer")
                        .HasColumnName("DEPTH");

                    b.Property<int>("DrillBlockId")
                        .HasColumnType("integer")
                        .HasColumnName("drill_block_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("DrillBlockId");

                    b.ToTable("Holes");
                });

            modelBuilder.Entity("RITest.Entities.HolePointEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("HoleId")
                        .HasColumnType("integer")
                        .HasColumnName("hole_id");

                    b.Property<float>("X")
                        .HasColumnType("real")
                        .HasColumnName("x");

                    b.Property<float>("Y")
                        .HasColumnType("real")
                        .HasColumnName("y");

                    b.Property<float>("Z")
                        .HasColumnType("real")
                        .HasColumnName("z");

                    b.HasKey("Id");

                    b.HasIndex("HoleId");

                    b.ToTable("HolePoints");
                });

            modelBuilder.Entity("RITest.Entities.DrillBlockPointEntity", b =>
                {
                    b.HasOne("RITest.Entities.DrillBlockEntity", "DrillBlock")
                        .WithMany()
                        .HasForeignKey("DrillBlockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DrillBlock");
                });

            modelBuilder.Entity("RITest.Entities.HoleEntity", b =>
                {
                    b.HasOne("RITest.Entities.DrillBlockEntity", "DrillBlock")
                        .WithMany("Holes")
                        .HasForeignKey("DrillBlockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DrillBlock");
                });

            modelBuilder.Entity("RITest.Entities.HolePointEntity", b =>
                {
                    b.HasOne("RITest.Entities.HoleEntity", "Hole")
                        .WithMany()
                        .HasForeignKey("HoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hole");
                });

            modelBuilder.Entity("RITest.Entities.DrillBlockEntity", b =>
                {
                    b.Navigation("Holes");
                });
#pragma warning restore 612, 618
        }
    }
}
