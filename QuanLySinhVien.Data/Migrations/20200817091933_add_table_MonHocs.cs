using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanLySinhVien.Data.Migrations
{
    public partial class add_table_MonHocs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTiet_ChuongTrinhDaoTao_MonHocs_MonHoc_ID_MonHoc",
                table: "ChiTiet_ChuongTrinhDaoTao_MonHocs");

            migrationBuilder.DropForeignKey(
                name: "FK_LopHocPhans_MonHoc_ID_MonHoc",
                table: "LopHocPhans");

            migrationBuilder.DropForeignKey(
                name: "FK_MonHoc_Khoas_KhoaID",
                table: "MonHoc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MonHoc",
                table: "MonHoc");

            migrationBuilder.DropIndex(
                name: "IX_MonHoc_KhoaID",
                table: "MonHoc");

            migrationBuilder.DropColumn(
                name: "KhoaID",
                table: "MonHoc");

            migrationBuilder.RenameTable(
                name: "MonHoc",
                newName: "MonHocs");

            migrationBuilder.RenameColumn(
                name: "Id_Khoa",
                table: "MonHocs",
                newName: "ID_Khoa");

            migrationBuilder.AlterColumn<string>(
                name: "TenMonHoc",
                table: "MonHocs",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ID_Khoa",
                table: "MonHocs",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MonHocs",
                table: "MonHocs",
                column: "ID");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("7e2de1ee-b97b-4698-abe4-c22a0332b2c9"),
                column: "ConcurrencyStamp",
                value: "0b90c062-de21-4a2e-8741-0ab29f794fad");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("ddcfd40f-0c20-4bbd-afbf-5936032ddde5"),
                column: "ConcurrencyStamp",
                value: "de4ccb6e-e4ba-44a5-b935-04c09eea1def");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("8dd4e4e7-cbb1-4db8-8cd8-3024401afc74"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1cd55f6f-eb30-475b-8aed-23cfb82c36a9", "AQAAAAEAACcQAAAAELPR1dgmpTHUOLyqW2JCb2LzIKSRbrohbbB0ftxM+FIEUQlIThNeiG6otFYHM8UVqA==" });

            migrationBuilder.UpdateData(
                table: "GiangViens",
                keyColumn: "ID",
                keyValue: "GV001",
                column: "IsActive",
                value: 1);

            migrationBuilder.UpdateData(
                table: "GiangViens",
                keyColumn: "ID",
                keyValue: "GV002",
                column: "IsActive",
                value: 1);

            migrationBuilder.UpdateData(
                table: "LopHocPhans",
                keyColumn: "ID",
                keyValue: "161INT001",
                column: "IsActive",
                value: 1);

            migrationBuilder.UpdateData(
                table: "LopHocPhans",
                keyColumn: "ID",
                keyValue: "161INT002",
                column: "IsActive",
                value: 1);

            migrationBuilder.UpdateData(
                table: "LopHocPhans",
                keyColumn: "ID",
                keyValue: "161INT003",
                column: "IsActive",
                value: 1);

            migrationBuilder.UpdateData(
                table: "LopHocPhans",
                keyColumn: "ID",
                keyValue: "161INT004",
                column: "IsActive",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SinhViens",
                keyColumn: "ID",
                keyValue: "161A010001",
                column: "IsActive",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SinhViens",
                keyColumn: "ID",
                keyValue: "161A010002",
                column: "IsActive",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SinhViens",
                keyColumn: "ID",
                keyValue: "161A010139",
                column: "IsActive",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_MonHocs_ID_Khoa",
                table: "MonHocs",
                column: "ID_Khoa");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTiet_ChuongTrinhDaoTao_MonHocs_MonHocs_ID_MonHoc",
                table: "ChiTiet_ChuongTrinhDaoTao_MonHocs",
                column: "ID_MonHoc",
                principalTable: "MonHocs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LopHocPhans_MonHocs_ID_MonHoc",
                table: "LopHocPhans",
                column: "ID_MonHoc",
                principalTable: "MonHocs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MonHocs_Khoas_ID_Khoa",
                table: "MonHocs",
                column: "ID_Khoa",
                principalTable: "Khoas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTiet_ChuongTrinhDaoTao_MonHocs_MonHocs_ID_MonHoc",
                table: "ChiTiet_ChuongTrinhDaoTao_MonHocs");

            migrationBuilder.DropForeignKey(
                name: "FK_LopHocPhans_MonHocs_ID_MonHoc",
                table: "LopHocPhans");

            migrationBuilder.DropForeignKey(
                name: "FK_MonHocs_Khoas_ID_Khoa",
                table: "MonHocs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MonHocs",
                table: "MonHocs");

            migrationBuilder.DropIndex(
                name: "IX_MonHocs_ID_Khoa",
                table: "MonHocs");

            migrationBuilder.RenameTable(
                name: "MonHocs",
                newName: "MonHoc");

            migrationBuilder.RenameColumn(
                name: "ID_Khoa",
                table: "MonHoc",
                newName: "Id_Khoa");

            migrationBuilder.AlterColumn<string>(
                name: "TenMonHoc",
                table: "MonHoc",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Id_Khoa",
                table: "MonHoc",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KhoaID",
                table: "MonHoc",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MonHoc",
                table: "MonHoc",
                column: "ID");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("7e2de1ee-b97b-4698-abe4-c22a0332b2c9"),
                column: "ConcurrencyStamp",
                value: "05072081-c769-4eca-88f1-004140f27054");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("ddcfd40f-0c20-4bbd-afbf-5936032ddde5"),
                column: "ConcurrencyStamp",
                value: "7b2c3a96-0d7e-4a26-ae6a-0db9439326ce");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("8dd4e4e7-cbb1-4db8-8cd8-3024401afc74"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "819f1f83-04b1-4bd5-b798-ca10b40bb178", "AQAAAAEAACcQAAAAECoOk9tSk9F2D/myE2NBkVDRpm6J5JPndHfk/lzz2jyZfADsAi76PdWcXDLTei1Zuw==" });

            migrationBuilder.UpdateData(
                table: "GiangViens",
                keyColumn: "ID",
                keyValue: "GV001",
                column: "IsActive",
                value: 1);

            migrationBuilder.UpdateData(
                table: "GiangViens",
                keyColumn: "ID",
                keyValue: "GV002",
                column: "IsActive",
                value: 1);

            migrationBuilder.UpdateData(
                table: "LopHocPhans",
                keyColumn: "ID",
                keyValue: "161INT001",
                column: "IsActive",
                value: 1);

            migrationBuilder.UpdateData(
                table: "LopHocPhans",
                keyColumn: "ID",
                keyValue: "161INT002",
                column: "IsActive",
                value: 1);

            migrationBuilder.UpdateData(
                table: "LopHocPhans",
                keyColumn: "ID",
                keyValue: "161INT003",
                column: "IsActive",
                value: 1);

            migrationBuilder.UpdateData(
                table: "LopHocPhans",
                keyColumn: "ID",
                keyValue: "161INT004",
                column: "IsActive",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SinhViens",
                keyColumn: "ID",
                keyValue: "161A010001",
                column: "IsActive",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SinhViens",
                keyColumn: "ID",
                keyValue: "161A010002",
                column: "IsActive",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SinhViens",
                keyColumn: "ID",
                keyValue: "161A010139",
                column: "IsActive",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_MonHoc_KhoaID",
                table: "MonHoc",
                column: "KhoaID");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTiet_ChuongTrinhDaoTao_MonHocs_MonHoc_ID_MonHoc",
                table: "ChiTiet_ChuongTrinhDaoTao_MonHocs",
                column: "ID_MonHoc",
                principalTable: "MonHoc",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LopHocPhans_MonHoc_ID_MonHoc",
                table: "LopHocPhans",
                column: "ID_MonHoc",
                principalTable: "MonHoc",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MonHoc_Khoas_KhoaID",
                table: "MonHoc",
                column: "KhoaID",
                principalTable: "Khoas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
