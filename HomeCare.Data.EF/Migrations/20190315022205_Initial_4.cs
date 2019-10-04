using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeCare.Data.EF.Migrations
{
    public partial class Initial_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Thirdcheck",
                table: "HelperChecks",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<bool>(
                name: "Secondcheck",
                table: "HelperChecks",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<bool>(
                name: "Firstcheck",
                table: "HelperChecks",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AddColumn<bool>(
                name: "Cancel",
                table: "HelperChecks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cancel",
                table: "HelperChecks");

            migrationBuilder.AlterColumn<bool>(
                name: "Thirdcheck",
                table: "HelperChecks",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Secondcheck",
                table: "HelperChecks",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Firstcheck",
                table: "HelperChecks",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);
        }
    }
}
