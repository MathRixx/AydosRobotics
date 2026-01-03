using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AydosRobotics_WEB.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MotorDrivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vendor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotorDrivers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Motors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vendor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Season = table.Column<int>(type: "int", nullable: false),
                    Regional = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeamNumber = table.Column<int>(type: "int", nullable: false),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamPitNo = table.Column<int>(type: "int", nullable: false),
                    School = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mentor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Robots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Season = table.Column<int>(type: "int", nullable: false),
                    Regional = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RobotName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    Taxi = table.Column<bool>(type: "bit", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AutonomousDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Robots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Robots_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DriveTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RobotId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriveTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DriveTypes_Robots_RobotId",
                        column: x => x.RobotId,
                        principalTable: "Robots",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RobotMotorDrivers",
                columns: table => new
                {
                    MotorDriverId = table.Column<int>(type: "int", nullable: false),
                    RobotId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RobotMotorDrivers", x => new { x.RobotId, x.MotorDriverId });
                    table.ForeignKey(
                        name: "FK_RobotMotorDrivers_MotorDrivers_MotorDriverId",
                        column: x => x.MotorDriverId,
                        principalTable: "MotorDrivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RobotMotorDrivers_Robots_RobotId",
                        column: x => x.RobotId,
                        principalTable: "Robots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RobotMotors",
                columns: table => new
                {
                    RobotId = table.Column<int>(type: "int", nullable: false),
                    MotorId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RobotMotors", x => new { x.RobotId, x.MotorId });
                    table.ForeignKey(
                        name: "FK_RobotMotors_Motors_MotorId",
                        column: x => x.MotorId,
                        principalTable: "Motors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RobotMotors_Robots_RobotId",
                        column: x => x.RobotId,
                        principalTable: "Robots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DriveTypes",
                columns: new[] { "Id", "Name", "RobotId" },
                values: new object[,]
                {
                    { 1, "Tank Drive", null },
                    { 2, "Mecanum Drive", null },
                    { 3, "Swerve Drive", null },
                    { 4, "H Drive", null },
                    { 5, "Octanum/Butterfly Drive", null },
                    { 6, "Kiwi Drive (Omni Wheels)", null },
                    { 7, "Holonomic Drive (Omni Wheel X-Drive)", null },
                    { 8, "Treads", null }
                });

            migrationBuilder.InsertData(
                table: "MotorDrivers",
                columns: new[] { "Id", "Name", "Type", "Vendor" },
                values: new object[,]
                {
                    { 1, "Talon SR", "PWM", "CTRE" },
                    { 2, "Talon SRX", "CAN", "CTRE" },
                    { 3, "Victor SP", "PWM", "VEX Robotics" },
                    { 4, "Victor SPX", "CAN", "VEX Robotics" },
                    { 5, "SPARK", "PWM", "REV Robotics" },
                    { 6, "SPARK MAX", "CAN", "REV Robotics" }
                });

            migrationBuilder.InsertData(
                table: "Motors",
                columns: new[] { "Id", "Name", "Type", "Vendor" },
                values: new object[,]
                {
                    { 1, "NEO", "Brushless", "REV Robotics" },
                    { 2, "NEO 550", "Brushless", "REV Robotics" },
                    { 3, "Falcon 500", "Brushless", "Falcon FX" },
                    { 4, "CIM", "Brushed", "AndyMark" },
                    { 5, "mini CIM", "Brushed", "AndyMark" },
                    { 6, "BAG", "Brushed", "AndyNark" },
                    { 7, "775pro", "Brushed", "VEX" },
                    { 8, "RedLine", "Brushed", "AndyNark" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DriveTypes_RobotId",
                table: "DriveTypes",
                column: "RobotId",
                unique: true,
                filter: "[RobotId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RobotMotorDrivers_MotorDriverId",
                table: "RobotMotorDrivers",
                column: "MotorDriverId");

            migrationBuilder.CreateIndex(
                name: "IX_RobotMotors_MotorId",
                table: "RobotMotors",
                column: "MotorId");

            migrationBuilder.CreateIndex(
                name: "IX_Robots_TeamId",
                table: "Robots",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DriveTypes");

            migrationBuilder.DropTable(
                name: "RobotMotorDrivers");

            migrationBuilder.DropTable(
                name: "RobotMotors");

            migrationBuilder.DropTable(
                name: "MotorDrivers");

            migrationBuilder.DropTable(
                name: "Motors");

            migrationBuilder.DropTable(
                name: "Robots");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
