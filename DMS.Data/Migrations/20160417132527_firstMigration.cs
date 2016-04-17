using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace DMS.Data.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EMail = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Host",
                columns: table => new
                {
                    HostId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    HostName = table.Column<string>(nullable: true),
                    IP = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    OsType = table.Column<string>(nullable: true),
                    ServerVersion = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Host", x => x.HostId);
                    table.ForeignKey(
                        name: "FK_Host_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    ActivityId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true),
                    HappendDate = table.Column<DateTime>(nullable: false),
                    HostId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.ActivityId);
                    table.ForeignKey(
                        name: "FK_Activity_Host_HostId",
                        column: x => x.HostId,
                        principalTable: "Host",
                        principalColumn: "HostId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activity_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Container",
                columns: table => new
                {
                    ContainerId = table.Column<string>(nullable: false),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    ContainerName = table.Column<string>(nullable: true),
                    HostId = table.Column<int>(nullable: false),
                    JSONDetail = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Container", x => x.ContainerId);
                    table.ForeignKey(
                        name: "FK_Container_Host_HostId",
                        column: x => x.HostId,
                        principalTable: "Host",
                        principalColumn: "HostId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Container_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "ContainerImage",
                columns: table => new
                {
                    ContainerImageId = table.Column<string>(nullable: false),
                    GetTime = table.Column<DateTime>(nullable: false),
                    HostId = table.Column<int>(nullable: false),
                    JSONDetail = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContainerImage", x => x.ContainerImageId);
                    table.ForeignKey(
                        name: "FK_ContainerImage_Host_HostId",
                        column: x => x.HostId,
                        principalTable: "Host",
                        principalColumn: "HostId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContainerImage_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Activity");
            migrationBuilder.DropTable("Container");
            migrationBuilder.DropTable("ContainerImage");
            migrationBuilder.DropTable("Host");
            migrationBuilder.DropTable("User");
            migrationBuilder.DropTable("Role");
        }
    }
}
