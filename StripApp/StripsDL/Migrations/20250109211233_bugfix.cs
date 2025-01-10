using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StripsDL.Migrations
{
    /// <inheritdoc />
    public partial class bugfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuteurStrip_Auteurs_AuteursId",
                table: "AuteurStrip");

            migrationBuilder.DropForeignKey(
                name: "FK_AuteurStrip_Strips_StripsId",
                table: "AuteurStrip");

            migrationBuilder.DropForeignKey(
                name: "FK_Strips_Reeksen_ReeksId",
                table: "Strips");

            migrationBuilder.DropForeignKey(
                name: "FK_Strips_Uitgeverijen_UitgeverijId",
                table: "Strips");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Uitgeverijen",
                table: "Uitgeverijen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Strips",
                table: "Strips");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reeksen",
                table: "Reeksen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Auteurs",
                table: "Auteurs");

            migrationBuilder.RenameTable(
                name: "Uitgeverijen",
                newName: "Uitgeverij");

            migrationBuilder.RenameTable(
                name: "Strips",
                newName: "Strip");

            migrationBuilder.RenameTable(
                name: "Reeksen",
                newName: "Reeks");

            migrationBuilder.RenameTable(
                name: "Auteurs",
                newName: "Auteur");

            migrationBuilder.RenameIndex(
                name: "IX_Strips_UitgeverijId",
                table: "Strip",
                newName: "IX_Strip_UitgeverijId");

            migrationBuilder.RenameIndex(
                name: "IX_Strips_ReeksId",
                table: "Strip",
                newName: "IX_Strip_ReeksId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Uitgeverij",
                table: "Uitgeverij",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Strip",
                table: "Strip",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reeks",
                table: "Reeks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Auteur",
                table: "Auteur",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuteurStrip_Auteur_AuteursId",
                table: "AuteurStrip",
                column: "AuteursId",
                principalTable: "Auteur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuteurStrip_Strip_StripsId",
                table: "AuteurStrip",
                column: "StripsId",
                principalTable: "Strip",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Strip_Reeks_ReeksId",
                table: "Strip",
                column: "ReeksId",
                principalTable: "Reeks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Strip_Uitgeverij_UitgeverijId",
                table: "Strip",
                column: "UitgeverijId",
                principalTable: "Uitgeverij",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuteurStrip_Auteur_AuteursId",
                table: "AuteurStrip");

            migrationBuilder.DropForeignKey(
                name: "FK_AuteurStrip_Strip_StripsId",
                table: "AuteurStrip");

            migrationBuilder.DropForeignKey(
                name: "FK_Strip_Reeks_ReeksId",
                table: "Strip");

            migrationBuilder.DropForeignKey(
                name: "FK_Strip_Uitgeverij_UitgeverijId",
                table: "Strip");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Uitgeverij",
                table: "Uitgeverij");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Strip",
                table: "Strip");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reeks",
                table: "Reeks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Auteur",
                table: "Auteur");

            migrationBuilder.RenameTable(
                name: "Uitgeverij",
                newName: "Uitgeverijen");

            migrationBuilder.RenameTable(
                name: "Strip",
                newName: "Strips");

            migrationBuilder.RenameTable(
                name: "Reeks",
                newName: "Reeksen");

            migrationBuilder.RenameTable(
                name: "Auteur",
                newName: "Auteurs");

            migrationBuilder.RenameIndex(
                name: "IX_Strip_UitgeverijId",
                table: "Strips",
                newName: "IX_Strips_UitgeverijId");

            migrationBuilder.RenameIndex(
                name: "IX_Strip_ReeksId",
                table: "Strips",
                newName: "IX_Strips_ReeksId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Uitgeverijen",
                table: "Uitgeverijen",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Strips",
                table: "Strips",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reeksen",
                table: "Reeksen",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Auteurs",
                table: "Auteurs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuteurStrip_Auteurs_AuteursId",
                table: "AuteurStrip",
                column: "AuteursId",
                principalTable: "Auteurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuteurStrip_Strips_StripsId",
                table: "AuteurStrip",
                column: "StripsId",
                principalTable: "Strips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Strips_Reeksen_ReeksId",
                table: "Strips",
                column: "ReeksId",
                principalTable: "Reeksen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Strips_Uitgeverijen_UitgeverijId",
                table: "Strips",
                column: "UitgeverijId",
                principalTable: "Uitgeverijen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
