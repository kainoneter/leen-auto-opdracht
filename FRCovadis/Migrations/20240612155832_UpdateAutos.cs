using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FRCovadis.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Autos_autoId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_autoId",
                table: "Reservations");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Autos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReservationsById",
                table: "Autos",
                type: "TEXT",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Autos");

            migrationBuilder.DropColumn(
                name: "ReservationsById",
                table: "Autos");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_autoId",
                table: "Reservations",
                column: "autoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Autos_autoId",
                table: "Reservations",
                column: "autoId",
                principalTable: "Autos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
