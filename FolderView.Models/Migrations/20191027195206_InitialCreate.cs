using Microsoft.EntityFrameworkCore.Migrations;

namespace FolderView.Models.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Folders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FolderTree",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AncestorId = table.Column<int>(nullable: false),
                    DescendantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FolderTree", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FolderTree_Folders_AncestorId",
                        column: x => x.AncestorId,
                        principalTable: "Folders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FolderTree_Folders_DescendantId",
                        column: x => x.DescendantId,
                        principalTable: "Folders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Creating Digital Images" });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Resources" });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Evidence" });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Graphic Products" });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Primary Sources" });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "Secondary Sourcess" });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "Id", "Name" },
                values: new object[] { 7, "Process" });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "Id", "Name" },
                values: new object[] { 8, "Final Procuct" });

            migrationBuilder.InsertData(
                table: "FolderTree",
                columns: new[] { "Id", "AncestorId", "DescendantId" },
                values: new object[] { 1, 1, 2 });

            migrationBuilder.InsertData(
                table: "FolderTree",
                columns: new[] { "Id", "AncestorId", "DescendantId" },
                values: new object[] { 2, 1, 3 });

            migrationBuilder.InsertData(
                table: "FolderTree",
                columns: new[] { "Id", "AncestorId", "DescendantId" },
                values: new object[] { 3, 1, 4 });

            migrationBuilder.InsertData(
                table: "FolderTree",
                columns: new[] { "Id", "AncestorId", "DescendantId" },
                values: new object[] { 4, 2, 5 });

            migrationBuilder.InsertData(
                table: "FolderTree",
                columns: new[] { "Id", "AncestorId", "DescendantId" },
                values: new object[] { 5, 2, 6 });

            migrationBuilder.InsertData(
                table: "FolderTree",
                columns: new[] { "Id", "AncestorId", "DescendantId" },
                values: new object[] { 6, 4, 7 });

            migrationBuilder.InsertData(
                table: "FolderTree",
                columns: new[] { "Id", "AncestorId", "DescendantId" },
                values: new object[] { 7, 4, 8 });

            migrationBuilder.CreateIndex(
                name: "IX_FolderTree_AncestorId",
                table: "FolderTree",
                column: "AncestorId");

            migrationBuilder.CreateIndex(
                name: "IX_FolderTree_DescendantId",
                table: "FolderTree",
                column: "DescendantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FolderTree");

            migrationBuilder.DropTable(
                name: "Folders");
        }
    }
}
