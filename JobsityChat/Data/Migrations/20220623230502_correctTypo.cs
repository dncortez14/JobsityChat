using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobsityChat.Data.Migrations
{
    public partial class correctTypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserSender",
                table: "Messages",
                newName: "SenderUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SenderUser",
                table: "Messages",
                newName: "UserSender");
        }
    }
}
