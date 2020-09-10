using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanLySinhVien.Data.Migrations
{
    public partial class add_id_chuongtrinhdaotao_to_sinhviens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ID_ChuongTrinhDaoTao",
                table: "SinhViens",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("7e2de1ee-b97b-4698-abe4-c22a0332b2c9"),
                column: "ConcurrencyStamp",
                value: "fece5e83-8ab0-47cd-968c-49836f178c53");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("ddcfd40f-0c20-4bbd-afbf-5936032ddde5"),
                column: "ConcurrencyStamp",
                value: "2fc4510e-caa2-4238-a519-87d55e14ca7c");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("8dd4e4e7-cbb1-4db8-8cd8-3024401afc74"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cb3fbc89-417d-4997-a282-4490f3bbd33b", "AQAAAAEAACcQAAAAEF2a5kHOwg9JdgJ6o4zjvoZR1GHlm1EYgxGGEMFFW+2hNueAazizNGoTdSZYCIMchQ==" });

            migrationBuilder.InsertData(
                table: "ChuyenMons",
                columns: new[] { "ID_GiangVien", "ID_MonHoc" },
                values: new object[,]
                {
                    { "GV001", "INT002" },
                    { "GV001", "INT003" },
                    { "GV002", "INT003" },
                    { "GV001", "INT004" }
                });

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
                columns: new[] { "ID_ChuongTrinhDaoTao", "IsActive" },
                values: new object[] { "2016CNTT01", 1 });

            migrationBuilder.UpdateData(
                table: "SinhViens",
                keyColumn: "ID",
                keyValue: "161A010002",
                columns: new[] { "ID_ChuongTrinhDaoTao", "IsActive" },
                values: new object[] { "2016CNTT01", 1 });

            migrationBuilder.UpdateData(
                table: "SinhViens",
                keyColumn: "ID",
                keyValue: "161A010003",
                columns: new[] { "ID_ChuongTrinhDaoTao", "IsActive" },
                values: new object[] { "2016CNTT01", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_SinhViens_ID_ChuongTrinhDaoTao",
                table: "SinhViens",
                column: "ID_ChuongTrinhDaoTao");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhViens_ChuongTrinhDaoTaos_ID_ChuongTrinhDaoTao",
                table: "SinhViens",
                column: "ID_ChuongTrinhDaoTao",
                principalTable: "ChuongTrinhDaoTaos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SinhViens_ChuongTrinhDaoTaos_ID_ChuongTrinhDaoTao",
                table: "SinhViens");

            migrationBuilder.DropIndex(
                name: "IX_SinhViens_ID_ChuongTrinhDaoTao",
                table: "SinhViens");

            migrationBuilder.DeleteData(
                table: "ChuyenMons",
                keyColumns: new[] { "ID_GiangVien", "ID_MonHoc" },
                keyValues: new object[] { "GV001", "INT002" });

            migrationBuilder.DeleteData(
                table: "ChuyenMons",
                keyColumns: new[] { "ID_GiangVien", "ID_MonHoc" },
                keyValues: new object[] { "GV001", "INT003" });

            migrationBuilder.DeleteData(
                table: "ChuyenMons",
                keyColumns: new[] { "ID_GiangVien", "ID_MonHoc" },
                keyValues: new object[] { "GV001", "INT004" });

            migrationBuilder.DeleteData(
                table: "ChuyenMons",
                keyColumns: new[] { "ID_GiangVien", "ID_MonHoc" },
                keyValues: new object[] { "GV002", "INT003" });

            migrationBuilder.DropColumn(
                name: "ID_ChuongTrinhDaoTao",
                table: "SinhViens");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("7e2de1ee-b97b-4698-abe4-c22a0332b2c9"),
                column: "ConcurrencyStamp",
                value: "cfde6648-f3f0-408e-ab12-2b3b85c73b4c");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("ddcfd40f-0c20-4bbd-afbf-5936032ddde5"),
                column: "ConcurrencyStamp",
                value: "334acdf9-0c3d-4947-b3eb-f20eeab60665");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("8dd4e4e7-cbb1-4db8-8cd8-3024401afc74"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "98deba71-381b-49da-be57-f89a701c532a", "AQAAAAEAACcQAAAAEMd/+frAr1gc8mVZv9LsZN3sbh2xIiD6q66dzdReZtDwl4NpYFDXR7UdbLm/t3Y5Fw==" });

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
                keyValue: "161A010003",
                column: "IsActive",
                value: 1);
        }
    }
}
