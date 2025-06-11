using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonelTayin.Migrations
{
    /// <inheritdoc />
    public partial class guncelv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adliyes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdliyeAdi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adliyes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Unvan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sicil = table.Column<int>(type: "int", nullable: true),
                    CalistigiAdliye = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CalistigiBirim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IseBaslamaTarihi = table.Column<DateOnly>(type: "date", nullable: true),
                    DogumTarihi = table.Column<DateOnly>(type: "date", nullable: true),
                    DogumYeri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cinsiyet = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Basvurular",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserAccountId = table.Column<int>(type: "int", nullable: false),
                    AdliyeAdiId = table.Column<int>(type: "int", nullable: false),
                    BasvuruTuru = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BasvuruTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Basvurular", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Basvurular_Adliyes_AdliyeAdiId",
                        column: x => x.AdliyeAdiId,
                        principalTable: "Adliyes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Basvurular_UserAccounts_UserAccountId",
                        column: x => x.UserAccountId,
                        principalTable: "UserAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Basvurular_AdliyeAdiId",
                table: "Basvurular",
                column: "AdliyeAdiId");

            migrationBuilder.CreateIndex(
                name: "IX_Basvurular_UserAccountId",
                table: "Basvurular",
                column: "UserAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccounts_Email",
                table: "UserAccounts",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAccounts_UserName",
                table: "UserAccounts",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Basvurular");

            migrationBuilder.DropTable(
                name: "Adliyes");

            migrationBuilder.DropTable(
                name: "UserAccounts");
        }
    }
}
