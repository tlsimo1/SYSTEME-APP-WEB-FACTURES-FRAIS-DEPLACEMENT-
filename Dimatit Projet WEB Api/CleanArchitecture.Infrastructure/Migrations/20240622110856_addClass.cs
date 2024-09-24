using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assistate_DAF",
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
                    table.PrimaryKey("PK_Assistate_DAF", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assistate_DAF_Facture_id_facture",
                        column: x => x.idfacture,
                        principalTable: "Facture",
                        principalColumn: "ID_facture",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bureau_Ordre",
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
                    table.PrimaryKey("PK_Bureau_Ordre", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bureau_Ordre_Facture_id_facture",
                        column: x => x.idfacture,
                        principalTable: "Facture",
                        principalColumn: "ID_facture",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comptabilite",
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
                    table.PrimaryKey("PK_Comptabilite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comptabilite_Facture_id_facture",
                        column: x => x.idfacture,
                        principalTable: "Facture",
                        principalColumn: "ID_facture",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assistate_DAF_id_facture",
                table: "Assistate_DAF",
                column: "id_facture");

            migrationBuilder.CreateIndex(
                name: "IX_Bureau_Ordre_id_facture",
                table: "Bureau_Ordre",
                column: "id_facture");

            migrationBuilder.CreateIndex(
                name: "IX_Comptabilite_id_facture",
                table: "Comptabilite",
                column: "id_facture");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assistate_DAF");

            migrationBuilder.DropTable(
                name: "Bureau_Ordre");

            migrationBuilder.DropTable(
                name: "Comptabilite");
        }
    }
}
