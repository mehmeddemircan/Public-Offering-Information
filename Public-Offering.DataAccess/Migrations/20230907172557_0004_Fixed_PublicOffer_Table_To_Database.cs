using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Public_Offering.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class _0004_Fixed_PublicOffer_Table_To_Database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PublicOfferStatu",
                table: "PublicOffers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PublicOffers_CompanyId",
                table: "PublicOffers",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_PublicOffers_Companies_CompanyId",
                table: "PublicOffers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PublicOffers_Companies_CompanyId",
                table: "PublicOffers");

            migrationBuilder.DropIndex(
                name: "IX_PublicOffers_CompanyId",
                table: "PublicOffers");

            migrationBuilder.AlterColumn<int>(
                name: "PublicOfferStatu",
                table: "PublicOffers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
