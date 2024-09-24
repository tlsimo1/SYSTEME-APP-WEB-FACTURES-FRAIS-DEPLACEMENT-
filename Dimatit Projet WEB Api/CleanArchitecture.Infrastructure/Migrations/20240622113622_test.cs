using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "blog");

            migrationBuilder.AlterColumn<float>(
                name: "Frais_Kilometrique",
                table: "frais_Deplacement",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date_Saisie",
                table: "frais_Deplacement",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Facture",
                columns: table => new
                {
                    IDfacture = table.Column<int>(name: "ID_facture", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumFacture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fournisseur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateFacture = table.Column<DateTime>(name: "Date_Facture", type: "datetime2", nullable: false),
                    DateSaisie = table.Column<DateTime>(name: "Date_Saisie", type: "datetime2", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facture", x => x.IDfacture);
                });

            migrationBuilder.CreateTable(
                name: "Achat",
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
                    table.PrimaryKey("PK_Achat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Achat_Facture_id_facture",
                        column: x => x.idfacture,
                        principalTable: "Facture",
                        principalColumn: "ID_facture",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Achat_id_facture",
                table: "Achat",
                column: "id_facture");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Achat");

            migrationBuilder.DropTable(
                name: "Facture");

            migrationBuilder.AlterColumn<float>(
                name: "Frais_Kilometrique",
                table: "frais_Deplacement",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date_Saisie",
                table: "frais_Deplacement",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "blog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blog", x => x.Id);
                });
        }
    }
}
