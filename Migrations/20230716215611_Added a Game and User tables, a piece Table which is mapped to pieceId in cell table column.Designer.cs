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
    [Migration("20230716215611_Added a Game and User tables, a piece Table which is mapped to pieceId in cell table column")]
    partial class AddedaGameandUsertablesapieceTablewhichismappedtopieceIdincelltablecolumn
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

                    b.Property<int?>("pieceId")
                        .HasColumnType("int");

                    b.Property<int>("x")
                        .HasColumnType("int");

                    b.Property<int>("y")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Boardid");

                    b.HasIndex("pieceId");

                    b.ToTable("Cells");
                });

            modelBuilder.Entity("CheckersProject.Models.Piece", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("pieceType")
                        .HasColumnType("int");

                    b.Property<int>("team")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Piece");
                });

            modelBuilder.Entity("CheckersProject.Models.Cell", b =>
                {
                    b.HasOne("CheckersProject.Models.Board", null)
                        .WithMany("cells")
                        .HasForeignKey("Boardid");

                    b.HasOne("CheckersProject.Models.Piece", "piece")
                        .WithMany()
                        .HasForeignKey("pieceId");

                    b.Navigation("piece");
                });

            modelBuilder.Entity("CheckersProject.Models.Board", b =>
                {
                    b.Navigation("cells");
                });
#pragma warning restore 612, 618
        }
    }
}
