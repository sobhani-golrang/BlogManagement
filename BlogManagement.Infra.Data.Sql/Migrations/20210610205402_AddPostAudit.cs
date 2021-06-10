using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogManagement.Infra.Data.Sql.Migrations
{
    public partial class AddPostAudit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDate",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: DateTime.Now);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: DateTime.Now);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Posts");
        }
    }
}
