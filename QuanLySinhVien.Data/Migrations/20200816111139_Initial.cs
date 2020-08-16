using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanLySinhVien.Data.Migrations
{
    public partial class Initial : Migration
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
                name: "HocKy_NamHoc",
                columns: table => new
                {
                    HocKy = table.Column<int>(nullable: false),
                    NamHoc = table.Column<int>(nullable: false),
                    NgayBatDau = table.Column<DateTime>(nullable: false),
                    NgayKetThuc = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocKy_NamHoc", x => new { x.HocKy, x.NamHoc });
                });

            migrationBuilder.CreateTable(
                name: "Khoa",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    TenKhoa = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khoa", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Phong",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    TenCoSo = table.Column<string>(maxLength: 100, nullable: true),
                    SoThuTu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phong", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ChuongTrinhDaoTao",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    TenChuongTrinh = table.Column<string>(maxLength: 200, nullable: true),
                    Nam = table.Column<string>(nullable: true),
                    Id_Khoa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChuongTrinhDaoTao", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ChuongTrinhDaoTao_Khoa_Id_Khoa",
                        column: x => x.Id_Khoa,
                        principalTable: "Khoa",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GiangVien",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Ho = table.Column<string>(maxLength: 50, nullable: true),
                    Ten = table.Column<string>(maxLength: 50, nullable: true),
                    HoTen = table.Column<string>(maxLength: 100, nullable: true),
                    NgaySinh = table.Column<DateTime>(nullable: false),
                    GioiTinh = table.Column<bool>(nullable: false),
                    SoDienThoai = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    DiaChi = table.Column<string>(maxLength: 500, nullable: true),
                    ID_Khoa = table.Column<string>(nullable: true),
                    IsActive = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiangVien", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GiangVien_Khoa_ID_Khoa",
                        column: x => x.ID_Khoa,
                        principalTable: "Khoa",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MonHoc",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    TenMonHoc = table.Column<string>(nullable: true),
                    SoTiet = table.Column<int>(nullable: false),
                    SoTinChi = table.Column<int>(nullable: false),
                    Id_Khoa = table.Column<string>(nullable: true),
                    KhoaID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonHoc", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MonHoc_Khoa_KhoaID",
                        column: x => x.KhoaID,
                        principalTable: "Khoa",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LopBienChe",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    NamBatDau = table.Column<int>(nullable: false),
                    NamKetThuc = table.Column<int>(nullable: false),
                    ID_Khoa = table.Column<string>(nullable: true),
                    ID_GiangVien = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopBienChe", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LopBienChe_GiangVien_ID_GiangVien",
                        column: x => x.ID_GiangVien,
                        principalTable: "GiangVien",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LopBienChe_Khoa_ID_Khoa",
                        column: x => x.ID_Khoa,
                        principalTable: "Khoa",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTiet_ChuongTrinhDaoTao_MonHoc",
                columns: table => new
                {
                    ID_ChuongTrinhDaoTao = table.Column<string>(nullable: false),
                    HK_HocKy = table.Column<int>(nullable: false),
                    HK_NamHoc = table.Column<int>(nullable: false),
                    ID_MonHoc = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTiet_ChuongTrinhDaoTao_MonHoc", x => new { x.ID_ChuongTrinhDaoTao, x.ID_MonHoc, x.HK_HocKy, x.HK_NamHoc });
                    table.ForeignKey(
                        name: "FK_ChiTiet_ChuongTrinhDaoTao_MonHoc_ChuongTrinhDaoTao_ID_ChuongTrinhDaoTao",
                        column: x => x.ID_ChuongTrinhDaoTao,
                        principalTable: "ChuongTrinhDaoTao",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTiet_ChuongTrinhDaoTao_MonHoc_MonHoc_ID_MonHoc",
                        column: x => x.ID_MonHoc,
                        principalTable: "MonHoc",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTiet_ChuongTrinhDaoTao_MonHoc_HocKy_NamHoc_HK_HocKy_HK_NamHoc",
                        columns: x => new { x.HK_HocKy, x.HK_NamHoc },
                        principalTable: "HocKy_NamHoc",
                        principalColumns: new[] { "HocKy", "NamHoc" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LopHocPhan",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    HK_HocKy = table.Column<int>(nullable: false),
                    HK_NamHoc = table.Column<int>(nullable: false),
                    ID_MonHoc = table.Column<string>(nullable: true),
                    ID_Phong = table.Column<string>(nullable: true),
                    SoTietHoc = table.Column<string>(nullable: true),
                    IsActive = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopHocPhan", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LopHocPhan_MonHoc_ID_MonHoc",
                        column: x => x.ID_MonHoc,
                        principalTable: "MonHoc",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LopHocPhan_Phong_ID_Phong",
                        column: x => x.ID_Phong,
                        principalTable: "Phong",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LopHocPhan_HocKy_NamHoc_HK_HocKy_HK_NamHoc",
                        columns: x => new { x.HK_HocKy, x.HK_NamHoc },
                        principalTable: "HocKy_NamHoc",
                        principalColumns: new[] { "HocKy", "NamHoc" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SinhVien",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Ho = table.Column<string>(maxLength: 50, nullable: true),
                    Ten = table.Column<string>(maxLength: 50, nullable: true),
                    HoTen = table.Column<string>(maxLength: 100, nullable: true),
                    NgaySinh = table.Column<string>(nullable: true),
                    GioiTinh = table.Column<int>(nullable: false),
                    SoDienThoai = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    DiaChi = table.Column<string>(maxLength: 500, nullable: true),
                    ID_LopBienChe = table.Column<string>(nullable: true),
                    IsActive = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhVien", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SinhVien_LopBienChe_ID_LopBienChe",
                        column: x => x.ID_LopBienChe,
                        principalTable: "LopBienChe",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhanCong",
                columns: table => new
                {
                    ID_GiangVien = table.Column<string>(nullable: false),
                    ID_LopHocPhan = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanCong", x => new { x.ID_LopHocPhan, x.ID_GiangVien });
                    table.ForeignKey(
                        name: "FK_PhanCong_GiangVien_ID_GiangVien",
                        column: x => x.ID_GiangVien,
                        principalTable: "GiangVien",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhanCong_LopHocPhan_ID_LopHocPhan",
                        column: x => x.ID_LopHocPhan,
                        principalTable: "LopHocPhan",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DanhSach_SinhVien_LopHocPhan",
                columns: table => new
                {
                    ID_SinhVien = table.Column<string>(nullable: false),
                    ID_LopHocPhan = table.Column<string>(nullable: false),
                    LanThi = table.Column<int>(nullable: false, defaultValue: 1),
                    Diem = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhSach_SinhVien_LopHocPhan", x => new { x.ID_SinhVien, x.ID_LopHocPhan });
                    table.ForeignKey(
                        name: "FK_DanhSach_SinhVien_LopHocPhan_LopHocPhan_ID_LopHocPhan",
                        column: x => x.ID_LopHocPhan,
                        principalTable: "LopHocPhan",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DanhSach_SinhVien_LopHocPhan_SinhVien_ID_SinhVien",
                        column: x => x.ID_SinhVien,
                        principalTable: "SinhVien",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTiet_ChuongTrinhDaoTao_MonHoc_ID_MonHoc",
                table: "ChiTiet_ChuongTrinhDaoTao_MonHoc",
                column: "ID_MonHoc");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTiet_ChuongTrinhDaoTao_MonHoc_HK_HocKy_HK_NamHoc",
                table: "ChiTiet_ChuongTrinhDaoTao_MonHoc",
                columns: new[] { "HK_HocKy", "HK_NamHoc" });

            migrationBuilder.CreateIndex(
                name: "IX_ChuongTrinhDaoTao_Id_Khoa",
                table: "ChuongTrinhDaoTao",
                column: "Id_Khoa");

            migrationBuilder.CreateIndex(
                name: "IX_DanhSach_SinhVien_LopHocPhan_ID_LopHocPhan",
                table: "DanhSach_SinhVien_LopHocPhan",
                column: "ID_LopHocPhan");

            migrationBuilder.CreateIndex(
                name: "IX_GiangVien_ID_Khoa",
                table: "GiangVien",
                column: "ID_Khoa");

            migrationBuilder.CreateIndex(
                name: "IX_LopBienChe_ID_GiangVien",
                table: "LopBienChe",
                column: "ID_GiangVien");

            migrationBuilder.CreateIndex(
                name: "IX_LopBienChe_ID_Khoa",
                table: "LopBienChe",
                column: "ID_Khoa");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocPhan_ID_MonHoc",
                table: "LopHocPhan",
                column: "ID_MonHoc");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocPhan_ID_Phong",
                table: "LopHocPhan",
                column: "ID_Phong");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocPhan_HK_HocKy_HK_NamHoc",
                table: "LopHocPhan",
                columns: new[] { "HK_HocKy", "HK_NamHoc" });

            migrationBuilder.CreateIndex(
                name: "IX_MonHoc_KhoaID",
                table: "MonHoc",
                column: "KhoaID");

            migrationBuilder.CreateIndex(
                name: "IX_PhanCong_ID_GiangVien",
                table: "PhanCong",
                column: "ID_GiangVien");

            migrationBuilder.CreateIndex(
                name: "IX_PhanCong_ID_LopHocPhan",
                table: "PhanCong",
                column: "ID_LopHocPhan",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_ID_LopBienChe",
                table: "SinhVien",
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
                name: "ChiTiet_ChuongTrinhDaoTao_MonHoc");

            migrationBuilder.DropTable(
                name: "DanhSach_SinhVien_LopHocPhan");

            migrationBuilder.DropTable(
                name: "PhanCong");

            migrationBuilder.DropTable(
                name: "ChuongTrinhDaoTao");

            migrationBuilder.DropTable(
                name: "SinhVien");

            migrationBuilder.DropTable(
                name: "LopHocPhan");

            migrationBuilder.DropTable(
                name: "LopBienChe");

            migrationBuilder.DropTable(
                name: "MonHoc");

            migrationBuilder.DropTable(
                name: "Phong");

            migrationBuilder.DropTable(
                name: "HocKy_NamHoc");

            migrationBuilder.DropTable(
                name: "GiangVien");

            migrationBuilder.DropTable(
                name: "Khoa");
        }
    }
}
