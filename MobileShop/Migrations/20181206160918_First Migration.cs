using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MobileShop.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CardDetails",
                columns: table => new
                {
                    cardNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Exp_date = table.Column<DateTime>(nullable: false),
                    cvv = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardDetails", x => x.cardNo);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CatID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CatName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CatID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CName = table.Column<string>(nullable: true),
                    CPassword = table.Column<string>(nullable: true),
                    CAge = table.Column<int>(nullable: false),
                    CEmail = table.Column<string>(nullable: true),
                    CPhone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CID);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SName = table.Column<string>(nullable: true),
                    SPhone = table.Column<string>(nullable: true),
                    SAddress = table.Column<string>(nullable: true),
                    PID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    PID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PName = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<decimal>(nullable: false),
                    CatID = table.Column<int>(nullable: false),
                    _suppliersSID = table.Column<int>(nullable: true),
                    oID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.PID);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CatID",
                        column: x => x.CatID,
                        principalTable: "Categories",
                        principalColumn: "CatID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Suppliers__suppliersSID",
                        column: x => x._suppliersSID,
                        principalTable: "Suppliers",
                        principalColumn: "SID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    fID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CID = table.Column<int>(nullable: false),
                    PID = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    oID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.fID);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Customers_CID",
                        column: x => x.CID,
                        principalTable: "Customers",
                        principalColumn: "CID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Products_PID",
                        column: x => x.PID,
                        principalTable: "Products",
                        principalColumn: "PID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    oID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    DeliveryStatus = table.Column<string>(nullable: true),
                    CID = table.Column<int>(nullable: false),
                    feedbackfID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.oID);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CID",
                        column: x => x.CID,
                        principalTable: "Customers",
                        principalColumn: "CID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Feedbacks_feedbackfID",
                        column: x => x.feedbackfID,
                        principalTable: "Feedbacks",
                        principalColumn: "fID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    PID = table.Column<int>(nullable: false),
                    oID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => new { x.PID, x.oID });
                    table.UniqueConstraint("AK_OrderDetails_oID_PID", x => new { x.oID, x.PID });
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_PID",
                        column: x => x.PID,
                        principalTable: "Products",
                        principalColumn: "PID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_oID",
                        column: x => x.oID,
                        principalTable: "Orders",
                        principalColumn: "oID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    paymentSerial = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    oID = table.Column<int>(nullable: false),
                    cardNo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.paymentSerial);
                    table.ForeignKey(
                        name: "FK_Payments_CardDetails_cardNo",
                        column: x => x.cardNo,
                        principalTable: "CardDetails",
                        principalColumn: "cardNo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_oID",
                        column: x => x.oID,
                        principalTable: "Orders",
                        principalColumn: "oID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_CID",
                table: "Feedbacks",
                column: "CID");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_PID",
                table: "Feedbacks",
                column: "PID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CID",
                table: "Orders",
                column: "CID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_feedbackfID",
                table: "Orders",
                column: "feedbackfID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_cardNo",
                table: "Payments",
                column: "cardNo");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_oID",
                table: "Payments",
                column: "oID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CatID",
                table: "Products",
                column: "CatID");

            migrationBuilder.CreateIndex(
                name: "IX_Products__suppliersSID",
                table: "Products",
                column: "_suppliersSID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "CardDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
