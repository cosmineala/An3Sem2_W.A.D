using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RealDeal.DataAccess.Migrations
{
    public partial class InitialDataAccess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdentityID = table.Column<Guid>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Adress = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    StartPrice = table.Column<decimal>(nullable: false),
                    AuctionDate = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Tag = table.Column<string>(nullable: true),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Items_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuctionRegistrations",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false),
                    ItemID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionRegistrations", x => new { x.UserID, x.ItemID });
                    table.ForeignKey(
                        name: "FK_AuctionRegistrations_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuctionRegistrations_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Histories",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false),
                    ItemID = table.Column<int>(nullable: false),
                    BuyPrice = table.Column<decimal>(nullable: false),
                    BuyDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Histories", x => new { x.UserID, x.ItemID });
                    table.ForeignKey(
                        name: "FK_Histories_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Histories_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuctionRegistrations_ItemID",
                table: "AuctionRegistrations",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Histories_ItemID",
                table: "Histories",
                column: "ItemID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_UserID",
                table: "Items",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuctionRegistrations");

            migrationBuilder.DropTable(
                name: "Histories");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
