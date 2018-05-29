using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TicketManagement.Infrastructure.Migrations
{
    public partial class event_description : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "WriteModel",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "ReadModel",
                table: "EventsDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                schema: "WriteModel",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "ReadModel",
                table: "EventsDetails");
        }
    }
}
