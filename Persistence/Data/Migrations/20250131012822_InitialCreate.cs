using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Production");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.EnsureSchema(
                name: "Sales");

            migrationBuilder.EnsureSchema(
                name: "HR");

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "Production",
                columns: table => new
                {
                    categoryid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryname = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.categoryid);
                });

            migrationBuilder.CreateTable(
                name: "CustomerOrderPrediction",
                schema: "dbo",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastOrderDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NextPredictedOrderDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "Sales",
                columns: table => new
                {
                    custid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    companyname = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    contactname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    contacttitle = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    address = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    city = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    region = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    postalcode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    country = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    fax = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.custid);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                schema: "HR",
                columns: table => new
                {
                    empid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lastname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    firstname = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    titleofcourtesy = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    birthdate = table.Column<DateTime>(type: "datetime", nullable: false),
                    hiredate = table.Column<DateTime>(type: "datetime", nullable: false),
                    address = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    city = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    region = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    postalcode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    country = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    mgrid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.empid);
                    table.ForeignKey(
                        name: "FK_Employees_Employees",
                        column: x => x.mgrid,
                        principalSchema: "HR",
                        principalTable: "Employees",
                        principalColumn: "empid");
                });

            migrationBuilder.CreateTable(
                name: "Shippers",
                schema: "Sales",
                columns: table => new
                {
                    shipperid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    companyname = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shippers", x => x.shipperid);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                schema: "Production",
                columns: table => new
                {
                    supplierid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    companyname = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    contactname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    contacttitle = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    address = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    city = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    region = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    postalcode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    country = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    fax = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.supplierid);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "Sales",
                columns: table => new
                {
                    orderid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    custid = table.Column<int>(type: "int", nullable: true),
                    empid = table.Column<int>(type: "int", nullable: false),
                    orderdate = table.Column<DateTime>(type: "datetime", nullable: false),
                    requireddate = table.Column<DateTime>(type: "datetime", nullable: false),
                    shippeddate = table.Column<DateTime>(type: "datetime", nullable: true),
                    shipperid = table.Column<int>(type: "int", nullable: false),
                    freight = table.Column<decimal>(type: "money", nullable: false),
                    shipname = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    shipaddress = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    shipcity = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    shipregion = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    shippostalcode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    shipcountry = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.orderid);
                    table.ForeignKey(
                        name: "FK_Orders_Customers",
                        column: x => x.custid,
                        principalSchema: "Sales",
                        principalTable: "Customers",
                        principalColumn: "custid");
                    table.ForeignKey(
                        name: "FK_Orders_Employees",
                        column: x => x.empid,
                        principalSchema: "HR",
                        principalTable: "Employees",
                        principalColumn: "empid");
                    table.ForeignKey(
                        name: "FK_Orders_Shippers",
                        column: x => x.shipperid,
                        principalSchema: "Sales",
                        principalTable: "Shippers",
                        principalColumn: "shipperid");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "Production",
                columns: table => new
                {
                    productid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productname = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    supplierid = table.Column<int>(type: "int", nullable: false),
                    categoryid = table.Column<int>(type: "int", nullable: false),
                    unitprice = table.Column<decimal>(type: "money", nullable: false),
                    discontinued = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.productid);
                    table.ForeignKey(
                        name: "FK_Products_Categories",
                        column: x => x.categoryid,
                        principalSchema: "Production",
                        principalTable: "Categories",
                        principalColumn: "categoryid");
                    table.ForeignKey(
                        name: "FK_Products_Suppliers",
                        column: x => x.supplierid,
                        principalSchema: "Production",
                        principalTable: "Suppliers",
                        principalColumn: "supplierid");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                schema: "Sales",
                columns: table => new
                {
                    orderid = table.Column<int>(type: "int", nullable: false),
                    productid = table.Column<int>(type: "int", nullable: false),
                    unitprice = table.Column<decimal>(type: "money", nullable: false),
                    qty = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)1),
                    discount = table.Column<decimal>(type: "numeric(4,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => new { x.orderid, x.productid });
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders",
                        column: x => x.orderid,
                        principalSchema: "Sales",
                        principalTable: "Orders",
                        principalColumn: "orderid");
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products",
                        column: x => x.productid,
                        principalSchema: "Production",
                        principalTable: "Products",
                        principalColumn: "productid");
                });

            migrationBuilder.CreateIndex(
                name: "categoryname",
                schema: "Production",
                table: "Categories",
                column: "categoryname");

            migrationBuilder.CreateIndex(
                name: "idx_nc_city",
                schema: "Sales",
                table: "Customers",
                column: "city");

            migrationBuilder.CreateIndex(
                name: "idx_nc_companyname",
                schema: "Sales",
                table: "Customers",
                column: "companyname");

            migrationBuilder.CreateIndex(
                name: "idx_nc_postalcode",
                schema: "Sales",
                table: "Customers",
                column: "postalcode");

            migrationBuilder.CreateIndex(
                name: "idx_nc_region",
                schema: "Sales",
                table: "Customers",
                column: "region");

            migrationBuilder.CreateIndex(
                name: "idx_nc_lastname",
                schema: "HR",
                table: "Employees",
                column: "lastname");

            migrationBuilder.CreateIndex(
                name: "idx_nc_postalcode",
                schema: "HR",
                table: "Employees",
                column: "postalcode");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_mgrid",
                schema: "HR",
                table: "Employees",
                column: "mgrid");

            migrationBuilder.CreateIndex(
                name: "idx_nc_orderid",
                schema: "Sales",
                table: "OrderDetails",
                column: "orderid");

            migrationBuilder.CreateIndex(
                name: "idx_nc_productid",
                schema: "Sales",
                table: "OrderDetails",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "idx_nc_custid",
                schema: "Sales",
                table: "Orders",
                column: "custid");

            migrationBuilder.CreateIndex(
                name: "idx_nc_empid",
                schema: "Sales",
                table: "Orders",
                column: "empid");

            migrationBuilder.CreateIndex(
                name: "idx_nc_orderdate",
                schema: "Sales",
                table: "Orders",
                column: "orderdate");

            migrationBuilder.CreateIndex(
                name: "idx_nc_shippeddate",
                schema: "Sales",
                table: "Orders",
                column: "shippeddate");

            migrationBuilder.CreateIndex(
                name: "idx_nc_shipperid",
                schema: "Sales",
                table: "Orders",
                column: "shipperid");

            migrationBuilder.CreateIndex(
                name: "idx_nc_shippostalcode",
                schema: "Sales",
                table: "Orders",
                column: "shippostalcode");

            migrationBuilder.CreateIndex(
                name: "idx_nc_categoryid",
                schema: "Production",
                table: "Products",
                column: "categoryid");

            migrationBuilder.CreateIndex(
                name: "idx_nc_productname",
                schema: "Production",
                table: "Products",
                column: "productname");

            migrationBuilder.CreateIndex(
                name: "idx_nc_supplierid",
                schema: "Production",
                table: "Products",
                column: "supplierid");

            migrationBuilder.CreateIndex(
                name: "idx_nc_companyname",
                schema: "Production",
                table: "Suppliers",
                column: "companyname");

            migrationBuilder.CreateIndex(
                name: "idx_nc_postalcode",
                schema: "Production",
                table: "Suppliers",
                column: "postalcode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerOrderPrediction",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "OrderDetails",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "Employees",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "Shippers",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "Suppliers",
                schema: "Production");
        }
    }
}
