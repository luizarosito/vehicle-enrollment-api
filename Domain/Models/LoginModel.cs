using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vehicle_enrollment.Models
{
    public class LoginModel
    {
        public string Email { get; set; } = default;
        public string Password { get; set; } = default;
    }
}