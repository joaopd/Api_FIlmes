﻿// <auto-generated />
using System;
using Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Api.Domain.Entities.AtoresEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("FilmeEntityId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(60) CHARACTER SET utf8mb4")
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.HasIndex("FilmeEntityId");

                    b.ToTable("Atores");
                });

            modelBuilder.Entity("Api.Domain.Entities.AvaliacaoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Avaliacao")
                        .HasColumnType("int");

                    b.Property<int?>("FilmeEntityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FilmeEntityId");

                    b.ToTable("Avaliacao");
                });

            modelBuilder.Entity("Api.Domain.Entities.FilmeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Diretor")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Gernero")
                        .IsRequired()
                        .HasColumnType("varchar(254) CHARACTER SET utf8mb4")
                        .HasMaxLength(254);

                    b.Property<string>("Imagem")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Filmes");
                });

            modelBuilder.Entity("Api.Domain.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(60) CHARACTER SET utf8mb4")
                        .HasMaxLength(60);

                    b.Property<string>("Role")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(254) CHARACTER SET utf8mb4")
                        .HasMaxLength(254);

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("Api.Domain.Entities.AtoresEntity", b =>
                {
                    b.HasOne("Api.Domain.Entities.FilmeEntity", null)
                        .WithMany("NomesAtores")
                        .HasForeignKey("FilmeEntityId");
                });

            modelBuilder.Entity("Api.Domain.Entities.AvaliacaoEntity", b =>
                {
                    b.HasOne("Api.Domain.Entities.FilmeEntity", null)
                        .WithMany("Avaliacao")
                        .HasForeignKey("FilmeEntityId");
                });
#pragma warning restore 612, 618
        }
    }
}
