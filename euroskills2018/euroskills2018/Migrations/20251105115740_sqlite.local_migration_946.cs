using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace euroskills2018.Migrations
{
    /// <inheritdoc />
    public partial class sqlitelocal_migration_946 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrszagNev",
                table: "Szakmak",
                newName: "SzakmaNev");

            migrationBuilder.RenameColumn(
                name: "SzakmaNev",
                table: "Orszagok",
                newName: "OrszagNev");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SzakmaNev",
                table: "Szakmak",
                newName: "OrszagNev");

            migrationBuilder.RenameColumn(
                name: "OrszagNev",
                table: "Orszagok",
                newName: "SzakmaNev");
        }
    }
}
