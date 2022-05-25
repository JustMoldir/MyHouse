using Microsoft.EntityFrameworkCore.Migrations;

namespace UserHouseRole.Data.Migrations
{
    public partial class FirstSRC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RentHouse",
                columns: table => new
                {
                    SaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    TipRent = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    KolKomnat = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    TipStroenie = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    Ploshad = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Sostoyanie = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Internet = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Bolkony = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Uchastok = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    RImageName1 = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    RImageName2 = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    RImageName3 = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    RImageName4 = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    RImageName5 = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    RImageName6 = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentHouse", x => x.SaleId);
                });

            migrationBuilder.CreateTable(
                name: "SaleHouse",
                columns: table => new
                {
                    SaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    KolKomnat = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    TipStroenie = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    Ploshad = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Sostoyanie = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Internet = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Bolkony = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Uchastok = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    SImageName1 = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    SImageName2 = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    SImageName3 = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    SImageName4 = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    SImageName5 = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    SImageName6 = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleHouse", x => x.SaleId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentHouse");

            migrationBuilder.DropTable(
                name: "SaleHouse");
        }
    }
}
