using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM_project.Migrations
{
    /// <inheritdoc />
    public partial class New_properties_For_Student : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentName",
                table: "Student",
                newName: "StudentSurname");

            migrationBuilder.AddColumn<string>(
                name: "RecordBook",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StudentFirstName",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StudentPatronymic",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecordBook",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "StudentFirstName",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "StudentPatronymic",
                table: "Student");

            migrationBuilder.RenameColumn(
                name: "StudentSurname",
                table: "Student",
                newName: "StudentName");
        }
    }
}
