using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Project.Service.Common;
using System.Threading.Tasks;
using Project.Model;
using Project.Common;
using AutoMapper;
using Project.WebAPI.ViewModels;
using Project.Service;

namespace Project.WebAPI.Controllers
{
    public class VehicleModelController : ApiController
    {
        protected IVehicleModelService Service { get; private set; }


        public VehicleModelController(IVehicleModelService service)
        {
            this.Service = service;
        }
        
        
        /// <summary>
        /// gets all models
        /// </summary>
        /// <param name="searchString"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]

        public async Task<HttpResponseMessage> Get(string searchString ="", int pageNumber = 0, int pageSize = 0)
        {
            try
            {
                var result = await Service.GetAsync(new Filter(searchString, pageNumber, pageSize));
                if (result != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK,
                        Mapper.Map<List<VehicleModelViewModel>>(result));
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

            }
            catch (Exception e)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, e.ToString());
            }
        }

        /// <summary>
        /// Get the model by id
        /// </summary>
        /// <param name="ModelID"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<HttpResponseMessage> GetByID(Guid ModelID)
        {
            try
            {
                var result = await Service.GetByModelIDAsync(ModelID);
                if(result != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK,
                        Mapper.Map<VehicleModelViewModel>(result));
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

            }
            catch (Exception e)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, e.ToString());
            }
        }

        /// <summary>
        /// Add new model
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<HttpResponseMessage> Add(VehicleModelViewModel model)
        {
            try
            {
                var vehiclemodel = new VehicleModelViewModel()
                {
                    ModelName = model.ModelName,
                    ModelAbrv = model.ModelAbrv

                };

                var result = await Service.AddAsync(Mapper.Map<VehicleModel>(model));
                if(result == 1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, model);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError,"Failed");
                }
            }
            catch (Exception e)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, e.ToString());
            }
        }

        /// <summary>
        /// update model
        /// </summary>
        /// <param name="ModelID"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<HttpResponseMessage> Update(Guid ModelID, VehicleModelViewModel entity)
        {
            try
            {
                var vehiclemodel = await Service.GetByModelIDAsync(ModelID);
                vehiclemodel.ModelName = entity.ModelName;
                if(vehiclemodel != null) { 

                var result = await Service.UpdateAsync(Mapper.Map<VehicleModel>(entity));
                return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception e)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, e.ToString());
            }
        }

        /// <summary>
        /// delete model
        /// </summary>
        /// <param name="ModelID"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(Guid ModelID)
        {
            try
            {
                var vehiclemodel = await Service.GetByModelIDAsync(ModelID);
                if(vehiclemodel != null)
                {
                    var result = await Service.DeleteAsync(ModelID);
                    return Request.CreateResponse(HttpStatusCode.OK, "Deleted");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception e)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, e.ToString());
            }
        }


    }
}
