using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model.Common;
using Project.Repository.Common;
using Project.Service.Common;
using Project.Common;
using Project.Model;
using System.Collections;
using AutoMapper;
using System.Data.Entity;

namespace Project.Service
{
   public class VehicleModelService: IVehicleModelService
    {
        protected IVehicleModelRepository Repository { get; private set; }

        public VehicleModelService(IVehicleModelRepository repository)
        {
            
            this.Repository = repository;
        }

        public virtual async Task<IEnumerable<IVehicleModel>> GetAsync(Filter filter = null)
        {
            var vehiclemodel = await Repository.GetAsync();

            vehiclemodel.OrderBy(m => m.ModelName)
                 .Skip((filter.Page - 1) * filter.PageSize)
                 .Take(filter.PageSize)
                 .ToList();

            return await Repository.GetAsync();

            

        }

        public virtual async Task<IVehicleModel> GetByModelIDAsync(Guid ModelID)
        {
            if (ModelID == Guid.Empty)
            {
                return null;

            }

            return await Repository.GetByModelIDAsync(ModelID);
        }

        public virtual async Task<int> AddAsync(Guid makeID, Guid modelID, string modelName, string modelAbrv)
        {
            if (modelName == null)
                return -1;

            if (modelAbrv == null)
                return -2;

            if (makeID == Guid.Empty)
                return -3;

            if (modelID == Guid.Empty)
                return -4;


            VehicleModel vehiclemodel = new VehicleModel
            {
                MakeID = makeID,
                ModelID = modelID,
                ModelName = modelName,
                ModelAbrv = modelAbrv
            };
           
            return await Repository.AddAsync(vehiclemodel);
        }

        public virtual async Task<int> UpdateAsync(Guid makeID, Guid modelID, string modelName, string modelAbrv)
        {
            var vehiclemodel = await Repository.GetByModelIDAsync(modelID);

            if (modelName == null)
                return -1;

            if (modelAbrv == null)
                return -2;

            if (makeID == Guid.Empty)
                return -3;

            if (modelID == Guid.Empty)
                return -4;

            vehiclemodel.MakeID = makeID;
            vehiclemodel.ModelID = modelID;
            vehiclemodel.ModelName = modelName;
            vehiclemodel.ModelAbrv = modelAbrv;
            //TODO...



            return await Repository.UpdateAsync(vehiclemodel);
        }

        public virtual Task<int> DeleteAsync(Guid ModelID)
        {
            return Repository.DeleteAsync(ModelID);
        }
    }
}
