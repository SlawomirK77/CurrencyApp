using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class Mig_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rates_CurrencyTables_CurrencyTableEntityId",
                table: "Rates");

            migrationBuilder.AlterColumn<decimal>(
                name: "Mid",
                table: "Rates",
                type: "decimal(12,10)",
                precision: 12,
                scale: 10,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CurrencyTableEntityId",
                table: "Rates",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Bid",
                table: "Rates",
                type: "decimal(12,10)",
                precision: 12,
                scale: 10,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Ask",
                table: "Rates",
                type: "decimal(12,10)",
                precision: 12,
                scale: 10,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rates_CurrencyTables_CurrencyTableEntityId",
                table: "Rates",
                column: "CurrencyTableEntityId",
                principalTable: "CurrencyTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rates_CurrencyTables_CurrencyTableEntityId",
                table: "Rates");

            migrationBuilder.AlterColumn<decimal>(
                name: "Mid",
                table: "Rates",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,10)",
                oldPrecision: 12,
                oldScale: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CurrencyTableEntityId",
                table: "Rates",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<decimal>(
                name: "Bid",
                table: "Rates",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,10)",
                oldPrecision: 12,
                oldScale: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Ask",
                table: "Rates",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,10)",
                oldPrecision: 12,
                oldScale: 10,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rates_CurrencyTables_CurrencyTableEntityId",
                table: "Rates",
                column: "CurrencyTableEntityId",
                principalTable: "CurrencyTables",
                principalColumn: "Id");
        }
    }
}
