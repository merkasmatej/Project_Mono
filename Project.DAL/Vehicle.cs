using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Project.DAL.Entities;
using System.Data.Entity.Infrastructure;

namespace Project.DAL
{
   public class Vehicle: DbContext
    {
        public Vehicle(): base("name=Vehicle")
        {

        }

        public static Vehicle Create()
        {
            return new Vehicle();
        }

        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
    }

    public interface IVehicle: IDisposable
    {
        DbSet<VehicleMake> VehicleMakes { get; set; }
        DbSet<VehicleModel> VehicleModels { get; set; }

        object Set<T>() where T : class;
        DbEntityEntry Entry<T>(T entity) where T : class;
        Task<int> SaveChangesAsync();
    }
}
