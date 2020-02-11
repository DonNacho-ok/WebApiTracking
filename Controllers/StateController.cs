using api.WebTracking.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.WebTracking.Controllers
{
    [Controller]
    [Route("[Controller]")]
    public class StateController : ControllerBase
    {
        [HttpGet]
        public IList<State> Get()
        {
            return new trackingContext().State.ToList();
        }

        [HttpPost]
        public void Post([FromBody]State State)
        {
            var context = new trackingContext();
            var NewState = new State
            {
                Id = State.Id,
                Name = State.Name,
                Countryid = State.Countryid,
            };
            context.Add<State>(NewState);
            context.SaveChanges();
        }

        [HttpPut]
        public void Put([FromBody]State updatedState)
        {
            var context = new trackingContext();
            var state = context.State.Where(s => s.Id == updatedState.Id).SingleOrDefault();
            
            state.Id = updatedState.Id;
            state.Name = updatedState.Name;
            state.Countryid = updatedState.Countryid;

            context.Update<State>(state);
            context.SaveChanges();
        }

        [HttpDelete]
        public void Delete([FromBody]State deletedState)
        {
            var context = new trackingContext();
            var state = context.State.Where(s => s.Id == deletedState.Id).SingleOrDefault();

            context.Remove<State>(state);
            context.SaveChanges();
        }
    }
}
