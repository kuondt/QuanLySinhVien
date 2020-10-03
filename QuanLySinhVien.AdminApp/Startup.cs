using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QuanLySinhVien.AdminApp.Services;
using QuanLySinhVien.AdminApp.Services.ChiTietChuongTrinhDaoTao;
using QuanLySinhVien.AdminApp.Services.ChuongTrinhDaoTao;
using QuanLySinhVien.AdminApp.Services.DanhSachSinhVien;
using QuanLySinhVien.AdminApp.Services.GiangVien;
using QuanLySinhVien.AdminApp.Services.HocKyNamHoc;
using QuanLySinhVien.AdminApp.Services.LopBienChe;
using QuanLySinhVien.AdminApp.Services.LopHocPhan;
using QuanLySinhVien.AdminApp.Services.MonHoc;
using QuanLySinhVien.AdminApp.Services.Phong;
using QuanLySinhVien.AdminApp.Services.SinhVien;
using QuanLySinhVien.ViewModel.System.Users;

namespace QuanLySinhVien.AdminApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                            .AddCookie(options =>
                            {
                                options.LoginPath = "/Login";
                                options.AccessDeniedPath = "/User/Forbidden/";
                            });

            services.AddControllersWithViews()
                   .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginRequestValidator>());

            services.AddSession(option => {
                option.IdleTimeout = TimeSpan.FromMinutes(30);
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IUserApiClient, UserApiClient>();
            services.AddTransient<IRoleApiClient, RoleApiClient>();
            services.AddTransient<IMonHocApiClient, MonHocApiClient>();
            services.AddTransient<IGiangVienApiClient, GiangVienApiClient>();
            services.AddTransient<ILopBienCheApiClient, LopBienCheApiClient>();
            services.AddTransient<ISinhVienApiClient, SinhVienApiClient>();
            services.AddTransient<IPhongApiClient, PhongApiClient>();
            services.AddTransient<IHocKyNamHocApiClient, HocKyNamHocApiClient>();
            services.AddTransient<IChuongTrinhDaoTaoApiClient, ChuongTrinhDaoTaoApiClient>(); 
            services.AddTransient<IChiTietChuongTrinhDaoTaoApiClient, ChiTietChuongTrinhDaoTaoApiClient>();
            services.AddTransient<ILopHocPhanApiClient, LopHocPhanApiClient>();
            services.AddTransient<IDanhSachSinhVienApiClient, DanhSachSinhVienApiClient>();

            IMvcBuilder builder = services.AddRazorPages();
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            #if DEBUG
            if (environment == Environments.Development)
            {
                builder.AddRazorRuntimeCompilation();
            }
            #endif
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
