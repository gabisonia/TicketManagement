using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TicketManagement.Infrastructure.Migrations
{
    public partial class event_fields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Poster",
                schema: "WriteModel",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                schema: "WriteModel",
                table: "Events",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Poster",
                schema: "WriteModel",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "VideoUrl",
                schema: "WriteModel",
                table: "Events");
        }
    }
}
