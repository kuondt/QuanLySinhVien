using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanLySinhVien.Data.Migrations
{
    public partial class firstdataseeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTiet_ChuongTrinhDaoTao_MonHoc_ChuongTrinhDaoTao_ID_ChuongTrinhDaoTao",
                table: "ChiTiet_ChuongTrinhDaoTao_MonHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTiet_ChuongTrinhDaoTao_MonHoc_MonHoc_ID_MonHoc",
                table: "ChiTiet_ChuongTrinhDaoTao_MonHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTiet_ChuongTrinhDaoTao_MonHoc_HocKy_NamHoc_HK_HocKy_HK_NamHoc",
                table: "ChiTiet_ChuongTrinhDaoTao_MonHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_ChuongTrinhDaoTao_Khoa_Id_Khoa",
                table: "ChuongTrinhDaoTao");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhSach_SinhVien_LopHocPhan_LopHocPhan_ID_LopHocPhan",
                table: "DanhSach_SinhVien_LopHocPhan");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhSach_SinhVien_LopHocPhan_SinhVien_ID_SinhVien",
                table: "DanhSach_SinhVien_LopHocPhan");

            migrationBuilder.DropForeignKey(
                name: "FK_GiangVien_Khoa_ID_Khoa",
                table: "GiangVien");

            migrationBuilder.DropForeignKey(
                name: "FK_LopBienChe_GiangVien_ID_GiangVien",
                table: "LopBienChe");

            migrationBuilder.DropForeignKey(
                name: "FK_LopBienChe_Khoa_ID_Khoa",
                table: "LopBienChe");

            migrationBuilder.DropForeignKey(
                name: "FK_LopHocPhan_MonHoc_ID_MonHoc",
                table: "LopHocPhan");

            migrationBuilder.DropForeignKey(
                name: "FK_LopHocPhan_Phong_ID_Phong",
                table: "LopHocPhan");

            migrationBuilder.DropForeignKey(
                name: "FK_LopHocPhan_HocKy_NamHoc_HK_HocKy_HK_NamHoc",
                table: "LopHocPhan");

            migrationBuilder.DropForeignKey(
                name: "FK_MonHoc_Khoa_KhoaID",
                table: "MonHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_PhanCong_GiangVien_ID_GiangVien",
                table: "PhanCong");

            migrationBuilder.DropForeignKey(
                name: "FK_PhanCong_LopHocPhan_ID_LopHocPhan",
                table: "PhanCong");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhVien_LopBienChe_ID_LopBienChe",
                table: "SinhVien");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SinhVien",
                table: "SinhVien");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Phong",
                table: "Phong");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhanCong",
                table: "PhanCong");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LopHocPhan",
                table: "LopHocPhan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LopBienChe",
                table: "LopBienChe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Khoa",
                table: "Khoa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HocKy_NamHoc",
                table: "HocKy_NamHoc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GiangVien",
                table: "GiangVien");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhSach_SinhVien_LopHocPhan",
                table: "DanhSach_SinhVien_LopHocPhan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChuongTrinhDaoTao",
                table: "ChuongTrinhDaoTao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTiet_ChuongTrinhDaoTao_MonHoc",
                table: "ChiTiet_ChuongTrinhDaoTao_MonHoc");

            migrationBuilder.DropColumn(
                name: "SoTietHoc",
                table: "LopHocPhan");

            migrationBuilder.RenameTable(
                name: "SinhVien",
                newName: "SinhViens");

            migrationBuilder.RenameTable(
                name: "Phong",
                newName: "Phongs");

            migrationBuilder.RenameTable(
                name: "PhanCong",
                newName: "PhanCongs");

            migrationBuilder.RenameTable(
                name: "LopHocPhan",
                newName: "LopHocPhans");

            migrationBuilder.RenameTable(
                name: "LopBienChe",
                newName: "LopBienChes");

            migrationBuilder.RenameTable(
                name: "Khoa",
                newName: "Khoas");

            migrationBuilder.RenameTable(
                name: "HocKy_NamHoc",
                newName: "HocKy_NamHocs");

            migrationBuilder.RenameTable(
                name: "GiangVien",
                newName: "GiangViens");

            migrationBuilder.RenameTable(
                name: "DanhSach_SinhVien_LopHocPhan",
                newName: "DanhSach_SinhVien_LopHocPhans");

            migrationBuilder.RenameTable(
                name: "ChuongTrinhDaoTao",
                newName: "ChuongTrinhDaoTaos");

            migrationBuilder.RenameTable(
                name: "ChiTiet_ChuongTrinhDaoTao_MonHoc",
                newName: "ChiTiet_ChuongTrinhDaoTao_MonHocs");

            migrationBuilder.RenameIndex(
                name: "IX_SinhVien_ID_LopBienChe",
                table: "SinhViens",
                newName: "IX_SinhViens_ID_LopBienChe");

            migrationBuilder.RenameIndex(
                name: "IX_PhanCong_ID_LopHocPhan",
                table: "PhanCongs",
                newName: "IX_PhanCongs_ID_LopHocPhan");

            migrationBuilder.RenameIndex(
                name: "IX_PhanCong_ID_GiangVien",
                table: "PhanCongs",
                newName: "IX_PhanCongs_ID_GiangVien");

            migrationBuilder.RenameIndex(
                name: "IX_LopHocPhan_HK_HocKy_HK_NamHoc",
                table: "LopHocPhans",
                newName: "IX_LopHocPhans_HK_HocKy_HK_NamHoc");

            migrationBuilder.RenameIndex(
                name: "IX_LopHocPhan_ID_Phong",
                table: "LopHocPhans",
                newName: "IX_LopHocPhans_ID_Phong");

            migrationBuilder.RenameIndex(
                name: "IX_LopHocPhan_ID_MonHoc",
                table: "LopHocPhans",
                newName: "IX_LopHocPhans_ID_MonHoc");

            migrationBuilder.RenameIndex(
                name: "IX_LopBienChe_ID_Khoa",
                table: "LopBienChes",
                newName: "IX_LopBienChes_ID_Khoa");

            migrationBuilder.RenameIndex(
                name: "IX_LopBienChe_ID_GiangVien",
                table: "LopBienChes",
                newName: "IX_LopBienChes_ID_GiangVien");

            migrationBuilder.RenameIndex(
                name: "IX_GiangVien_ID_Khoa",
                table: "GiangViens",
                newName: "IX_GiangViens_ID_Khoa");

            migrationBuilder.RenameIndex(
                name: "IX_DanhSach_SinhVien_LopHocPhan_ID_LopHocPhan",
                table: "DanhSach_SinhVien_LopHocPhans",
                newName: "IX_DanhSach_SinhVien_LopHocPhans_ID_LopHocPhan");

            migrationBuilder.RenameIndex(
                name: "IX_ChuongTrinhDaoTao_Id_Khoa",
                table: "ChuongTrinhDaoTaos",
                newName: "IX_ChuongTrinhDaoTaos_Id_Khoa");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTiet_ChuongTrinhDaoTao_MonHoc_HK_HocKy_HK_NamHoc",
                table: "ChiTiet_ChuongTrinhDaoTao_MonHocs",
                newName: "IX_ChiTiet_ChuongTrinhDaoTao_MonHocs_HK_HocKy_HK_NamHoc");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTiet_ChuongTrinhDaoTao_MonHoc_ID_MonHoc",
                table: "ChiTiet_ChuongTrinhDaoTao_MonHocs",
                newName: "IX_ChiTiet_ChuongTrinhDaoTao_MonHocs_ID_MonHoc");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_Diem_Duoi_10",
                table: "DanhSach_SinhVien_LopHocPhans",
                sql: "Diem <= 10");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgaySinh",
                table: "SinhViens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BuoiHoc",
                table: "LopHocPhans",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NgayHoc",
                table: "LopHocPhans",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "GioiTinh",
                table: "GiangViens",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "LanThi",
                table: "DanhSach_SinhVien_LopHocPhans",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "Nam",
                table: "ChuongTrinhDaoTaos",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SinhViens",
                table: "SinhViens",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Phongs",
                table: "Phongs",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhanCongs",
                table: "PhanCongs",
                columns: new[] { "ID_LopHocPhan", "ID_GiangVien" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_LopHocPhans",
                table: "LopHocPhans",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LopBienChes",
                table: "LopBienChes",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Khoas",
                table: "Khoas",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HocKy_NamHocs",
                table: "HocKy_NamHocs",
                columns: new[] { "HocKy", "NamHoc" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_GiangViens",
                table: "GiangViens",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhSach_SinhVien_LopHocPhans",
                table: "DanhSach_SinhVien_LopHocPhans",
                columns: new[] { "ID_SinhVien", "ID_LopHocPhan" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChuongTrinhDaoTaos",
                table: "ChuongTrinhDaoTaos",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTiet_ChuongTrinhDaoTao_MonHocs",
                table: "ChiTiet_ChuongTrinhDaoTao_MonHocs",
                columns: new[] { "ID_ChuongTrinhDaoTao", "ID_MonHoc", "HK_HocKy", "HK_NamHoc" });

            migrationBuilder.InsertData(
                table: "AppConfig",
                columns: new[] { "Key", "Value" },
                values: new object[,]
                {
                    { "HomeTitle", "This is home" },
                    { "HomeKeyword", "This is keyword" },
                    { "HomeDescription", "This is description" }
                });

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("7e2de1ee-b97b-4698-abe4-c22a0332b2c9"), "05072081-c769-4eca-88f1-004140f27054", "Administrator role", "admin", "admin" },
                    { new Guid("ddcfd40f-0c20-4bbd-afbf-5936032ddde5"), "7b2c3a96-0d7e-4a26-ae6a-0db9439326ce", "Nhân viên", "nhanvien", "nhanvien" }
                });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("8dd4e4e7-cbb1-4db8-8cd8-3024401afc74"), new Guid("7e2de1ee-b97b-4698-abe4-c22a0332b2c9") });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ho", "HoTen", "LockoutEnabled", "LockoutEnd", "NgaySinh", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Ten", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("8dd4e4e7-cbb1-4db8-8cd8-3024401afc74"), 0, "819f1f83-04b1-4bd5-b798-ca10b40bb178", "cuong.263@gmail.com", true, "Dao", "Dao Cuong", false, null, new DateTime(1998, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "cuong.263@gmail.com", "admin", "AQAAAAEAACcQAAAAECoOk9tSk9F2D/myE2NBkVDRpm6J5JPndHfk/lzz2jyZfADsAi76PdWcXDLTei1Zuw==", null, false, "", "Cuong", false, "admin" });

            migrationBuilder.InsertData(
                table: "HocKy_NamHocs",
                columns: new[] { "HocKy", "NamHoc", "NgayBatDau", "NgayKetThuc" },
                values: new object[,]
                {
                    { 2, 2016, new DateTime(2016, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2016, new DateTime(2016, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 2016, new DateTime(2016, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Khoas",
                columns: new[] { "ID", "TenKhoa" },
                values: new object[] { "KTCN", "Kỹ thuật công nghệ" });

            migrationBuilder.InsertData(
                table: "MonHoc",
                columns: new[] { "ID", "Id_Khoa", "KhoaID", "SoTiet", "SoTinChi", "TenMonHoc" },
                values: new object[,]
                {
                    { "INT001", "KTCN", null, 30, 2, "Kỹ thuật lập trình" },
                    { "INT002", "KTCN", null, 30, 2, "Cấu trúc dữ liệu và giải thuật" },
                    { "INT003", "KTCN", null, 45, 3, "Cơ sở dữ liệu" },
                    { "INT004", "KTCN", null, 45, 3, "Hệ điều hành	" },
                    { "INT005", "KTCN", null, 45, 3, "Vật lý đại cương" },
                    { "INT006", "KTCN", null, 30, 2, "Toán cao cấp" }
                });

            migrationBuilder.InsertData(
                table: "Phongs",
                columns: new[] { "ID", "SoThuTu", "TenCoSo" },
                values: new object[,]
                {
                    { "BPH002", "002", "624 Âu Cơ" },
                    { "BPH001", "001", "624 Âu Cơ" },
                    { "BPH003", "003", "624 Âu Cơ" }
                });

            migrationBuilder.InsertData(
                table: "ChuongTrinhDaoTaos",
                columns: new[] { "ID", "Id_Khoa", "Nam", "TenChuongTrinh" },
                values: new object[] { "HTTT2016", "KTCN", 2016, "Hệ thống thông tin" });

            migrationBuilder.InsertData(
                table: "GiangViens",
                columns: new[] { "ID", "DiaChi", "Email", "GioiTinh", "Ho", "HoTen", "ID_Khoa", "IsActive", "NgaySinh", "SoDienThoai", "Ten" },
                values: new object[,]
                {
                    { "GV001", "624 Âu Cơ", "nva@vhu.edu.vn", 1, "Nguyễn Văn", "Nguyễn Văn A", "KTCN", 1, new DateTime(1975, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0987654321", "A" },
                    { "GV002", "642 Âu Cơ", "pvb@vhu.edu.vn", 1, "Phạm Văn", "Phạm Văn B", "KTCN", 1, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "012332123", "B" }
                });

            migrationBuilder.InsertData(
                table: "LopHocPhans",
                columns: new[] { "ID", "BuoiHoc", "HK_HocKy", "HK_NamHoc", "ID_MonHoc", "ID_Phong", "IsActive", "NgayHoc" },
                values: new object[,]
                {
                    { "161INT001", 1, 1, 2016, "INT001", "BPH001", 1, 2 },
                    { "161INT002", 1, 1, 2016, "INT001", "BPH002", 1, 2 },
                    { "161INT004", 1, 1, 2016, "INT006", "BPH002", 1, 4 },
                    { "161INT003", 1, 1, 2016, "INT005", "BPH003", 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "ChiTiet_ChuongTrinhDaoTao_MonHocs",
                columns: new[] { "ID_ChuongTrinhDaoTao", "ID_MonHoc", "HK_HocKy", "HK_NamHoc" },
                values: new object[,]
                {
                    { "HTTT2016", "INT001", 1, 2016 },
                    { "HTTT2016", "INT005", 1, 2016 },
                    { "HTTT2016", "INT006", 1, 2016 }
                });

            migrationBuilder.InsertData(
                table: "LopBienChes",
                columns: new[] { "ID", "ID_GiangVien", "ID_Khoa", "NamBatDau", "NamKetThuc" },
                values: new object[] { "161A0101", "GV001", "KTCN", 2016, 2020 });

            migrationBuilder.InsertData(
                table: "PhanCongs",
                columns: new[] { "ID_LopHocPhan", "ID_GiangVien" },
                values: new object[,]
                {
                    { "161INT001", "GV001" },
                    { "161INT002", "GV001" },
                    { "161INT004", "GV002" },
                    { "161INT003", "GV002" }
                });

            migrationBuilder.InsertData(
                table: "SinhViens",
                columns: new[] { "ID", "DiaChi", "Email", "GioiTinh", "Ho", "HoTen", "ID_LopBienChe", "IsActive", "NgaySinh", "SoDienThoai", "Ten" },
                values: new object[] { "161A010139", "5/9A Hóc Môn", "cuong.263@gmail.com", 1, "Đào Tuấn", "Đào Tuấn Cường", "161A0101", 1, new DateTime(1998, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "0904590481", "Cường" });

            migrationBuilder.InsertData(
                table: "SinhViens",
                columns: new[] { "ID", "DiaChi", "Email", "GioiTinh", "Ho", "HoTen", "ID_LopBienChe", "IsActive", "NgaySinh", "SoDienThoai", "Ten" },
                values: new object[] { "161A010001", "TPHCM", "ntc@gmail.com", 0, "Nguyễn Thị", "Nguyễn Thị C", "161A0101", 1, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0123456789", "C" });

            migrationBuilder.InsertData(
                table: "SinhViens",
                columns: new[] { "ID", "DiaChi", "Email", "GioiTinh", "Ho", "HoTen", "ID_LopBienChe", "IsActive", "NgaySinh", "SoDienThoai", "Ten" },
                values: new object[] { "161A010002", "Hóc Môn", "nvd@gmail.com", 1, "Nguyễn Văn", "Nguyễn Văn D", "161A0101", 1, new DateTime(1998, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "0321456987", "D" });

            migrationBuilder.InsertData(
                table: "DanhSach_SinhVien_LopHocPhans",
                columns: new[] { "ID_SinhVien", "ID_LopHocPhan", "Diem", "LanThi" },
                values: new object[,]
                {
                    { "161A010139", "161INT001", 10f, 1 },
                    { "161A010001", "161INT001", 8.5f, 1 },
                    { "161A010001", "161INT002", 10f, 1 },
                    { "161A010002", "161INT001", 7f, 1 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTiet_ChuongTrinhDaoTao_MonHocs_ChuongTrinhDaoTaos_ID_ChuongTrinhDaoTao",
                table: "ChiTiet_ChuongTrinhDaoTao_MonHocs",
                column: "ID_ChuongTrinhDaoTao",
                principalTable: "ChuongTrinhDaoTaos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTiet_ChuongTrinhDaoTao_MonHocs_MonHoc_ID_MonHoc",
                table: "ChiTiet_ChuongTrinhDaoTao_MonHocs",
                column: "ID_MonHoc",
                principalTable: "MonHoc",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTiet_ChuongTrinhDaoTao_MonHocs_HocKy_NamHocs_HK_HocKy_HK_NamHoc",
                table: "ChiTiet_ChuongTrinhDaoTao_MonHocs",
                columns: new[] { "HK_HocKy", "HK_NamHoc" },
                principalTable: "HocKy_NamHocs",
                principalColumns: new[] { "HocKy", "NamHoc" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChuongTrinhDaoTaos_Khoas_Id_Khoa",
                table: "ChuongTrinhDaoTaos",
                column: "Id_Khoa",
                principalTable: "Khoas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhSach_SinhVien_LopHocPhans_LopHocPhans_ID_LopHocPhan",
                table: "DanhSach_SinhVien_LopHocPhans",
                column: "ID_LopHocPhan",
                principalTable: "LopHocPhans",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhSach_SinhVien_LopHocPhans_SinhViens_ID_SinhVien",
                table: "DanhSach_SinhVien_LopHocPhans",
                column: "ID_SinhVien",
                principalTable: "SinhViens",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GiangViens_Khoas_ID_Khoa",
                table: "GiangViens",
                column: "ID_Khoa",
                principalTable: "Khoas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LopBienChes_GiangViens_ID_GiangVien",
                table: "LopBienChes",
                column: "ID_GiangVien",
                principalTable: "GiangViens",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LopBienChes_Khoas_ID_Khoa",
                table: "LopBienChes",
                column: "ID_Khoa",
                principalTable: "Khoas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LopHocPhans_MonHoc_ID_MonHoc",
                table: "LopHocPhans",
                column: "ID_MonHoc",
                principalTable: "MonHoc",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LopHocPhans_Phongs_ID_Phong",
                table: "LopHocPhans",
                column: "ID_Phong",
                principalTable: "Phongs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LopHocPhans_HocKy_NamHocs_HK_HocKy_HK_NamHoc",
                table: "LopHocPhans",
                columns: new[] { "HK_HocKy", "HK_NamHoc" },
                principalTable: "HocKy_NamHocs",
                principalColumns: new[] { "HocKy", "NamHoc" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MonHoc_Khoas_KhoaID",
                table: "MonHoc",
                column: "KhoaID",
                principalTable: "Khoas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhanCongs_GiangViens_ID_GiangVien",
                table: "PhanCongs",
                column: "ID_GiangVien",
                principalTable: "GiangViens",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhanCongs_LopHocPhans_ID_LopHocPhan",
                table: "PhanCongs",
                column: "ID_LopHocPhan",
                principalTable: "LopHocPhans",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SinhViens_LopBienChes_ID_LopBienChe",
                table: "SinhViens",
                column: "ID_LopBienChe",
                principalTable: "LopBienChes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTiet_ChuongTrinhDaoTao_MonHocs_ChuongTrinhDaoTaos_ID_ChuongTrinhDaoTao",
                table: "ChiTiet_ChuongTrinhDaoTao_MonHocs");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTiet_ChuongTrinhDaoTao_MonHocs_MonHoc_ID_MonHoc",
                table: "ChiTiet_ChuongTrinhDaoTao_MonHocs");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTiet_ChuongTrinhDaoTao_MonHocs_HocKy_NamHocs_HK_HocKy_HK_NamHoc",
                table: "ChiTiet_ChuongTrinhDaoTao_MonHocs");

            migrationBuilder.DropForeignKey(
                name: "FK_ChuongTrinhDaoTaos_Khoas_Id_Khoa",
                table: "ChuongTrinhDaoTaos");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhSach_SinhVien_LopHocPhans_LopHocPhans_ID_LopHocPhan",
                table: "DanhSach_SinhVien_LopHocPhans");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhSach_SinhVien_LopHocPhans_SinhViens_ID_SinhVien",
                table: "DanhSach_SinhVien_LopHocPhans");

            migrationBuilder.DropForeignKey(
                name: "FK_GiangViens_Khoas_ID_Khoa",
                table: "GiangViens");

            migrationBuilder.DropForeignKey(
                name: "FK_LopBienChes_GiangViens_ID_GiangVien",
                table: "LopBienChes");

            migrationBuilder.DropForeignKey(
                name: "FK_LopBienChes_Khoas_ID_Khoa",
                table: "LopBienChes");

            migrationBuilder.DropForeignKey(
                name: "FK_LopHocPhans_MonHoc_ID_MonHoc",
                table: "LopHocPhans");

            migrationBuilder.DropForeignKey(
                name: "FK_LopHocPhans_Phongs_ID_Phong",
                table: "LopHocPhans");

            migrationBuilder.DropForeignKey(
                name: "FK_LopHocPhans_HocKy_NamHocs_HK_HocKy_HK_NamHoc",
                table: "LopHocPhans");

            migrationBuilder.DropForeignKey(
                name: "FK_MonHoc_Khoas_KhoaID",
                table: "MonHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_PhanCongs_GiangViens_ID_GiangVien",
                table: "PhanCongs");

            migrationBuilder.DropForeignKey(
                name: "FK_PhanCongs_LopHocPhans_ID_LopHocPhan",
                table: "PhanCongs");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhViens_LopBienChes_ID_LopBienChe",
                table: "SinhViens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SinhViens",
                table: "SinhViens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Phongs",
                table: "Phongs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhanCongs",
                table: "PhanCongs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LopHocPhans",
                table: "LopHocPhans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LopBienChes",
                table: "LopBienChes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Khoas",
                table: "Khoas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HocKy_NamHocs",
                table: "HocKy_NamHocs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GiangViens",
                table: "GiangViens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhSach_SinhVien_LopHocPhans",
                table: "DanhSach_SinhVien_LopHocPhans");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Diem_Duoi_10",
                table: "DanhSach_SinhVien_LopHocPhans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChuongTrinhDaoTaos",
                table: "ChuongTrinhDaoTaos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTiet_ChuongTrinhDaoTao_MonHocs",
                table: "ChiTiet_ChuongTrinhDaoTao_MonHocs");

            migrationBuilder.DeleteData(
                table: "AppConfig",
                keyColumn: "Key",
                keyValue: "HomeDescription");

            migrationBuilder.DeleteData(
                table: "AppConfig",
                keyColumn: "Key",
                keyValue: "HomeKeyword");

            migrationBuilder.DeleteData(
                table: "AppConfig",
                keyColumn: "Key",
                keyValue: "HomeTitle");

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("7e2de1ee-b97b-4698-abe4-c22a0332b2c9"));

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("ddcfd40f-0c20-4bbd-afbf-5936032ddde5"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("8dd4e4e7-cbb1-4db8-8cd8-3024401afc74"), new Guid("7e2de1ee-b97b-4698-abe4-c22a0332b2c9") });

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("8dd4e4e7-cbb1-4db8-8cd8-3024401afc74"));

            migrationBuilder.DeleteData(
                table: "ChiTiet_ChuongTrinhDaoTao_MonHocs",
                keyColumns: new[] { "ID_ChuongTrinhDaoTao", "ID_MonHoc", "HK_HocKy", "HK_NamHoc" },
                keyValues: new object[] { "HTTT2016", "INT001", 1, 2016 });

            migrationBuilder.DeleteData(
                table: "ChiTiet_ChuongTrinhDaoTao_MonHocs",
                keyColumns: new[] { "ID_ChuongTrinhDaoTao", "ID_MonHoc", "HK_HocKy", "HK_NamHoc" },
                keyValues: new object[] { "HTTT2016", "INT005", 1, 2016 });

            migrationBuilder.DeleteData(
                table: "ChiTiet_ChuongTrinhDaoTao_MonHocs",
                keyColumns: new[] { "ID_ChuongTrinhDaoTao", "ID_MonHoc", "HK_HocKy", "HK_NamHoc" },
                keyValues: new object[] { "HTTT2016", "INT006", 1, 2016 });

            migrationBuilder.DeleteData(
                table: "DanhSach_SinhVien_LopHocPhans",
                keyColumns: new[] { "ID_SinhVien", "ID_LopHocPhan" },
                keyValues: new object[] { "161A010001", "161INT001" });

            migrationBuilder.DeleteData(
                table: "DanhSach_SinhVien_LopHocPhans",
                keyColumns: new[] { "ID_SinhVien", "ID_LopHocPhan" },
                keyValues: new object[] { "161A010001", "161INT002" });

            migrationBuilder.DeleteData(
                table: "DanhSach_SinhVien_LopHocPhans",
                keyColumns: new[] { "ID_SinhVien", "ID_LopHocPhan" },
                keyValues: new object[] { "161A010002", "161INT001" });

            migrationBuilder.DeleteData(
                table: "DanhSach_SinhVien_LopHocPhans",
                keyColumns: new[] { "ID_SinhVien", "ID_LopHocPhan" },
                keyValues: new object[] { "161A010139", "161INT001" });

            migrationBuilder.DeleteData(
                table: "HocKy_NamHocs",
                keyColumns: new[] { "HocKy", "NamHoc" },
                keyValues: new object[] { 2, 2016 });

            migrationBuilder.DeleteData(
                table: "HocKy_NamHocs",
                keyColumns: new[] { "HocKy", "NamHoc" },
                keyValues: new object[] { 3, 2016 });

            migrationBuilder.DeleteData(
                table: "MonHoc",
                keyColumn: "ID",
                keyValue: "INT002");

            migrationBuilder.DeleteData(
                table: "MonHoc",
                keyColumn: "ID",
                keyValue: "INT003");

            migrationBuilder.DeleteData(
                table: "MonHoc",
                keyColumn: "ID",
                keyValue: "INT004");

            migrationBuilder.DeleteData(
                table: "PhanCongs",
                keyColumns: new[] { "ID_LopHocPhan", "ID_GiangVien" },
                keyValues: new object[] { "161INT001", "GV001" });

            migrationBuilder.DeleteData(
                table: "PhanCongs",
                keyColumns: new[] { "ID_LopHocPhan", "ID_GiangVien" },
                keyValues: new object[] { "161INT002", "GV001" });

            migrationBuilder.DeleteData(
                table: "PhanCongs",
                keyColumns: new[] { "ID_LopHocPhan", "ID_GiangVien" },
                keyValues: new object[] { "161INT003", "GV002" });

            migrationBuilder.DeleteData(
                table: "PhanCongs",
                keyColumns: new[] { "ID_LopHocPhan", "ID_GiangVien" },
                keyValues: new object[] { "161INT004", "GV002" });

            migrationBuilder.DeleteData(
                table: "ChuongTrinhDaoTaos",
                keyColumn: "ID",
                keyValue: "HTTT2016");

            migrationBuilder.DeleteData(
                table: "GiangViens",
                keyColumn: "ID",
                keyValue: "GV002");

            migrationBuilder.DeleteData(
                table: "LopHocPhans",
                keyColumn: "ID",
                keyValue: "161INT001");

            migrationBuilder.DeleteData(
                table: "LopHocPhans",
                keyColumn: "ID",
                keyValue: "161INT002");

            migrationBuilder.DeleteData(
                table: "LopHocPhans",
                keyColumn: "ID",
                keyValue: "161INT003");

            migrationBuilder.DeleteData(
                table: "LopHocPhans",
                keyColumn: "ID",
                keyValue: "161INT004");

            migrationBuilder.DeleteData(
                table: "SinhViens",
                keyColumn: "ID",
                keyValue: "161A010001");

            migrationBuilder.DeleteData(
                table: "SinhViens",
                keyColumn: "ID",
                keyValue: "161A010002");

            migrationBuilder.DeleteData(
                table: "SinhViens",
                keyColumn: "ID",
                keyValue: "161A010139");

            migrationBuilder.DeleteData(
                table: "HocKy_NamHocs",
                keyColumns: new[] { "HocKy", "NamHoc" },
                keyValues: new object[] { 1, 2016 });

            migrationBuilder.DeleteData(
                table: "LopBienChes",
                keyColumn: "ID",
                keyValue: "161A0101");

            migrationBuilder.DeleteData(
                table: "MonHoc",
                keyColumn: "ID",
                keyValue: "INT001");

            migrationBuilder.DeleteData(
                table: "MonHoc",
                keyColumn: "ID",
                keyValue: "INT005");

            migrationBuilder.DeleteData(
                table: "MonHoc",
                keyColumn: "ID",
                keyValue: "INT006");

            migrationBuilder.DeleteData(
                table: "Phongs",
                keyColumn: "ID",
                keyValue: "BPH001");

            migrationBuilder.DeleteData(
                table: "Phongs",
                keyColumn: "ID",
                keyValue: "BPH002");

            migrationBuilder.DeleteData(
                table: "Phongs",
                keyColumn: "ID",
                keyValue: "BPH003");

            migrationBuilder.DeleteData(
                table: "GiangViens",
                keyColumn: "ID",
                keyValue: "GV001");

            migrationBuilder.DeleteData(
                table: "Khoas",
                keyColumn: "ID",
                keyValue: "KTCN");

            migrationBuilder.DropColumn(
                name: "BuoiHoc",
                table: "LopHocPhans");

            migrationBuilder.DropColumn(
                name: "NgayHoc",
                table: "LopHocPhans");

            migrationBuilder.RenameTable(
                name: "SinhViens",
                newName: "SinhVien");

            migrationBuilder.RenameTable(
                name: "Phongs",
                newName: "Phong");

            migrationBuilder.RenameTable(
                name: "PhanCongs",
                newName: "PhanCong");

            migrationBuilder.RenameTable(
                name: "LopHocPhans",
                newName: "LopHocPhan");

            migrationBuilder.RenameTable(
                name: "LopBienChes",
                newName: "LopBienChe");

            migrationBuilder.RenameTable(
                name: "Khoas",
                newName: "Khoa");

            migrationBuilder.RenameTable(
                name: "HocKy_NamHocs",
                newName: "HocKy_NamHoc");

            migrationBuilder.RenameTable(
                name: "GiangViens",
                newName: "GiangVien");

            migrationBuilder.RenameTable(
                name: "DanhSach_SinhVien_LopHocPhans",
                newName: "DanhSach_SinhVien_LopHocPhan");

            migrationBuilder.RenameTable(
                name: "ChuongTrinhDaoTaos",
                newName: "ChuongTrinhDaoTao");

            migrationBuilder.RenameTable(
                name: "ChiTiet_ChuongTrinhDaoTao_MonHocs",
                newName: "ChiTiet_ChuongTrinhDaoTao_MonHoc");

            migrationBuilder.RenameIndex(
                name: "IX_SinhViens_ID_LopBienChe",
                table: "SinhVien",
                newName: "IX_SinhVien_ID_LopBienChe");

            migrationBuilder.RenameIndex(
                name: "IX_PhanCongs_ID_LopHocPhan",
                table: "PhanCong",
                newName: "IX_PhanCong_ID_LopHocPhan");

            migrationBuilder.RenameIndex(
                name: "IX_PhanCongs_ID_GiangVien",
                table: "PhanCong",
                newName: "IX_PhanCong_ID_GiangVien");

            migrationBuilder.RenameIndex(
                name: "IX_LopHocPhans_HK_HocKy_HK_NamHoc",
                table: "LopHocPhan",
                newName: "IX_LopHocPhan_HK_HocKy_HK_NamHoc");

            migrationBuilder.RenameIndex(
                name: "IX_LopHocPhans_ID_Phong",
                table: "LopHocPhan",
                newName: "IX_LopHocPhan_ID_Phong");

            migrationBuilder.RenameIndex(
                name: "IX_LopHocPhans_ID_MonHoc",
                table: "LopHocPhan",
                newName: "IX_LopHocPhan_ID_MonHoc");

            migrationBuilder.RenameIndex(
                name: "IX_LopBienChes_ID_Khoa",
                table: "LopBienChe",
                newName: "IX_LopBienChe_ID_Khoa");

            migrationBuilder.RenameIndex(
                name: "IX_LopBienChes_ID_GiangVien",
                table: "LopBienChe",
                newName: "IX_LopBienChe_ID_GiangVien");

            migrationBuilder.RenameIndex(
                name: "IX_GiangViens_ID_Khoa",
                table: "GiangVien",
                newName: "IX_GiangVien_ID_Khoa");

            migrationBuilder.RenameIndex(
                name: "IX_DanhSach_SinhVien_LopHocPhans_ID_LopHocPhan",
                table: "DanhSach_SinhVien_LopHocPhan",
                newName: "IX_DanhSach_SinhVien_LopHocPhan_ID_LopHocPhan");

            migrationBuilder.RenameIndex(
                name: "IX_ChuongTrinhDaoTaos_Id_Khoa",
                table: "ChuongTrinhDaoTao",
                newName: "IX_ChuongTrinhDaoTao_Id_Khoa");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTiet_ChuongTrinhDaoTao_MonHocs_HK_HocKy_HK_NamHoc",
                table: "ChiTiet_ChuongTrinhDaoTao_MonHoc",
                newName: "IX_ChiTiet_ChuongTrinhDaoTao_MonHoc_HK_HocKy_HK_NamHoc");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTiet_ChuongTrinhDaoTao_MonHocs_ID_MonHoc",
                table: "ChiTiet_ChuongTrinhDaoTao_MonHoc",
                newName: "IX_ChiTiet_ChuongTrinhDaoTao_MonHoc_ID_MonHoc");

            migrationBuilder.AlterColumn<string>(
                name: "NgaySinh",
                table: "SinhVien",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<string>(
                name: "SoTietHoc",
                table: "LopHocPhan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "GioiTinh",
                table: "GiangVien",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "LanThi",
                table: "DanhSach_SinhVien_LopHocPhan",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Nam",
                table: "ChuongTrinhDaoTao",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_SinhVien",
                table: "SinhVien",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Phong",
                table: "Phong",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhanCong",
                table: "PhanCong",
                columns: new[] { "ID_LopHocPhan", "ID_GiangVien" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_LopHocPhan",
                table: "LopHocPhan",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LopBienChe",
                table: "LopBienChe",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Khoa",
                table: "Khoa",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HocKy_NamHoc",
                table: "HocKy_NamHoc",
                columns: new[] { "HocKy", "NamHoc" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_GiangVien",
                table: "GiangVien",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhSach_SinhVien_LopHocPhan",
                table: "DanhSach_SinhVien_LopHocPhan",
                columns: new[] { "ID_SinhVien", "ID_LopHocPhan" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChuongTrinhDaoTao",
                table: "ChuongTrinhDaoTao",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTiet_ChuongTrinhDaoTao_MonHoc",
                table: "ChiTiet_ChuongTrinhDaoTao_MonHoc",
                columns: new[] { "ID_ChuongTrinhDaoTao", "ID_MonHoc", "HK_HocKy", "HK_NamHoc" });

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTiet_ChuongTrinhDaoTao_MonHoc_ChuongTrinhDaoTao_ID_ChuongTrinhDaoTao",
                table: "ChiTiet_ChuongTrinhDaoTao_MonHoc",
                column: "ID_ChuongTrinhDaoTao",
                principalTable: "ChuongTrinhDaoTao",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTiet_ChuongTrinhDaoTao_MonHoc_MonHoc_ID_MonHoc",
                table: "ChiTiet_ChuongTrinhDaoTao_MonHoc",
                column: "ID_MonHoc",
                principalTable: "MonHoc",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTiet_ChuongTrinhDaoTao_MonHoc_HocKy_NamHoc_HK_HocKy_HK_NamHoc",
                table: "ChiTiet_ChuongTrinhDaoTao_MonHoc",
                columns: new[] { "HK_HocKy", "HK_NamHoc" },
                principalTable: "HocKy_NamHoc",
                principalColumns: new[] { "HocKy", "NamHoc" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChuongTrinhDaoTao_Khoa_Id_Khoa",
                table: "ChuongTrinhDaoTao",
                column: "Id_Khoa",
                principalTable: "Khoa",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhSach_SinhVien_LopHocPhan_LopHocPhan_ID_LopHocPhan",
                table: "DanhSach_SinhVien_LopHocPhan",
                column: "ID_LopHocPhan",
                principalTable: "LopHocPhan",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhSach_SinhVien_LopHocPhan_SinhVien_ID_SinhVien",
                table: "DanhSach_SinhVien_LopHocPhan",
                column: "ID_SinhVien",
                principalTable: "SinhVien",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GiangVien_Khoa_ID_Khoa",
                table: "GiangVien",
                column: "ID_Khoa",
                principalTable: "Khoa",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LopBienChe_GiangVien_ID_GiangVien",
                table: "LopBienChe",
                column: "ID_GiangVien",
                principalTable: "GiangVien",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LopBienChe_Khoa_ID_Khoa",
                table: "LopBienChe",
                column: "ID_Khoa",
                principalTable: "Khoa",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LopHocPhan_MonHoc_ID_MonHoc",
                table: "LopHocPhan",
                column: "ID_MonHoc",
                principalTable: "MonHoc",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LopHocPhan_Phong_ID_Phong",
                table: "LopHocPhan",
                column: "ID_Phong",
                principalTable: "Phong",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LopHocPhan_HocKy_NamHoc_HK_HocKy_HK_NamHoc",
                table: "LopHocPhan",
                columns: new[] { "HK_HocKy", "HK_NamHoc" },
                principalTable: "HocKy_NamHoc",
                principalColumns: new[] { "HocKy", "NamHoc" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MonHoc_Khoa_KhoaID",
                table: "MonHoc",
                column: "KhoaID",
                principalTable: "Khoa",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhanCong_GiangVien_ID_GiangVien",
                table: "PhanCong",
                column: "ID_GiangVien",
                principalTable: "GiangVien",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhanCong_LopHocPhan_ID_LopHocPhan",
                table: "PhanCong",
                column: "ID_LopHocPhan",
                principalTable: "LopHocPhan",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVien_LopBienChe_ID_LopBienChe",
                table: "SinhVien",
                column: "ID_LopBienChe",
                principalTable: "LopBienChe",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
