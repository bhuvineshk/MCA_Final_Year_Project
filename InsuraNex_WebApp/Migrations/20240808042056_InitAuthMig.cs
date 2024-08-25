using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Insuranex.Migrations
{
    /// <inheritdoc />
    public partial class InitAuthMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9bd868d0-5833-4cf3-838e-af2edede220d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa9c9bcb-5e90-4a93-b94e-f96cbbaa74d1", "AQAAAAIAAYagAAAAELpy+PT3z0NMh+e0NUiQmrkDObJzOiWdK4vgNAqVshfKca93RLv504Sk526Xdi5HVw==", "9d73a0d0-ae0c-4820-9cc4-fc9e20e71b43" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9bd868d0-5833-4cf3-838e-af2edede220d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68b4552d-3026-4845-9262-1c3515454c7a", "AQAAAAIAAYagAAAAEAo5TadAiu5HIJWVY+1be/bkSYFHkYzFFxbdqnIvztokgVqpBq7wm5XYbE4NhqxhzA==", "e2f9d533-e460-4153-a81c-3f05e083e944" });
        }
    }
}
