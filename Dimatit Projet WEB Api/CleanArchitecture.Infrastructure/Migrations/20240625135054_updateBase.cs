using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Designation",
                table: "Facture");

            migrationBuilder.AddColumn<double>(
                name: "TotalTTC",
                table: "Facture",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalTTC",
                table: "Facture");

            migrationBuilder.AddColumn<string>(
                name: "Designation",
                table: "Facture",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
