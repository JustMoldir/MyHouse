using Microsoft.EntityFrameworkCore.Migrations;

namespace UserHouseRole.Data.Migrations
{
    public partial class FirstSRC2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreditHouse",
                columns: table => new
                {
                    CreditId = table.Column<int>(type: "int", nullable: false)
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
                    CImageName1 = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    CImageName2 = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    CImageName3 = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    CImageName4 = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    CImageName5 = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    CImageName6 = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditHouse", x => x.CreditId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditHouse");
        }
    }
}
