using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WROCERBackend.Migrations
{
    public partial class WrocerDatabaseV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Numer",
                table: "DataGraczs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "PozycjaID",
                table: "DataGraczs",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SkladID",
                table: "DataGraczs",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DataSklads",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSklads", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataGraczs_PozycjaID",
                table: "DataGraczs",
                column: "PozycjaID");

            migrationBuilder.CreateIndex(
                name: "IX_DataGraczs_SkladID",
                table: "DataGraczs",
                column: "SkladID");

            migrationBuilder.AddForeignKey(
                name: "FK_DataGraczs_DataPozycjas_PozycjaID",
                table: "DataGraczs",
                column: "PozycjaID",
                principalTable: "DataPozycjas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataGraczs_DataSklads_SkladID",
                table: "DataGraczs",
                column: "SkladID",
                principalTable: "DataSklads",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataGraczs_DataPozycjas_PozycjaID",
                table: "DataGraczs");

            migrationBuilder.DropForeignKey(
                name: "FK_DataGraczs_DataSklads_SkladID",
                table: "DataGraczs");

            migrationBuilder.DropTable(
                name: "DataSklads");

            migrationBuilder.DropIndex(
                name: "IX_DataGraczs_PozycjaID",
                table: "DataGraczs");

            migrationBuilder.DropIndex(
                name: "IX_DataGraczs_SkladID",
                table: "DataGraczs");

            migrationBuilder.DropColumn(
                name: "Numer",
                table: "DataGraczs");

            migrationBuilder.DropColumn(
                name: "PozycjaID",
                table: "DataGraczs");

            migrationBuilder.DropColumn(
                name: "SkladID",
                table: "DataGraczs");
        }
    }
}
