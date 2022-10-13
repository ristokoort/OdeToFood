﻿using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.ViewComponents
{
    public class BestReviewViewComponent:ViewComponent
    {

        public IViewComponentResult Invoke(IList<RestaurantReview> reviews)
        {
            var bestReview = from r in reviews
                             orderby r.Rating descending
                             select r;
            return View(bestReview.First());
        }
    }
}
