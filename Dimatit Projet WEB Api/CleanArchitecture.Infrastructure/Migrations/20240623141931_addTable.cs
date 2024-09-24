using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chef_Comptabilite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacNum = table.Column<string>(name: "Fac_Num", type: "nvarchar(max)", nullable: false),
                    DateSaisie = table.Column<DateTime>(name: "Date_Saisie", type: "datetime2", nullable: false),
                    Statut = table.Column<int>(type: "int", nullable: false),
                    idfacture = table.Column<int>(name: "id_facture", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chef_Comptabilite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chef_Comptabilite_Facture_id_facture",
                        column: x => x.idfacture,
                        principalTable: "Facture",
                        principalColumn: "ID_facture",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chef_Comptabilite_id_facture",
                table: "Chef_Comptabilite",
                column: "id_facture");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chef_Comptabilite");
        }
    }
}
