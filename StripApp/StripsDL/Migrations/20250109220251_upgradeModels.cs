using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StripsDL.Migrations
{
    /// <inheritdoc />
    public partial class upgradeModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adres",
                table: "Uitgeverij",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Auteur",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adres",
                table: "Uitgeverij");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Auteur");
        }
    }
}
