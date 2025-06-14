using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIdColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Prenom",
                table: "persons",
                newName: "prenom");

            migrationBuilder.RenameColumn(
                name: "Nom",
                table: "persons",
                newName: "nom");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "persons",
                newName: "age");

            migrationBuilder.RenameColumn(
                name: "Adresse",
                table: "persons",
                newName: "adresse");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "prenom",
                table: "persons",
                newName: "Prenom");

            migrationBuilder.RenameColumn(
                name: "nom",
                table: "persons",
                newName: "Nom");

            migrationBuilder.RenameColumn(
                name: "age",
                table: "persons",
                newName: "Age");

            migrationBuilder.RenameColumn(
                name: "adresse",
                table: "persons",
                newName: "Adresse");
        }
    }
}
