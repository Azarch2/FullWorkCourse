using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WpfApp6.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    Login = table.Column<string>(type: "TEXT (100)", nullable: false),
                    Password = table.Column<string>(type: "TEXT (100)", nullable: false),
                    Email = table.Column<string>(type: "TEXT (100)", nullable: false),
                    Role = table.Column<string>(type: "TEXT (100)", nullable: false),
                    Storage = table.Column<long>(nullable: false),
                    MaxStorage = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Video",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    Resolution = table.Column<string>(type: "TEXT (100)", nullable: true),
                    Size = table.Column<long>(nullable: false),
                    Format = table.Column<string>(type: "TEXT (4)", nullable: false),
                    Name = table.Column<string>(type: "TEXT (100)", nullable: false),
                    Time = table.Column<string>(nullable: false),
                    Preview = table.Column<string>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    VideoData = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Video_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AuthorOfVideo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    Name = table.Column<string>(type: "TEXT (100)", nullable: false),
                    Surname = table.Column<string>(type: "TEXT (100)", nullable: false),
                    Country = table.Column<string>(type: "TEXT (100)", nullable: false),
                    Street = table.Column<string>(type: "TEXT (100)", nullable: false),
                    House = table.Column<string>(type: "TEXT (100)", nullable: false),
                    Email = table.Column<string>(type: "TEXT (100)", nullable: false),
                    City = table.Column<string>(type: "TEXT (100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorOfVideo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthorOfVideo_Video_Id",
                        column: x => x.Id,
                        principalTable: "Video",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlaceOfVideo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    Country = table.Column<string>(type: "TEXT (100)", nullable: false),
                    City = table.Column<string>(type: "TEXT (100)", nullable: false),
                    Street = table.Column<string>(type: "TEXT (100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceOfVideo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaceOfVideo_Video_Id",
                        column: x => x.Id,
                        principalTable: "Video",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Video_UserId",
                table: "Video",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorOfVideo");

            migrationBuilder.DropTable(
                name: "PlaceOfVideo");

            migrationBuilder.DropTable(
                name: "Video");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
