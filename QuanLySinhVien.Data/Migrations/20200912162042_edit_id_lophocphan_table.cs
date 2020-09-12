using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanLySinhVien.Data.Migrations
{
    public partial class edit_id_lophocphan_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppConfig",
                columns: table => new
                {
                    Key = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppConfig", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "AppRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserLogins",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    ProviderKey = table.Column<string>(nullable: true),
                    ProviderDisplayName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserLogins", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRoles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Ho = table.Column<string>(maxLength: 50, nullable: false),
                    Ten = table.Column<string>(maxLength: 50, nullable: false),
                    HoTen = table.Column<string>(maxLength: 100, nullable: false),
                    NgaySinh = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserTokens", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "HocKy_NamHocs",
                columns: table => new
                {
                    HocKy = table.Column<int>(nullable: false),
                    NamHoc = table.Column<int>(nullable: false),
                    NgayBatDau = table.Column<DateTime>(nullable: false),
                    NgayKetThuc = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocKy_NamHocs", x => new { x.HocKy, x.NamHoc });
                });

            migrationBuilder.CreateTable(
                name: "Khoas",
                columns: table => new
                {
                    ID = table.Column<string>(maxLength: 10, nullable: false),
                    TenKhoa = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khoas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Phongs",
                columns: table => new
                {
                    ID = table.Column<string>(maxLength: 10, nullable: false),
                    TenCoSo = table.Column<string>(maxLength: 100, nullable: true),
                    SoThuTu = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phongs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ChuongTrinhDaoTaos",
                columns: table => new
                {
                    ID = table.Column<string>(maxLength: 10, nullable: false),
                    TenChuongTrinh = table.Column<string>(maxLength: 200, nullable: true),
                    SoThuTu = table.Column<int>(nullable: false),
                    Nam = table.Column<int>(nullable: false),
                    Id_Khoa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChuongTrinhDaoTaos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ChuongTrinhDaoTaos_Khoas_Id_Khoa",
                        column: x => x.Id_Khoa,
                        principalTable: "Khoas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GiangViens",
                columns: table => new
                {
                    ID = table.Column<string>(maxLength: 10, nullable: false),
                    SoThuTu = table.Column<int>(nullable: false),
                    Ho = table.Column<string>(maxLength: 50, nullable: false),
                    Ten = table.Column<string>(maxLength: 50, nullable: false),
                    HoTen = table.Column<string>(maxLength: 100, nullable: false),
                    NgaySinh = table.Column<DateTime>(nullable: false),
                    GioiTinh = table.Column<int>(nullable: false),
                    SoDienThoai = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    DiaChi = table.Column<string>(maxLength: 500, nullable: true),
                    ID_Khoa = table.Column<string>(nullable: true),
                    IsActive = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiangViens", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GiangViens_Khoas_ID_Khoa",
                        column: x => x.ID_Khoa,
                        principalTable: "Khoas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MonHocs",
                columns: table => new
                {
                    ID = table.Column<string>(maxLength: 10, nullable: false),
                    SoThuTu = table.Column<int>(nullable: false),
                    TenMonHoc = table.Column<string>(nullable: false),
                    SoTiet = table.Column<int>(nullable: false),
                    SoTinChi = table.Column<int>(nullable: false),
                    ID_Khoa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonHocs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MonHocs_Khoas_ID_Khoa",
                        column: x => x.ID_Khoa,
                        principalTable: "Khoas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LopBienChes",
                columns: table => new
                {
                    ID = table.Column<string>(maxLength: 10, nullable: false),
                    SoThuTu = table.Column<int>(nullable: false),
                    NamBatDau = table.Column<int>(nullable: false),
                    NamKetThuc = table.Column<int>(nullable: false),
                    ID_Khoa = table.Column<string>(nullable: true),
                    ID_GiangVien = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopBienChes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LopBienChes_GiangViens_ID_GiangVien",
                        column: x => x.ID_GiangVien,
                        principalTable: "GiangViens",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LopBienChes_Khoas_ID_Khoa",
                        column: x => x.ID_Khoa,
                        principalTable: "Khoas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTiet_ChuongTrinhDaoTao_MonHocs",
                columns: table => new
                {
                    ID_ChuongTrinhDaoTao = table.Column<string>(nullable: false),
                    ID_MonHoc = table.Column<string>(nullable: false),
                    HocKyDuKien = table.Column<int>(nullable: false),
                    Nam = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTiet_ChuongTrinhDaoTao_MonHocs", x => new { x.ID_ChuongTrinhDaoTao, x.ID_MonHoc });
                    table.ForeignKey(
                        name: "FK_ChiTiet_ChuongTrinhDaoTao_MonHocs_ChuongTrinhDaoTaos_ID_ChuongTrinhDaoTao",
                        column: x => x.ID_ChuongTrinhDaoTao,
                        principalTable: "ChuongTrinhDaoTaos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTiet_ChuongTrinhDaoTao_MonHocs_MonHocs_ID_MonHoc",
                        column: x => x.ID_MonHoc,
                        principalTable: "MonHocs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChuyenMons",
                columns: table => new
                {
                    ID_GiangVien = table.Column<string>(nullable: false),
                    ID_MonHoc = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChuyenMons", x => new { x.ID_GiangVien, x.ID_MonHoc });
                    table.ForeignKey(
                        name: "FK_ChuyenMons_GiangViens_ID_GiangVien",
                        column: x => x.ID_GiangVien,
                        principalTable: "GiangViens",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChuyenMons_MonHocs_ID_MonHoc",
                        column: x => x.ID_MonHoc,
                        principalTable: "MonHocs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LopHocPhans",
                columns: table => new
                {
                    ID = table.Column<string>(maxLength: 12, nullable: false),
                    SoThuTu = table.Column<int>(nullable: false),
                    HK_HocKy = table.Column<int>(nullable: false),
                    HK_NamHoc = table.Column<int>(nullable: false),
                    ID_MonHoc = table.Column<string>(nullable: true),
                    ID_Phong = table.Column<string>(nullable: true),
                    ID_GiangVien = table.Column<string>(nullable: true),
                    BuoiHoc = table.Column<int>(nullable: false),
                    NgayHoc = table.Column<int>(nullable: false),
                    IsActive = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopHocPhans", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LopHocPhans_GiangViens_ID_GiangVien",
                        column: x => x.ID_GiangVien,
                        principalTable: "GiangViens",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LopHocPhans_MonHocs_ID_MonHoc",
                        column: x => x.ID_MonHoc,
                        principalTable: "MonHocs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LopHocPhans_Phongs_ID_Phong",
                        column: x => x.ID_Phong,
                        principalTable: "Phongs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LopHocPhans_HocKy_NamHocs_HK_HocKy_HK_NamHoc",
                        columns: x => new { x.HK_HocKy, x.HK_NamHoc },
                        principalTable: "HocKy_NamHocs",
                        principalColumns: new[] { "HocKy", "NamHoc" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SinhViens",
                columns: table => new
                {
                    ID = table.Column<string>(maxLength: 10, nullable: false),
                    SoThuTu = table.Column<int>(nullable: false),
                    Nam = table.Column<int>(nullable: false),
                    Ho = table.Column<string>(maxLength: 50, nullable: false),
                    Ten = table.Column<string>(maxLength: 50, nullable: false),
                    HoTen = table.Column<string>(maxLength: 100, nullable: false),
                    NgaySinh = table.Column<DateTime>(nullable: false),
                    GioiTinh = table.Column<int>(nullable: false),
                    SoDienThoai = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    DiaChi = table.Column<string>(maxLength: 500, nullable: true),
                    ID_LopBienChe = table.Column<string>(nullable: true),
                    ID_ChuongTrinhDaoTao = table.Column<string>(nullable: true),
                    IsActive = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhViens", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SinhViens_ChuongTrinhDaoTaos_ID_ChuongTrinhDaoTao",
                        column: x => x.ID_ChuongTrinhDaoTao,
                        principalTable: "ChuongTrinhDaoTaos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SinhViens_LopBienChes_ID_LopBienChe",
                        column: x => x.ID_LopBienChe,
                        principalTable: "LopBienChes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DanhSach_SinhVien_LopHocPhans",
                columns: table => new
                {
                    ID_SinhVien = table.Column<string>(nullable: false),
                    ID_LopHocPhan = table.Column<string>(nullable: false),
                    LanThi = table.Column<int>(nullable: false),
                    Diem = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhSach_SinhVien_LopHocPhans", x => new { x.ID_LopHocPhan, x.ID_SinhVien });
                    table.CheckConstraint("CK_Diem_Duoi_10", "Diem <= 10");
                    table.ForeignKey(
                        name: "FK_DanhSach_SinhVien_LopHocPhans_LopHocPhans_ID_LopHocPhan",
                        column: x => x.ID_LopHocPhan,
                        principalTable: "LopHocPhans",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DanhSach_SinhVien_LopHocPhans_SinhViens_ID_SinhVien",
                        column: x => x.ID_SinhVien,
                        principalTable: "SinhViens",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    { new Guid("7e2de1ee-b97b-4698-abe4-c22a0332b2c9"), "06ba06a2-3cf0-4ebf-96a6-1f8d6fe74fe5", "Administrator role", "admin", "admin" },
                    { new Guid("ddcfd40f-0c20-4bbd-afbf-5936032ddde5"), "8044b1f1-adb7-44ec-9d5f-2774406d364f", "Nhân viên", "nhanvien", "nhanvien" }
                });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("8dd4e4e7-cbb1-4db8-8cd8-3024401afc74"), new Guid("7e2de1ee-b97b-4698-abe4-c22a0332b2c9") });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ho", "HoTen", "LockoutEnabled", "LockoutEnd", "NgaySinh", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Ten", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("8dd4e4e7-cbb1-4db8-8cd8-3024401afc74"), 0, "d1b4f6dc-602f-49aa-9189-26f87824fc2a", "cuong.263@gmail.com", true, "Dao", "Dao Cuong", false, null, new DateTime(1998, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "cuong.263@gmail.com", "admin", "AQAAAAEAACcQAAAAED6x+B88vpvP58msB4HdKRrICYgQ54xA7uGb5SO27STvGESig0wr86+viXkTTCVETA==", null, false, "", "Cuong", false, "admin" });

            migrationBuilder.InsertData(
                table: "HocKy_NamHocs",
                columns: new[] { "HocKy", "NamHoc", "NgayBatDau", "NgayKetThuc" },
                values: new object[,]
                {
                    { 1, 2016, new DateTime(2016, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2016, new DateTime(2016, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2016, new DateTime(2016, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Khoas",
                columns: new[] { "ID", "TenKhoa" },
                values: new object[] { "CNTT", "Công nghệ thông tin" });

            migrationBuilder.InsertData(
                table: "Phongs",
                columns: new[] { "ID", "SoThuTu", "TenCoSo" },
                values: new object[,]
                {
                    { "PH001", 1, "624 Âu Cơ" },
                    { "PH002", 2, "624 Âu Cơ" },
                    { "PH003", 3, "624 Âu Cơ" }
                });

            migrationBuilder.InsertData(
                table: "ChuongTrinhDaoTaos",
                columns: new[] { "ID", "Id_Khoa", "Nam", "SoThuTu", "TenChuongTrinh" },
                values: new object[,]
                {
                    { "2016CNTT01", "CNTT", 2016, 1, "Hệ thống thông tin" },
                    { "2020CNTT01", "CNTT", 2020, 1, "Hệ thống thông tin" },
                    { "2020CNTT02", "CNTT", 2020, 2, "Kỹ thuật phần mềm" }
                });

            migrationBuilder.InsertData(
                table: "GiangViens",
                columns: new[] { "ID", "DiaChi", "Email", "GioiTinh", "Ho", "HoTen", "ID_Khoa", "IsActive", "NgaySinh", "SoDienThoai", "SoThuTu", "Ten" },
                values: new object[,]
                {
                    { "GV001", "624 Âu Cơ", "nva@vhu.edu.vn", 1, "Nguyễn Văn", "Nguyễn Văn A", "CNTT", 1, new DateTime(1975, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0987654321", 1, "A" },
                    { "GV002", "642 Âu Cơ", "pvb@vhu.edu.vn", 1, "Phạm Văn", "Phạm Văn B", "CNTT", 1, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "012332123", 2, "B" },
                    { "GV003", "642 Âu Cơ", "pvb@vhu.edu.vn", 0, "Nguyễn Thị", "Nguyễn Thị T", "CNTT", 1, new DateTime(1985, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "012332123", 3, "T" }
                });

            migrationBuilder.InsertData(
                table: "MonHocs",
                columns: new[] { "ID", "ID_Khoa", "SoThuTu", "SoTiet", "SoTinChi", "TenMonHoc" },
                values: new object[,]
                {
                    { "INT001", "CNTT", 1, 30, 2, "Kỹ thuật lập trình" },
                    { "INT002", "CNTT", 2, 30, 2, "Cấu trúc dữ liệu và giải thuật" },
                    { "INT003", "CNTT", 3, 45, 3, "Cơ sở dữ liệu" },
                    { "INT004", "CNTT", 4, 45, 3, "Hệ điều hành	" },
                    { "INT005", "CNTT", 5, 45, 3, "Vật lý đại cương" },
                    { "INT006", "CNTT", 6, 30, 2, "Toán cao cấp" }
                });

            migrationBuilder.InsertData(
                table: "ChiTiet_ChuongTrinhDaoTao_MonHocs",
                columns: new[] { "ID_ChuongTrinhDaoTao", "ID_MonHoc", "HocKyDuKien", "Nam" },
                values: new object[,]
                {
                    { "2016CNTT01", "INT001", 1, 2016 },
                    { "2016CNTT01", "INT005", 1, 2016 },
                    { "2016CNTT01", "INT006", 1, 2016 }
                });

            migrationBuilder.InsertData(
                table: "ChuyenMons",
                columns: new[] { "ID_GiangVien", "ID_MonHoc" },
                values: new object[,]
                {
                    { "GV001", "INT001" },
                    { "GV001", "INT002" },
                    { "GV001", "INT003" },
                    { "GV002", "INT003" },
                    { "GV002", "INT004" },
                    { "GV003", "INT004" },
                    { "GV003", "INT005" }
                });

            migrationBuilder.InsertData(
                table: "LopBienChes",
                columns: new[] { "ID", "ID_GiangVien", "ID_Khoa", "NamBatDau", "NamKetThuc", "SoThuTu" },
                values: new object[] { "161A0101", "GV001", "CNTT", 2016, 2020, 1 });

            migrationBuilder.InsertData(
                table: "LopHocPhans",
                columns: new[] { "ID", "BuoiHoc", "HK_HocKy", "HK_NamHoc", "ID_GiangVien", "ID_MonHoc", "ID_Phong", "IsActive", "NgayHoc", "SoThuTu" },
                values: new object[,]
                {
                    { "161INT00101", 1, 1, 2016, null, "INT001", "PH001", 1, 2, 1 },
                    { "161INT00102", 2, 1, 2016, null, "INT001", "PH002", 1, 7, 2 },
                    { "161INT00201", 2, 1, 2016, null, "INT001", "PH002", 1, 2, 1 },
                    { "161INT00301", 3, 1, 2016, null, "INT005", "PH003", 1, 3, 1 },
                    { "161INT00401", 1, 1, 2016, null, "INT006", "PH002", 1, 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "SinhViens",
                columns: new[] { "ID", "DiaChi", "Email", "GioiTinh", "Ho", "HoTen", "ID_ChuongTrinhDaoTao", "ID_LopBienChe", "IsActive", "Nam", "NgaySinh", "SoDienThoai", "SoThuTu", "Ten" },
                values: new object[] { "161A010001", "TPHCM", "ntc@gmail.com", 0, "Nguyễn Thị", "Nguyễn Thị C", "2016CNTT01", "161A0101", 1, 2016, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0123456789", 1, "C" });

            migrationBuilder.InsertData(
                table: "SinhViens",
                columns: new[] { "ID", "DiaChi", "Email", "GioiTinh", "Ho", "HoTen", "ID_ChuongTrinhDaoTao", "ID_LopBienChe", "IsActive", "Nam", "NgaySinh", "SoDienThoai", "SoThuTu", "Ten" },
                values: new object[] { "161A010002", "Hóc Môn", "nvd@gmail.com", 1, "Nguyễn Văn", "Nguyễn Văn D", "2016CNTT01", "161A0101", 1, 2016, new DateTime(1998, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "0321456987", 2, "D" });

            migrationBuilder.InsertData(
                table: "SinhViens",
                columns: new[] { "ID", "DiaChi", "Email", "GioiTinh", "Ho", "HoTen", "ID_ChuongTrinhDaoTao", "ID_LopBienChe", "IsActive", "Nam", "NgaySinh", "SoDienThoai", "SoThuTu", "Ten" },
                values: new object[] { "161A010003", "5/9A Hóc Môn", "cuong.263@gmail.com", 1, "Đào Tuấn", "Đào Tuấn Cường", "2016CNTT01", "161A0101", 1, 2016, new DateTime(1998, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "0904590481", 3, "Cường" });

            migrationBuilder.InsertData(
                table: "DanhSach_SinhVien_LopHocPhans",
                columns: new[] { "ID_LopHocPhan", "ID_SinhVien", "Diem", "LanThi" },
                values: new object[,]
                {
                    { "161INT00101", "161A010001", 8.5f, 1 },
                    { "161INT00201", "161A010001", 10f, 1 },
                    { "161INT00101", "161A010002", 7f, 1 },
                    { "161INT00101", "161A010003", 7f, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTiet_ChuongTrinhDaoTao_MonHocs_ID_MonHoc",
                table: "ChiTiet_ChuongTrinhDaoTao_MonHocs",
                column: "ID_MonHoc");

            migrationBuilder.CreateIndex(
                name: "IX_ChuongTrinhDaoTaos_Id_Khoa",
                table: "ChuongTrinhDaoTaos",
                column: "Id_Khoa");

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenMons_ID_MonHoc",
                table: "ChuyenMons",
                column: "ID_MonHoc");

            migrationBuilder.CreateIndex(
                name: "IX_DanhSach_SinhVien_LopHocPhans_ID_SinhVien",
                table: "DanhSach_SinhVien_LopHocPhans",
                column: "ID_SinhVien");

            migrationBuilder.CreateIndex(
                name: "IX_GiangViens_ID_Khoa",
                table: "GiangViens",
                column: "ID_Khoa");

            migrationBuilder.CreateIndex(
                name: "IX_LopBienChes_ID_GiangVien",
                table: "LopBienChes",
                column: "ID_GiangVien");

            migrationBuilder.CreateIndex(
                name: "IX_LopBienChes_ID_Khoa",
                table: "LopBienChes",
                column: "ID_Khoa");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocPhans_ID_GiangVien",
                table: "LopHocPhans",
                column: "ID_GiangVien");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocPhans_ID_MonHoc",
                table: "LopHocPhans",
                column: "ID_MonHoc");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocPhans_ID_Phong",
                table: "LopHocPhans",
                column: "ID_Phong");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocPhans_HK_HocKy_HK_NamHoc",
                table: "LopHocPhans",
                columns: new[] { "HK_HocKy", "HK_NamHoc" });

            migrationBuilder.CreateIndex(
                name: "IX_MonHocs_ID_Khoa",
                table: "MonHocs",
                column: "ID_Khoa");

            migrationBuilder.CreateIndex(
                name: "IX_SinhViens_ID_ChuongTrinhDaoTao",
                table: "SinhViens",
                column: "ID_ChuongTrinhDaoTao");

            migrationBuilder.CreateIndex(
                name: "IX_SinhViens_ID_LopBienChe",
                table: "SinhViens",
                column: "ID_LopBienChe");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppConfig");

            migrationBuilder.DropTable(
                name: "AppRoleClaims");

            migrationBuilder.DropTable(
                name: "AppRoles");

            migrationBuilder.DropTable(
                name: "AppUserClaims");

            migrationBuilder.DropTable(
                name: "AppUserLogins");

            migrationBuilder.DropTable(
                name: "AppUserRoles");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "AppUserTokens");

            migrationBuilder.DropTable(
                name: "ChiTiet_ChuongTrinhDaoTao_MonHocs");

            migrationBuilder.DropTable(
                name: "ChuyenMons");

            migrationBuilder.DropTable(
                name: "DanhSach_SinhVien_LopHocPhans");

            migrationBuilder.DropTable(
                name: "LopHocPhans");

            migrationBuilder.DropTable(
                name: "SinhViens");

            migrationBuilder.DropTable(
                name: "MonHocs");

            migrationBuilder.DropTable(
                name: "Phongs");

            migrationBuilder.DropTable(
                name: "HocKy_NamHocs");

            migrationBuilder.DropTable(
                name: "ChuongTrinhDaoTaos");

            migrationBuilder.DropTable(
                name: "LopBienChes");

            migrationBuilder.DropTable(
                name: "GiangViens");

            migrationBuilder.DropTable(
                name: "Khoas");
        }
    }
}
