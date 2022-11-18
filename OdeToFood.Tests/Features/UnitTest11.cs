using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdeToFood.Data.Migrations;
using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Tests.Features
{
    [TestClass]
    public class UnitTest11
    {
        [TestMethod]
        public void Computes_Result_For_One_Reviews()
        {
            var data = BuildRestaurantAndReviews(4);
            var rater = new RestaurantRater(data);
            var result = rater.ComputeRating(10);
            Assert.AreEqual(4, result.Rating);


        }
        [TestMethod]
        public void Computes_Result_For_Two_Reviews()
        {
            var data = BuildRestaurantAndReviews(4, 8);
            var rater = new RestaurantRater(data);
            var result = rater.ComputeRating(10);
            Assert.AreEqual(6, result.Rating);
        }
      

        private Restaurant BuildRestaurantAndReviews(params int[] ratings)
        {
            var restaurant = new Restaurant();

            restaurant.Reviews =
                ratings.Select(r => new RestaurantReview { Rating = r })
                      .ToList();
            return restaurant;
        }
        [TestMethod]
        public void Weighted_Averaging_for_Two_Reviews()
        { var data = BuildRestaurantAndReviews(4, 8); }

       

        public RatingResult ComputeWeightedRate(int numberOfReviews)
        {
            var reviews = Restaurant.Reviews.ToArray();
            var result = new RatingResult();
            var counter = 0;
            var total = 0;
            for (int i = 0;  <reviews.Count() ; i++)
            {
                if(i<reviews.Count()/2)
                {
                    counter += 2;
                    total + reviews
                }
            }
        }
    }
    }
