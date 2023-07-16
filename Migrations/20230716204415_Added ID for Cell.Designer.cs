﻿// <auto-generated />
using System;
using CheckersProject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CheckersProject.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20230716204415_Added ID for Cell")]
    partial class AddedIDforCell
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CheckersProject.Models.Board", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.HasKey("id");

                    b.ToTable("Boards");
                });

            modelBuilder.Entity("CheckersProject.Models.Cell", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("Boardid")
                        .HasColumnType("int");

                    b.Property<int?>("piece")
                        .HasColumnType("int");

                    b.Property<int>("x")
                        .HasColumnType("int");

                    b.Property<int>("y")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Boardid");

                    b.ToTable("Cells");
                });

            modelBuilder.Entity("CheckersProject.Models.Cell", b =>
                {
                    b.HasOne("CheckersProject.Models.Board", null)
                        .WithMany("cells")
                        .HasForeignKey("Boardid");
                });

            modelBuilder.Entity("CheckersProject.Models.Board", b =>
                {
                    b.Navigation("cells");
                });
#pragma warning restore 612, 618
        }
    }
}
