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


namespace Project.WebAPI.Controllers
{
    [RoutePrefix("api/model")]

    public class VehicleModelController : ApiController
    {
        protected IVehicleModelService ModelService { get; private set; }
        protected IVehicleMakeService MakeService { get; private set; }


        public VehicleModelController(IVehicleModelService modelService, IVehicleMakeService makeService)
        {
            this.ModelService = modelService;
            this.MakeService = makeService;
        }
        
        
        /// <summary>
        /// gets all models
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getall")]

        public async Task<HttpResponseMessage> Get()
        {
            try
            {
                var response = Mapper.Map<IEnumerable<VehicleModelViewModel>>(await ModelService.GetAsync());

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch 
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Couldn't get data, database error");
            }
        }

        
        

        /// <summary>
        /// Get the model by id
        /// </summary>
        /// <param name="ModelID"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get")]

        public async Task<HttpResponseMessage> GetByID(Guid ModelID)
        {
            try
            {
                var response = Mapper.Map<VehicleModelViewModel>(await ModelService.GetByModelIDAsync(ModelID));
                if(response == null)

                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Bad id");
                return Request.CreateResponse(HttpStatusCode.OK, response);
                
            }
            catch 
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Couldn't get data, database error");

            }
        }

        /// <summary>
        /// Add new model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("add")]

        public async Task<HttpResponseMessage> Add(VehicleModelViewModel model)
        {
            try
            {
                if (model.ModelName == null || model.ModelAbrv == null || model.MakeID == null)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "model is not complete, please provide name, abrv and make id");

                var IfMakeExist = await MakeService.GetByMakeIDAsync(model.MakeID);

                if (IfMakeExist == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "invalid MakeID");

                model.ModelID = Guid.NewGuid();
                model.MakeID = Guid.NewGuid();
                model.ModelName = null;
                model.ModelAbrv = null;

                var response = await ModelService.AddAsync(model.MakeID, model.ModelID, model.ModelName, model.ModelAbrv);

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch 
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "couldn't add model, database error");
            }
        }

       

        /// <summary>
        /// update model
        /// </summary>
        /// <param name="ModelID"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update")]

        public async Task<HttpResponseMessage> Update(VehicleModelViewModel model)
        {
            try
            {
                var toBeUpdated = await ModelService.GetByModelIDAsync(model.ModelID);

                if (model.ModelName != null)
                    toBeUpdated.ModelName = model.ModelName;

                if (model.ModelAbrv != null)
                    toBeUpdated.ModelAbrv = model.ModelAbrv;

                var response = await ModelService.UpdateAsync(model.MakeID, model.ModelID, model.ModelName, model.ModelAbrv);
                if (response == 0)
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "couldn't update model");

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch 
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "couldn't update model. database error");
            }
        }

        /// <summary>
        /// delete model
        /// </summary>
        /// <param name="ModelID"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete")]

        public async Task<HttpResponseMessage> Delete(Guid ModelID)
        {
            try
            {
                var response = await ModelService.DeleteAsync(ModelID);

                if (response == 0)
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "couldn't delete model");

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch 
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, "couldn't delete model. database error");
            }
        }


    }
}
