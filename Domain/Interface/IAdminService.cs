using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vehicle_enrollment.Models;
using vehicle_enrollment_api.Entities;

namespace vehicle_enrollment.Domain.Interface
{
    public interface IAdminService
    {
        Admin? Login(LoginModel loginModel);
    }
}