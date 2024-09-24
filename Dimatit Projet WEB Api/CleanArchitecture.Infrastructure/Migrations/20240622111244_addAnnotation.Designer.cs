﻿// <auto-generated />
using System;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    [DbContext(typeof(BlogDbContext))]
    [Migration("20240622111244_addAnnotation")]
    partial class addAnnotation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.Achat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date_Saisie")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fac_Num")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Statut")
                        .HasColumnType("int");

                    b.Property<int>("id_facture")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("id_facture");

                    b.ToTable("Achat");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.Assistate_DAF", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date_Saisie")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fac_Num")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Statut")
                        .HasColumnType("int");

                    b.Property<int>("id_facture")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("id_facture");

                    b.ToTable("Assistate_DAF");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.Bureau_Ordre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date_Saisie")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fac_Num")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Statut")
                        .HasColumnType("int");

                    b.Property<int>("id_facture")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("id_facture");

                    b.ToTable("Bureau_Ordre");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.Code_Analytique", b =>
                {
                    b.Property<int>("ID_Analytique")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Analytique"));

                    b.Property<string>("Activite_Service")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodeAnalytique")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Analytique");

                    b.ToTable("code_Analytique");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.Comptabilite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date_Saisie")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fac_Num")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Statut")
                        .HasColumnType("int");

                    b.Property<int>("id_facture")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("id_facture");

                    b.ToTable("Comptabilite");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.Facture", b =>
                {
                    b.Property<int>("ID_facture")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_facture"));

                    b.Property<DateTime>("Date_Facture")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date_Saisie")
                        .HasColumnType("datetime2");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fournisseur")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumFacture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_facture");

                    b.ToTable("Facture");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.Frais_Deplacement", b =>
                {
                    b.Property<int>("ID_Frais")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Frais"));

                    b.Property<string>("Circulation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Date_Avancement")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Date_Preparation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Date_Regelement")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date_Saisie")
                        .HasColumnType("datetime2");

                    b.Property<float?>("FraisDeplacement")
                        .HasColumnType("real");

                    b.Property<float>("Frais_Kilometrique")
                        .HasColumnType("real");

                    b.Property<string>("Mat_PER")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mode_Reglement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Montant_Avance")
                        .HasColumnType("real");

                    b.Property<DateTime?>("Periode")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Periode_De")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Periode_Deplacement")
                        .HasColumnType("datetime2");

                    b.Property<int>("Personnel_id")
                        .HasColumnType("int");

                    b.Property<string>("Reprise_Frais")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ville_Region")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Frais");

                    b.ToTable("frais_Deplacement");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.Personnel", b =>
                {
                    b.Property<int>("ID_Personnel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Personnel"));

                    b.Property<string>("Activite_Service")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Analytique_id")
                        .HasColumnType("int");

                    b.Property<string>("Matricule")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Personnel");

                    b.ToTable("personnel");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.Achat", b =>
                {
                    b.HasOne("CleanArchitecture.Domain.Entities.Facture", "Facture")
                        .WithMany("Achats")
                        .HasForeignKey("id_facture")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Facture");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.Assistate_DAF", b =>
                {
                    b.HasOne("CleanArchitecture.Domain.Entities.Facture", "Facture")
                        .WithMany("Assistate_DAF")
                        .HasForeignKey("id_facture")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Facture");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.Bureau_Ordre", b =>
                {
                    b.HasOne("CleanArchitecture.Domain.Entities.Facture", "Facture")
                        .WithMany("Bureau_Ordre")
                        .HasForeignKey("id_facture")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Facture");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.Comptabilite", b =>
                {
                    b.HasOne("CleanArchitecture.Domain.Entities.Facture", "Facture")
                        .WithMany("Comptabilite")
                        .HasForeignKey("id_facture")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Facture");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.Facture", b =>
                {
                    b.Navigation("Achats");

                    b.Navigation("Assistate_DAF");

                    b.Navigation("Bureau_Ordre");

                    b.Navigation("Comptabilite");
                });
#pragma warning restore 612, 618
        }
    }
}
