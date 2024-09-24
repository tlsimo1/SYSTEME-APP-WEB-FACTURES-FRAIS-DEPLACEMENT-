using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatedatabase2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "blog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "code_Analytique",
                columns: table => new
                {
                    IDAnalytique = table.Column<int>(name: "ID_Analytique", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActiviteService = table.Column<string>(name: "Activite_Service", type: "nvarchar(max)", nullable: false),
                    CodeAnalytique = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_code_Analytique", x => x.IDAnalytique);
                });

            migrationBuilder.CreateTable(
                name: "frais_Deplacement",
                columns: table => new
                {
                    IDFrais = table.Column<int>(name: "ID_Frais", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateSaisie = table.Column<DateTime>(name: "Date_Saisie", type: "datetime2", nullable: true),
                    FraisKilometrique = table.Column<float>(name: "Frais_Kilometrique", type: "real", nullable: true),
                    FraisDeplacement = table.Column<float>(type: "real", nullable: true),
                    PeriodeDeplacement = table.Column<DateTime>(name: "Periode_Deplacement", type: "datetime2", nullable: true),
                    Circulation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateRegelement = table.Column<DateTime>(name: "Date_Regelement", type: "datetime2", nullable: true),
                    RepriseFrais = table.Column<string>(name: "Reprise_Frais", type: "nvarchar(max)", nullable: false),
                    DateAvancement = table.Column<DateTime>(name: "Date_Avancement", type: "datetime2", nullable: true),
                    MontantAvance = table.Column<float>(name: "Montant_Avance", type: "real", nullable: false),
                    MatPER = table.Column<string>(name: "Mat_PER", type: "nvarchar(max)", nullable: false),
                    VilleRegion = table.Column<string>(name: "Ville_Region", type: "nvarchar(max)", nullable: false),
                    ModeReglement = table.Column<string>(name: "Mode_Reglement", type: "nvarchar(max)", nullable: false),
                    DatePreparation = table.Column<DateTime>(name: "Date_Preparation", type: "datetime2", nullable: true),
                    PeriodeDe = table.Column<DateTime>(name: "Periode_De", type: "datetime2", nullable: true),
                    Periode = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Personnelid = table.Column<int>(name: "Personnel_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_frais_Deplacement", x => x.IDFrais);
                });

            migrationBuilder.CreateTable(
                name: "personnel",
                columns: table => new
                {
                    IDPersonnel = table.Column<int>(name: "ID_Personnel", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matricule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActiviteService = table.Column<string>(name: "Activite_Service", type: "nvarchar(max)", nullable: false),
                    Analytiqueid = table.Column<int>(name: "Analytique_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personnel", x => x.IDPersonnel);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "blog");

            migrationBuilder.DropTable(
                name: "code_Analytique");

            migrationBuilder.DropTable(
                name: "frais_Deplacement");

            migrationBuilder.DropTable(
                name: "personnel");
        }
    }
}
