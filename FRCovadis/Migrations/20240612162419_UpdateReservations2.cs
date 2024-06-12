using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FRCovadis.Migrations
{
    /// <inheritdoc />
    public partial class UpdateReservations2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Reservations",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "start",
                table: "Reservations",
                newName: "Start");

            migrationBuilder.RenameColumn(
                name: "end",
                table: "Reservations",
                newName: "End");

            migrationBuilder.RenameColumn(
                name: "autoId",
                table: "Reservations",
                newName: "AutoId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Reservations",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "EndAdress",
                table: "Reservations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "KmAmount",
                table: "Reservations",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "StartAdress",
                table: "Reservations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<TimeOnly>(
                name: "Time",
                table: "Reservations",
                type: "TEXT",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AlterColumn<string>(
                name: "ReservationsById",
                table: "Autos",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndAdress",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "KmAmount",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "StartAdress",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Reservations",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "Start",
                table: "Reservations",
                newName: "start");

            migrationBuilder.RenameColumn(
                name: "End",
                table: "Reservations",
                newName: "end");

            migrationBuilder.RenameColumn(
                name: "AutoId",
                table: "Reservations",
                newName: "autoId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Reservations",
                newName: "id");

            migrationBuilder.AlterColumn<string>(
                name: "ReservationsById",
                table: "Autos",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
