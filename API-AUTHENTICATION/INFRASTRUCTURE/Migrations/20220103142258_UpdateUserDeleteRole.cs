using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace INFRASTRUCTURE.Migrations.ApplicationDb
{
    public partial class UpdateUserDeleteRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "User",
                schema: "authentication"
               );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "User",
                schema: "authentication",
                nullable : true
                );

        }
    }
}
