using AspNetCore.Unobtrusive.Ajax;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OdeToFood.Data;
using OdeToFood.Filters;
using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace OdeToFood.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<HomeController> _logger;
       

        public HomeController(ILogger<HomeController> logger,ApplicationDbContext dbContext)
        {
            _db = dbContext;
            _logger = logger;
        }
        public ActionResult Autocomplete(string term)
        {
            var model = _db.Restaurants
            .Where(r => r.Name.StartsWith(term))
            .Select(r => new { label = r.Name });
            return Json(model);
        }

        public IActionResult Index(string searchTerm=null,int page =1)
        {
            var model =
                _db.Restaurants
                    .OrderByDescending(r => r.Reviews.Average(review => review.Rating))
                    .Where(r => searchTerm == null || r.Name.StartsWith(searchTerm))
                    
                    .Select(r => new RestaurantListViewModel
                    {
                        Id = r.Id,
                        Name = r.Name,
                        City = r.City,
                        Country = r.Country,
                        CountOfReviews = r.Reviews.Count()
                    }
                    ).ToPagedList(page, 10);
            if(Request.IsAjaxRequest())
            {
                return PartialView("_Restaurants", model);
            }
            return View(model);


        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            var model = new AboutModel();
            model.Name = "Risto";
            model.Location = "Tallinn" ;

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        protected override void Dispose(bool disposing)
        {
            if (_db!=null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
