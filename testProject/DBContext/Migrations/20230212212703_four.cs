using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class four : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_People_GenderId",
                table: "People",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_People_HealthFundId",
                table: "People",
                column: "HealthFundId");

            migrationBuilder.CreateIndex(
                name: "IX_Children_ParentId",
                table: "Children",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Children_People_ParentId",
                table: "Children",
                column: "ParentId",
                principalTable: "People",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Genders_GenderId",
                table: "People",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_People_HealthFunds_HealthFundId",
                table: "People",
                column: "HealthFundId",
                principalTable: "HealthFunds",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Children_People_ParentId",
                table: "Children");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Genders_GenderId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_People_HealthFunds_HealthFundId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_GenderId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_HealthFundId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_Children_ParentId",
                table: "Children");
        }
    }
}
