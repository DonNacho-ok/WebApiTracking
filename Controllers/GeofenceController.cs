using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.WebTracking.Models;
using Microsoft.AspNetCore.Mvc;



namespace api.WebTracking.Controllers
{
    [Controller]
    [Route("[Controller]")]
    public class GeofenceController : Controller
    {
        //Get
        [HttpGet]
        public IList<Geofence> Get()
        {
            var geolist = new trackingContext().Geofence.ToList();
            return geolist;
        }
        //Post
        [HttpPost]
        public void Post([FromBody]Geofence Geofence)
        {
            var context = new trackingContext();
            var geo = new Geofence
            {
                Id = Geofence.Id,
                Name = Geofence.Name,
                Description = Geofence.Description,
                Latitude=Geofence.Latitude,
                Longitude=Geofence.Longitude,
                Radius=Geofence.Radius,
                Enterpriseid=Geofence.Enterpriseid,
                Geofencetypeid=Geofence.Geofencetypeid,
                Active=Geofence.Active
            };
            context.Add<Geofence>(geo);
            context.SaveChanges();
        }

        [HttpPut]
        public void Put([FromBody]Geofence updatedGeofence)
        {
            var context = new trackingContext();

            var geo = context.Geofence.Where(g => g.Id == updatedGeofence.Id).SingleOrDefault();
            geo.Name = updatedGeofence.Name;
            geo.Description = updatedGeofence.Description;
            geo.Latitude = updatedGeofence.Latitude;
            geo.Longitude = updatedGeofence.Longitude;
            geo.Radius = updatedGeofence.Radius;
            geo.Enterpriseid = updatedGeofence.Enterpriseid;
            geo.Geofencetypeid = updatedGeofence.Geofencetypeid;
            geo.Active = updatedGeofence.Active;

            context.Update<Geofence>(geo);
            context.SaveChanges();
        }

        [HttpDelete]
        public void Delete([FromBody] Geofence deletedGeofence)
        {
            var context = new trackingContext();

            var geo = context.Geofence.Where(g => g.Id == deletedGeofence.Id).SingleOrDefault();

            context.Remove<Geofence>(geo);
            context.SaveChanges();
        }

    }
}
