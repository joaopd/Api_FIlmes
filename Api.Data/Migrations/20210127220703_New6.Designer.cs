﻿// <auto-generated />
using System;
using Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20210127220703_New6")]
    partial class New6
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Api.Domain.Entities.AtoresEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FilmeEntityId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.HasIndex("FilmeEntityId");

                    b.ToTable("Atores");
                });

            modelBuilder.Entity("Api.Domain.Entities.AvaliacaoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Diretor")
                        .HasColumnType("nvarchar(254)")
                        .HasMaxLength(254);

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("nvarchar(254)")
                        .HasMaxLength(254);

                    b.Property<string>("Imagem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Filmes");
                });

            modelBuilder.Entity("Api.Domain.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(254)")
                        .HasMaxLength(254);

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 49,
                            Email = "jpkabral@live.com",
                            Name = "Administrador",
                            Role = "Adm",
                            Senha = "Vur67203"
                        });
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
