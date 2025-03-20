using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateHotel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "room",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    price_currency = table.Column<string>(type: "text", nullable: false),
                    price_value = table.Column<double>(type: "double precision", nullable: false),
                    room_type = table.Column<int>(type: "integer", nullable: false),
                    conveniences = table.Column<int[]>(type: "integer[]", nullable: false),
                    hotel_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_room", x => x.id);
                    table.ForeignKey(
                        name: "fk_room_hotels_hotel_id",
                        column: x => x.hotel_id,
                        principalTable: "hotels",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "current_room",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    number = table.Column<int>(type: "integer", nullable: false),
                    photos = table.Column<byte[]>(type: "smallint[]", nullable: false),
                    room_id = table.Column<Guid>(type: "uuid", nullable: false),
                    hotel_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_current_room", x => x.id);
                    table.ForeignKey(
                        name: "fk_current_room_hotels_hotel_id",
                        column: x => x.hotel_id,
                        principalTable: "hotels",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_current_room_room_room_id",
                        column: x => x.room_id,
                        principalTable: "room",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_current_room_hotel_id",
                table: "current_room",
                column: "hotel_id");

            migrationBuilder.CreateIndex(
                name: "ix_current_room_room_id",
                table: "current_room",
                column: "room_id");

            migrationBuilder.CreateIndex(
                name: "ix_room_hotel_id",
                table: "room",
                column: "hotel_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "current_room");

            migrationBuilder.DropTable(
                name: "room");
        }
    }
}
