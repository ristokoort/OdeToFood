﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Data;
using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Controllers
{
    public class ReviewsController : Controller
    {
           private readonly ApplicationDbContext _context;

        public ReviewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index([Bind(Prefix ="id")]int restaurantId)
        {
            var restaurant = await _context.Restaurants
                        .Include(r=>r.Reviews)
               .FirstOrDefaultAsync(m => m.Id == restaurantId);
            if (restaurant == null)
            {
                return NotFound();
            }
            return View(restaurant);
        }

        [HttpGet]
            public ActionResult Create(int restaurantId)
            {
                return View();
            }
        
        [HttpPost]
        public ActionResult Create(RestaurantReview review) 
        {
            if(ModelState.IsValid)
            {
                _context.RestaurantReviews.Add(review);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index), new { id = review.RestaurantId });
            }
            return View(review);
        }
    }
}


