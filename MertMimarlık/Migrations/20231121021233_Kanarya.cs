using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MertMimarlık.Migrations
{
    /// <inheritdoc />
    public partial class Kanarya : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    AdminID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    username = table.Column<string>(type: "TEXT", nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false),
                    confirmpassword = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admins", x => x.AdminID);
                });

            migrationBuilder.CreateTable(
                name: "iletisimBilgileris",
                columns: table => new
                {
                    IletisimID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AdSoyad = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    TelefonNumarasi = table.Column<string>(type: "TEXT", nullable: false),
                    Konu = table.Column<string>(type: "TEXT", nullable: false),
                    Mesaj = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_iletisimBilgileris", x => x.IletisimID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admins");

            migrationBuilder.DropTable(
                name: "iletisimBilgileris");
        }
    }
}
