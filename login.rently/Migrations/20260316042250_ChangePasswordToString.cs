using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace login.rently.Migrations
{
    /// <inheritdoc />
    public partial class ChangePasswordToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lenders");

            migrationBuilder.DropTable(
                name: "Renters");
        }
    }
}
