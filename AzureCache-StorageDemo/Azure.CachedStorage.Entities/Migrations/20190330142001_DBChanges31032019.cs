using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Azure.CachedStorage.Entities.Migrations
{
    public partial class DBChanges31032019 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Expense",
                newName: "Title");

            migrationBuilder.AddColumn<float>(
                name: "Amount",
                table: "Expense",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Attachments",
                table: "Expense",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BilledDate",
                table: "Expense",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "ExpenseCategoryId",
                table: "Expense",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Expense",
                maxLength: 500,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ExpenseCategories",
                columns: table => new
                {
                    ExpenseCategoryId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    Descrption = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseCategories", x => x.ExpenseCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    ProfileId = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 60, nullable: false),
                    LastName = table.Column<string>(maxLength: 60, nullable: false),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.ProfileId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expense_ExpenseCategoryId",
                table: "Expense",
                column: "ExpenseCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_ExpenseCategories_ExpenseCategoryId",
                table: "Expense",
                column: "ExpenseCategoryId",
                principalTable: "ExpenseCategories",
                principalColumn: "ExpenseCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expense_ExpenseCategories_ExpenseCategoryId",
                table: "Expense");

            migrationBuilder.DropTable(
                name: "ExpenseCategories");

            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropIndex(
                name: "IX_Expense_ExpenseCategoryId",
                table: "Expense");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Expense");

            migrationBuilder.DropColumn(
                name: "Attachments",
                table: "Expense");

            migrationBuilder.DropColumn(
                name: "BilledDate",
                table: "Expense");

            migrationBuilder.DropColumn(
                name: "ExpenseCategoryId",
                table: "Expense");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "Expense");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Expense",
                newName: "Name");
        }
    }
}
