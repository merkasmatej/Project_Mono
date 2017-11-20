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
    [RoutePrefix("api/make")]
    public class VehicleMakeController : ApiController
    {
        protected IVehicleMakeService MakeService { get; private set; }

        public VehicleMakeController(IVehicleMakeService makeService)
        {
            this.MakeService = makeService;
        }

        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getall")]

        public async Task<HttpResponseMessage> Get()
        {
            try
            {
                var response = Mapper.Map<IEnumerable<VehicleMakeViewModel>>(await MakeService.GetAsync());

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Couldn't get data, database error");
            }
        }

        /// <summary>
        /// get by id
        /// </summary>
        /// <param name="MakeID"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get")]

        public async Task<HttpResponseMessage> GetByID(Guid MakeID)
        {
            try
            {
                var response = Mapper.Map<VehicleMakeViewModel>(await MakeService.GetByMakeIDAsync(MakeID));
                if (response == null)

                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Bad id");
                return Request.CreateResponse(HttpStatusCode.OK, response);

            }
            catch
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Couldn't get data, database error");

            }
        }

        /// <summary>
        /// add make
        /// </summary>
        /// <param name="make"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("add")]

        public async Task<HttpResponseMessage> Add(VehicleMakeViewModel make)
        {
            try
            {
                if (make.MakeName == null || make.MakeAbrv == null )
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "make is not complete, please provide name and abrv");


                make.MakeID = Guid.NewGuid();
               

                var response = await MakeService.AddAsync(Mapper.Map<VehicleMake>(make));

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "couldn't add data, database error");
            }
        }
        /// <summary>
        /// update make
        /// </summary>
        /// <param name="make"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update")]

        public async Task<HttpResponseMessage> Update(VehicleMakeViewModel make)
        {
            try
            {
                var toBeUpdated = await MakeService.GetByMakeIDAsync(make.MakeID);

                if (toBeUpdated == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "make not found");

                if (make.MakeName != null)
                    toBeUpdated.MakeName = make.MakeName;

                if (make.MakeAbrv != null)
                    toBeUpdated.MakeAbrv = make.MakeAbrv;

                var response = await MakeService.UpdateAsync(Mapper.Map<VehicleMake>(toBeUpdated));

                

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "couldn't update make. database error");
            }
        }
        /// <summary>
        /// delete make
        /// </summary>
        /// <param name="MakeID"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete")]

        public async Task<HttpResponseMessage> Delete(Guid MakeID)
        {
            try
            {
                var maker = Mapper.Map<VehicleMakeViewModel>(await MakeService.GetByMakeIDAsync(MakeID));

                if (maker.VehicleModel.Count != 0)
                    return Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, "make has models bind to him, first you have to delete models");

                if (maker == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "bad id");

                var response = await MakeService.DeleteAsync(MakeID);

                if (response == 0)
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "couldn't delete make");

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, "couldn't delete make. database error");
            }
        }
    }
}
