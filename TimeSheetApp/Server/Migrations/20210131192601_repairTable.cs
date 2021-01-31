using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheetApp.Server.Migrations
{
    public partial class repairTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Timesheets_TimesheetID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_TimesheetID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TimesheetID",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "TimesheetUser",
                columns: table => new
                {
                    TimesheetsID = table.Column<int>(type: "int", nullable: false),
                    UsersID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimesheetUser", x => new { x.TimesheetsID, x.UsersID });
                    table.ForeignKey(
                        name: "FK_TimesheetUser_Timesheets_TimesheetsID",
                        column: x => x.TimesheetsID,
                        principalTable: "Timesheets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimesheetUser_Users_UsersID",
                        column: x => x.UsersID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimesheetUser_UsersID",
                table: "TimesheetUser",
                column: "UsersID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimesheetUser");

            migrationBuilder.AddColumn<int>(
                name: "TimesheetID",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_TimesheetID",
                table: "Users",
                column: "TimesheetID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Timesheets_TimesheetID",
                table: "Users",
                column: "TimesheetID",
                principalTable: "Timesheets",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
