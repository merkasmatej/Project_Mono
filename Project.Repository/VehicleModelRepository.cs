using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.DAL;
using Project.Model;
using Project.Model.Common;
using Project.Repository.Common;
using AutoMapper;
using System.Data.Entity;

namespace Project.Repository
{
   public class VehicleModelRepository : IVehicleModelRepository
    {
        protected IRepository Repository { get; private set; }

        public VehicleModelRepository(IRepository repository)
        {
            this.Repository = repository;
        }

        public virtual async Task<IEnumerable<IVehicleModel>> GetAsync()
        {
            return Mapper.Map<IEnumerable<VehicleModel>>(await Repository.Table<VehicleModel>().ToListAsync());
        }

        public virtual async Task<IVehicleModel> GetByModelIDAsync(Guid ModelID)
        {
            return Mapper.Map<VehicleModel>(await Repository.Table<VehicleModel>().Where(p => p.ModelID == ModelID).FirstOrDefaultAsync());
        }

        public virtual Task<int> AddAsync(IVehicleModel vehiclemodel)
        {
            return Repository.AddAsync(Mapper.Map<VehicleModel>(vehiclemodel));
        }

        public virtual Task<int> UpdateAsync(IVehicleModel vehiclemodel)
        {
            return Repository.UpdateAsync(Mapper.Map<VehicleModel>(vehiclemodel));
        }

        public virtual Task<int> DeleteAsync(Guid ModelID)
        {
            return Repository.DeleteAsync(Mapper.Map<VehicleModel>(ModelID));
        }
    }
}
