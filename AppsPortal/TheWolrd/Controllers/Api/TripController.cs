using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using TheWolrd.Models;
using TheWolrd.ViewModels;

namespace TheWolrd.Controllers.Api
{
    [Route("api/trips")]
    public class TripController:Controller
    {
        private IWorldRepository _reposiory;
        private ILogger<TripController> _logger;

        public TripController(IWorldRepository repository,ILogger<TripController> logger)
        {
            _reposiory = repository;
            _logger = logger;
        }

        [HttpGet("")]
        public JsonResult Get()
        {
            var results = Mapper.Map<IEnumerable<TripViewModel>>( _reposiory.GetAllTripsWithStops());
            return Json(results);
        }

        [HttpPost("")]
        public JsonResult Post([FromBody]TripViewModel vm)
        {
            try
            {
                
            if (ModelState.IsValid)
            {

                var newTrip = AutoMapper.Mapper.Map<Trip>(vm);

                //Save to the Database
                _logger.LogInformation("Attempting to save new trip");
                _reposiory.AddTrip(newTrip);

                if (_reposiory.SaveAll())
                {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return Json(Mapper.Map<TripViewModel>(newTrip));
                 }
                
            }
            
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to save new trip", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new {Message = ex.Message});
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json("Failed");
        }
    }
}
