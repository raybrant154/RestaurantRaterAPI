using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantRaterAPI.Models
{
    // Restaurant Entity (The class that gets stored in the database)
    public class Restaurant
    {
        // Primary Key
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        
        public double Rating
        {
            get
            {
                // Calculate a total average score based on Ratings
                double totalAverageRating = 0;

                // Add all Ratings together to get total Average Rating
                foreach (var rating in Ratings)
                {
                    totalAverageRating += rating.AverageRating;
                }

                // Return Average of Total if the count is above 0
                return (Ratings.Count > 0) ? Math.Round(totalAverageRating / Ratings.Count, 2) : 0;
            }
        }

        // Average Food Rating
        public double FoodRating
        {
            get
            {
                double totalFoodRating = 0;

                foreach (var rating in Ratings)
                {
                    totalFoodRating += rating.FoodScore;
                }

                return (Ratings.Count > 0) ? Math.Round(totalFoodRating / Ratings.Count, 2) : 0;
            }
        }

        // Average Environment Rating
        public double EnvironmentRating
        {
            get
            {
                double totalEnvironmentRating = 0;

                foreach (var rating in Ratings)
                {
                    totalEnvironmentRating += rating.EnvironmentScore;
                }

                return (Ratings.Count > 0) ? Math.Round(totalEnvironmentRating / Ratings.Count, 2) : 0;
            }
        }

        // Average Cleanliness
        public double Cleanliness
        {
            get
            {
                double totalCleanlinessRating = 0;

                foreach (var rating in Ratings)
                {
                    totalCleanlinessRating += rating.CleanlinessScore;
                }

                return (Ratings.Count > 0) ? Math.Round(totalCleanlinessRating / Ratings.Count, 2) : 0;
            }
        }


        public bool IsRecommended
        {
            get
            {
                return (Rating > 3.5);
            }
        }

        // All of the associated Rating objects from the database based on the Foreign Key relationship
        public virtual List<Rating> Ratings { get; set; } = new List<Rating>();
    }
}