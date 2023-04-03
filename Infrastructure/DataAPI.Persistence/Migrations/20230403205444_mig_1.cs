using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExchangeCrossRates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CurrencyCode = table.Column<string>(type: "text", nullable: false),
                    Unit = table.Column<string>(type: "text", nullable: false),
                    FromCurrency = table.Column<string>(type: "text", nullable: false),
                    CrossRate = table.Column<decimal>(type: "numeric", nullable: false),
                    ToCurrency = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UnixTime = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeCrossRates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExchangeEffectiveRates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CurrencyCode = table.Column<string>(type: "text", nullable: false),
                    Unit = table.Column<int>(type: "integer", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: false),
                    ForexBuyying = table.Column<decimal>(type: "numeric", nullable: false),
                    ForexSelling = table.Column<decimal>(type: "numeric", nullable: false),
                    BanknoteBuyying = table.Column<decimal>(type: "numeric", nullable: false),
                    BanknoteSelling = table.Column<decimal>(type: "numeric", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UnixTime = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeEffectiveRates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExchangeRates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CurrencyCode = table.Column<string>(type: "text", nullable: false),
                    Unit = table.Column<int>(type: "integer", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: false),
                    ForexBuyying = table.Column<decimal>(type: "numeric", nullable: false),
                    ForexSelling = table.Column<decimal>(type: "numeric", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UnixTime = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeRates", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExchangeCrossRates");

            migrationBuilder.DropTable(
                name: "ExchangeEffectiveRates");

            migrationBuilder.DropTable(
                name: "ExchangeRates");
        }
    }
}
