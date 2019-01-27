﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WROCERBackend.Model.DataDirectAccess;

namespace WROCERBackend.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20190127121702_DatabaseWROCERv5")]
    partial class DatabaseWROCERv5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WROCERBackend.Model.DataModel.DataDruzyna", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nazwa");

                    b.Property<long?>("TrenerID");

                    b.HasKey("ID");

                    b.HasIndex("TrenerID");

                    b.ToTable("DataDruzynas");
                });

            modelBuilder.Entity("WROCERBackend.Model.DataModel.DataGracz", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CzasNaBoisku");

                    b.Property<int>("Numer");

                    b.Property<long?>("PozycjaID");

                    b.Property<long?>("RaportID");

                    b.Property<long?>("SkladID");

                    b.Property<long?>("ZawodnikID");

                    b.HasKey("ID");

                    b.HasIndex("PozycjaID");

                    b.HasIndex("RaportID");

                    b.HasIndex("SkladID");

                    b.HasIndex("ZawodnikID");

                    b.ToTable("DataGraczs");
                });

            modelBuilder.Entity("WROCERBackend.Model.DataModel.DataMecz", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("GoscID");

                    b.Property<long?>("GospodarzID");

                    b.Property<long?>("SedziaID");

                    b.Property<long?>("SezonID");

                    b.Property<long>("Termin");

                    b.HasKey("ID");

                    b.HasIndex("GoscID");

                    b.HasIndex("GospodarzID");

                    b.HasIndex("SedziaID");

                    b.HasIndex("SezonID");

                    b.ToTable("DataMeczs");
                });

            modelBuilder.Entity("WROCERBackend.Model.DataModel.DataPozycja", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nazwa");

                    b.HasKey("ID");

                    b.ToTable("DataPozycjas");
                });

            modelBuilder.Entity("WROCERBackend.Model.DataModel.DataRaport", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("MeczID");

                    b.Property<string>("Uwagi");

                    b.HasKey("ID");

                    b.HasIndex("MeczID");

                    b.ToTable("DataRaports");
                });

            modelBuilder.Entity("WROCERBackend.Model.DataModel.DataSezon", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Rok");

                    b.HasKey("ID");

                    b.ToTable("DataSezons");
                });

            modelBuilder.Entity("WROCERBackend.Model.DataModel.DataSklad", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nazwa");

                    b.HasKey("ID");

                    b.ToTable("DataSklads");
                });

            modelBuilder.Entity("WROCERBackend.Model.DataModel.DataSytuacjaMeczowa", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Czas");

                    b.Property<long?>("GraczID");

                    b.Property<long?>("TypID");

                    b.HasKey("ID");

                    b.HasIndex("GraczID");

                    b.HasIndex("TypID");

                    b.ToTable("DataSytuacjaMeczowas");
                });

            modelBuilder.Entity("WROCERBackend.Model.DataModel.DataSytuacjaTyp", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nazwa");

                    b.HasKey("ID");

                    b.ToTable("DataSytuacjaTyps");
                });

            modelBuilder.Entity("WROCERBackend.Model.DataModel.DataUzytkownik", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Haslo");

                    b.Property<string>("Imie");

                    b.Property<string>("Login");

                    b.Property<string>("Nazwisko");

                    b.Property<long?>("TypID");

                    b.HasKey("ID");

                    b.HasIndex("TypID");

                    b.ToTable("DataUzytkowniks");
                });

            modelBuilder.Entity("WROCERBackend.Model.DataModel.DataUzytkownikTyp", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nazwa");

                    b.HasKey("ID");

                    b.ToTable("DataUzytkownikTyps");
                });

            modelBuilder.Entity("WROCERBackend.Model.DataModel.DataZawodnik", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("DataUrodzenia");

                    b.Property<long?>("DruzynaID");

                    b.Property<string>("Imie");

                    b.Property<string>("Nazwisko");

                    b.Property<int>("NumerKoszulki");

                    b.Property<long?>("PozycjaID");

                    b.HasKey("ID");

                    b.HasIndex("DruzynaID");

                    b.HasIndex("PozycjaID");

                    b.ToTable("DataZawodniks");
                });

            modelBuilder.Entity("WROCERBackend.Model.DataModel.DataZmiana", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Czas");

                    b.Property<long?>("SchodzacyID");

                    b.Property<long?>("WchodzacyID");

                    b.HasKey("ID");

                    b.HasIndex("SchodzacyID");

                    b.HasIndex("WchodzacyID");

                    b.ToTable("DataZmianas");
                });

            modelBuilder.Entity("WROCERBackend.Model.DataModel.DataDruzyna", b =>
                {
                    b.HasOne("WROCERBackend.Model.DataModel.DataUzytkownik", "Trener")
                        .WithMany()
                        .HasForeignKey("TrenerID");
                });

            modelBuilder.Entity("WROCERBackend.Model.DataModel.DataGracz", b =>
                {
                    b.HasOne("WROCERBackend.Model.DataModel.DataPozycja", "Pozycja")
                        .WithMany()
                        .HasForeignKey("PozycjaID");

                    b.HasOne("WROCERBackend.Model.DataModel.DataRaport", "Raport")
                        .WithMany()
                        .HasForeignKey("RaportID");

                    b.HasOne("WROCERBackend.Model.DataModel.DataSklad", "Sklad")
                        .WithMany()
                        .HasForeignKey("SkladID");

                    b.HasOne("WROCERBackend.Model.DataModel.DataZawodnik", "Zawodnik")
                        .WithMany()
                        .HasForeignKey("ZawodnikID");
                });

            modelBuilder.Entity("WROCERBackend.Model.DataModel.DataMecz", b =>
                {
                    b.HasOne("WROCERBackend.Model.DataModel.DataDruzyna", "Gosc")
                        .WithMany()
                        .HasForeignKey("GoscID");

                    b.HasOne("WROCERBackend.Model.DataModel.DataDruzyna", "Gospodarz")
                        .WithMany()
                        .HasForeignKey("GospodarzID");

                    b.HasOne("WROCERBackend.Model.DataModel.DataUzytkownik", "Sedzia")
                        .WithMany()
                        .HasForeignKey("SedziaID");

                    b.HasOne("WROCERBackend.Model.DataModel.DataSezon", "Sezon")
                        .WithMany()
                        .HasForeignKey("SezonID");
                });

            modelBuilder.Entity("WROCERBackend.Model.DataModel.DataRaport", b =>
                {
                    b.HasOne("WROCERBackend.Model.DataModel.DataMecz", "Mecz")
                        .WithMany()
                        .HasForeignKey("MeczID");
                });

            modelBuilder.Entity("WROCERBackend.Model.DataModel.DataSytuacjaMeczowa", b =>
                {
                    b.HasOne("WROCERBackend.Model.DataModel.DataGracz", "Gracz")
                        .WithMany()
                        .HasForeignKey("GraczID");

                    b.HasOne("WROCERBackend.Model.DataModel.DataSytuacjaTyp", "Typ")
                        .WithMany()
                        .HasForeignKey("TypID");
                });

            modelBuilder.Entity("WROCERBackend.Model.DataModel.DataUzytkownik", b =>
                {
                    b.HasOne("WROCERBackend.Model.DataModel.DataUzytkownikTyp", "Typ")
                        .WithMany()
                        .HasForeignKey("TypID");
                });

            modelBuilder.Entity("WROCERBackend.Model.DataModel.DataZawodnik", b =>
                {
                    b.HasOne("WROCERBackend.Model.DataModel.DataDruzyna", "Druzyna")
                        .WithMany()
                        .HasForeignKey("DruzynaID");

                    b.HasOne("WROCERBackend.Model.DataModel.DataPozycja", "Pozycja")
                        .WithMany()
                        .HasForeignKey("PozycjaID");
                });

            modelBuilder.Entity("WROCERBackend.Model.DataModel.DataZmiana", b =>
                {
                    b.HasOne("WROCERBackend.Model.DataModel.DataGracz", "Schodzacy")
                        .WithMany()
                        .HasForeignKey("SchodzacyID");

                    b.HasOne("WROCERBackend.Model.DataModel.DataGracz", "Wchodzacy")
                        .WithMany()
                        .HasForeignKey("WchodzacyID");
                });
#pragma warning restore 612, 618
        }
    }
}
