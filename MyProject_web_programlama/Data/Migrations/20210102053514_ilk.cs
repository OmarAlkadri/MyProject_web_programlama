using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyProject_web_programlama.Data.Migrations
{
    public partial class ilk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ilce = table.Column<string>(nullable: true),
                    Il = table.Column<string>(nullable: true),
                    Satir1 = table.Column<string>(nullable: true),
                    Satir2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kiracis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(nullable: true),
                    Soyad = table.Column<string>(nullable: true),
                    Yas = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kiracis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ofis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ofis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ozelliks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OzellikTipi = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ozelliks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServisFirmas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(nullable: true),
                    Servis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServisFirmas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArabaFirmas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(nullable: true),
                    FirmaSahibi = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    AdresId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArabaFirmas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArabaFirmas_Adres_AdresId",
                        column: x => x.AdresId,
                        principalTable: "Adres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Arabas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArabaFirId = table.Column<int>(nullable: false),
                    ServisId = table.Column<int>(nullable: false),
                    Ad = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arabas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Arabas_ArabaFirmas_ArabaFirId",
                        column: x => x.ArabaFirId,
                        principalTable: "ArabaFirmas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Arabas_ServisFirmas_ServisId",
                        column: x => x.ServisId,
                        principalTable: "ServisFirmas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArabaKiras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelId = table.Column<int>(nullable: false),
                    ArabaId = table.Column<int>(nullable: false),
                    KiraciId = table.Column<int>(nullable: false),
                    KiraFiyati = table.Column<int>(nullable: false),
                    Sure = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArabaKiras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArabaKiras_Arabas_ArabaId",
                        column: x => x.ArabaId,
                        principalTable: "Arabas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArabaKiras_Kiracis_KiraciId",
                        column: x => x.KiraciId,
                        principalTable: "Kiracis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fotografs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArabaId = table.Column<int>(nullable: false),
                    Fotograf1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fotografs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fotografs_Arabas_ArabaId",
                        column: x => x.ArabaId,
                        principalTable: "Arabas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IlanKoys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArabaId = table.Column<int>(nullable: false),
                    PersonelId = table.Column<int>(nullable: false),
                    Tarih = table.Column<DateTime>(nullable: false),
                    Fiyat = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IlanKoys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IlanKoys_Arabas_ArabaId",
                        column: x => x.ArabaId,
                        principalTable: "Arabas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OzellikEkles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArabaId = table.Column<int>(nullable: false),
                    OzellikId = table.Column<int>(nullable: false),
                    Tarih = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OzellikEkles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OzellikEkles_Arabas_ArabaId",
                        column: x => x.ArabaId,
                        principalTable: "Arabas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OzellikEkles_Ozelliks_OzellikId",
                        column: x => x.OzellikId,
                        principalTable: "Ozelliks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArabaFirmas_AdresId",
                table: "ArabaFirmas",
                column: "AdresId");

            migrationBuilder.CreateIndex(
                name: "IX_ArabaKiras_ArabaId",
                table: "ArabaKiras",
                column: "ArabaId");

            migrationBuilder.CreateIndex(
                name: "IX_ArabaKiras_KiraciId",
                table: "ArabaKiras",
                column: "KiraciId");

            migrationBuilder.CreateIndex(
                name: "IX_Arabas_ArabaFirId",
                table: "Arabas",
                column: "ArabaFirId");

            migrationBuilder.CreateIndex(
                name: "IX_Arabas_ServisId",
                table: "Arabas",
                column: "ServisId");

            migrationBuilder.CreateIndex(
                name: "IX_Fotografs_ArabaId",
                table: "Fotografs",
                column: "ArabaId");

            migrationBuilder.CreateIndex(
                name: "IX_IlanKoys_ArabaId",
                table: "IlanKoys",
                column: "ArabaId");

            migrationBuilder.CreateIndex(
                name: "IX_OzellikEkles_ArabaId",
                table: "OzellikEkles",
                column: "ArabaId");

            migrationBuilder.CreateIndex(
                name: "IX_OzellikEkles_OzellikId",
                table: "OzellikEkles",
                column: "OzellikId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArabaKiras");

            migrationBuilder.DropTable(
                name: "Fotografs");

            migrationBuilder.DropTable(
                name: "IlanKoys");

            migrationBuilder.DropTable(
                name: "Ofis");

            migrationBuilder.DropTable(
                name: "OzellikEkles");

            migrationBuilder.DropTable(
                name: "Kiracis");

            migrationBuilder.DropTable(
                name: "Arabas");

            migrationBuilder.DropTable(
                name: "Ozelliks");

            migrationBuilder.DropTable(
                name: "ArabaFirmas");

            migrationBuilder.DropTable(
                name: "ServisFirmas");

            migrationBuilder.DropTable(
                name: "Adres");
        }
    }
}
