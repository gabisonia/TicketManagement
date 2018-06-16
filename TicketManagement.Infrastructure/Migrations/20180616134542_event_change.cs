using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TicketManagement.Infrastructure.Migrations
{
    public partial class event_change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrderNumber",
                schema: "WriteModel",
                table: "Orders",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "AvailableSeats",
                schema: "WriteModel",
                table: "Events",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderNumber",
                schema: "WriteModel",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AvailableSeats",
                schema: "WriteModel",
                table: "Events");
        }
    }
}
