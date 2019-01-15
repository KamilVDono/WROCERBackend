using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WROCERBackend.Migrations
{
    public partial class WROCERBackendModelDataDirectAccessDatabaseContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataPozycjas",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataPozycjas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DataSezons",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Rok = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSezons", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DataSytuacjaTyps",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSytuacjaTyps", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DataUzytkownikTyps",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataUzytkownikTyps", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DataUzytkowniks",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Login = table.Column<string>(nullable: true),
                    Haslo = table.Column<string>(nullable: true),
                    Imie = table.Column<string>(nullable: true),
                    Nazwisko = table.Column<string>(nullable: true),
                    TypID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataUzytkowniks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DataUzytkowniks_DataUzytkownikTyps_TypID",
                        column: x => x.TypID,
                        principalTable: "DataUzytkownikTyps",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DataDruzynas",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true),
                    TrenerID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataDruzynas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DataDruzynas_DataUzytkowniks_TrenerID",
                        column: x => x.TrenerID,
                        principalTable: "DataUzytkowniks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DataMeczs",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Termin = table.Column<long>(nullable: false),
                    SedziaID = table.Column<long>(nullable: true),
                    GospodarzID = table.Column<long>(nullable: true),
                    GoscID = table.Column<long>(nullable: true),
                    SezonID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataMeczs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DataMeczs_DataDruzynas_GoscID",
                        column: x => x.GoscID,
                        principalTable: "DataDruzynas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataMeczs_DataDruzynas_GospodarzID",
                        column: x => x.GospodarzID,
                        principalTable: "DataDruzynas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataMeczs_DataUzytkowniks_SedziaID",
                        column: x => x.SedziaID,
                        principalTable: "DataUzytkowniks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataMeczs_DataSezons_SezonID",
                        column: x => x.SezonID,
                        principalTable: "DataSezons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DataZawodniks",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Imie = table.Column<string>(nullable: true),
                    Nazwisko = table.Column<string>(nullable: true),
                    DataUrodzenia = table.Column<long>(nullable: false),
                    NumerKoszulki = table.Column<int>(nullable: false),
                    PozycjaID = table.Column<long>(nullable: true),
                    DruzynaID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataZawodniks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DataZawodniks_DataDruzynas_DruzynaID",
                        column: x => x.DruzynaID,
                        principalTable: "DataDruzynas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataZawodniks_DataPozycjas_PozycjaID",
                        column: x => x.PozycjaID,
                        principalTable: "DataPozycjas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DataRaports",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Uwagi = table.Column<string>(nullable: true),
                    MeczID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataRaports", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DataRaports_DataMeczs_MeczID",
                        column: x => x.MeczID,
                        principalTable: "DataMeczs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DataGraczs",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CzasNaBoisku = table.Column<long>(nullable: false),
                    ZawodnikID = table.Column<long>(nullable: true),
                    RaportID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataGraczs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DataGraczs_DataRaports_RaportID",
                        column: x => x.RaportID,
                        principalTable: "DataRaports",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataGraczs_DataZawodniks_ZawodnikID",
                        column: x => x.ZawodnikID,
                        principalTable: "DataZawodniks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DataSytuacjaMeczowas",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Czas = table.Column<long>(nullable: false),
                    GraczID = table.Column<long>(nullable: true),
                    TypID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSytuacjaMeczowas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DataSytuacjaMeczowas_DataGraczs_GraczID",
                        column: x => x.GraczID,
                        principalTable: "DataGraczs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataSytuacjaMeczowas_DataSytuacjaTyps_TypID",
                        column: x => x.TypID,
                        principalTable: "DataSytuacjaTyps",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DataZmianas",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Czas = table.Column<long>(nullable: false),
                    SchodzacyID = table.Column<long>(nullable: true),
                    WchodzacyID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataZmianas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DataZmianas_DataGraczs_SchodzacyID",
                        column: x => x.SchodzacyID,
                        principalTable: "DataGraczs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataZmianas_DataGraczs_WchodzacyID",
                        column: x => x.WchodzacyID,
                        principalTable: "DataGraczs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataDruzynas_TrenerID",
                table: "DataDruzynas",
                column: "TrenerID");

            migrationBuilder.CreateIndex(
                name: "IX_DataGraczs_RaportID",
                table: "DataGraczs",
                column: "RaportID");

            migrationBuilder.CreateIndex(
                name: "IX_DataGraczs_ZawodnikID",
                table: "DataGraczs",
                column: "ZawodnikID");

            migrationBuilder.CreateIndex(
                name: "IX_DataMeczs_GoscID",
                table: "DataMeczs",
                column: "GoscID");

            migrationBuilder.CreateIndex(
                name: "IX_DataMeczs_GospodarzID",
                table: "DataMeczs",
                column: "GospodarzID");

            migrationBuilder.CreateIndex(
                name: "IX_DataMeczs_SedziaID",
                table: "DataMeczs",
                column: "SedziaID");

            migrationBuilder.CreateIndex(
                name: "IX_DataMeczs_SezonID",
                table: "DataMeczs",
                column: "SezonID");

            migrationBuilder.CreateIndex(
                name: "IX_DataRaports_MeczID",
                table: "DataRaports",
                column: "MeczID");

            migrationBuilder.CreateIndex(
                name: "IX_DataSytuacjaMeczowas_GraczID",
                table: "DataSytuacjaMeczowas",
                column: "GraczID");

            migrationBuilder.CreateIndex(
                name: "IX_DataSytuacjaMeczowas_TypID",
                table: "DataSytuacjaMeczowas",
                column: "TypID");

            migrationBuilder.CreateIndex(
                name: "IX_DataUzytkowniks_TypID",
                table: "DataUzytkowniks",
                column: "TypID");

            migrationBuilder.CreateIndex(
                name: "IX_DataZawodniks_DruzynaID",
                table: "DataZawodniks",
                column: "DruzynaID");

            migrationBuilder.CreateIndex(
                name: "IX_DataZawodniks_PozycjaID",
                table: "DataZawodniks",
                column: "PozycjaID");

            migrationBuilder.CreateIndex(
                name: "IX_DataZmianas_SchodzacyID",
                table: "DataZmianas",
                column: "SchodzacyID");

            migrationBuilder.CreateIndex(
                name: "IX_DataZmianas_WchodzacyID",
                table: "DataZmianas",
                column: "WchodzacyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataSytuacjaMeczowas");

            migrationBuilder.DropTable(
                name: "DataZmianas");

            migrationBuilder.DropTable(
                name: "DataSytuacjaTyps");

            migrationBuilder.DropTable(
                name: "DataGraczs");

            migrationBuilder.DropTable(
                name: "DataRaports");

            migrationBuilder.DropTable(
                name: "DataZawodniks");

            migrationBuilder.DropTable(
                name: "DataMeczs");

            migrationBuilder.DropTable(
                name: "DataPozycjas");

            migrationBuilder.DropTable(
                name: "DataDruzynas");

            migrationBuilder.DropTable(
                name: "DataSezons");

            migrationBuilder.DropTable(
                name: "DataUzytkowniks");

            migrationBuilder.DropTable(
                name: "DataUzytkownikTyps");
        }
    }
}
