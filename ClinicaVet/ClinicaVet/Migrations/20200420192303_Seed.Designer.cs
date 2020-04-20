﻿// <auto-generated />
using System;
using ClinicaVet.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClinicaVet.Migrations
{
    [DbContext(typeof(VetsDB))]
    [Migration("20200420192303_Seed")]
    partial class Seed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClinicaVet.Models.Animais", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DonoFK")
                        .HasColumnType("int");

                    b.Property<string>("Especie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Foto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Peso")
                        .HasColumnType("real");

                    b.Property<string>("Raca")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("DonoFK");

                    b.ToTable("Animais");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            DonoFK = 1,
                            Especie = "Cão",
                            Foto = "animal1.jpg",
                            Nome = "Bubi",
                            Peso = 24f,
                            Raca = "Pastor Alemão"
                        },
                        new
                        {
                            ID = 10,
                            DonoFK = 1,
                            Especie = "Gato",
                            Foto = "animal10.jpg",
                            Nome = "Saltitão",
                            Peso = 2f,
                            Raca = "Persa"
                        },
                        new
                        {
                            ID = 3,
                            DonoFK = 2,
                            Especie = "Cão",
                            Foto = "animal3.jpg",
                            Nome = "Tripé",
                            Peso = 4f,
                            Raca = "Serra Estrela"
                        },
                        new
                        {
                            ID = 2,
                            DonoFK = 3,
                            Especie = "Cão",
                            Foto = "animal2.jpg",
                            Nome = "Pastor",
                            Peso = 50f,
                            Raca = "Serra Estrela"
                        },
                        new
                        {
                            ID = 4,
                            DonoFK = 3,
                            Especie = "Cavalo",
                            Foto = "animal4.jpg",
                            Nome = "Saltador",
                            Peso = 580f,
                            Raca = "Lusitana"
                        },
                        new
                        {
                            ID = 5,
                            DonoFK = 3,
                            Especie = "Gato",
                            Foto = "animal5.jpg",
                            Nome = "Tareco",
                            Peso = 1f,
                            Raca = "siamês"
                        },
                        new
                        {
                            ID = 8,
                            DonoFK = 7,
                            Especie = "Cão",
                            Foto = "animal8.jpg",
                            Nome = "Forte",
                            Peso = 20f,
                            Raca = "Rottweiler"
                        },
                        new
                        {
                            ID = 9,
                            DonoFK = 8,
                            Especie = "Vaca",
                            Foto = "animal9.jpg",
                            Nome = "Castanho",
                            Peso = 652f,
                            Raca = "Mirandesa"
                        },
                        new
                        {
                            ID = 6,
                            DonoFK = 9,
                            Especie = "Cão",
                            Foto = "animal6.jpg",
                            Nome = "Cusca",
                            Peso = 45f,
                            Raca = "Labrador"
                        },
                        new
                        {
                            ID = 7,
                            DonoFK = 10,
                            Especie = "Cão",
                            Foto = "animal7.jpg",
                            Nome = "Morde Tudo",
                            Peso = 39f,
                            Raca = "Dobermann"
                        });
                });

            modelBuilder.Entity("ClinicaVet.Models.Consultas", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnimalFK")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Observacoes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VeterinarioFK")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AnimalFK");

                    b.HasIndex("VeterinarioFK");

                    b.ToTable("Consulta");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            AnimalFK = 1,
                            Data = new DateTime(2020, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VeterinarioFK = 1
                        },
                        new
                        {
                            ID = 2,
                            AnimalFK = 3,
                            Data = new DateTime(2020, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VeterinarioFK = 1
                        },
                        new
                        {
                            ID = 3,
                            AnimalFK = 2,
                            Data = new DateTime(2020, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VeterinarioFK = 1
                        },
                        new
                        {
                            ID = 4,
                            AnimalFK = 4,
                            Data = new DateTime(2020, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VeterinarioFK = 2
                        },
                        new
                        {
                            ID = 5,
                            AnimalFK = 9,
                            Data = new DateTime(2020, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VeterinarioFK = 2
                        },
                        new
                        {
                            ID = 6,
                            AnimalFK = 5,
                            Data = new DateTime(2020, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VeterinarioFK = 3
                        },
                        new
                        {
                            ID = 7,
                            AnimalFK = 6,
                            Data = new DateTime(2020, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VeterinarioFK = 3
                        },
                        new
                        {
                            ID = 8,
                            AnimalFK = 7,
                            Data = new DateTime(2020, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VeterinarioFK = 3
                        },
                        new
                        {
                            ID = 9,
                            AnimalFK = 8,
                            Data = new DateTime(2020, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VeterinarioFK = 3
                        },
                        new
                        {
                            ID = 10,
                            AnimalFK = 9,
                            Data = new DateTime(2020, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VeterinarioFK = 2
                        },
                        new
                        {
                            ID = 11,
                            AnimalFK = 10,
                            Data = new DateTime(2020, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VeterinarioFK = 1
                        },
                        new
                        {
                            ID = 12,
                            AnimalFK = 7,
                            Data = new DateTime(2020, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VeterinarioFK = 1
                        },
                        new
                        {
                            ID = 13,
                            AnimalFK = 1,
                            Data = new DateTime(2020, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VeterinarioFK = 1
                        },
                        new
                        {
                            ID = 14,
                            AnimalFK = 2,
                            Data = new DateTime(2020, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VeterinarioFK = 1
                        },
                        new
                        {
                            ID = 15,
                            AnimalFK = 5,
                            Data = new DateTime(2020, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VeterinarioFK = 1
                        },
                        new
                        {
                            ID = 16,
                            AnimalFK = 6,
                            Data = new DateTime(2020, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VeterinarioFK = 1
                        },
                        new
                        {
                            ID = 17,
                            AnimalFK = 9,
                            Data = new DateTime(2020, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VeterinarioFK = 2
                        },
                        new
                        {
                            ID = 18,
                            AnimalFK = 1,
                            Data = new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VeterinarioFK = 3
                        },
                        new
                        {
                            ID = 19,
                            AnimalFK = 10,
                            Data = new DateTime(2020, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VeterinarioFK = 1
                        },
                        new
                        {
                            ID = 20,
                            AnimalFK = 5,
                            Data = new DateTime(2020, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VeterinarioFK = 1
                        });
                });

            modelBuilder.Entity("ClinicaVet.Models.Donos", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NIF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("Sexo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Donos");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            NIF = "813635582",
                            Nome = "Luís Freitas",
                            Sexo = "M"
                        },
                        new
                        {
                            ID = 2,
                            NIF = "854613462",
                            Nome = "Andreia Gomes",
                            Sexo = "F"
                        },
                        new
                        {
                            ID = 3,
                            NIF = "265368715",
                            Nome = "Cristina Sousa",
                            Sexo = "F"
                        },
                        new
                        {
                            ID = 4,
                            NIF = "835623190",
                            Nome = "Sónia Rosa",
                            Sexo = "F"
                        },
                        new
                        {
                            ID = 5,
                            NIF = "751512205",
                            Nome = "António Santos",
                            Sexo = "M"
                        },
                        new
                        {
                            ID = 6,
                            NIF = "728663835",
                            Nome = "Gustavo Alves",
                            Sexo = "M"
                        },
                        new
                        {
                            ID = 7,
                            NIF = "644388118",
                            Nome = "Rosa Vieira",
                            Sexo = "F"
                        },
                        new
                        {
                            ID = 8,
                            NIF = "262618487",
                            Nome = "Daniel Dias",
                            Sexo = "M"
                        },
                        new
                        {
                            ID = 9,
                            NIF = "842615197",
                            Nome = "Tânia Gomes",
                            Sexo = "F"
                        },
                        new
                        {
                            ID = 10,
                            NIF = "635139506",
                            Nome = "Andreia Correia",
                            Sexo = "F"
                        });
                });

            modelBuilder.Entity("ClinicaVet.Models.Veterinarios", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("NumCedulaProf")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("ID");

                    b.ToTable("Veterinarios");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Foto = "Maria.jpg",
                            Nome = "Maria Pinto",
                            NumCedulaProf = "vet-034589"
                        },
                        new
                        {
                            ID = 2,
                            Foto = "Ricardo.jpg",
                            Nome = "Ricardo Ribeiro",
                            NumCedulaProf = "vet-034590"
                        },
                        new
                        {
                            ID = 3,
                            Foto = "Jose.jpg",
                            Nome = "José Soares",
                            NumCedulaProf = "vet-056732"
                        });
                });

            modelBuilder.Entity("ClinicaVet.Models.Animais", b =>
                {
                    b.HasOne("ClinicaVet.Models.Donos", "Dono")
                        .WithMany("ListaDeAnimais")
                        .HasForeignKey("DonoFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClinicaVet.Models.Consultas", b =>
                {
                    b.HasOne("ClinicaVet.Models.Animais", "Animal")
                        .WithMany("ListaDeConsultas")
                        .HasForeignKey("AnimalFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClinicaVet.Models.Veterinarios", "Veterinario")
                        .WithMany("ListaDeConsultas")
                        .HasForeignKey("VeterinarioFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
