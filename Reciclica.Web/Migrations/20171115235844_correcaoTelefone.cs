using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Reciclica.Web.Migrations
{
    public partial class correcaoTelefone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telefonne",
                table: "Empresa");

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Empresa",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Empresa");

            migrationBuilder.AddColumn<string>(
                name: "Telefonne",
                table: "Empresa",
                nullable: true);
        }
    }
}
