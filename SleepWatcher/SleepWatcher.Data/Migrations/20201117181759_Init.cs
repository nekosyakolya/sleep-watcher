using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SleepWatcher.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SleepTimeSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeginSleepTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndSleepTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SleepTimeSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    VkId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    SleepTimeSettingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.VkId);
                    table.ForeignKey(
                        name: "FK_Users_SleepTimeSettings_SleepTimeSettingId",
                        column: x => x.SleepTimeSettingId,
                        principalTable: "SleepTimeSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SleepTimeSettings_BeginSleepTime_EndSleepTime",
                table: "SleepTimeSettings",
                columns: new[] { "BeginSleepTime", "EndSleepTime" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_SleepTimeSettingId",
                table: "Users",
                column: "SleepTimeSettingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "SleepTimeSettings");
        }
    }
}
