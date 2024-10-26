using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vehicle_enrollment_api.Domain.Models
{
    public struct Home
    {
        public string Message { get => "Welcome my API";}
        public string Doc { get => "/swagger/index.html";}
    }
}