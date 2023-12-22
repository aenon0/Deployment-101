using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class secdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Message = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "98299e6c-a49e-4c73-bef8-35744ee41fd5", "AQAAAAIAAYagAAAAEAqyzDvD737twJIniZOzB4d2b+5lTzTONIFJ1YRvJJN/rTCH65OBU9zw9BD0XiQJAg==", "e7f4d584-30fb-4184-8a0f-75498bb225b6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe9ca14d-bcae-4226-b2a9-8fe980a846b6", "AQAAAAIAAYagAAAAEGNrYY5Tt+vxqhUtQmRmVMegUQ40XyfnjRSUyetD1BH9nunJTR3wKNmmXnJzZj4WAQ==", "72bf3356-9554-4074-b961-d831961a82a8" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f97808a3-db7d-4351-b2fa-0444df366185", "AQAAAAIAAYagAAAAEHm0TF5ZUxJF3bc+DY4AE8Mbp/n9SvxNiL8njgzL3Y1sNlgvuCxD8/knVghLLEnZow==", "e5662b4b-1ffa-46ab-bd21-1fcc5ee8b28c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "55f3fdc4-0c9c-4bbd-9b07-04f447df3c9a", "AQAAAAIAAYagAAAAEMTyedDnT12Nyydk9MkwSA5VyeQkxjc0Tg90d6EpxrmtrdxVIfWjRDtEsR81TI8BEA==", "d631cd87-dcf1-4d10-9e59-0d63e12c9e56" });
        }
    }
}
