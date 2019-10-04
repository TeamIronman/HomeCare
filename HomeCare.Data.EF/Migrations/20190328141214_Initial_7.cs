using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeCare.Data.EF.Migrations
{
    public partial class Initial_7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Workinghours",
                table: "Bills");

            migrationBuilder.RenameColumn(
                name: "Rooms",
                table: "Bills",
                newName: "PaymentMethodId");

            migrationBuilder.RenameColumn(
                name: "Acreage",
                table: "Bills",
                newName: "BillOptionId");

            migrationBuilder.AddColumn<int>(
                name: "ReviewStatus",
                table: "Reviews",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Workday",
                table: "Bills",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "CancelBillNumber",
                table: "AppHelpers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CancelBillNumber",
                table: "AppCustomers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BillCancelNumbers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Number = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillCancelNumbers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BillOptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Workinghours = table.Column<string>(nullable: false),
                    Acreage = table.Column<int>(nullable: false),
                    Rooms = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillOptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HelperNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HelperNumbers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BillOptionHelperNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BillOptionId = table.Column<int>(nullable: false),
                    HelperNumberId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillOptionHelperNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillOptionHelperNumbers_BillOptions_BillOptionId",
                        column: x => x.BillOptionId,
                        principalTable: "BillOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillOptionHelperNumbers_HelperNumbers_HelperNumberId",
                        column: x => x.HelperNumberId,
                        principalTable: "HelperNumbers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bills_BillOptionId",
                table: "Bills",
                column: "BillOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_PaymentMethodId",
                table: "Bills",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_BillOptionHelperNumbers_BillOptionId",
                table: "BillOptionHelperNumbers",
                column: "BillOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_BillOptionHelperNumbers_HelperNumberId",
                table: "BillOptionHelperNumbers",
                column: "HelperNumberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_BillOptions_BillOptionId",
                table: "Bills",
                column: "BillOptionId",
                principalTable: "BillOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_PaymentMethods_PaymentMethodId",
                table: "Bills",
                column: "PaymentMethodId",
                principalTable: "PaymentMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_BillOptions_BillOptionId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Bills_PaymentMethods_PaymentMethodId",
                table: "Bills");

            migrationBuilder.DropTable(
                name: "BillCancelNumbers");

            migrationBuilder.DropTable(
                name: "BillOptionHelperNumbers");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "BillOptions");

            migrationBuilder.DropTable(
                name: "HelperNumbers");

            migrationBuilder.DropIndex(
                name: "IX_Bills_BillOptionId",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_Bills_PaymentMethodId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "ReviewStatus",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "CancelBillNumber",
                table: "AppHelpers");

            migrationBuilder.DropColumn(
                name: "CancelBillNumber",
                table: "AppCustomers");

            migrationBuilder.RenameColumn(
                name: "PaymentMethodId",
                table: "Bills",
                newName: "Rooms");

            migrationBuilder.RenameColumn(
                name: "BillOptionId",
                table: "Bills",
                newName: "Acreage");

            migrationBuilder.AlterColumn<string>(
                name: "Workday",
                table: "Bills",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<string>(
                name: "Workinghours",
                table: "Bills",
                nullable: false,
                defaultValue: "");
        }
    }
}
