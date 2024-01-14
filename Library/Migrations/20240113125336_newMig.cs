using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class newMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnneePublication",
                table: "Livres");

            migrationBuilder.RenameColumn(
                name: "Editeur",
                table: "Livres",
                newName: "Description");

            migrationBuilder.AlterColumn<string>(
                name: "Disponible",
                table: "Livres",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Livres",
                newName: "Editeur");

            migrationBuilder.AlterColumn<bool>(
                name: "Disponible",
                table: "Livres",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "AnneePublication",
                table: "Livres",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
