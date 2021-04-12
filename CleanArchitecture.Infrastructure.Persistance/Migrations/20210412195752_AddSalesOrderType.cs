using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchitecture.Infrastructure.Persistance.Migrations
{
    public partial class AddSalesOrderType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SalesOrders",
                keyColumn: "Id",
                keyValue: new Guid("1a9e7c80-f21b-470f-8a63-0d14b69e0094"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDepracted",
                table: "SalesOrders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SalesOrderType",
                table: "SalesOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDepracted",
                table: "SalesOrders");

            migrationBuilder.DropColumn(
                name: "SalesOrderType",
                table: "SalesOrders");

            migrationBuilder.InsertData(
                table: "SalesOrders",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "EditedBy", "LastEditAt", "Name" },
                values: new object[] { new Guid("1a9e7c80-f21b-470f-8a63-0d14b69e0094"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "First Sales Order" });
        }
    }
}
