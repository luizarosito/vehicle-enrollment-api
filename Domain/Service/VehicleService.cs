using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using vehicle_enrollment.Db;
using vehicle_enrollment.Models;
using vehicle_enrollment.Domain.Interface;
using vehicle_enrollment_api.Entities;
using Microsoft.EntityFrameworkCore;

namespace vehicle_enrollment.Domain.Service
{
    public class VehicleService : IVehicleService
    {
        private readonly DbContextConfig _context;
        public VehicleService(DbContextConfig db)
        {
            _context = db;
        }

        public void CreateVehicle(Vehicle vehicle)
        {
             _context.Vehicle.Add(vehicle);
            _context.SaveChanges(); 
        }

        public void DeleteVehicle(Vehicle vehicle)
        {
            _context.Vehicle.Remove(vehicle);
            _context.SaveChanges(); 
        }

        public List<Vehicle> GetAllVehicle(int page = 1, string? name = null, string? brand = null)
        {
            var query = _context.Vehicle.AsQueryable();
            if(!string.IsNullOrEmpty(name))
            {
                query = query.Where(v => EF.Functions.Like(v.Name.ToLower(), $"%{name.ToLower()}%"));
            }

            int itemPage = 10;

            query = query.Skip((page -1)  * itemPage).Take(itemPage);

            return query.ToList();
        }


        public Vehicle? GetVehicleId(int id)
        {
            return _context.Vehicle.Where( v => v.Id == id).FirstOrDefault();
        }

        public Vehicle SaveVehicle(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public void UpdateVehicle(Vehicle vehicle)
        {
            _context.Vehicle.Update(vehicle);
            _context.SaveChanges(); 
        }
    }
}