using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuanLySinhVien.Data.Entities;
using QuanLySinhVien.ViewModel.System.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Service.System.Roles
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleService(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<List<RoleViewModel>> GetAll()
        {
            var roles = await _roleManager.Roles
                .Select(x => new RoleViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                }).ToListAsync();

            return roles;
        }
    }
}
