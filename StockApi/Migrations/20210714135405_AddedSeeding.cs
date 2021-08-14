using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockApi.Migrations
{
    public partial class AddedSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TblBrokers",
                columns: table => new
                {
                    BrokerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Country = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Continent = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblBrokers", x => x.BrokerId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TblExchanges",
                columns: table => new
                {
                    ExchangeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Country = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Continent = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblExchanges", x => x.ExchangeId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TblStocks",
                columns: table => new
                {
                    StockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ticker = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Employees = table.Column<int>(type: "int", nullable: false),
                    ListDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblStocks", x => x.StockId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BrokerStock",
                columns: table => new
                {
                    BrokersBrokerId = table.Column<int>(type: "int", nullable: false),
                    StocksStockId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrokerStock", x => new { x.BrokersBrokerId, x.StocksStockId });
                    table.ForeignKey(
                        name: "FK_BrokerStock_TblBrokers_BrokersBrokerId",
                        column: x => x.BrokersBrokerId,
                        principalTable: "TblBrokers",
                        principalColumn: "BrokerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BrokerStock_TblStocks_StocksStockId",
                        column: x => x.StocksStockId,
                        principalTable: "TblStocks",
                        principalColumn: "StockId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ExchangeStock",
                columns: table => new
                {
                    ExchangesExchangeId = table.Column<int>(type: "int", nullable: false),
                    StocksStockId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeStock", x => new { x.ExchangesExchangeId, x.StocksStockId });
                    table.ForeignKey(
                        name: "FK_ExchangeStock_TblExchanges_ExchangesExchangeId",
                        column: x => x.ExchangesExchangeId,
                        principalTable: "TblExchanges",
                        principalColumn: "ExchangeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExchangeStock_TblStocks_StocksStockId",
                        column: x => x.StocksStockId,
                        principalTable: "TblStocks",
                        principalColumn: "StockId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "TblBrokers",
                columns: new[] { "BrokerId", "Continent", "Country", "Name" },
                values: new object[,]
                {
                    { 1, "Europe", "United Kingdom", "Etoro" },
                    { 2, "North America", "USA", "Robinhood" },
                    { 3, "North America", "USA", "Fidelity" }
                });

            migrationBuilder.InsertData(
                table: "TblExchanges",
                columns: new[] { "ExchangeId", "Continent", "Country", "Name" },
                values: new object[,]
                {
                    { 1, "North America", "USA", "New York Stock Exchange" },
                    { 2, "North America", "USA", "NASDAQ" },
                    { 3, "Asia", "China", "Hong Kong Stock Exchange" }
                });

            migrationBuilder.InsertData(
                table: "TblStocks",
                columns: new[] { "StockId", "Employees", "ListDate", "Name", "Ticker" },
                values: new object[,]
                {
                    { 1, 12000, new DateTime(2002, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gamestop", "GME" },
                    { 2, 4408, new DateTime(2013, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "AMC Entertainment", "AMC" },
                    { 3, 4044, new DateTime(1997, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Blackberry", "BB" }
                });

            migrationBuilder.InsertData(
                table: "BrokerStock",
                columns: new[] { "BrokersBrokerId", "StocksStockId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "ExchangeStock",
                columns: new[] { "ExchangesExchangeId", "StocksStockId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BrokerStock_StocksStockId",
                table: "BrokerStock",
                column: "StocksStockId");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeStock_StocksStockId",
                table: "ExchangeStock",
                column: "StocksStockId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrokerStock");

            migrationBuilder.DropTable(
                name: "ExchangeStock");

            migrationBuilder.DropTable(
                name: "TblBrokers");

            migrationBuilder.DropTable(
                name: "TblExchanges");

            migrationBuilder.DropTable(
                name: "TblStocks");
        }
    }
}
