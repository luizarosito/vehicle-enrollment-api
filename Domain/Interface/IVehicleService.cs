using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vehicle_enrollment.Models;
using vehicle_enrollment_api.Entities;

namespace vehicle_enrollment.Domain.Interface
{
    public interface IVehicleService
    {
        List<Vehicle> GetAllVehicle(int page = 1, string? name = null, string? brand = null);
        Vehicle? GetVehicleId(int id);
        Vehicle SaveVehicle(Vehicle vehicle);
        void CreateVehicle(Vehicle vehicle);
        void UpdateVehicle(Vehicle vehicle);
        void DeleteVehicle(Vehicle vehicle);
    }
}