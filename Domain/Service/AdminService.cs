using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using vehicle_enrollment.Db;
using vehicle_enrollment.Models;
using vehicle_enrollment.Domain.Interface;
using vehicle_enrollment_api.Entities;

namespace vehicle_enrollment.Domain.Service
{
    public class AdminService : IAdminService
    {
        private readonly DbContextConfig _context;
        public AdminService(DbContextConfig db)
        {
            _context = db;
        }

        public Admin? Login(LoginModel login)
        {
            var profile = _context.Admins.Where(a => a.Email == login.Email && a.Password == login.Password).FirstOrDefault();
            return profile;
        }
    }
}