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
    public class RatingController : ApiController
    {
        private readonly RestaurantDBContext _context = new RestaurantDBContext();

        // Create new ratings
        [HttpPost]
        public async Task<IHttpActionResult> CreateRating(Rating model)
        {
            if (model == null)
            {
                return BadRequest("Your request cannot be empty.");
            }

            // Check to see if the model is NOT valid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Find the targeted restaurant
            var restaurant = await _context.Restaurants.FindAsync(model.RestaurantId);

            if (restaurant == null)
            {
                return BadRequest($"The target restaurant with the ID of {model.RestaurantId} does not exist");
            }

            //The resaurant isn't null, so we can successfully rate it
            _context.Ratings.Add(model);
            if (await _context.SaveChangesAsync() == 1)
            {
                return Ok($"You rated {restaurant.Name} successfully!");
            }

            return InternalServerError();
        }

        // Get a rating by its ID ?

        // Get ALL ratings for a specific restaurant by restaurant ID

        // Update rating

        // Delete rating


    }
}
