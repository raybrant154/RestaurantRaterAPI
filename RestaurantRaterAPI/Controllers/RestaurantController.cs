using RestaurantRaterAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestaurantRaterAPI.Controllers
{
    public class RestaurantController : ApiController
    {
                RestaurantDBContext _context = new RestaurantDBContext();
        // -- Create (POST)
        public async Task<IHttpActionResult> PostRestaurant(Restaurant model)
        {
            if (ModelState.IsValid)
            {
                _context.Restaurants.Add(model);
                await _context.SaveChangesAsync();

                return Ok();
            }

            return BadRequest(ModelState);
        }
        
        // -- Read (GET)
        // Get by ID

        // Get All

        // -- Update (PUT)

        // -- Delete (DELETE)
    }
}
