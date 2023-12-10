﻿// <auto-generated />
using System;
using HealthCare.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HealthCare.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230913164659_Povezivanje_Tabele_Termin_Ljekar")]
    partial class PovezivanjeTabeleTerminLjekar
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AmbulantaOsoblje", b =>
                {
                    b.Property<int>("AmbulanteId")
                        .HasColumnType("int");

                    b.Property<int>("OsobljaId")
                        .HasColumnType("int");

                    b.HasKey("AmbulanteId", "OsobljaId");

                    b.HasIndex("OsobljaId");

                    b.ToTable("AmbulantaOsoblje");
                });

            modelBuilder.Entity("HealthCare.Models.Ambulanta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BolnicaId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vrsta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BolnicaId");

                    b.ToTable("Ambulanta");
                });

            modelBuilder.Entity("HealthCare.Models.Apoteka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BolnicaId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vrsta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BolnicaId");

                    b.ToTable("Apoteka");
                });

            modelBuilder.Entity("HealthCare.Models.Bolnica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Bolnica");
                });

            modelBuilder.Entity("HealthCare.Models.Karton", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PacijentId")
                        .HasColumnType("int");

                    b.Property<string>("Sifra")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PacijentId")
                        .IsUnique();

                    b.ToTable("Karton");
                });

            modelBuilder.Entity("HealthCare.Models.Korisnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BrojTelefona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KorisnickoIme")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("slika")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Korisnik");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("HealthCare.Models.Lijek", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ApotekaId")
                        .HasColumnType("int");

                    b.Property<double>("Cijena")
                        .HasColumnType("float");

                    b.Property<double>("KolicinaNaStanju")
                        .HasColumnType("float");

                    b.Property<string>("NacinUpotrebe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nuspojave")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProizvodjacId")
                        .HasColumnType("int");

                    b.Property<int>("ReceptId")
                        .HasColumnType("int");

                    b.Property<string>("Upozorenja")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vrsta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApotekaId");

                    b.HasIndex("ProizvodjacId");

                    b.HasIndex("ReceptId");

                    b.ToTable("Lijek");
                });

            modelBuilder.Entity("HealthCare.Models.Lokacija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BolnicaId")
                        .HasColumnType("int");

                    b.Property<string>("Grad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opstina")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ulica")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BolnicaId")
                        .IsUnique();

                    b.ToTable("Lokacija");
                });

            modelBuilder.Entity("HealthCare.Models.Menadzment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BolnicaId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Uloga")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BolnicaId");

                    b.ToTable("Menadzment");
                });

            modelBuilder.Entity("HealthCare.Models.Nalaz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LjekarId")
                        .HasColumnType("int");

                    b.Property<int>("PacijentId")
                        .HasColumnType("int");

                    b.Property<string>("Prioritet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vrsta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LjekarId");

                    b.HasIndex("PacijentId");

                    b.ToTable("Nalaz");
                });

            modelBuilder.Entity("HealthCare.Models.Odjeljenje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BolnicaId")
                        .HasColumnType("int");

                    b.Property<int>("BrojOsoblja")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vrsta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BolnicaId");

                    b.ToTable("Odjeljenje");
                });

            modelBuilder.Entity("HealthCare.Models.Proizvodjac", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Proizvodjac");
                });

            modelBuilder.Entity("HealthCare.Models.Recept", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DatumIzdavanja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Doza")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LjekarId")
                        .HasColumnType("int");

                    b.Property<string>("Napomena")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PacijentId")
                        .HasColumnType("int");

                    b.Property<string>("SifraBolesti")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LjekarId");

                    b.HasIndex("PacijentId");

                    b.ToTable("Recept");
                });

            modelBuilder.Entity("HealthCare.Models.Termin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AmbulantaId")
                        .HasColumnType("int");

                    b.Property<int>("LjekarId")
                        .HasColumnType("int");

                    b.Property<int>("PacijentId")
                        .HasColumnType("int");

                    b.Property<string>("Prioritet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("VrijemeDo")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("VrijemeOd")
                        .HasColumnType("datetime2");

                    b.Property<string>("Vrsta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("isZakazan")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AmbulantaId");

                    b.HasIndex("LjekarId");

                    b.HasIndex("PacijentId");

                    b.ToTable("Termin");
                });

            modelBuilder.Entity("HealthCare.Models.Uloga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Uloga");
                });

            modelBuilder.Entity("HealthCare.Models.Uputnica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DatumIzdavanja")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatumVazenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Dijagnoza")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LjekarId")
                        .HasColumnType("int");

                    b.Property<string>("Odjeljenje")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PacijentId")
                        .HasColumnType("int");

                    b.Property<string>("Primjedba")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LjekarId");

                    b.HasIndex("PacijentId");

                    b.ToTable("Uputnica");
                });

            modelBuilder.Entity("HealthCare.Models.ZdravstvenaLegitimacija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DatumIzdavanja")
                        .HasColumnType("datetime2");

                    b.Property<string>("DopunskoOsiguranje")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JMBG")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PacijentId")
                        .HasColumnType("int");

                    b.Property<string>("SrodstvoOsiguranika")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PacijentId")
                        .IsUnique();

                    b.ToTable("ZdravstvenaLegitimacija");
                });

            modelBuilder.Entity("KartonLjekar", b =>
                {
                    b.Property<int>("KartoniId")
                        .HasColumnType("int");

                    b.Property<int>("LjekariId")
                        .HasColumnType("int");

                    b.HasKey("KartoniId", "LjekariId");

                    b.HasIndex("LjekariId");

                    b.ToTable("KartonLjekar");
                });

            modelBuilder.Entity("KorisnikUloga", b =>
                {
                    b.Property<int>("KorisniciId")
                        .HasColumnType("int");

                    b.Property<int>("UlogeId")
                        .HasColumnType("int");

                    b.HasKey("KorisniciId", "UlogeId");

                    b.HasIndex("UlogeId");

                    b.ToTable("KorisnikUloga");
                });

            modelBuilder.Entity("HealthCare.Models.Osoblje", b =>
                {
                    b.HasBaseType("HealthCare.Models.Korisnik");

                    b.Property<int>("GodineIskustva")
                        .HasColumnType("int");

                    b.Property<int>("OdjeljenjeId")
                        .HasColumnType("int");

                    b.HasIndex("OdjeljenjeId");

                    b.ToTable("Osoblje");
                });

            modelBuilder.Entity("HealthCare.Models.Pacijent", b =>
                {
                    b.HasBaseType("HealthCare.Models.Korisnik");

                    b.Property<DateTime>("DatumRodenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("MjestoRodenja")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Pacijent");
                });

            modelBuilder.Entity("HealthCare.Models.Asistent", b =>
                {
                    b.HasBaseType("HealthCare.Models.Osoblje");

                    b.Property<string>("Kvalifikacija")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specijalizacija")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Asistent");
                });

            modelBuilder.Entity("HealthCare.Models.Farmaceut", b =>
                {
                    b.HasBaseType("HealthCare.Models.Osoblje");

                    b.Property<int>("ApotekaId")
                        .HasColumnType("int");

                    b.Property<string>("Radnik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("ApotekaId");

                    b.ToTable("Farmaceut");
                });

            modelBuilder.Entity("HealthCare.Models.Ljekar", b =>
                {
                    b.HasBaseType("HealthCare.Models.Osoblje");

                    b.Property<string>("Sifra")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specifikacija")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specjalizacija")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Ljekar");
                });

            modelBuilder.Entity("HealthCare.Models.Tehnicar", b =>
                {
                    b.HasBaseType("HealthCare.Models.Osoblje");

                    b.Property<string>("Kvalifikacija")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specijalizacija")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Tehnicar");
                });

            modelBuilder.Entity("AmbulantaOsoblje", b =>
                {
                    b.HasOne("HealthCare.Models.Ambulanta", null)
                        .WithMany()
                        .HasForeignKey("AmbulanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthCare.Models.Osoblje", null)
                        .WithMany()
                        .HasForeignKey("OsobljaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HealthCare.Models.Ambulanta", b =>
                {
                    b.HasOne("HealthCare.Models.Bolnica", "Bolnica")
                        .WithMany("Ambulante")
                        .HasForeignKey("BolnicaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bolnica");
                });

            modelBuilder.Entity("HealthCare.Models.Apoteka", b =>
                {
                    b.HasOne("HealthCare.Models.Bolnica", "Bolnica")
                        .WithMany("Apoteke")
                        .HasForeignKey("BolnicaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bolnica");
                });

            modelBuilder.Entity("HealthCare.Models.Karton", b =>
                {
                    b.HasOne("HealthCare.Models.Pacijent", "Pacijent")
                        .WithOne("Karton")
                        .HasForeignKey("HealthCare.Models.Karton", "PacijentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pacijent");
                });

            modelBuilder.Entity("HealthCare.Models.Lijek", b =>
                {
                    b.HasOne("HealthCare.Models.Apoteka", "Apoteka")
                        .WithMany("Lijekovi")
                        .HasForeignKey("ApotekaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthCare.Models.Proizvodjac", "Proizvodjac")
                        .WithMany("Lijekovi")
                        .HasForeignKey("ProizvodjacId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthCare.Models.Recept", "Recept")
                        .WithMany("Lijekovi")
                        .HasForeignKey("ReceptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Apoteka");

                    b.Navigation("Proizvodjac");

                    b.Navigation("Recept");
                });

            modelBuilder.Entity("HealthCare.Models.Lokacija", b =>
                {
                    b.HasOne("HealthCare.Models.Bolnica", "Bolnica")
                        .WithOne("Lokacija")
                        .HasForeignKey("HealthCare.Models.Lokacija", "BolnicaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bolnica");
                });

            modelBuilder.Entity("HealthCare.Models.Menadzment", b =>
                {
                    b.HasOne("HealthCare.Models.Bolnica", "Bolnica")
                        .WithMany("Menadzmenti")
                        .HasForeignKey("BolnicaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bolnica");
                });

            modelBuilder.Entity("HealthCare.Models.Nalaz", b =>
                {
                    b.HasOne("HealthCare.Models.Ljekar", "Ljekar")
                        .WithMany("Nalazi")
                        .HasForeignKey("LjekarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthCare.Models.Pacijent", "Pacijent")
                        .WithMany("Nalazi")
                        .HasForeignKey("PacijentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ljekar");

                    b.Navigation("Pacijent");
                });

            modelBuilder.Entity("HealthCare.Models.Odjeljenje", b =>
                {
                    b.HasOne("HealthCare.Models.Bolnica", "Bolnica")
                        .WithMany("Odjeljenja")
                        .HasForeignKey("BolnicaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bolnica");
                });

            modelBuilder.Entity("HealthCare.Models.Recept", b =>
                {
                    b.HasOne("HealthCare.Models.Ljekar", "Ljekar")
                        .WithMany("Recepti")
                        .HasForeignKey("LjekarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthCare.Models.Pacijent", "Pacijent")
                        .WithMany("Recepti")
                        .HasForeignKey("PacijentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ljekar");

                    b.Navigation("Pacijent");
                });

            modelBuilder.Entity("HealthCare.Models.Termin", b =>
                {
                    b.HasOne("HealthCare.Models.Ambulanta", "Ambulanta")
                        .WithMany("Termini")
                        .HasForeignKey("AmbulantaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthCare.Models.Ljekar", "Ljekar")
                        .WithMany("Termini")
                        .HasForeignKey("LjekarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthCare.Models.Pacijent", "Pacijent")
                        .WithMany("Termini")
                        .HasForeignKey("PacijentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ambulanta");

                    b.Navigation("Ljekar");

                    b.Navigation("Pacijent");
                });

            modelBuilder.Entity("HealthCare.Models.Uputnica", b =>
                {
                    b.HasOne("HealthCare.Models.Ljekar", "Ljekar")
                        .WithMany("Uputnice")
                        .HasForeignKey("LjekarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthCare.Models.Pacijent", "Pacijent")
                        .WithMany("Uputnice")
                        .HasForeignKey("PacijentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ljekar");

                    b.Navigation("Pacijent");
                });

            modelBuilder.Entity("HealthCare.Models.ZdravstvenaLegitimacija", b =>
                {
                    b.HasOne("HealthCare.Models.Pacijent", "Pacijent")
                        .WithOne("ZdravstvenaLegitimacija")
                        .HasForeignKey("HealthCare.Models.ZdravstvenaLegitimacija", "PacijentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pacijent");
                });

            modelBuilder.Entity("KartonLjekar", b =>
                {
                    b.HasOne("HealthCare.Models.Karton", null)
                        .WithMany()
                        .HasForeignKey("KartoniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthCare.Models.Ljekar", null)
                        .WithMany()
                        .HasForeignKey("LjekariId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KorisnikUloga", b =>
                {
                    b.HasOne("HealthCare.Models.Korisnik", null)
                        .WithMany()
                        .HasForeignKey("KorisniciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthCare.Models.Uloga", null)
                        .WithMany()
                        .HasForeignKey("UlogeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HealthCare.Models.Osoblje", b =>
                {
                    b.HasOne("HealthCare.Models.Korisnik", null)
                        .WithOne()
                        .HasForeignKey("HealthCare.Models.Osoblje", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthCare.Models.Odjeljenje", "Odjeljenje")
                        .WithMany("Oosblja")
                        .HasForeignKey("OdjeljenjeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Odjeljenje");
                });

            modelBuilder.Entity("HealthCare.Models.Pacijent", b =>
                {
                    b.HasOne("HealthCare.Models.Korisnik", null)
                        .WithOne()
                        .HasForeignKey("HealthCare.Models.Pacijent", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HealthCare.Models.Asistent", b =>
                {
                    b.HasOne("HealthCare.Models.Osoblje", null)
                        .WithOne()
                        .HasForeignKey("HealthCare.Models.Asistent", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HealthCare.Models.Farmaceut", b =>
                {
                    b.HasOne("HealthCare.Models.Apoteka", "Apoteka")
                        .WithMany("Farmaceuti")
                        .HasForeignKey("ApotekaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthCare.Models.Osoblje", null)
                        .WithOne()
                        .HasForeignKey("HealthCare.Models.Farmaceut", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Apoteka");
                });

            modelBuilder.Entity("HealthCare.Models.Ljekar", b =>
                {
                    b.HasOne("HealthCare.Models.Osoblje", null)
                        .WithOne()
                        .HasForeignKey("HealthCare.Models.Ljekar", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HealthCare.Models.Tehnicar", b =>
                {
                    b.HasOne("HealthCare.Models.Osoblje", null)
                        .WithOne()
                        .HasForeignKey("HealthCare.Models.Tehnicar", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HealthCare.Models.Ambulanta", b =>
                {
                    b.Navigation("Termini");
                });

            modelBuilder.Entity("HealthCare.Models.Apoteka", b =>
                {
                    b.Navigation("Farmaceuti");

                    b.Navigation("Lijekovi");
                });

            modelBuilder.Entity("HealthCare.Models.Bolnica", b =>
                {
                    b.Navigation("Ambulante");

                    b.Navigation("Apoteke");

                    b.Navigation("Lokacija")
                        .IsRequired();

                    b.Navigation("Menadzmenti");

                    b.Navigation("Odjeljenja");
                });

            modelBuilder.Entity("HealthCare.Models.Odjeljenje", b =>
                {
                    b.Navigation("Oosblja");
                });

            modelBuilder.Entity("HealthCare.Models.Proizvodjac", b =>
                {
                    b.Navigation("Lijekovi");
                });

            modelBuilder.Entity("HealthCare.Models.Recept", b =>
                {
                    b.Navigation("Lijekovi");
                });

            modelBuilder.Entity("HealthCare.Models.Pacijent", b =>
                {
                    b.Navigation("Karton")
                        .IsRequired();

                    b.Navigation("Nalazi");

                    b.Navigation("Recepti");

                    b.Navigation("Termini");

                    b.Navigation("Uputnice");

                    b.Navigation("ZdravstvenaLegitimacija")
                        .IsRequired();
                });

            modelBuilder.Entity("HealthCare.Models.Ljekar", b =>
                {
                    b.Navigation("Nalazi");

                    b.Navigation("Recepti");

                    b.Navigation("Termini");

                    b.Navigation("Uputnice");
                });
#pragma warning restore 612, 618
        }
    }
}
