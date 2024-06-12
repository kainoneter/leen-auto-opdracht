using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FRCovadis.Migrations
{
    /// <inheritdoc />
    public partial class updateReservations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Autos_AutoId",
                table: "Reservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation");

            migrationBuilder.RenameTable(
                name: "Reservation",
                newName: "Reservations");

            migrationBuilder.RenameColumn(
                name: "AutoId",
                table: "Reservations",
                newName: "autoId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_AutoId",
                table: "Reservations",
                newName: "IX_Reservations_autoId");

            migrationBuilder.AlterColumn<int>(
                name: "autoId",
                table: "Reservations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "Reservations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Autos_autoId",
                table: "Reservations",
                column: "autoId",
                principalTable: "Autos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Autos_autoId",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Reservations");

            migrationBuilder.RenameTable(
                name: "Reservations",
                newName: "Reservation");

            migrationBuilder.RenameColumn(
                name: "autoId",
                table: "Reservation",
                newName: "AutoId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_autoId",
                table: "Reservation",
                newName: "IX_Reservation_AutoId");

            migrationBuilder.AlterColumn<int>(
                name: "AutoId",
                table: "Reservation",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Autos_AutoId",
                table: "Reservation",
                column: "AutoId",
                principalTable: "Autos",
                principalColumn: "Id");
        }
    }
}
